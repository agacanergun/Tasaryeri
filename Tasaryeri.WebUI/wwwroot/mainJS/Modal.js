//VARİABLES
var modalAdd = document.getElementById('myModalAdd');
var modalUpdate = document.getElementById('myModalUpdate');
var modalAddSlide = document.getElementById('myModalAddSlide');
var modalUpdateSlide = document.getElementById('myModalUpdateSlide');
var myModalAddMainCat1 = document.getElementById('myModalAddMainCat');
var myModalUpdateMainCat1 = document.getElementById('myModalUpdateMainCat');
var myModalAddSubCat1 = document.getElementById('myModalAddSubCat');
var myModalUpdateSubCat1 = document.getElementById('myModalUpdateSubCat');
var modalAddSocialMedia = document.getElementById('myModalAddSocialMedia');
var modalUpdateSocialMedia = document.getElementById('myModalUpdateSocialMedia');
var modalAddContact = document.getElementById('myModalAddContact');
var modalUpdateContact = document.getElementById('myModalUpdateContact');
var modalAddAboutUs = document.getElementById('myModalAddAboutUs');
var modalUpdateAboutUs = document.getElementById('myModalUpdateAboutUs');
var modalAddInstitutional = document.getElementById('myModalAddInstitutional');
var modalUpdateInstitutional = document.getElementById('myModalUpdateInstitutional');

//VARİABLES


//CLOSE MODAL
window.onclick = function (event) {
    var modals = document.getElementsByClassName("modal");
    for (var i = 0; i < modals.length; i++) {
        if (event.target == modals[i]) {
            modals[i].style.display = "none";
        }
    }
}
//CLOSE MODAL






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



//ADMİN MODALS

//SLİDE MODALS
function showModalAddSlide() {
    document.getElementById("myModalAddSlide").style.display = "block";
}

function showModalUpdateSlide(event) {
    var result = event.split(",/,/");
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




//FOOTER SOCİALMEDİA ADD-UPDATE MODAL
function showModalAddSocialMedia() {
    document.getElementById("myModalAddSocialMedia").style.display = "block";
}

function showModalUpdateSocialMedia(event) {
    var result = event.split(",");
    document.getElementById("id").value = result[0];
    document.getElementById("facebook").value = result[1];
    document.getElementById("instagram").value = result[2];
    document.getElementById("twitter").value = result[3];
    document.getElementById("youtube").value = result[4];
    document.getElementById("myModalUpdateSocialMedia").style.display = "block";
}


//FOOTER SOCİALMEDİA ADD-UPDATE MODAL



//FOOTER CONTACT ADD-UPDATE MODAL
function showModalAddContact() {
    document.getElementById("myModalAddContact").style.display = "block";
}

function showModalUpdateContact(event) {
    var result = event.split(",");
    document.getElementById("id").value = result[0];
    document.getElementById("contactType").value = result[1];
    document.getElementById("ContactInfo").value = result[2];
    document.getElementById("DisplayIndex").value = result[3];
    document.getElementById("myModalUpdateContact").style.display = "block";
}



//FOOTER CONTACT ADD-UPDATE MODAL



//FOOTER AboutUs ADD-UPDATE MODAL
function showModalAddAboutUs() {
    document.getElementById("myModalAddAboutUs").style.display = "block";
}

function showModalUpdateAboutUs(event) {
    var result = event.split(",/,/");
    document.getElementById("id").value = result[0];
    document.getElementById("AboutUsName").value = result[1];
    document.getElementById("AboutUsDescription").value = result[2];
    document.getElementById("DisplayIndex").value = result[3];
    document.getElementById("myModalUpdateAboutUs").style.display = "block";
}


//FOOTER AboutUs ADD-UPDATE MODAL



//FOOTER Institutional ADD-UPDATE MODAL
function showModalAddInstitutional() {
    document.getElementById("myModalAddInstitutional").style.display = "block";
}

function showModalUpdateInstitutional(event) {
    var result = event.split(",/,/");
    document.getElementById("id").value = result[0];
    document.getElementById("InstitutionalName").value = result[1];
    document.getElementById("InstitutionalDescription").value = result[2];
    document.getElementById("DisplayIndex").value = result[3];
    document.getElementById("myModalUpdateInstitutional").style.display = "block";
}



//FOOTER Institutional ADD-UPDATE MODAL




