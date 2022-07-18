import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Home from '../Pages/Home'

export const HomeRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<Home/>} />
    </Routes>
  )
}
