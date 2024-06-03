

var moon = document.getElementById("moon");
var sun = document.getElementById("sun");
var mode = "light";
if (localStorage.getItem("mode") !=null) {
    mode = localStorage.getItem("mode");
}


if (mode == "dark") {
    moon.style.display = "none";
    let element = document.body;
    element.classList.add("darkMode");
}
else {
    sun.style.display = "none";
    let element = document.body;
    element.classList.remove("darkMode");

}

function LightMode() {
    sun.style.display = "none";
    moon.style.display = "block";
    let element = document.body;
    element.classList.remove("darkMode");
    localStorage.setItem("mode", "light");

}
function DarkMode() {
    moon.style.display = "none";
    sun.style.display = "block";
    let element = document.body;
    element.classList.add("darkMode");
    localStorage.setItem("mode", "dark");


}