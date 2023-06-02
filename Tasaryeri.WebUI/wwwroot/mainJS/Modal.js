
//ADMİN MODALS
function showModalAdd() {
    document.getElementById("myModalAdd").style.display = "block";
}

function showModalUpdate(event) {
    var result = event.split(",");
    document.getElementById("id").value = result[0];
    document.getElementById("name").value = result[1];
    document.getElementById("surname").value = result[2];
    document.getElementById("username").value = result[3];
    document.getElementById("password").value = result[4];
    document.getElementById("myModalUpdate").style.display = "block";
}

var modalAdd = document.getElementById('myModalAdd');
var modalUpdate = document.getElementById('myModalUpdate');

window.onclick = function (event) {
    if (event.target == modalUpdate || event.target == modalAdd) {
        modalUpdate.style.display = "none";
        modalAdd.style.display = "none";
    }
}
//ADMİN MODALS

//SLİDE MODALS
function showModalAddSlide() {
    document.getElementById("myModalAddSlide").style.display = "block";
}

function showModalUpdateSlide(event) {
    var result = event.split(",");
    document.getElementById("id").value = result[0];
    document.getElementById("name").value = result[1];
    document.getElementById("surname").value = result[2];
    document.getElementById("shortdesc").value = result[3];
    document.getElementById("longdesc").value = result[4];
    document.getElementById("picture").value = result[5];
    document.getElementById("displayindex").value = result[6];
    document.getElementById("link").value = result[7];
    document.getElementById("myModalUpdateSlide").style.display = "block";
}

var modalAddSlide = document.getElementById('myModalAddSlide');
var modalUpdateSlide = document.getElementById('myModalUpdateSlide');

window.onclick = function (event) {
    if (event.target == myModalUpdateSlide || event.target == myModalAddSlide) {
        modalAddSlide.style.display = "none";
        modalUpdateSlide.style.display = "none";
    }
}
//SLİDE MODALS



//CATEGORY ADD MODALS
function showModalAddMainCat() {
    document.getElementById("myModalAddMainCat").style.display = "block";
}

function showModalUpdateMainCat(event) {
    var result = event.split(",");
    document.getElementById("id").value = result[0];
    document.getElementById("name").value = result[1];
    document.getElementById("displayindex").value = result[2];
    document.getElementById("myModalUpdateMainCat").style.display = "block";
}

var myModalAddMainCat = document.getElementById('myModalAddMainCat');
var myModalUpdateMainCat = document.getElementById('myModalUpdateMainCat');

window.onclick = function (event) {
    if (event.target == myModalAddMainCat || event.target == myModalUpdateMainCat) {
        myModalAddMainCat.style.display = "none";
        myModalUpdateMainCat.style.display = "none";
    }
}
//SLİDE MODALS