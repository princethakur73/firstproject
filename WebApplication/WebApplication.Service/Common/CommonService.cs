using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Common;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class CommonService : ICommonService
    {
        private CommonRepository commonRepository;

        public CommonService()
        {
            commonRepository = new CommonRepository();
        }

        public List<Session> GetGellerySessionList()
        {
            List<Session> list = new List<Session>();

            try
            {
                list = commonRepository.GetGallerySessionList();
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return list;
        }

        public List<Session> GetSessionList()
        {
            List<Session> list = new List<Session>();

            try
            {
                list = commonRepository.GetSessionList();
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return list;
        }

        public List<UserMenu> GetUserMenuByUserId(int userId)
        {
            List<UserMenu> list = new List<UserMenu>();

            try
            {
                list = commonRepository.GetUserMenuByUserId(userId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return list;
        }

        public Session GetSessionByName(string sessionName)
        {
            Session data = new Session();

            try
            {
                data = commonRepository.GetSessionByName(sessionName);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return data;
        }
    }
}
