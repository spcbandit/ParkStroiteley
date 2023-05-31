$(document).ready(function () {
    $('#weusecookie').fadeIn(1000);

    var slideCount = 1;
    var slideCountOut = 1;
    setInterval(() => {
        if (slideCount > 4) {

            $('#slide_4').fadeOut(500);
            slideCount = 1;
            slideCountOut = 1;
        }
        slideCountOut = slideCount - 1;
        let pathin = '#slide_' + slideCount + '';
        let pathout = '#slide_' + slideCountOut + '';

        console.log(pathin);

        console.log(pathout);

        $(pathin).fadeIn(1000);
        //$(pathin).addClass('active');
        $(pathout).fadeOut(1000);
        //$(pathout).removeClass('active');
        slideCount++;
    }, 4000);

});
$('.cookie .btn').click(function () {
    $(this).parent().parent().fadeOut()
});