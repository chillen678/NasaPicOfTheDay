// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function searchPictureOfTheDay(form, e) {
    e.preventDefault();
    var form = document.getElementById('searchPictureOfTheDay');
    form.submit();
}

function ShowPopUp(e) {

    var myModal = new bootstrap.Modal(document.getElementById('nasaModal'))

    var title = e.parentNode.children[0].innerHTML;
    var ModalTitle = document.getElementById('modalTitle');
    ModalTitle.innerHTML = title;

    var date = e.parentNode.children[1].innerHTML;
    var modalDate = document.getElementById('modalDate');
    modalDate.innerHTML = date;

    var explanation = e.parentNode.children[2].value;
    var modalExplanation = document.getElementById('modalExplanation');
    modalExplanation.innerHTML = explanation;

    var media_type = e.parentNode.children[3].value;
    if (media_type != "video") {

        var img = e.parentNode.children[5].children[0].src;
        var modalImage = document.getElementById('modalImage');
        modalImage.src = img;
        document.getElementById('modalVideo').style.display = 'none';
        document.getElementById('modalImage').style.display = 'show';
    }
    else {
        var img = e.parentNode.children[4].src;
        var modalImage = document.getElementById('modalVideo');
        modalImage.src = img;
        document.getElementById('modalImage').style.display = 'none';
        document.getElementById('modalVideo').style.display = 'show';
    }
    myModal.show()
}

function overlayOn() {
    document.getElementById("overlay").style.display = "block";
}

function overlayOff() {
    document.getElementById("overlay").style.display = "none";
}

document.addEventListener('readystatechange', event => {
    overlayOn();
    if (event.target.readyState === "complete") {
        overlayOff()
    }
});

function ShowMarsPopUp(e) {

    var myModal = new bootstrap.Modal(document.getElementById('marsRoverModal'))
    var img = e.parentNode.children[1].children[0].src;
    var modalImage = document.getElementById('marsRovermodalImage');
        modalImage.src = img;

    
    myModal.show()
}