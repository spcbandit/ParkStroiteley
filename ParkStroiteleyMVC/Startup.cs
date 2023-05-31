using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ParkStroiteleyMVC.Controllers;
using ParkStroiteleyMVC.Controllers.Core.HomeCore;
using ParkStroiteleyMVC.Models;
using ParkStroiteleyMVC.Models.Configs;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ParkStroiteleyMVC
{
    public class Startup
    {
        internal static Action<string> Logs = null;
        public Startup(IConfiguration configuration)
        {
            HomeController.Dispatcher = new HomeDispatcher();
            Configuration = configuration;
            Logs += Loger;
        }
        public void Loger(string message)
        {
            var main_path = Environment.CurrentDirectory + @"\Logs\" + ConfigApp.AppVersionName + "_" + ConfigApp.AppVersion + DateTime.Now.Date.Day.ToString() + "." + DateTime.Now.Date.Month.ToString() + @"\";
            if (Directory.Exists(main_path))
            {
                var file_path = $"{main_path}LOGAT{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}.txt";

                File.AppendAllText(file_path, message);
            }
            else
            {
                Directory.CreateDirectory(main_path);
                Loger(message);
            }
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddDbContextPool<DBContext>(
               options => options.UseMySql(ConfigDatabase.ConnectionString,
               mySqlOptions =>
               {
                   mySqlOptions.ServerVersion(new Version(5, 6, 45), ServerType.MySql);
               }
           ));
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            };
            app.UseWebSockets(webSocketOptions); // подрубаем WebSocket с параметрами (можно без них - пустой конструктор UseWebSockets)
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws") // /ws - путь подключения
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
                        {
                            await Echo(context, webSocket);
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });
        }
        private async Task Echo(HttpContext context, WebSocket webSocket) // вот эт херню над вынести куда то отдельно
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
