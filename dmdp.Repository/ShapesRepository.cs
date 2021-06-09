using System;
using System.Collections.Generic;
using System.Text;

namespace dmdp.Repository
{
    class ShapesRepository
    {
        public ShapesRepository()
        {

        }
        /// <summary>
        /// Fetches data from Data store based on scope and object will be detroyed once job is done
        /// </summary>
        /// <returns></returns>
        public string GetData() {
            string data = string.Empty;

            //using (var scope = _serviceSope.CreateScope()) {
            //    var _context = scope.GetRequiredService();
            //    return _context.GetData();
            //}

            return data;
        }
    }
}
