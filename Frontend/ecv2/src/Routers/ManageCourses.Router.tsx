import React from 'react'
import { Route, Routes } from 'react-router-dom'
import ManageCourse from '../Pages/ManageCourse'

export const ManageCoursesRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<ManageCourse/>} />
    </Routes>
  )
}
