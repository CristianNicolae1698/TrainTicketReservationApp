import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import { useState } from "react"
import React from 'react'


const TrainPage = () => {

    const [token, setToken] = useState('')
    const [departureStation, setDepartureStation] = useState('')
    const [arrivalStation, setArrivalStation] = useState('')
    const [trains, setTrains] = useState([])
    const [isLoading, setIsLoading] = useState(false)
    const [openRegister, setOpenRegister] = useState(false);
    const [openLogin, setOpenLogin] = useState(false);
    const [openDisplayBookings, setOpenDisplayBookings] = useState(false);
    const [routeId, setRouteId] = useState([])
    const [optionsState, setOptionsState] = useState([])
    const [selectedTrain, setSelectedTrain] = useState({})
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [bookings, setBookings] = useState([])

    var TrainUrl = new URL('https://localhost:7007/api/route/getTrainsByStationsName');
    var RouteIdUrl = new URL('https://localhost:7007/api/route/getRouteIdByStationsName');
    var PostClientUrl = new URL('https://localhost:7007/api/client/Register');
    var ReturnClientUrl = new URL('https://localhost:7007/api/client/SignIn');
    var PostBookingUrl = new URL("https://localhost:7007/api/booking/postBooking")
    var DisplayBookingsUrl = new URL('https://localhost:7007/api/booking/displayBookingsByClientId');


    const handleSubmit = async (event) => {
        setIsLoading(true)
        event.preventDefault();
        let data;
        const body = {
            "DepartureStation": departureStation,
            "ArrivalStation": arrivalStation
        };
        const responseTrains = await fetch(TrainUrl, {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        }).then(responseTrains => responseTrains.json())
            .then((responseTrainsData) => setTrains(responseTrainsData));

        setIsLoading(false);
        const responseRoute = await fetch(RouteIdUrl, {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        }).then(responseRoute => responseRoute.json())
            .then((responseRouteData) => setRouteId(responseRouteData));


    }
    const handleSubmitRegister = () => {
        const body = {
            "FirstName": firstName,
            "LastName": lastName
        };
        fetch(PostClientUrl, {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(data => data.json())
            .then(response => console.log(response));
        setOpenRegister(false)
    }

    const handleSubmitLogin = () => {
        const body = {
            "FirstName": firstName,
            "LastName": lastName
        };
        fetch(ReturnClientUrl, {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(response => response.json())
            .then((responseData) => { setToken(responseData) });
        console.log(token)
        setOpenLogin(false)

    }
    const handleClose = () => {


        setFirstName('')
        setLastName('')
        setOpenLogin(false)
        setOpenRegister(false)
        setOpenDisplayBookings(false)


    }
    const handleSelect = (item) => {

        const body = {
            "clientId": token,
            "trainId": item.id,
            "routeId": routeId
        };
        fetch(PostBookingUrl, {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(data => data.json())
            .then(response => console.log(response));
        alert("Your booking has been submitted");


    }

    const handleDisplaybookings = async () => {

        const responseBookings = await fetch(DisplayBookingsUrl, {
            method: 'POST',
            body: JSON.stringify(token),
            headers: {
                "content-type": "application/json"
            }
        }).then(responseBookings => responseBookings.json())
            .then((responseBookingsData) => setBookings(responseBookingsData));
        setOpenDisplayBookings(true);
    }





    return (
        <><>
            
            <div class="container">
                <button onClick={() => setOpenLogin(true)}>SignIn</button>
                <button onClick={() => setOpenRegister(true)}>Register</button>
                <button onClick={() => handleDisplaybookings()}>Display Your Bookings</button>
                <div class="routes_sidebar">
                    <form>
                        <select value={optionsState}>
                            <option value="Bucuresti">Bucuresti</option>
                            <option value="Craiova">Craiova</option>
                            <option value="Brasov">Brasov</option>
                        </select>
                        <select value={optionsState}>
                            <option value="Bucuresti">Bucuresti</option>
                            <option value="Craiova">Craiova</option>
                            <option value="Constanta">Constanta</option>
                        </select>

                        <input onChange={(e) => setDepartureStation(e.target.value)} type="text" id="departureStation" placeholder="Departure Station" />
                        <input onChange={(e) => setArrivalStation(e.target.value)} type="text" id="arrivalStation" placeholder="Arrival Station" />

                        <button onClick={handleSubmit} type="submit" id="btnSearch">Search</button>
                    </form>

                </div>
                <div class="routes_container">
                </div>
            </div>
            <div class="d-flex justify-content-center">
                {isLoading ? <div class="spinner-border"
                    role="status" id="loading">
                    <span class="sr-only">Loading...</span>
                </div> : null}

            </div><h1>Trains for Specified Route</h1><Dialog
                open={openRegister}
                keepMounted
                aria-describedby="alert-dialog-slide-description"
            >
                <DialogTitle>Fill in the blank fields with your credentials</DialogTitle>
                <DialogContent>
                    <form class="form" method="dialog">
                        <div><label>Your First Name </label><input onChange={(e) => setFirstName(e.target.value)} type="text" /></div>

                        <label>Your Last Name</label> <input onChange={(e) => setLastName(e.target.value)} type="text" id="lastName" />
                    </form>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Close</Button>
                    <Button onClick={() => handleSubmitRegister()}>Register</Button>
                </DialogActions>
            </Dialog><Dialog
                open={openLogin}
                keepMounted
                aria-describedby="alert-dialog-slide-description"
            >
                <DialogTitle>Fill in the blank fields with your credentials</DialogTitle>
                <DialogContent>
                    <form class="form" method="dialog">
                        <div><label>Your First Name </label><input onChange={(e) => setFirstName(e.target.value)} type="text" /></div>

                        <label>Your Last Name</label> <input onChange={(e) => setLastName(e.target.value)} type="text" id="lastName" />
                    </form>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Close</Button>
                    <Button onClick={() => handleSubmitLogin()}>Login</Button>
                </DialogActions>
            </Dialog><Dialog
                open={openDisplayBookings}
                keepMounted
                aria-describedby="alert-dialog-slide-description"
            >
                <DialogTitle>These are your bookings</DialogTitle>
                <DialogContent>
                    <table id="bookings">
                        <tr>
                            <th>Booking Date</th>
                            <th>Booking Price</th>
                        </tr>

                        {bookings ? bookings.map((bookingItem) => <tr>
                            <td>{bookingItem.bookingDate}</td>
                            <td>{bookingItem.bookingPrice}</td>
                        </tr>) : null}

                    </table>
                </DialogContent>
                <Button onClick={handleClose}>Close</Button>
            </Dialog><table id="trains">
                <tr>

                    <th>Train Number</th>
                    <th>Train Type</th>

                </tr>
                {trains ? trains.map((item) => <tr>
                    <td>{item.trainNumber}</td>
                    <td>{item.trainType}</td>
                    <td><button onClick={() => handleSelect(item)}>Select</button></td>

                </tr>) : null}
            </table><dialog class="modal" id="modal">


            </dialog></>
        </>
    );
}; export default TrainPage