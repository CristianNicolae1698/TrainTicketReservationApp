
const searchButton = document.querySelector('#btnSearch')
const routeNameInput = document.querySelector("#routeName")
var responseVariabile;

async function searchForRoute(routeName) {

    var data;
    const response = await fetch('https://localhost:7007/api/index/getTrainsByRouteName', {
        method: 'POST',
        body: JSON.stringify(routeName),
        headers: {
            "content-type": "application/json"
        }
    }).then(response => response.json())
        .then((responseData) => data = responseData);

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


    data.forEach((item) => {
        tab += `<tr>
    <td>${item.id} </td>
    <td>${item.trainNumber}</td>
    <td>${item.trainType}</td>
    <td><button class="btnSelect">Select</button></td>

    </tr>`;
    });
    // Setting innerHTML as tab variable
    document.getElementById("trains").innerHTML = tab;

    // function for the submit button
    $(document).ready(function () {
        $(".btnSelect").on('click', function () {
            var currentRow = $(this).closest("tr");
            var col1 = currentRow.find("td:eq(0)").text();
            /*var col2 = currentRow.find("td:eq(1)").text();*/
            var col3 = currentRow.find("td:eq(2)").text();
            /*alert(col1 + "\n" + "\n" + col3);*/
            var firstName = window.prompt("What is your First Name");
            var lastName = window.prompt("What is your First Name");
            

        });

    });
}


