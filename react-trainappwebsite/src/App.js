import React, { Fragment } from 'react';
import NavBar from "./components/NavBar";
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import './App.css';
import Home from './components/Pages/Home';
import SignUpComponent from './components/SignUpComponent';
function App() {
  return (
    <>
    <Router>
    <Fragment>
    <NavBar />
      <Routes>
        
        
      
          <Route index element={<Home/>}/>
          <Route path='/SignUp' element={<SignUpComponent/>}/>
      
      </Routes>
      </Fragment>
    </Router>
    </>
  );
}

export default App;
