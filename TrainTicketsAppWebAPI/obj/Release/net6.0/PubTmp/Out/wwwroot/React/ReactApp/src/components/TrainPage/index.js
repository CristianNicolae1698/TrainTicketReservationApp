import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import { useState } from "react"
import React from 'react'


const TrainPage = () =>{

    const [token, setToken] = useState('')
    const [departureStation, setDepartureStation] = useState('')
    const [arrivalStation, setArrivalStation] = useState('')
    const [trains, setTrains] = useState([])
    const [isLoading, setIsLoading] = useState(false)
    const [openRegister, setOpenRegister] = useState(false);
    const [openLogin, setOpenLogin] = useState(false);
    
    const [selectedTrain, setSelectedTrain] = useState({})
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')


    const handleSubmit = async (event) =>{
        setIsLoading(true)
        event.preventDefault();
        let data;
    const body = {
        "DepartureStation": departureStation,
        "ArrivalStation": arrivalStation
    };
        const response = await fetch('https://trainticketsapi.azurewebsites.net/api/index/getTrainsByRoute', {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    }).then(response => response.json())
        .then((responseData) => setTrains(responseData) );
    setIsLoading(false);

    }
    const handleSubmitRegister = () => {
        const body = {
            "FirstName": firstName,
            "LastName": lastName
        };
        fetch('https://trainticketsapi.azurewebsites.net/api/index/postClient', {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(data => data.json())
            .then(response => console.log(response));
       
    }

    const handleSubmitLogin = () => {
        const body = {
            "FirstName": firstName,
            "LastName": lastName
        };
        fetch('https://trainticketsapi.azurewebsites.net/api/index/getClientId', {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(response => response.json())
            .then((responseData) => {setToken(responseData)});
        console.log(token)
        setOpenLogin(false)

    }
    const handleClose = () => {
        
        
        setFirstName('')
        setLastName('')
    }
    const handleSelect = (item) => {
        
        const body = {
            "clientId": token,
            "trainId": item.id
        };
        fetch("https://trainticketsapi.azurewebsites.net/api/index/postBooking", {
            method: 'POST',
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(data => data.json())
            .then(response => console.log(response));


    }

    return(
        <>
        <div class="container">
            <button onClick={() => setOpenLogin(true)}>SignIn</button>
            <button onClick={ ()=> setOpenRegister()} >Register</button>
        <div class="routes_sidebar">
            <form >
            <input onChange={(e)=> setDepartureStation(e.target.value)} type="text" id="departureStation" placeholder="Departure Station"/>
            <input onChange={(e)=> setArrivalStation(e.target.value)} type="text" id="arrivalStation" placeholder="Arrival Station" />
            <button onClick={handleSubmit}type="submit" id="btnSearch">Search</button>
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
        
    </div>
    <h1>Trains for Specified Route</h1>
    <Dialog
        open={openRegister}
        keepMounted
        aria-describedby="alert-dialog-slide-description"
      >
        <DialogTitle>{"Use Google's location service?"}</DialogTitle>
        <DialogContent>
        <form class="form" method="dialog">
            <div><label>Your First Name </label><input onChange={(e)=> setFirstName(e.target.value)} type="text"/></div>
            
            <label>Your Last Name</label> <input onChange={(e)=> setLastName(e.target.value)} type="text" id="lastName"/>
        </form>
        </DialogContent>
        <DialogActions>
        <Button onClick={handleClose}>Close</Button>
        <Button onClick={() => handleSubmitRegister()}>Register</Button>
        </DialogActions>
      </Dialog>
      <Dialog
        open={openLogin}
        keepMounted
        aria-describedby="alert-dialog-slide-description"
      >
        <DialogTitle>{"Use Google's location service?"}</DialogTitle>
        <DialogContent>
        <form class="form" method="dialog">
            <div><label>Your First Name </label><input onChange={(e)=> setFirstName(e.target.value)} type="text"/></div>
            
            <label>Your Last Name</label> <input onChange={(e)=> setLastName(e.target.value)} type="text" id="lastName"/>
        </form>
        </DialogContent>
        <DialogActions>
        <Button onClick={handleClose}>Close</Button>
        <Button onClick={() => handleSubmitLogin()}>Login</Button>
        </DialogActions>
      </Dialog>
    <table id="trains">
        <tr>
    
          <th>Train Number</th>
          <th>Train Type</th>
           
         </tr>
         {trains ? trains.map((item) => <tr>
    <td>{item.trainNumber}</td>
    <td>{item.trainType}</td>
    <td><button onClick={() => handleSelect(item)}>Select</button></td>

    </tr>) : null}
         </table>

    <dialog class="modal" id="modal">
        

    </dialog>
    </>
    );
}; export default TrainPage