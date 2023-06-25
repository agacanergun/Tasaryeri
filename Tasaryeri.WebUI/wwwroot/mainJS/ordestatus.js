var selectElements = document.querySelectorAll("select[id^='orderStatus_']");

selectElements.forEach(function (selectElement) {
    selectElement.addEventListener("change", function () {
        var id = selectElement.id.split("_")[1];
        var selectedValue = selectElement.value;
        $.ajax({
            url: "/satici/siparislerim-güncelle",
            type: "POST",
            data: {
                id: id,
                selectedValue: selectedValue
            },
            success: function (response) {
                if (response=="Ok") {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Sipariş Durumu Güncellendi',
                        showConfirmButton: false,
                        timer: 600
                    });
                }

                setTimeout(function () {
                    location.href = "/satici/siparislerim";
                }, 600);
            },
            error: function (error) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'error',
                    title: 'Sipariş Durumu Güncellenemedi',
                    showConfirmButton: false,
                    timer: 600
                });

                setTimeout(function () {
                    location.href = "/satici/siparislerim";
                }, 600);
            }
        });
    });
});
