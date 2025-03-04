import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom"; // Correct imports
import Login from './Auth/Login';
import Home from './Auth/Home';


import './App.css';

function App() {
  return (
    <Router>
      <Routes>
        {/* Define your routes here */}
        
        <Route path="/login" element={<Login />} />
        <Route path="/home" element={<Home/>}/>
        
      </Routes>
    </Router>
  );
}

export default App;
