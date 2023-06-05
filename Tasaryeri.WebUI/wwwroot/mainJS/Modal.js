



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

var myModalAddMainCat1 = document.getElementById('myModalAddMainCat');
var myModalUpdateMainCat1 = document.getElementById('myModalUpdateMainCat');
var myModalAddSubCat1 = document.getElementById('myModalAddSubCat');
var myModalUpdateSubCat1 = document.getElementById('myModalUpdateSubCat');

window.onclick = function (event) {
    var modals = document.getElementsByClassName("modal");
    for (var i = 0; i < modals.length; i++) {
        if (event.target == modals[i]) {
            modals[i].style.display = "none";
        }
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


