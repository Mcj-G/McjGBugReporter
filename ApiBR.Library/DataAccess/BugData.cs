using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBR.Library.DataAccess
{
    public class BugData
    {
        public List<BugDisplayModel> LoadBugs()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<BugDisplayModel, dynamic>("dbo.spBug_GetAll", new { }, "BRData");

            return output;
        }

        public void SaveBug(BugModel bug)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spBug_Insert", bug, "BRData");
        }

        public void UpdateAssignedUser(List<string> idList)
        {
            int bugId = int.Parse(idList[0]);
            string userId = idList[1];
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spBug_AssignedUserUpdate", new { bugId, userId }, "BRData");
        }
    }
}
