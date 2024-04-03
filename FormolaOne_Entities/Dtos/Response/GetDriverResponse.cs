using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Response
{
    public class GetDriverResponse
    {
        public Guid DriveId { get; set; }

        public string FullName { get; set; }
        public int DriverName { get; set; }



    }
}
