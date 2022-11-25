import React from 'react';
import '../App.css';
import {Button} from './Button';
import './TrainComponent.css';
import { useState } from "react";






function TrainComponent() {

  const [token, setToken] = useState('')
  const [departureStation, setDepartureStation] = useState('')
  const [arrivalStation, setArrivalStation] = useState('')
  const [trains, setTrains] = useState([])
  const [routeId, setRouteId] = useState([])
  const [optionsState, setOptionsState] = useState([])
  const [selectedTrain, setSelectedTrain] = useState({})

  var TrainUrl = new URL('https://localhost:7007/api/route/getTrainsByStations');
  var RouteIdUrl = new URL('https://localhost:7007/api/route/getRouteIdByStations');
  var PostBookingUrl = new URL("https://localhost:7007/api/booking/postBooking")


  const handleSubmit = async (event) => {
    
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

    
    const responseRoute = await fetch(RouteIdUrl, {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    }).then(responseRoute => responseRoute.json())
        .then((responseRouteData) => setRouteId(responseRouteData));


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







  return (
    <div className='train-container'>
        <h1>Search for a train</h1>
        <p>Choose departure and arrival stations</p>
        <div className='train-btns'>
        <form>
            <input onChange={(e) => setDepartureStation(e.target.value)} type="text" id="departureStation" placeholder="Departure Station" />
            <input onChange={(e) => setArrivalStation(e.target.value)} type="text" id="arrivalStation" placeholder="Arrival Station" />
            <Button className='btns' buttonStyle='btn--outline' buttonSize='btn--large' onClick={handleSubmit} type="submit" id="btnSearch">
                SEARCH<i className='far fa-play-circle'/>
            </Button>
        </form>    

        </div>
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
    </div>
  )
}

export default TrainComponent