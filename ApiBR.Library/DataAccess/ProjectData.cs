using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBR.Library.DataAccess
{
    public class ProjectData
    {
        public List<ProjectModel> LoadProjects()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProjectModel, dynamic>("dbo.spProject_GetAll", new { }, "BRData");

            return output;
        }

        public void SaveProject(ProjectModel project)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spProject_Insert", project, "BRData");
        }

        public void UpdateProject(ProjectModel project)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spProject_Update", project, "BRData");
        }

        public void DeleteProject(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spProject_Delete", new { Id }, "BRData");
        }
    }
}
