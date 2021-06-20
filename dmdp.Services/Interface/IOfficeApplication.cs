using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dmdp.Services.Interface
{
   
    /// <summary>
    /// used to extend export,refresh and delete with multiple office applications
    /// </summary>
   public interface IOfficeApplication
    {
        string identifier { get; set; }
        Task<string> ExportData(int chartid);
        Task<string> RefreshData(int chartid);
        Task<string> DeleteShape(int shapeid);

    }

    

}
