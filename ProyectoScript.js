const label = document.querySelector('#ContentPlaceHolder1_dgvList_label1_1');
const buttom = document.querySelector('input');
buttom.addEventListener('click', (e) => {
    setTimeout(() => {
        label.remove();
    }, 5000);
    console.log(e.target)
})


function processImage() {
    var fileUpload = document.getElementById("<%=inpImage.ClientID%>");
    var imgNewProfile = document.getElementById("<%=imgNewProfile.ClientID%>");

    if (fileUpload.value != "") {
        var file = fileUpload.files[0];
        var reader = new FileReader();

        reader.onload = function (e) {
            imgNewProfile.src = e.target.result;
        }
        reader.readAsDataURL(file);
    }
}

