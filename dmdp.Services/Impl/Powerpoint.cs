using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dmdp.Services.Interface;

namespace dmdp.Services.Impl
{
   public class Powerpoint : IOfficeApplication
    {
        public string identifier { get; set; }
        public Powerpoint()
        {
            identifier = nameof(Powerpoint);
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
