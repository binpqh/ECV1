import React from 'react'
import { Route, Routes } from 'react-router-dom'
import ManageClasses from '../Pages/ManageClasses'

export const ManageClassesRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<ManageClasses/>} />
    </Routes>
  )
}
