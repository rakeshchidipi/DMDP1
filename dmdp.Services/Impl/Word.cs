using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dmdp.Services.Interface;
using Microsoft.Extensions.Logging;
using dmdp.common;
using Microsoft.AspNetCore.Mvc;


namespace dmdp.Services.Impl
{
    [ServiceFilter(typeof(ErrorHandlingFilter))]
    public class Word : IOfficeApplication,IOfficeOperations
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

        public async Task<string> RefreshData(int chartid)
        {
            string response = string.Empty;
            try
            {
                // Logic of fresh
                response = await Task.FromResult("Success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error_GatData");
                response = "failure";
            }
            return response;
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

        public Task<string> ReplaceShape(int chartid)
        {
            throw new NotImplementedException();
        }
    }
}
