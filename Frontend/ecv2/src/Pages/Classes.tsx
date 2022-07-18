import React, { useEffect, useState } from 'react'
import { IClassResult } from '../Interfaces';
import { GetAllClass } from '../Service';

const Classes = () => {
  const [classes,setClasses] = useState<IClassResult[]>([])
    
    useEffect(() => {
        const fetchData = async () => {
          const results = await GetAllClass();
          setClasses(results);
        };
        fetchData();
      },[]);
console.log(classes)
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
    {classes.map((item, i)=>
    {
      return(
        <tr className="table-primary" key = {i}>
        <th scope="row">{item.Id}</th>
        <td>{item.ClassName}</td>
        <td>{item.StartTime}</td>
        <td>{item.EndTime}</td>
        <td>{item.LinkGGMeet}</td>
        <td>{item.IdCourse}</td>
      </tr>
        )
    })}
  </tbody>
</table>
</div>
  )
}

export default Classes