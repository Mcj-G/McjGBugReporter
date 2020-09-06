using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBR.Library.Models
{
    public class BugDisplayModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectVersion { get; set; }
        public string CategoryName { get; set; }
        public string PriorityName { get; set; }
        public string StatusName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string FrequencyName { get; set; }
        public string AssignedUserMail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModificationDate { get; set; }
    }
}
