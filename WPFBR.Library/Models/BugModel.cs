using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBR.Library.Models
{
    public class BugModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int FrequencyId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
