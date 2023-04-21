using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Core;
using WebApplication.Core.Helper;
using WebApplication.Core.Model;
using WebApplication.Repository;
namespace WebApplication.Service
{
    public class AdmissionService : IAdmissionService
    {
        private AdmissionRepository AdmissionRepository;
        public AdmissionService()
        {
            AdmissionRepository = new AdmissionRepository();
        }
         
        public bool DeleteById(StudentAdmission obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = AdmissionRepository.DeleteById(obj.Id);
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
                result = AdmissionRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }
        public Task<bool> DeleteByIdAsync(StudentAdmission obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }
        public StudentAdmission GetById(StudentAdmission obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }
        public StudentAdmission GetById(int Id, long currentUserId)
        {
            StudentAdmission obj = new StudentAdmission();
            try
            {
                obj = AdmissionRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return obj;
        }
        public Task<StudentAdmission> GetByIdAsync(StudentAdmission obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }
        public Task<StudentAdmission> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }
        public List<StudentAdmission> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<StudentAdmission> list = new List<StudentAdmission>();
            try
            {
                list = AdmissionRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return list;
        }
        public List<StudentAdmission> GetList(long currentUserId)
        {
            List<StudentAdmission> list = new List<StudentAdmission>();
            try
            {
                list = AdmissionRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return list;
        }
        public Task<IEnumerable<StudentAdmission>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }
        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = AdmissionRepository.GetListCount(pageNo, pageSize);
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
                result = AdmissionRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }
        public int Save(StudentAdmission obj)
        {
            int result = 0;
            try
            {
                result = AdmissionRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }
        public Task<StudentAdmission> SaveAsync(StudentAdmission obj)
        {
            throw new System.NotImplementedException();
        }

        public bool SubmitRecruitmentForm(RecruitmentModel model)
        {
            bool status = false;
            try
            {
                #region Candidate information
                string mailText = string.Empty;
                HttpPostedFileBase file = model.RecruitmentFile;
                using (var sr = new StreamReader(model.RecruitmentTemplatePath))
                {
                    mailText = sr.ReadToEnd();
                    mailText = mailText.Replace("[Name]", model.FullName.Trim());
                    mailText = mailText.Replace("[Gender]", model.Gender.Trim());
                    mailText = mailText.Replace("[DOB]", model.DOB.Trim());
                    mailText = mailText.Replace("[Address]", model.Address.Trim());
                    mailText = mailText.Replace("[Contact]", model.Contact.Trim());
                    mailText = mailText.Replace("[Email]", model.Email.Trim());
                    mailText = mailText.Replace("[ApplyFor]", model.ApplyFor.Trim());
                }
                MailMessage _mailmsg = new MailMessage
                {
                    //Make TRUE because our body text is html  
                    IsBodyHtml = true,

                    //Set From Email ID  
                    From = new MailAddress(AppSetting.From),

                    //Set Subject  
                    Subject = "Candidate Detail",

                    //Set Body Text of Email   
                    Body = mailText
                };

                //Set To Email ID  
                _mailmsg.To.Add(AppSetting.SchoolEmail);

                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    _mailmsg.Attachments.Add(new Attachment(file.InputStream, fileName));
                }
                EmailHelper.Send(_mailmsg);
                #endregion

                #region Send Confirmation to Candidate
                mailText = string.Empty;
                using (var sr = new StreamReader(model.ConfirmationTemplatePath))
                {
                    mailText = sr.ReadToEnd();
                    mailText = mailText.Replace("[CustomerName]", model.FullName.Trim());
                }

                _mailmsg = new MailMessage
                {
                    //Make TRUE because our body text is html  
                    IsBodyHtml = true,

                    //Set From Email ID  
                    From = new MailAddress(AppSetting.From),

                    //Set Subject  
                    Subject = "HVM Confirmation",

                    //Set Body Text of Email   
                    Body = mailText
                };

                //Set To Email ID  
                _mailmsg.To.Add(model.Email);

                EmailHelper.Send(_mailmsg);
                #endregion
                return status;
            }
            catch (System.Exception)
            {
                return status;
            }
        }
    }
}
