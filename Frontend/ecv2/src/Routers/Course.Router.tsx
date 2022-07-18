import React from 'react'
import { Routes,Route } from 'react-router-dom'
import { Course } from '../Pages/Course'

export const CourseRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<Course/>} />
    </Routes>
  )
}
