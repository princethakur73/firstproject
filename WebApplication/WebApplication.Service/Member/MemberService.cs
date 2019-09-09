using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class MemberService : IMemberService
    {
        private MemberRepository MemberRepository;
        public MemberService()
        {
            MemberRepository = new MemberRepository();
        }

        public bool DeleteById(Member obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = MemberRepository.DeleteById(obj.Id);
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
                result = MemberRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(Member obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Member GetById(Member obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Member GetById(int Id, long currentUserId)
        {
            Member obj = new Member();
            try
            {
                obj = MemberRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<Member> GetByIdAsync(Member obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Member> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<Member> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Member> list = new List<Member>();
            try
            {
                list = MemberRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Member> GetList(long currentUserId)
        {
            List<Member> list = new List<Member>();

            try
            {
                list = MemberRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<Member>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = MemberRepository.GetListCount(pageNo, pageSize);
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
                result = MemberRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(Member obj)
        {
            int result = 0;
            try
            {
                result = MemberRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<Member> SaveAsync(Member obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
