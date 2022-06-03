using Data.Defined.Enum;
using Data.Interface;
using Data.Tables;
using Data.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services;
public class CourseService : ICourseService
{
    private readonly ECV1DevContext _context;
    public CourseService(ECV1DevContext context)
    {
        _context = context;
    }
    public async Task<CourseResult> CreateAsync(CourseInput create)
    {
        var course = new Course
        {
            Coursename = create.Name,
            DayStart = create.DayStart,
            DayEnd = create.DayEnd,
            Level = create.Level,
            Price = create.Price,
            Status = Status.Active
        };
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return new CourseResult
        {
            Id = course.Id,
            Name = course.Coursename,
            DayStart = course.DayStart,
            DayEnd = course.DayEnd,
            Level = course.Level,
            Price = course.Price
        };
    }

    public async Task DeleteAsync(int id)
    {
        var course = _context.Courses.Where(e => e.Id == id && e.Status != Status.Deleted).FirstOrDefault();
        if (course != null)
        {
            course.Status = Status.Deleted;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<List<CourseResult>> GetAllAsync()
    {
        var courses = await _context.Courses.Where(e => e.Status ==Status.Active)
            .Select(e => new CourseResult
            {
                Id = e.Id,
                Name =e.Coursename,
                DayStart = e.DayStart,
                DayEnd =e.DayEnd,
                Price = e.Price,
                Level = e.Level
            })
            .ToListAsync();
        return courses;
        
    }

    public async Task<CourseResult> GetbyIdAsync(int id)
    {
        var course = await _context.Courses.Where(e => e.Id == id && e.Status == Status.Active)
            .Select(e => new CourseResult
            {
                Id = e.Id,
                Name = e.Coursename,
                DayStart = e.DayStart,
                DayEnd = e.DayEnd,
                Price = e.Price,
                Level = e.Level
            }).FirstOrDefaultAsync();
        if(course == null)
        {
            throw new Exception("Không tìm thấy id");
        }
        return course;
    }

    public async Task<CourseResult> UpdateAsync(int id, CourseInput update)
    {
        var course = await _context.Courses.Where(e => e.Id == id && e.Status == Status.Active)
            .FirstOrDefaultAsync();
        if(course != null)
        {
            course.Coursename = update.Name ?? course.Coursename;
            course.DayStart = update.DayStart ?? course.DayStart;
            course.DayEnd = update.DayEnd ?? course.DayEnd;
            course.Price = update.Price;
            course.Level = update.Level ?? course.Level;
        }
        await _context.SaveChangesAsync();
        return new CourseResult
        {
            Id = id,
            Name = course.Coursename,
            DayStart = course.DayStart,
            DayEnd = course.DayEnd,
            Price = course.Price,
            Level = course.Level
        };
    }
}

