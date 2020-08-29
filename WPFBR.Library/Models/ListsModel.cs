using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBR.Library.Models
{
    public class ListsModel
    {
        public List<CategoryModel> CategoryList { get; set; }
        public List<FrequencyModel> FrequencyList { get; set; }
        public List<PriorityModel> PriorityList { get; set; }
        public List<ProjectModel> ProjectList { get; set; }
    }
}
