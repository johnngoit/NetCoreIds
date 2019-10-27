using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class AlertLog
    {
        //dbo.AlertLog (AnalyserId, IdmefMessage, Created)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlertId { get; set; }
        public string AnalyserId { get; set; }
        public string IdmefMessage { get; set; }
        public DateTime Created { get; set; }
    }
}