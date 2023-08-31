using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : IRepo<Course>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public bool Remove(int id)
        {
            db.Courses.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Course obj)
        {
            db.Entry(Get(obj.CourseId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
