import React from 'react';
import  Navbar  from './Components/Navbar';
import "./App.scss"; 
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './Pages/Home';
import { NotFound404 } from './Components/404NF';
function App() {
  return (
    
    <>
    <BrowserRouter>
    <Navbar/>
    <Routes>
      <Route path="/" element={<Home/>}>
      <Route path="*" element={<NotFound404 />} />
      </Route>
    </Routes>
    </BrowserRouter>
    
    
  </>
  );
} 
export default App;
