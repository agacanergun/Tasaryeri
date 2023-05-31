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