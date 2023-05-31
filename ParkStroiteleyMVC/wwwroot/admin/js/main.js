$(document).ready(function () {
    // тут тупо чилим :D
});
var myfiles = new FormData();
var idNew = null;
$('#addtextblock').click(function () { /* создаем блок для добавления текста */
    addblocktext();
});
$('#addimageblock').click(function () { /* создаем блок для добавления изображений */
    addblockimage();
});
$('#addvideoblock').click(function () { /* создаем блок для добавления кода видео */
    addblockvideo();
});
/* Функция установки сегодняшней даты в inputdate */
function setdatenow() {
    var date = new Date();
    $('#newdate').attr('value', date.getFullYear() + '-'
        + ((date.getMonth() + 1) + '').padStart(2, "0") + '-'
        + (date.getDate() + '').padStart(2, "0"));
}
/* Функция добавления блока заголовка новости */
function addblockheader(text = 'Заголовок новости') {
    $('#newcontainer').append($('<h4 class="border p-2 mb-2" id="newheader" contenteditable="true">' + text + '</h4>'));
}
/* Функция добавления блока текста */
function addblocktext(text = 'Новый блок текста - добавьте ваш текст сюда') {
    var textblock = $(
        '<div type="0" class="border mb-2">' +
            '<div class="w-100" style="display: flex; justify-content: flex-end;">' +
                '<button title="Удалить этот блок" onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">✕</button>' +
            '</div>' +
            '<p class="p-2 m-1 mb-0" contenteditable="true">' + text + '</p>' +
        '</div>');
    $('#newcontainer').append(textblock);
}
/* Функция добавления блока изображения */
function addblockimage(url = 'adding.png', description = 'Добавьте подпись к рисунку') {
    var imageblock = $(
        '<div type="1" class="border mb-2">' +
            '<div class="w-100" style="display: flex; justify-content: flex-end;">' +
                '<button title="Удалить этот блок" onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">✕</button>' +
            '</div>' +
            '<div class="m-2 row justify-content-around">' +
                '<div>' +
                    '<div title="Нажмите чтобы добавить\\изменить изображение" onclick="addimage(this)" style="display: flex; justify-content: center; cursor: pointer;">' +
                        '<input name="imgs" type="file" style="display: none;" form="imagesform"/>' +
                        '<img class="img-fluid" src="' + url + '">' +
                    '</div>' +
                    '<p contenteditable="true" class="p-1 mt-2 text-center">' + description + '</p>' +
                '</div>' +
            '</div>' +
        '</div>');
    imageblock.find('input[type=file]').bind('change', function () { // находим в элементе инпут-файл
        var img = $(this).next();// добавляем на него обработчик на выбор файла
        var reader = new FileReader();
        reader.onload = function (e) {
            img.attr('src', e.target.result);// создаем превьюшку изображения
        };
        myfiles.append('imgs', this.files[0]);
        reader.readAsDataURL(this.files[0]);
    });
    $('#newcontainer').append(imageblock);// добавляем его на страницу
}
/* Функция добавления блока видео */
function addblockvideo(src = '') {
    var textblock = $(
        '<div type="2" class="border mb-2">' +
            '<div class="w-100" style="display: flex; justify-content: flex-end;">' +
                '<button title="Удалить этот блок" onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">✕</button>' +
            '</div>' +
            '<div class="w-100" style="display: flex;">' +
                '<textarea class="m-2 w-100 p-2" rows="5" style="resize: vertical;" placeholder="Это поле для вставки кода видео">' + src + '</textarea>' +
            '</div>' +
        '</div>');
    $('#newcontainer').append(textblock);
}
/* Функция удаления блока из разметки */
function deleteblock(e) {
    var block = $(e).parent().parent(); // находим родителя от кликнутой кнопки
    block.remove(); // удаляем
};
/* Функция имитацияя нажатия на fileinput для выбора нового изображения */
function addimage(elem) {
    $(elem).children()[0].click(); // делаем клик по инпут-файлу
}
/* Функция очистки модального окна от блоков */
function clearmodal() {
    $('#newcontainer').empty(); // Очищаем модалку
}
/* Функция для кнопки 'Новая новость' */
function addnew() {
    idNew = null;
    myfiles = new FormData();
    clearmodal(); // Очищаем модалку
    setdatenow();
    addblockheader(); // Добавляем дефолт заголовок
    $('#modalnew').modal('show'); // Показываем модалку
}
/* Фукция редактирования новости */
function editnew(id_new) {
    idNew = id_new;
    myfiles = new FormData();
    clearmodal();
    $.ajax({
        url: '/Admin/GetNews',
        //async: false,
        method: 'post',
        data: "Id=" + id_new,
        success: function (data) {
            var news = JSON.parse(data);
            $('#newdate').attr('value', news.DatePublish.split('T')[0]);
            $('#newtype').find('option')[news.Type].selected = true
            addblockheader(news.Header);
            news.Blocks.forEach(function (item, i, arr) {
                switch (item.Type) {
                    case 0: //text
                        addblocktext(item.Text);
                        break;
                    case 1: //image
                        addblockimage('/images/' + item.ImageURL, item.ImageAbout);
                        break;
                    case 2: //video
                        addblockvideo(item.VideoLink);
                        break;
                    default:
                }
            });
            $('#modalnew').modal('show'); // Показываем модалку
        },
    });
}
function sendnew() {
    
    myfiles.append("news", JSON.stringify({
        Header: $('#newheader').html(),
        Type: parseInt($('#newtype').val()),
        DatePublish: $('#newdate').val(),
        Id: idNew
    }));
    $('#newcontainer').children().each(function (i, block) {
        if (i == 0) return;
        switch ($(block).attr('type')) {
            case '0':
                myfiles.append("blocks", JSON.stringify({
                    Type: 0,
                    Text: $(block).find('p').text()
                }));
                break;
            case '1':
                myfiles.append("blocks", JSON.stringify({
                    Type: 1,
                    ImageURL: $(block).find('input[type=file]')[0].files.length > 0 ? $(block).find('input[type=file]')[0].files[0].name : $(block).find('img')[0].src.split('/').pop(),
                    ImageSizeType: 0,
                    ImageAbout: $(block).find('p').text()
                }));
                break;
            case '2':
                myfiles.append("blocks", JSON.stringify({
                    Type: 2,
                    VideoLink: $(block).find('textarea').val()
                }));
                break;
            default:
        }
        
    });
    $.ajax({
        url: '/Admin/News',
        method: 'post',
        cache: false,
        contentType: false,
        processData: false,
        data: myfiles,
        success: function (data) {
            var a = JSON.parse(data);
            if (a.status == 'success') {
                swal('Успешно', a.data, 'success');
            }
            if (a.status == 'error') {
                swal('Ошибка', a.data, 'error');
            }
        },
    });
}
function delnew(id_new) {
    swal({
        title: "Подтверждение",
        text: "Удалить новость?",
        buttons: {
            del: {
                text: "Удалить"
            },
            cancel_: {
                text: "Отмена"
            }
        }
    }).then((value) => {
        if (value === 'cancel_') 
            return;
        if (value === 'del') {
            $.ajax({
                url: '/Admin/DelNews',
                method: 'post',
                data: "Id=" + id_new,
                success: function (data) {
                    var a = JSON.parse(data);
                    if (a.status == 'success') {
                        swal('Успешно', a.data, 'success');
                    }
                    if (a.status == 'error') {
                        swal('Ошибка', a.data, 'error');
                    }
                }
            });
        }
    });
}