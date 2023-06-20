$(document).ready(function () {

})

function addCart(productid, stock) {
    istenenMiktar = parseInt($(".inputQuantity").val())
    if (istenenMiktar <= stock) {

    }
    else {
        $(".inputQuantity").val(stock);
        $(".SpanQuantity").text(stock);
        alert("istenen miktar stoktan fazla");
    }
}