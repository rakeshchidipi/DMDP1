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

    // monolith problems
    // exiting solution -- open existing class with more code
    // interface segration
    // architeture -- design pattrens -- singleton, dynamic injection
    // Solid priciples ***
    // exception handling
    // DRY , KISS ,
    // using block -- object lifecycle
    // openclose -- extending object -- class initialise and modify
    // unit test
    // add UI layer

}
