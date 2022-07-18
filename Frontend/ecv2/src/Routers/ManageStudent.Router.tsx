import React from 'react'
import { Route, Routes } from 'react-router-dom'
import ManageStudent from '../Pages/ManageStudent'

export const ManageStudentRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<ManageStudent/>} />
    </Routes>
  )
}
