using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBR.Library.DataAccess
{
    public class StatusData
    {
        public List<StatusModel> GetStatusList()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var list = sql.LoadData<StatusModel, dynamic>("dbo.spStatus_GetAll", new { }, "BRData");

            return list;
        }

        public void UpdateStatus(int bugId, int newStatusId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spBug_StatusUpdate", new { bugId, newStatusId }, "BRData");
        }
    }
}
