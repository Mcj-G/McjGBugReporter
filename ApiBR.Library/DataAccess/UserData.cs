using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBR.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUser_GetById", new { Id }, "BRData");

            return output;
        }
    }
}
