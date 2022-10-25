
const searchButton = document.querySelector('#btnSearch');
const departureStationInput = document.querySelector("#departureStation");
const arrivalStationInput = document.querySelector("#arrivalStation");


async function searchForRoute(arrivalStation, departureStation) {

    var data;
    const body = {
        "DepartureStation": departureStation,
        "ArrivalStation": arrivalStation
    };
    const response = await fetch('https://localhost:7007/api/index/getTrainsByRoute', {
        method: 'POST',
        body: JSON.stringify(body),
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
    searchForRoute(arrivalStationInput.value, departureStationInput.value);
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
            var col2 = currentRow.find("td:eq(1)").text();
            var col3 = currentRow.find("td:eq(2)").text();
            /*alert(col1 + "\n" + "\n" + col3);*/
            //var firstName = window.prompt("What is your First Name");
            //var lastName = window.prompt("What is your First Name");

            const modal = document.querySelector("#modal");
            modal.showModal();

            //function for posting the client to the db after filling in the form

            const addButton = document.querySelector('#btnAdd');
            const firstNameInput = document.querySelector("#firstName");
            const lastNameInput = document.querySelector("#lastName");


            function addItem(firstName, lastName) {

                const body = {
                    "FirstName": firstName,
                    "LastName": lastName
                };
                fetch('https://localhost:7007/api/index/postClient', {
                    method: 'POST',
                    body: JSON.stringify(body),
                    headers: {
                        "content-type": "application/json"
                    }
                })
                    .then(data => data.json())
                    .then(response => console.log(response));

            }

            function getClientId(firstName, lastName) {

                var clientDataId;
                const body = {
                    "FirstName": firstName,
                    "LastName": lastName
                };
                fetch('https://localhost:7007/api/index/getClientId', {
                    method: 'POST',
                    body: JSON.stringify(body),
                    headers: {
                        "content-type": "application/json"
                    }
                })
                    .then(response => response.json())
                    .then((responseData) => clientDataId = responseData);

            }

            function addBooking(clientId, trainId) {
                var bookingData;
                const body = {
                    "clientId": clientId,
                    "trainId": traindId
                };
                fetch("https://localhost:7007/api/index/postBooking", {
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
                addItem(firstNameInput.value, lastNameInput.value);
                getClientId(firstNameInput.value, lastNameInput.value);
                addBooking(clientDataId, col1);
            })

        });

    });
}


