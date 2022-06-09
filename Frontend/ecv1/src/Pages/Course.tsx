import React, { useEffect, useState } from 'react'
import { ICourseResult } from '../Interfaces/ICourseService';
import {GetAllCourse} from '../Service/Course.Service'




export const Course = () => {
    const [courses,setCourses] = useState<Array<ICourseResult>>([])
    
    useEffect(() => {
        const fetchData = async () => {
            
          const results = await GetAllCourse();
          setCourses(results);
        };
        fetchData();
      }, []);
    
  return (
    <>
        <div>
        {courses.map((item, index) => {
          return (
                <div>
                    {item.Name}
                </div>
            );
        })}
        </div>
    </>
  )
}

export default Course