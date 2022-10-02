const searchButton = document.querySelector('#btnSearch')



function loadTrainSearchPage() {
    location.href("https://www.google.ro/");
}
searchButton.addEventListener('click', function () {
    loadTrainSearchPage();
})