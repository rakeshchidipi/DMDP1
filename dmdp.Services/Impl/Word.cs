using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dmdp.Services.Interface;
using Microsoft.Extensions.Logging;

namespace dmdp.Services.Impl
{
   public class Word : IOfficeApplication
    {
        public string identifier { get; set; }
        ILogger<Word> _logger;
        public Word(ILogger<Word> logger)
        {
            identifier = nameof(Word);
        }
        public Task<string> DeleteShape(int shapeid)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExportData(int chartid)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshData(int chartid)
        {
            throw new NotImplementedException();
        }

        private string GetData(int shapeid) {
            string response=string.Empty;
            try
            {
               // Repository.GetData();   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error_GatData");
                throw;
            }
            return response;
        
        }
    }
}
