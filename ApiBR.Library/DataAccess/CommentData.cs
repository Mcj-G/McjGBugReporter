using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBR.Library.DataAccess
{
    public class CommentData
    {
        public void SaveComment(CommentModel comment)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spComment_Insert", comment, "BRData");
        }

        public List<CommentModel> LoadComments(int bugId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<CommentModel, dynamic>("dbo.spComment_GetById", new { bugId }, "BRData");

            return output;
        }
    }
}
