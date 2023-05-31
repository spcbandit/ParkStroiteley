using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumMemberAttributeValue<T>(this T enumValue) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Has to be of enum type!", nameof(enumValue));

            return GetFieldCustomAttribute<T, EnumMemberAttribute>(enumValue.ToString())?.Value;
        }

        public static TAttribute GetFieldCustomAttribute<TObject, TAttribute>( string name) where TAttribute : class =>
            (typeof(TObject).GetField(name)
             ?? throw new ArgumentException($"There is no such field as {name} in {typeof(TObject).FullName}!", nameof(name)))
            .GetCustomAttributes(false)
            .OfType<TAttribute>()
            .FirstOrDefault();
    }
}
