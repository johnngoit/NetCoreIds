using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class SensorHeartBeatLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }
        public string SensorId { get; set; }
        public DateTime Created { get; set; }
        public string Filter { get; set; }
    }
    
}