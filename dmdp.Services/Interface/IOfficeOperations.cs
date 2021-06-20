using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dmdp.Services.Interface
{
    interface IOfficeOperations
    {
        Task<string> ExportRefreshData(int chartid);
    }
}
