
const addButton = document.querySelector('#btnSearch')
const routeNameInput = document.querySelector("#departureStation")
var responseVariabile;
function addItem(routeName) {

    const body = {
        "routeName": routeName
    };


    fetch(' https://localhost:7007/api/index', {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
        .then(data => data.json())
        .then(response => console.log(response));

}

addButton.addEventListener('click', function () {


    addItem(routeNameInput.value);
})



