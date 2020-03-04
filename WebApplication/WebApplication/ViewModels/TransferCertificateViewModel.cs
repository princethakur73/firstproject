using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class TransferCertificateViewModel
    {
        public List<TransferCertificateModel> TransferCertificateModels { get; set; }

        public Pager Pager { get; set; }
    }
}