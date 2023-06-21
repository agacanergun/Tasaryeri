﻿$(document).ready(function () {
    getCartCounter();
})

function addCart(productid, stock) {
    istenenMiktar = parseInt($(".inputQuantity").val())
    if (istenenMiktar <= stock) {
        $.ajax({
            url: "/sepetim/ekle",
            type: "POST",
            data: { productid: productid, quantity: istenenMiktar },
            success: function (data) {
                if (data != "") {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: data + ' Sepete Eklendi',
                        showConfirmButton: false,
                        timer: 1000
                    })
                    getCartCounter();
                }
                else {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'error',
                        title: 'Ürün Sepete Eklenemedi',
                        showConfirmButton: false,
                        timer: 1000
                    })
                }
            }
        });
    }
    else {
        $(".inputQuantity").val(stock);
        $(".SpanQuantity").text(stock);
        alert("istenen miktar stoktan fazla");
    }
}

function getCartCounter() {

    $.ajax({
        url: "/sepetim/sayiver",
        type: "GET",
        success: function (data) {
            $(".cartCounter").text(data);
        }
    });
}