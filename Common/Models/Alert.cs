using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class Alert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlertId { get; set; }
        public Guid DatasourceId { get; set; }
        public string SourceIp { get; set; }
        public int SourcePort { get; set; }
        public string DestinationIp { get; set; }
        public int DestinationPort { get; set; }
        public string Payload { get; set; }  
        public DateTime Captured { get; set; } 
        public DateTime Created { get; set; }
        public int RuleId { get; set; }

        [ForeignKey("RuleId")]
        public Rule Rule { get; set; }
    }
    
}