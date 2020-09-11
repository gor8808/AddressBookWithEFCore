var modal = document.getElementById("qrModal");

var img = document.getElementsByClassName("qrCode");
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
for (var i = 0; i < img.length; i++) {
    img[i].onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
    }

}

var span = document.getElementsByClassName("close")[0];

span.onclick = function () {
    modal.style.display = "none";
}