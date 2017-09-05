using ETOS.Core.Services.Abstract;
using System;
using System.Collections.Generic;
using ETOS.Core.DTO;
using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;
using System.Linq;
using ETOS.Common;

namespace ETOS.Core.Services
{
    public class LogService : ILogService
    {

        private ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public bool AddLog(DtoLog item, out string errorMsg)
        {
            errorMsg = "";
            if (item != null)
            {
                var logItem = new Log()
                {
                    CreatorFirstName = item.CreatorFirstName,
                    CreatorLastName = item.CreatorLastName,
                    BrowserName = item.BrowserName,
                    IpAddress = item.IpAddress,
                    RequestMile = item.RequestMile,
                    RequestPrice = item.RequestPrice,
                    CreationDateTime = DateTime.Now
                };

                try
                {
                    _logRepository.Add(logItem);

                    return true;
                }
                catch (Exception)
                {
                    errorMsg = "Ошибка добавления логов";
                    return false;
                }
            }
            return false;
        }

        public void DeleteLog(DtoLog item)
        {
            _logRepository.Delete(item.Id);
        }

        public IEnumerable<DtoLog> GetAllByFilter(LogFilter filter)
        {
            var logList = _logRepository.GetLogsByFilter(filter);

            var outList = logList.Select(l => new DtoLog
            {
                Id = l.Id,
                CreatorFirstName = l.CreatorFirstName,
                CreatorLastName = l.CreatorLastName,
                BrowserName = l.BrowserName,
                IpAddress = l.IpAddress,
                RequestMile = l.RequestMile,
                RequestPrice = l.RequestPrice,
                CreationDataTime = l.CreationDateTime                
            });

            return outList;
        }
    }
}
