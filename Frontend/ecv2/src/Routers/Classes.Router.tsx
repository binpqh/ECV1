import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Classes from '../Pages/Classes'

export const ClassesRouter = () => {
  return (
    <Routes>
        <Route path ="/" element={<Classes/>} />
    </Routes>
  )
}
