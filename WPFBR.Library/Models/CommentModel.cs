using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBR.Library.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int BugId { get; set; }
        public string Content { get; set; }
    }
}
