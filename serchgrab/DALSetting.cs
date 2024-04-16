using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler;

namespace serchgrab
{
    public class DALSetting:BaseService
    {
        public bool GetLiveStatus()
        {
            bool status = false;
            try
            {
                string sql = "Select IsLive from SiteSetting Where UId='1'";
                DataTable dt = SelectSakurai(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    status = bool.Parse(dr["IsLive"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
        public bool UpdateLiveStatus(bool state)
        {
            bool status = false;
            try
            {
                string sql = "Update SiteSetting Set IsLive='"+ state + "'  UId='1'";
                status = UpdateSakurai(sql);
                
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
    } 
}
