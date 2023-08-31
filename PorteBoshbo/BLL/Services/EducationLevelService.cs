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
    public static class EducationLevelService
    {
        public static List<EducationLevelDTO> Get()
        {
            var educationLevels = new List<EducationLevelDTO>();
            var educationLeveldb = DataAccessFactory.EducationLevelDataAccess().GetAll();
            foreach (var educationLevel in educationLeveldb)
            {
                educationLevels.Add(new EducationLevelDTO()
                {
                    EducationLevelId = educationLevel.EducationLevelId,
                    EducationLevelName = educationLevel.EducationLevelName
                });
            }
            return educationLevels;
        }
        public static EducationLevelDTO Get(int id)
        {
            var educationLeveldb = DataAccessFactory.EducationLevelDataAccess().Get(id);
            var educationLevel = new EducationLevelDTO()
            {
                EducationLevelId = educationLeveldb.EducationLevelId,
                EducationLevelName = educationLeveldb.EducationLevelName
            };
            return educationLevel;
        }
        public static bool Add(EducationLevelDTO educationLevel)
        {
            var educationLeveldb = new EducationLevel()
            {
                EducationLevelId = educationLevel.EducationLevelId,
                EducationLevelName = educationLevel.EducationLevelName
            };
            return DataAccessFactory.EducationLevelDataAccess().Add(educationLeveldb);
        }
        public static bool Update(EducationLevelDTO educationLevel)
        {
            var educationLeveldb = DataAccessFactory.EducationLevelDataAccess().Get(educationLevel.EducationLevelId);
            educationLeveldb.EducationLevelName = educationLevel.EducationLevelName;

            return DataAccessFactory.EducationLevelDataAccess().Update(educationLeveldb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.EducationLevelDataAccess().Remove(id);
        }
    }
}
