using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class SensorEventLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }
        public string SensorId { get; set; }
        public string SourceAddress { get; set; }
        public int SourcePort { get; set; }
        public string DestinationAddress { get; set; }
        public int DestinationPort { get; set; }
        public string TimeVal { get; set; }
        public string Payload { get; set; }
        public DateTime Created{get; set; }
        public string Comment { get; set; }
    
    }
}