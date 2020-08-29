using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBR.Library.DataAccess
{
    public class ListsData
    {
        public ListsModel GetLists()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var categoryList = sql.LoadData<CategoryModel, dynamic>("dbo.spCategory_GetAll", new { }, "BRData");
            var frequencyList = sql.LoadData<FrequencyModel, dynamic>("dbo.spFrequency_GetAll", new { }, "BRData");
            var priorityList = sql.LoadData<PriorityModel, dynamic>("dbo.spPriority_GetAll", new { }, "BRData");
            var projectList = sql.LoadData<ProjectModel, dynamic>("dbo.spProject_GetAll", new { }, "BRData");

            ListsModel output = new ListsModel
            {
                CategoryList = categoryList,
                FrequencyList = frequencyList,
                PriorityList = priorityList,
                ProjectList = projectList
            };

            return output;
        }
    }
}
