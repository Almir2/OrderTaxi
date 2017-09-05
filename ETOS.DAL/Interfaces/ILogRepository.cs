using ETOS.Common;
using ETOS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.DAL.Interfaces
{
    public interface ILogRepository : IRepository<Log>
    {
        IEnumerable<Log> GetLogsByFilter(LogFilter filter);
    }
}
