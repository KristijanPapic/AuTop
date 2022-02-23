import logo from './logo.svg';
import './App.css';
import Navbar from './components/common/navbar.js'
import Footer from './components/common/footer';
import Manufacturers from './components/manufacturer/manufacturers.js';
import Models from './components/model/models.js'
import ModelVersions from './components/modelVersion/modelVersions';
import axios from 'axios';
import{useState,useEffect} from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Container, footer } from 'reactstrap'
import ModelVerionDetail from './components/modelVersionDetail/modelVersionDetail';





function App() {

  return (
    <Router>
      <div className="App" id='page-container'>
        <Navbar/>
        <Container className='bg-light border mb-5' id='page-content'>
          <Routes>
            <Route
            path='/'
            element={
              <Manufacturers/>
            }
            />
            <Route
            path='/Manufacturer/:id'
            element={
              <Models/>
            }
            />
            <Route
            path='/Model/:modelId'
            element={
              <ModelVersions/>
            }
            />
            <Route
            path='/ModelVersion/:modelVersionId'
            element={
              <ModelVerionDetail/> 
            }
            />
            </Routes>
        </Container>
        
      
      </div>
      <Footer/>
    </Router>
    
  );
}

export default App;
