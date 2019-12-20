/// <reference path="../vendors/jquery/jquery-3.2.1.min.js" />

$(document).ready(function () {

    $('.pixel-radio').click(function () {

        var data;
        data = $(this).attr("id");
        alert(data);

        $.ajax({
            url: "GetCatType",
            type: "GET",
            data: { type: data },
            success: function (result) {
                alert("thanh cong");
                console.log(result);
                $('div#row_product').html("");
                var code0 = '	<link rel="icon" href="../Content/img/Fevicon.png" type="image/png">'
+ '<link rel="stylesheet" href="../Content/vendors/bootstrap/bootstrap.min.css">'
  + '<link rel="stylesheet" href="../Content/vendors/fontawesome/~/Content/css/all.min.css">'
	+ '<link rel="stylesheet" href="../Content/vendors/themify-icons/themify-icons.css">'
	+ '<link rel="stylesheet" href="../Content/vendors/linericon/style.css">'
  + '<link rel="stylesheet" href="../Content/vendors/owl-carousel/owl.theme.default.min.css">'
  + '<link rel="stylesheet" href="../Content/vendors/owl-carousel/owl.carousel.min.css">'
  + '<link rel="stylesheet" href="../Content/vendors/nice-select/nice-select.css">'
 + '<link rel="stylesheet" href="../Content/vendors/nouislider/nouislider.min.css">'
  + '<link rel="stylesheet" href="../Content/css/style.css">';

                var code1 = '<div class="col-md-6 col-lg-4">'
                + '<div class="card text-center card-product">'
                + '<div class="card-product__img">'
                + '<img class="card-img"' + 'src="../';
                var img;

                var code2 = '" alt="">'
                + '<ul class="card-product__imgOverlay">'
                + '<li><button><i class="ti-search"></i></button></li>'
                + '<li><button><i class="ti-shopping-cart"></i></button></li>'
                + '<li><button><i class="ti-heart"></i></button></li></ul></div>'
                + '<div class="card-body"><p>Accessories</p><h4 class="card-product__title"><a href="#">Quartz Belt Watch</a></h4>'
                + '<p class="card-product__price">$'

                var count;
                var code3 = '</p></div></div></div>'


                var code;
                var count = ' ';
                var img;

                //document.querySelectorAll('.img-section-start')

                

                for (var i = 0; i < result.length; i++) {
                    img = result[i].img;
                    count = result[i].GiaBan;
                    code += code1 + img + code2 + count + code3;
                    console.log(code);

                }
                $('#row_product').append('<div>' + code0 + code + '</div>');
                alert(code0);
                alert('sss');

            },
            error: function () {
                alert("co loi xay ra");
            }
        })

    })



});
