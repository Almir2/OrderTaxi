using ETOS.DAL.Interfaces;
using System;
using System.Data.Entity.ModelConfiguration;

namespace ETOS.DAL.Entities
{
    public class Log : IEntity
    {
        public int Id { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }

        public string BrowserName { get; set; }

        public string IpAddress { get; set; }

        public decimal? RequestPrice { get; set; }

        public double? RequestMile { get; set; }

        public DateTime CreationDateTime { get; set; }
    }

    internal class LogEntityTypeConfiguration : EntityTypeConfiguration<Log>
    {
        public LogEntityTypeConfiguration()
        {
            ToTable("Logs");

            HasKey(l => l.Id);
        }
    }
}
