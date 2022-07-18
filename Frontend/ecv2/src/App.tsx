import React from 'react';
import  Navbar  from './Components/Navbar';
import "./App.css"; 
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './Pages/Home';
import { NotFound404 } from './Components/404NF';
import { CourseRouter } from './Routers/Course.Router';
import { ClassesRouter } from './Routers/Classes.Router';
function App() {
  
  return (

    <BrowserRouter>
    <Navbar></Navbar>
    <Routes>
      <Route path="/" element={<Home/>}/>
      <Route path="*" element={<NotFound404 />} />
      <Route path="khoahoc/*" element = {<CourseRouter/>}/>
      <Route path="lophoc/*" element = {<ClassesRouter/>}/>
    </Routes>
    </BrowserRouter>  

  );
} 
export default App;
