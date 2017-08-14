using RTS.Weds.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Interface
{
   public interface IFamilyDetailsRepository
    {
        FamilyDetails insertFamilyDetails(FamilyDetails item);
    }
}
