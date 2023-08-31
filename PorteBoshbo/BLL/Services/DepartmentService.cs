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
    public static class DepartmentService
    {
        public static List<DepartmentDTO> Get()
        {
            var departments = new List<DepartmentDTO>();
            var departmentdb = DataAccessFactory.DepartmentDataAccess().GetAll();
            foreach (var Department in departmentdb)
            {
                departments.Add(new DepartmentDTO()
                {
                    DepartmentId = Department.DepartmentId,
                    DepartmentName = Department.DepartmentName
                });
            }
            return departments;
        }
        public static DepartmentDTO Get(int id)
        {
            var departmentdb = DataAccessFactory.DepartmentDataAccess().Get(id);
            var department = new DepartmentDTO()
            {
                DepartmentId = departmentdb.DepartmentId,
                DepartmentName = departmentdb.DepartmentName
            };
            return department;
        }
        public static bool Add(DepartmentDTO department)
        {
            var Departmentdb = new Department()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
            return DataAccessFactory.DepartmentDataAccess().Add(Departmentdb);
        }
        public static bool Update(DepartmentDTO Department)
        {
            var departmentdb = DataAccessFactory.DepartmentDataAccess().Get(Department.DepartmentId);
            departmentdb.DepartmentName = Department.DepartmentName;

            return DataAccessFactory.DepartmentDataAccess().Update(departmentdb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.DepartmentDataAccess().Remove(id);
        }

        public static int total()
        {
            var departments = new List<DepartmentDTO>();
            int total = 0;
            var departmentdb = DataAccessFactory.DepartmentDataAccess().GetAll();
            foreach (var Department in departmentdb)
            {
                total++;
            }
            return total;
        }

    }
}
