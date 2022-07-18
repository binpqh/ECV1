import React, { useEffect, useState } from 'react'
import { ICourseResult } from '../Interfaces/ICourseService';
import {GetAllCourse} from '../Service/Course.Service'

export const Course = () => {
    const [courses,setCourses] = useState<ICourseResult[]>([])
    
    useEffect(() => {
        const fetchData = async () => {
            
          const results = await GetAllCourse();
          console.log(results)
          setCourses(results);

        };
        fetchData();
      },[]);

  return (

<div>
<br/>
<table className="table table-hover">
  <thead>
    <tr>
      <th scope="col">ID</th>
      <th scope="col">Tên Khoá Học</th>
      <th scope="col">Ngày bắt đầu</th>
      <th scope="col">Ngày kết thúc</th>
      <th scope="col">Cấp độ</th>
      <th scope="col">Giá</th>
    </tr>
  </thead>
  <tbody>
  {courses.map((item,index) =>
  {
    
    return(
      <tr className="table-primary" key ={index}>
        <th scope="row">{item.id}</th>
        <td>{item.name}</td>
        <td>{item.dayStart}</td>
        <td>{item.dayEnd}</td>
        <td>{item.level}</td>
        <td>{item.price}</td>
      </tr>
)
  })}
  </tbody>
</table>
</div>

  );
};