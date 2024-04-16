using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class DataAccess:BaseService
    {

        public TaskData SelectTaskData(DateTime FromDate,DateTime ToDate)
        {
            string sqlQuery;
            DataTable dt = new DataTable();
            TaskData oTaskData = new TaskData();
            try
            {

                sqlQuery = " SELECT Top 1 T.*,M.Code FROM [TaskData] AS T,MethodAction AS M WHERE T.Active='TRUE' AND T.MethodActionUId=M.Code AND T.EffectiveDate Between '" + FromDate + "' AND '" + ToDate + "'";
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
        public TaskData ConvertToObject(DataRow row)
        {
            TaskData TaskData = new TaskData();
            try
            {
                TaskData.UId = (Convert.IsDBNull(row["UId"]) ? 0 : int.Parse(row["UId"].ToString()));
                TaskData.Code = (Convert.IsDBNull(row["Code"]) ? 0 : int.Parse(row["Code"].ToString()));
                TaskData.EffectiveDate = (Convert.IsDBNull(row["EffectiveDate"]) ? DateTime.MinValue : DateTime.Parse(row["EffectiveDate"].ToString()));
                TaskData.MethodActionUId = (Convert.IsDBNull(row["MethodActionUId"]) ? 0 : int.Parse(row["MethodActionUId"].ToString()));
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TaskData;
        } 
    }
}
