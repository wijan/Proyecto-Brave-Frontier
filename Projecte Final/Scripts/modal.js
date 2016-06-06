
$(document).ready(function () {
    $('.select2').attr('multiple', 'multiple');
    $('.select2').select2();


    var imps = true;
    $('#activarImps').on('click', function () {
        
        if (imps) {
            imps = false;
            $('.stat').each(function () {
                var stat = $(this).data('stat');
                var stat = stat + $(this).data('imp');
                $(this).html(stat);
            })
            $(this).html('<span class="glyphicon glyphicon-arrow-down"></span>Desactivar Imps');
            $(this).addClass('btn btn-primary');
        }
        else {
            imps = true;
            $('.stat').each(function () {
                $(this).html($(this).data('stat'));
            })
            $(this).html('<span class="glyphicon glyphicon-arrow-up"></span>Activar Imps');
            $(this).addClass('btn btn-primary');
        }
    })

    $('.actual').css('border', '5px solid red').css('border-radius', '2px');
    $('.modal-dialog').css('width', '90%').css('height', '60%');

    $(".btnImage").on('click', function () {
        var idImagen = $(this).data('imagenid');
        if ($(this).hasClass('normal')) {
            //Imagen
            $(".imagenGrande").toggle('fast', function () {
                $('.seleccionada').attr('src', '/File?id='+idImagen).attr('width', '80%');
                $('.imagenGrande').css('background', 'none').css('padding', '3em');
                $(".imagenGrande").toggle("fast");
            });
        }
        else if ($(this).hasClass('normalGif')) {
            //Gif
            $(".imagenGrande").toggle('fast', function () {
                $('.seleccionada').attr('src', '/File?id='+idImagen).removeAttr('width');
                $('.imagenGrande').css('background', 'url("http://vignette3.wikia.nocookie.net/bravefrontierrpg/images/e/ea/Dungeon_battle_arena.jpg/revision/latest?cb=20150529222450&path-prefix=es") center no-repeat').css('padding-top', '80px');
                $(".imagenGrande").toggle("fast");
            });
        }
        else {
            $(".imagenGrande").toggle('fast', function () {
                $('.seleccionada').attr('src', '/File?id='+idImagen).removeAttr('width').css('bottom', '0px');
                $('.imagenGrande').css('background', 'url("http://vignette3.wikia.nocookie.net/bravefrontierrpg/images/e/ea/Dungeon_battle_arena.jpg/revision/latest?cb=20150529222450&path-prefix=es") center no-repeat').css('padding-top', '60px');
                $(".imagenGrande").toggle("fast");
            });
        }
    });

    $(".pestana").hide();
    $('.activa').toggle();

    $(".btnpestana").on("click ", function () {
        var pestana = $(this).data("pestana");
        switch (pestana) {
            case "stats":
                if ($('#stats').hasClass("activa")) {

                }
                else {
                    $('.activa').slideUp('fast', function () {
                        $('.activa').removeClass('activa');
                        $('#stats').slideDown('fast').addClass('activa');
                    });
                }
                break;
            case "braveburst":
                if ($(this).hasClass("activa")) {

                }
                else {
                    $('.activa').slideUp('fast', function () {
                        $('.activa').removeClass('activa');
                        $('#braveburst').slideDown('fast').addClass('activa');
                    });
                }
                break;
            case "rolUnidad":
                if ($(this).hasClass("activa")) {

                }
                else {
                    $('.activa').slideUp('fast', function () {
                        $('.activa').removeClass('activa');
                        $('#rolUnidad').slideDown('fast').addClass('activa');
                    });
                }
                break;
            case "cristales":
                if ($(this).hasClass("activa")) {

                }
                else {
                    $('.activa').slideUp('fast', function () {
                        $('.activa').removeClass('activa');
                        $('#cristales').slideDown('fast').addClass('activa');
                    });
                }
                break;
            case "skills":
                if ($(this).hasClass("activa")) {

                }
                else {
                    $('.activa').slideUp('fast', function () {
                        $('.activa').removeClass('activa');
                        $('#skills').slideDown('fast').addClass('activa');
                    });
                }
                break;
        }
    });

});