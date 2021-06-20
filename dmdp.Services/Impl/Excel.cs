using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dmdp.Services.Interface;

namespace dmdp.Services.Impl
{
   public class Excel : IOfficeApplication
    {
        public string identifier { get; set; }
        public Excel()
        {
            identifier = nameof(Excel);   // LSP
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
    }
}
