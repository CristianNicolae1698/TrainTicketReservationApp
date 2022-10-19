
const searchButton = document.querySelector('#btnSearch')
const routeNameInput = document.querySelector("#routeName")
var responseVariabile;
async function searchForRoute(routeName) {

    const body = {
        "routeName": routeName
    };


    const response = await fetch('https://localhost:7007/api/index/gettrainsbyroutename', {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
    var data = await response.json();
    console.log(data);
    if (response) {
        hideloader();
    }
    show(data);
        

}

//adding event to the submit search button for calling the searchForRoute function

searchButton.addEventListener('click', function () {


    searchForRoute(routeNameInput.value);
})

//function to hide the loader

function hideloader() {
    document.getElementById('loading').style.display = 'none';
}

//function to display the data in a table for the trains of the specified route

function show(data) {
    let tab =
        `<tr>
          <th>Id</th>
          <th>Train Number</th>
          <th>Train Type</th>
          
         </tr>`;

    // Loop to access all rows 
    for (let r of data.list) {
        tab += `<tr> 
    <td>${r.id} </td>
    <td>${r.trainNumber}</td>
    <td>${r.trainType}</td> 
          
    </tr>`;
    }
    // Setting innerHTML as tab variable
    document.getElementById("routes").innerHTML = tab;
}


