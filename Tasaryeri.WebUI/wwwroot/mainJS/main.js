//ADMİN DELETE JS
function confirmDelete(id) {
    swal({
        title: "Silmek İstediğine Emin misin?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            deleteItem(id);
        }
    });
}

function deleteItem(id) {
    event.preventDefault();

    var data = {
        id: id
    };

    $.ajax({
        url: '/admin/delete',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response == "Ok") {
                swal({
                    title: "Silme İşlemi Başarılı",
                    icon: "success",
                    buttons: {
                        confirm: {
                            text: "Tamam",
                            value: true,
                            visible: true,
                            className: "",
                            closeModal: true
                        }
                    }
                }).then((value) => {
                    if (value) {
                        location.href = "/admin/adminler";
                    }
                    else {
                        location.href = "/admin/adminler";
                    }
                });
            } else {
                alert(response);
            }
        },
        error: function (xhr, status, error) {
            swal("Error", "An error occurred: " + error, "error");
        }
    });
}
//ADMİN DELETE JS



//SLİDE DELETE JS

function confirmDeleteSlide(id, picture) {
    swal({
        title: "Silmek İstediğine Emin misin?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            deleteItemSlide(id, picture);
        }
    });
}

function deleteItemSlide(id, picture) {
    event.preventDefault();

    var data = {
        id: id,
        picture: picture
    };
 

    $.ajax({
        url: '/slide/delete',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response == "Ok") {
                swal({
                    title: "Silme İşlemi Başarılı",
                    icon: "success",
                    buttons: {
                        confirm: {
                            text: "Tamam",
                            value: true,
                            visible: true,
                            className: "",
                            closeModal: true
                        }
                    }
                }).then((value) => {
                    if (value) {
                        location.href = "/slide/slidelar";
                    }
                    else {
                        location.href = "/slide/slidelar";
                    }
                });
            } else {
                alert(response);
            }
        },
        error: function (xhr, status, error) {
            swal("Error", "An error occurred: " + error, "error");
        }
    });
}
//SLİDE DELETE JS



//SubCategory Delet JS

function confirmDeleteSubCat(id) {
    swal({
        title: "Silmek İstediğine Emin misin?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            deleteItem(id);
        }
    });
}

function deleteItem(id) {
    event.preventDefault();

    var data = {
        id: id
    };

    $.ajax({
        url: '/kategori/delete-subcategory',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response == "Ok") {
                swal({
                    title: "Silme İşlemi Başarılı",
                    icon: "success",
                    buttons: {
                        confirm: {
                            text: "Tamam",
                            value: true,
                            visible: true,
                            className: "",
                            closeModal: true
                        }
                    }
                }).then((value) => {
                    if (value) {
                        location.href = "/kategori/kategoriler";
                    }
                    else {
                        location.href = "/kategori/kategoriler";
                    }
                });
            } else {
                alert(response);
            }
        },
        error: function (xhr, status, error) {
            swal("Error", "An error occurred: " + error, "error");
        }
    });
}

//SubCategory Delet JS



//MainCategory Delet JS

function confirmDeleteMainCat(id) {
    swal({
        title: "Silmek İstediğine Emin misin?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            deleteItem(id);
        }
    });
}

function deleteItem(id) {
    event.preventDefault();

    var data = {
        id: id
    };

    $.ajax({
        url: '/kategori/delete-maincategory',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response == "Ok") {
                swal({
                    title: "Silme İşlemi Başarılı",
                    icon: "success",
                    buttons: {
                        confirm: {
                            text: "Tamam",
                            value: true,
                            visible: true,
                            className: "",
                            closeModal: true
                        }
                    }
                }).then((value) => {
                    if (value) {
                        location.href = "/kategori/kategoriler";
                    }
                    else {
                        location.href = "/kategori/kategoriler";
                    }
                });
            } else {
                alert(response);
            }
        },
        error: function (xhr, status, error) {
            swal("Error", "An error occurred: " + error, "error");
        }
    });
}

//MainCategory Delet JS