
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data
{
    public class DataContext: DbContext
    {
        public DataContext(){}
        public DataContext(DbContextOptions options):base(options) {
        }
        public DbSet<Alert> Alerts {get; set;}
        public DbSet<Rule> Rules {get; set;}
        public DbSet<SensorEventLog> SensorEventLogs {get; set;}
        public DbSet<SensorHeartBeatLog> SensorHeartBeatLogs {get; set;}
        public DbSet<AlertLog> AlertLogs { get; set; }
    }    
}
