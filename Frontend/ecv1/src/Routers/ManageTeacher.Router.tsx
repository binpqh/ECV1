import React from 'react'
import { Route, Routes } from 'react-router-dom'
import ManageTeacher from '../Pages/ManageTeacher'

export const ManageTeacherRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<ManageTeacher/>} />
    </Routes>
  )
}
