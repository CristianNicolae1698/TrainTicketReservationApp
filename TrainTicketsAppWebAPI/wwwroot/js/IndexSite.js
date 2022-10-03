
const addButton = document.querySelector('#btnAdd')
const routeNameInput = document.querySelector("#title")

function addItem(routeName) {

    const body = {
        "routeName": routeName
    };


    fetch(' https://localhost:7007/api/route', {
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
