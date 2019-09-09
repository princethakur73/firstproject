using System.Web;
using WebApplication.Infrastructure.Tasks;

namespace WebApplication.Infrastructure
{
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {

        }

        void IRunOnError.Execute()
        {
            _httpContext.Items["_Error"] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            //var transaction = (DbTransaction)_httpContext.Items["_Transaction"];
            //if (_httpContext.Items["_Error"] != null)
            //{
            //    transaction.Rollback();
            //}
            //else
            //{
            //    transaction.Commit();
            //}
        }
    }
}