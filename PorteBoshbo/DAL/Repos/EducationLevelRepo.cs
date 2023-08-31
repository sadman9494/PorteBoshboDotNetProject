using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EducationLevelRepo : IRepo<EducationLevel>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(EducationLevel obj)
        {
            db.EducationLevels.Add(obj);
            return db.SaveChanges() > 0;
        }

        public EducationLevel Get(int id)
        {
            return db.EducationLevels.Find(id);
        }

        public List<EducationLevel> GetAll()
        {
            return db.EducationLevels.ToList();
        }

        public bool Remove(int id)
        {
            db.EducationLevels.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(EducationLevel obj)
        {
            db.Entry(Get(obj.EducationLevelId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
