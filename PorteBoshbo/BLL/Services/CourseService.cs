using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class CourseService
    {
        public static List<CourseDTO> Get()
        {
            var courses = new List<CourseDTO>();
            var coursedb = DataAccessFactory.CourseDataAccess().GetAll();
            foreach (var course in coursedb)
            {
                courses.Add(new CourseDTO()
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName
                });
            }
            return courses;
        }
        public static CourseDTO Get(int id)
        {
            var coursedb = DataAccessFactory.CourseDataAccess().Get(id);
            var course = new CourseDTO()
            {
                CourseId = coursedb.CourseId,
                CourseName = coursedb.CourseName
            };
            return course;
        }
        public static bool Add(CourseDTO course)
        {
            var coursedb = new Course()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName
            };
            return DataAccessFactory.CourseDataAccess().Add(coursedb);
        }
        public static bool Update(CourseDTO Course)
        {
            var coursedb = DataAccessFactory.CourseDataAccess().Get(Course.CourseId);
            coursedb.CourseName = Course.CourseName;

            return DataAccessFactory.CourseDataAccess().Update(coursedb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CourseDataAccess().Remove(id);
        }

        public static int total()
        {
            var courses = new List<CourseDTO>();
            int total = 0;
            var coursedb = DataAccessFactory.CourseDataAccess().GetAll();
            foreach (var course in coursedb)
            {
                total++;

            }
            return total;
        }
    }
}
