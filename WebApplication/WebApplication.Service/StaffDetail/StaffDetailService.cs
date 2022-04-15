using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Core.Model;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class StaffDetailService : IStaffDetailService
    {
        private StaffDetailRepository staffDetailRepository;
        public StaffDetailService()
        {
            staffDetailRepository = new StaffDetailRepository();
        }

        public bool DeleteById(StaffDetail obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = staffDetailRepository.DeleteById(obj.Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public bool DeleteById(int Id, long currentUserId)
        {
            bool result = false;
            try
            {
                result = staffDetailRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(StaffDetail obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public StaffDetail GetById(StaffDetail obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public StaffDetail GetById(int Id, long currentUserId)
        {
            StaffDetail obj = new StaffDetail();
            try
            {
                obj = staffDetailRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<StaffDetail> GetByIdAsync(StaffDetail obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<StaffDetail> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<StaffDetail> GetList(string staffName="",int pageNo = 1, int pageSize = 10)
        {
            List<StaffDetail> list = new List<StaffDetail>();
            try
            {
                list = staffDetailRepository.GetList(staffName,pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<StaffDetail> GetList(long currentUserId)
        {
            List<StaffDetail> list = new List<StaffDetail>();

            try
            {
                list = staffDetailRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<StaffDetail>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(string staffName="", int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = staffDetailRepository.GetListCount(staffName,pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return count;
        }

        public bool IsNameExist(string name, int id)
        {
            bool result = false;
            try
            {
                result = staffDetailRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(StaffDetail obj)
        {
            int result = 0;
            try
            {
                result = staffDetailRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<StaffDetail> SaveAsync(StaffDetail obj)
        {
            throw new System.NotImplementedException();
        }
        public List<DepartmentStaffModel> GetStaffList()
        {
            List<StaffModel> dblist = new List<StaffModel>();
            List<DepartmentStaffModel> departmentStaffModels = new List<DepartmentStaffModel>();
            try
             {   
                dblist = staffDetailRepository.GetStaffList();
                foreach (var item in dblist)
                {
                    if (departmentStaffModels.Exists(a=>a.Department==item.Department))
                    {
                        departmentStaffModels.Find(a => a.Department == item.Department).Staff.Add(item);
                    }
                    else
                    {
                        DepartmentStaffModel departmentStaffModel = new DepartmentStaffModel();
                        departmentStaffModel.Staff = new List<StaffModel>();
                        departmentStaffModel.Department = item.Department;
                        departmentStaffModel.SortId = item.DSortId;
                        departmentStaffModel.Staff.Add(item);
                        departmentStaffModels.Add(departmentStaffModel);
                    }
                }
                
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return departmentStaffModels.OrderBy(a=>a.SortId).ToList();
        }
    }
}
