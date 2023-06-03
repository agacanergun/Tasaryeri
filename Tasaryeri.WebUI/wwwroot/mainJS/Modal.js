﻿
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



//MAİN CATEGORY ADD-UPDATE MODALS
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

var myModalAddSubCat = document.getElementById('myModalAddSubCat');
var myModalUpdateSubCat = document.getElementById('myModalUpdateSubCat');

window.onclick = function (event) {
    if (event.target == myModalAddMainCat || event.target == myModalUpdateMainCat || event.target == myModalAddSubCat || event.target == myModalUpdateSubCat) {
        myModalAddMainCat.style.display = "none";
        myModalUpdateMainCat.style.display = "none";
        myModalAddSubCat.style.display = "none";
        myModalUpdateSubCat.style.display = "none";
    }
}
//MAİN CATEGORY ADD-UPDATE MODALS



//SUB CATEGORY ADD-UPDATE MODALS
function showModalAddSubCat() {
    document.getElementById("myModalAddSubCat").style.display = "block";
}

function showModalUpdateSubCat(event) {
    var result = event.split(",");
    document.getElementById("idsub").value = result[0];
    document.getElementById("namesub").value = result[1];
    document.getElementById("displayindexsub").value = result[2];
    document.getElementById("myModalUpdateSubCat").style.display = "block";
}



//SUB CATEGORY ADD-UPDATE MODALS

