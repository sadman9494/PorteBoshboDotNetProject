using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DepartmentRepo : IRepo<Department>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Department obj)
        {
            db.Departments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public bool Remove(int id)
        {
            db.Departments.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Department obj)
        {
            db.Entry(Get(obj.DepartmentId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
