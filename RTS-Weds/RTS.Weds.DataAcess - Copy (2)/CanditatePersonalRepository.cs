using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess
{
    public interface ICanditatePersonalRepository : IGenericDataRepository<Canditate_Personal>
    {
    }

    
    public class CanditatePersonalRepository : GenericDataRepository<Canditate_Personal>, ICanditatePersonalRepository
    {
    }

   
}
