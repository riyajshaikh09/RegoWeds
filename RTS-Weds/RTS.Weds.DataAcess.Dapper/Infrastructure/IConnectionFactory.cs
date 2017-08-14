using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace RTS.Weds.DataAcess.Dapper.Infrastructure
{
   public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; set; }

    }
}
