using ETOS.Common;
using ETOS.Core.DTO;
using ETOS.DAL.Entities;
using System.Collections.Generic;

namespace ETOS.Core.Services.Abstract
{
    public interface ILogService
    {
        IEnumerable<DtoLog> GetAllByFilter(LogFilter filter);

        bool AddLog(DtoLog item, out string errorMsg);

        void DeleteLog(DtoLog item);
    }
}
