var myform = new FormData();
/* Функция иммитации нажатия на fileinput для выбора нового изображения */
function addimage(elem){
    $(elem).children()[0].click(); // делаем клик по инпут-файлу
}
$('#files').on('change', function(){ // находим в элементе инпут-файл
    $('#addingfiles').empty();
    $('#addingfiles').append('<p>Выбранные файлы:</p>');
    for (let i = 0; i < this.files.length; i++) {
        myform.append('imgs', this.files[i]);
        $('#addingfiles').append('<b>' + this.files[i].name + ' (' + mathsize(this.files[i].size) + ')</b><br>');
    }
});
function clearmodal_j(){
    //$('#phototype').find('option')[0].selected = true
    clearfiles();
}
function clearfiles() {
    $('#addingfiles').empty();
    $('#files').val('');
}
function openmodal(){
    clearmodal_j();
    $('#modal').modal('show');
}
function send() {
    console.log($('#phototype').val());
    myform.append('type', $('#phototype').val());
    $.ajax({
        url: '/Admin/Gallery',
        method: 'post',
        cache: false,
        contentType: false,
        processData: false,
        data: myform,
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
function mathsize(bytes){
    if((t = bytes) < 1024)
        return t + " bytes";
    if((t = bytes / 1024) < 1024)
        return t.toFixed(2) + " Kb";
    if((t = bytes / 1024 / 1024) < 1024)
        return t.toFixed(2) + " Mb";
    else
        return (t / 1024).toFixed(2) + " Gb";
}
$('.trash').on('click', function() {
    var id_img = $(this).attr('id_image');
    swal({
        title: "Подтверждение",
        text: "Удалить изображение?",
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
                url: '/Admin/DelGallery',
                method: 'post',
                data: "Id=" + id_img,
                success: function(data) {
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
});