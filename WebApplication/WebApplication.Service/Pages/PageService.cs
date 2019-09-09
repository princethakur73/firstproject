using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication.Core.Common;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class PageService : IPageService
    {
        private PageRepository pageRepository;

        public PageService()
        {
            pageRepository = new PageRepository();
        }

        public bool DeleteById(Page obj, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int Id, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(Page obj, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Page GetById(Page obj, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Page GetById(int Id, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Page> GetByIdAsync(Page obj, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Page> GetByIdAsync(int Id, long currentUserId)
        {
            throw new NotImplementedException();
        }

        public List<Page> GetList(long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Page>> GetListAsync(long currentUserId)
        {
            throw new NotImplementedException();
        }

        public Page GetPageByMenuCode(string menuCode)
        {
            Page page = new Page();
            try
            {
                page = pageRepository.GetPageByMenuCode(menuCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return page;
        }

        public int Save(Page obj)
        {
            int result = 0;
            try
            {
                result = pageRepository.Save(obj);
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            return result;
        }

        public Task<Page> SaveAsync(Page obj)
        {
            throw new NotImplementedException();
        }
    }
}
