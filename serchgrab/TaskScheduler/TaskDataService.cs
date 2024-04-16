using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class TaskDataService:BaseService
    {
        public TaskData ConvertToObject(DataRow row)
        {
            TaskData oTaskData = new TaskData();
            try
            {
               oTaskData.UId = (Convert.IsDBNull(row["UId"]) ? 0 : int.Parse(row["UId"].ToString()));
               oTaskData.MethodActionUId = (Convert.IsDBNull(row["MethodActionUId"]) ? 0 : int.Parse(row["MethodActionUId"].ToString()));
               oTaskData.Code = (Convert.IsDBNull(row["Code"]) ? 0 : int.Parse(row["Code"].ToString()));
               oTaskData.EffectiveDate = (Convert.IsDBNull(row["EffectiveDate"]) ? DateTime.MinValue : DateTime.Parse(row["EffectiveDate"].ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oTaskData;
        }
        public TaskData SelectJobField(DateTime FromDate,DateTime ToDate)
        {
            TaskData oTaskData = new TaskData();
            string sqlQuery;
            DataTable dt = new DataTable();
            try
            {
                sqlQuery = " SELECT * FROM [JobField] WHERE 1 = 1 ";
                
                dt = Select(sqlQuery);
                foreach (DataRow row in dt.Rows)
                {
                    oTaskData = ConvertToObject(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oTaskData;
        }
    }
}
