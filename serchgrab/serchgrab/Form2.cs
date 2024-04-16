using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Permissions;

namespace serchgrab
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        public WebBrowser Browser
        {

            get { return webBrowser1;

            }
        }
        public static string uril;
        public static string sts;
        public static decimal starp;
        public static decimal buynp;
        public static bool istru;
        public static string modelyr;
        public static string loc;
        public static int issolds;
        string ftpip = ConfigurationManager.AppSettings["ftpip"];
        string ftpun = ConfigurationManager.AppSettings["ftpun"];
        string ftppw = ConfigurationManager.AppSettings["ftppw"];
        string constr = ConfigurationManager.AppSettings["constr"];
        SqlConnection oSqlConnection;
        SqlCommand oSqlCommand;
        SqlDataAdapter oSqlDataAdapter;
        public string sqlQuery;
        //public static webBrowser1. wb;
        private void Form2_Load(object sender, EventArgs e)
        {
            istru = false;
            this.Activated += AfterLoading;

        }
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //  webBrowser1.Navigate(uril);
            HtmlDocument doc1 = webBrowser1.Document;


            while (true)
            {
                HtmlElement elem6 = doc1.GetElementById("btPlaceBid");
                // wait asynchronously, this will throw if cancellation requested


                // continue polling if the WebBrowser is still busy


                if (this.webBrowser1.IsBusy || elem6 == null)
                    continue;


                if (elem6 != null)
                    break; // no changes detected, end the poll loop


            }


            istru = false;
            this.Dispose();
        }
        SHDocVw.WebBrowser nativeBrowser;
        private int tuid;
        private bool exists;
        private string pyh;
        private string catid;

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    nativeBrowser = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
        //    nativeBrowser.NewWindow2 += nativeBrowser_NewWindow2;
        //    nativeBrowser.DocumentComplete += nativeBrowser_DocumentComplete;
        //    nativeBrowser.WebWorkerStarted += nativeBrowser_ReadyState;
        //}

        private async void nativeBrowser_ReadyState(uint dwUniqueID, string bstrWorkerLabel)
        {
           // await c1();
        }


      
        public async Task c1()
        {
            try
            {
                
                oSqlConnection = new SqlConnection(constr);

             


                while (true)
                {
                    
                        HtmlDocument doc1 = webBrowser1.Document;
                        HtmlElement elem6 = doc1.GetElementById("gazou");
                        HtmlElementCollection tables1 = elem6.GetElementsByTagName("img");
                        int sdfgh = tables1.Count;
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(1000);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null && tables1.Count > 2)
                            break; // no changes detected, end the poll loop

                       
                   
                }

                
                    HtmlDocument doc2 = webBrowser1.Document;
                    HtmlElement elem5 = doc2.GetElementById("gazou");
                    HtmlElement elemt6 = doc2.GetElementById("syamei");
                    HtmlElement elemt7 = doc2.GetElementById("sp0500");

                    string noHTMLNormalised = stParse(elemt7.InnerText);
                    // HtmlElement elemt8 = doc2.GetElementById("start");

                    HtmlElement elemt8 = doc2.GetElementById("st_kakaku");
                    string noHTMLNormalised14 = stParse(elemt8.InnerText);
                    string numberOnly = Regex.Replace(noHTMLNormalised14, "[^0-9.]", "");
                    Decimal starp = Convert.ToDecimal(numberOnly);
                    HtmlElement elemt9 = doc2.GetElementById("sp0800");

                    string noHTMLNormalised1 = stParse(elemt9.InnerText);
                    Decimal milage = Parse(noHTMLNormalised1);
                    HtmlElement elemt10 = doc2.GetElementById("sp4000");

                    string noHTMLNormalised2 = stParse(elemt10.InnerText);
                    int modely = intParse(noHTMLNormalised2);
                    HtmlElement elemt11 = doc2.GetElementById("sp0600");

                    string noHTMLNormalised3 = stParse(elemt11.InnerText);
                    HtmlElement elemt12 = doc2.GetElementById("sno");
                    HtmlElement elemt13 = doc2.GetElementById("simekiri");
                    HtmlElement elemt14 = doc2.GetElementById("seriyoso");
                    HtmlElement elemt15 = doc2.GetElementById("kaijo_name");
                    HtmlElement elemt16 = doc2.GetElementById("kaisaibi");
                    HtmlElement elemt17 = doc2.GetElementById("kaisu");
                HtmlElement elemt18 = null;
                HtmlElement elemt19 = null;
                string current = "";
                string currenthaba = "";
                try
                {
                     elemt18 = doc2.GetElementById("current");
                     elemt19 = doc2.GetElementById("currenthaba");
                    current = elemt18.InnerText;
                    currenthaba = elemt19.InnerText;
                }
                catch (Exception ex)
                {

                }
                HtmlElement elemt20 = doc2.GetElementById("sp0400");

                    string noHTMLNormalised4 = stParse(elemt20.InnerText);


                    HtmlElement elemt21 = doc2.GetElementById("sp07000");

                    string noHTMLNormalised5 = stParse(elemt21.InnerText);
                    HtmlElement elemt22 = doc2.GetElementById("sp0900");

                    string noHTMLNormalised6 = stParse(elemt22.InnerText);
                    HtmlElement elemt23 = doc2.GetElementById("sp3000");

                    string noHTMLNormalised7 = stParse(elemt23.InnerText);
                    HtmlElement elemt24 = doc2.GetElementById("sp1000");

                    string noHTMLNormalised8 = stParse(elemt24.InnerText);
                    HtmlElement elemt25 = doc2.GetElementById("sp3100");

                    string noHTMLNormalised9 = stParse(elemt25.InnerText);
                    HtmlElement elemt26 = doc2.GetElementById("sp3200");

                    string noHTMLNormalised10 = stParse(elemt26.InnerText);
                    HtmlElement elemt27 = doc2.GetElementById("sp1100");

                    string noHTMLNormalised11 = stParse(elemt27.InnerText);

                    HtmlElement elemt28 = doc2.GetElementById("notify");

                    string noHTMLNormalised12 = stParse(elemt28.InnerText);

                    noHTMLNormalised12 = noHTMLNormalised12.Replace("'", "");

                    HtmlElement elemt29 = doc2.GetElementById("teisei_detail");

                    string noHTMLNormalised13 = stParse(elemt29.InnerText);
              


                /////////////////////////////////

                try {
                DataSet odsvoltxndata = new DataSet();
                
                
                oSqlCommand = new SqlCommand();
                sqlQuery = "SELECT  [UId] ,[Category]  FROM [dbo].[ProdCategory] where [ParentUId]!=0 ";
                //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                oSqlCommand.Connection = oSqlConnection;
                oSqlCommand.CommandText = sqlQuery;
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlConnection.Open();
                //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(odsvoltxndata);
               // oSqlConnection.Close();
                for (int i = 0; i < odsvoltxndata.Tables[0].Rows.Count; i++)
                {
                    if (odsvoltxndata.Tables[0].Rows[i]["Category"].ToString().ToLower().Trim()== elemt6.InnerText.ToLower().Trim())
                    {
                        catid = odsvoltxndata.Tables[0].Rows[i]["Uid"].ToString();
                    }




                }
            }
            catch (Exception ex)
            {
                    label1.Text = ex.ToString();

                }
            /////////////////////////////////////////////////////////////////////
            try
                {
                   // oSqlConnection = new SqlConnection(constr);
                oSqlCommand = new SqlCommand();
                sqlQuery = "INSERT INTO [dbo].[ProductInfo] ([IsSold],[BuynowPrice],[CategoryId] ,[Name],[StartingPrice] " +
           ",[Active],[Mileage],[ModelYear],[Model],[EntryNo] ,[cutofftime],[estimatedtime] "+
          " ,[place] ,[biddate]  ,[eventdate]  ,[currentbid]  ,[regno]  ,[DsplVol] ,[color] "+
         "  ,[TrnAC] ,[Eval],[loadage] ,[capacity] ,[Equip],[notify],[corection],[CreatedDate],[Status]) " +
          "  OUTPUT INSERTED.Uid "+
         "   VALUES (" + issolds + "," + buynp + ","+Convert.ToInt32( catid)+",N'"+ noHTMLNormalised + "'," + starp+","+1+","+ milage + ","+ modelyr+",'"+noHTMLNormalised3+"','"+ elemt12.InnerText + "','"+ elemt13.InnerText + "','"+ elemt14.InnerText + "','"+ elemt15.InnerText + "', "+
"'"+elemt16.InnerText+"','"+ elemt17.InnerText + "','" + current + currenthaba + "','"+ noHTMLNormalised4 + "','"+ noHTMLNormalised5 + "','"+ noHTMLNormalised6 + "','"+ noHTMLNormalised7 + "','"+ noHTMLNormalised8 + "','"+ noHTMLNormalised9 + "','"+ noHTMLNormalised10 + "','"+ noHTMLNormalised11 + "','"+ noHTMLNormalised12+"','"+ noHTMLNormalised13 + "',GETDATE(),'"+sts+"') ";
                //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                oSqlCommand.Connection = oSqlConnection;
                oSqlCommand.CommandText = sqlQuery;
                //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
               // oSqlConnection.Open();
                 tuid = (int)oSqlCommand.ExecuteScalar();
               // oSqlConnection.Close();

                }
                catch (Exception ex)
                {
                    label1.Text = ex.ToString();

                }



                ///////////////////////////////////////////////////////////////////
                
                HtmlElementCollection tables = elem5.GetElementsByTagName("img");
                progressBar1.Maximum = tables.Count;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                int iop = 0;
                foreach (HtmlElement TBL in tables)
                {
                    //if (TBL.GetAttribute("src").Contains(".jp/IL"))
                    //{
                   
                    progressBar1.Value = iop;
                    var fileUrl = TBL.GetAttribute("src");
                    string[] asd = fileUrl.Split('/');
                    string[] flp = asd[asd.Length - 1].Replace("?", "").Split('.');
                    var localFile = Properties.Settings.Default.Setting1 + "\\" + tuid + "\\" + flp[0]+".jpg";
                     pyh = Properties.Settings.Default.Setting1 + "\\";

                     exists = System.IO.Directory.Exists(pyh + tuid);
                    try
                    {
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pyh + tuid);
                            //WebRequest ftpRequest = WebRequest.Create(ftpip + tuid);
                            //ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                            //ftpRequest.Credentials = new NetworkCredential(ftpun, ftppw);
                            //FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                        }
                    }
                    catch (Exception ex)
                    {
                        label1.Text = ex.ToString();

                    }

                   var client = new System.Net.WebClient();
                    // Download the image using WebClient:
                    // ebclient.DownloadFile(new Uri("http://mytestwebsite.com/temp/test.html"), @"D:\web\test.html");
                    try
                    {
                        
                        //int index = fileUrl.IndexOf("?");
                        //if (index > 0)
                        //    fileUrl = fileUrl.Substring(0, index);

                        //int index2 = localFile.IndexOf("?");
                        //if (index2 > 0)
                        //    localFile = localFile.Substring(0, index);
                        client.DownloadFile(fileUrl, localFile);



                        //using (WebClient client2 = new WebClient())
                        //{
                        //    client2.Credentials = new NetworkCredential(ftpun, ftppw);

                        //    client2.UploadFile(ftpip + tuid + "/" + asd[asd.Length - 1], WebRequestMethods.Ftp.UploadFile, localFile);


                        //}

                        //////////////////////////////////////////////////////////////
                        try
                        {
                           // oSqlConnection = new SqlConnection(constr);
                            oSqlCommand = new SqlCommand();
                            sqlQuery = "INSERT INTO [dbo].[ProdImage] ([ProductId] ,[ImageName],[Active] )" +
                     "   VALUES (" + tuid + ",'" + tuid + "/" + flp[0] + ".jpg" + "',"+1+") ";
                            //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                            oSqlCommand.Connection = oSqlConnection;
                            oSqlCommand.CommandText = sqlQuery;
                            //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                          //  oSqlConnection.Open();
                            oSqlCommand.ExecuteScalar();
                         //   oSqlConnection.Close();

                        }
                        catch (Exception ex)
                        {
                            label1.Text = ex.ToString();

                        }

                        ////////////////////////////////////////////////////////////



                    }
                    catch (Exception ex)
                    {
                        label1.Text = ex.ToString();

                    }
                    iop++;
                    
                }
                if (exists)
                {
                   // Directory.Delete(pyh + uril, true);
                }
                oSqlConnection.Close();
                istru = true;
                this.Dispose();

            }
            catch (Exception ex)
            {
                oSqlConnection.Close();
                label1.Text = ex.ToString();
            }


        }
        public async Task c2()
        {
            try
            {
                oSqlConnection = new SqlConnection(constr);
                while (true)
                {
                    HtmlDocument doc1 = webBrowser1.Document;
                    HtmlElement elem6 = doc1.GetElementById("gazou");
                    HtmlElementCollection tables1 = elem6.GetElementsByTagName("img");
                    int sdfgh = tables1.Count;
                    // wait asynchronously, this will throw if cancellation requested
                    await Task.Delay(500);

                    // continue polling if the WebBrowser is still busy


                    if (this.webBrowser1.IsBusy || elem6 == null)
                        continue;


                    if (elem6 != null && tables1.Count > 2)
                        break; // no changes detected, end the poll loop


                }


                HtmlDocument doc2 = webBrowser1.Document;
                HtmlElement elem5 = doc2.GetElementById("gazou");
                //HtmlElement elemt6 = doc2.GetElementById("syamei");
                HtmlElement elemt7 = doc2.GetElementById("sp0500");
                string[] newcat = elemt7.InnerText.Split('\r');
                string newcat2 = newcat[0];
                string noHTMLNormalised = stParse(elemt7.InnerText);
                // HtmlElement elemt8 = doc2.GetElementById("start");

                //HtmlElement elemt8 = doc2.GetElementById("st_kakaku");
                //string noHTMLNormalised14 = stParse(elemt8.InnerText);
                //string numberOnly = Regex.Replace(noHTMLNormalised14, "[^0-9.]", "");
                //Decimal starp = Convert.ToDecimal(numberOnly);
                HtmlElement elemt9 = doc2.GetElementById("sp0800");

                string noHTMLNormalised1 = stParse(elemt9.InnerText);
                Decimal milage = Parse(noHTMLNormalised1);
                HtmlElement elemt10 = doc2.GetElementById("sp4000");

                string noHTMLNormalised2 = stParse(elemt10.InnerText);
                int modely = intParse(noHTMLNormalised2);
                HtmlElement elemt11 = doc2.GetElementById("sp0600");

                string noHTMLNormalised3 = stParse(elemt11.InnerText);
                HtmlElement elemt12 = doc2.GetElementById("sp0300");
                //HtmlElement elemt13 = doc2.GetElementById("simekiri");
                //HtmlElement elemt14 = doc2.GetElementById("seriyoso");
                //HtmlElement elemt15 = doc2.GetElementById("kaijo_name");
                //HtmlElement elemt16 = doc2.GetElementById("kaisaibi");
                //HtmlElement elemt17 = doc2.GetElementById("kaisu");
                //HtmlElement elemt18 = doc2.GetElementById("current");
                //HtmlElement elemt19 = doc2.GetElementById("currenthaba");
                HtmlElement elemt20 = doc2.GetElementById("sp0400");

                string noHTMLNormalised4 = stParse(elemt20.InnerText);


                HtmlElement elemt21 = doc2.GetElementById("sp0700");

                string noHTMLNormalised5 = stParse(elemt21.InnerText);
                HtmlElement elemt22 = doc2.GetElementById("sp0900");

                string noHTMLNormalised6 = stParse(elemt22.InnerText);
                HtmlElement elemt23 = doc2.GetElementById("sp3000");

                string noHTMLNormalised7 = stParse(elemt23.InnerText);
                HtmlElement elemt24 = doc2.GetElementById("sp1000");

                string noHTMLNormalised8 = stParse(elemt24.InnerText);
                HtmlElement elemt25 = doc2.GetElementById("sp3100");

                string noHTMLNormalised9 = stParse(elemt25.InnerText);
                HtmlElement elemt26 = doc2.GetElementById("sp3200");

                string noHTMLNormalised10 = stParse(elemt26.InnerText);
                HtmlElement elemt27 = doc2.GetElementById("sp1100");

                string noHTMLNormalised11 = stParse(elemt27.InnerText);

                //HtmlElement elemt28 = doc2.GetElementById("notify");

                //string noHTMLNormalised12 = stParse(elemt28.InnerText);

                //HtmlElement elemt29 = doc2.GetElementById("teisei_detail");

                //string noHTMLNormalised13 = stParse(elemt29.InnerText);



                /////////////////////////////////

                try
                {
                    DataSet odsvoltxndata = new DataSet();


                    oSqlCommand = new SqlCommand();
                    sqlQuery = "SELECT  [UId] ,[Category]  FROM [dbo].[ProdCategory] where [ParentUId]!=0 ";
                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                    oSqlCommand.Connection = oSqlConnection;
                    oSqlCommand.CommandText = sqlQuery;
                    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlConnection.Open();
                    //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlDataAdapter.Fill(odsvoltxndata);
                    // oSqlConnection.Close();
                    for (int i = 0; i < odsvoltxndata.Tables[0].Rows.Count; i++)
                    {
                        if (odsvoltxndata.Tables[0].Rows[i]["Category"].ToString().ToLower().Trim() == newcat2.ToLower().Trim())
                        {
                            catid = odsvoltxndata.Tables[0].Rows[i]["Uid"].ToString();
                        }




                    }
                }
                catch (Exception ex)
                {
                    label1.Text = ex.ToString();

                }
                /////////////////////////////////////////////////////////////////////
                try
                {
                    // oSqlConnection = new SqlConnection(constr);
                    oSqlCommand = new SqlCommand();
                    sqlQuery = "INSERT INTO [dbo].[ProductInfo] ([CategoryId] ,[Name],[StartingPrice] " +
               ",[Active],[Mileage],[ModelYear],[Model],[EntryNo] ,[cutofftime],[estimatedtime] " +
              " ,[place] ,[biddate]  ,[eventdate]  ,[currentbid]  ,[regno]  ,[DsplVol] ,[color] " +
             "  ,[TrnAC] ,[Eval],[loadage] ,[capacity] ,[Equip],[notify],[corection],[CreatedDate],[Status]) " +
              "  OUTPUT INSERTED.Uid " +
             "   VALUES (" + Convert.ToInt32(catid) + ",N'" + noHTMLNormalised + "'," + starp + "," + 1 + "," + milage + "," + modelyr + ",'" + noHTMLNormalised3 + "','"+elemt12.InnerText+ "',' ',' ','"+ loc + " ', " +
    "' ',' ',' ','" + noHTMLNormalised4 + "','" + noHTMLNormalised5 + "','" + noHTMLNormalised6 + "','" + noHTMLNormalised7 + "','" + noHTMLNormalised8 + "','" + noHTMLNormalised9 + "','" + noHTMLNormalised10 + "','" + noHTMLNormalised11 + "',' ',' ',GETDATE(),'" + sts + "') ";
                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                    oSqlCommand.Connection = oSqlConnection;
                    oSqlCommand.CommandText = sqlQuery;
                    //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    // oSqlConnection.Open();
                    tuid = (int)oSqlCommand.ExecuteScalar();
                    // oSqlConnection.Close();

                }
                catch (Exception ex)
                {
                    label1.Text = ex.ToString();

                }



                ///////////////////////////////////////////////////////////////////

                HtmlElementCollection tables = elem5.GetElementsByTagName("img");
                progressBar1.Maximum = tables.Count;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                int iop = 0;
                foreach (HtmlElement TBL in tables)
                {
                    //if (TBL.GetAttribute("src").Contains(".jp/IL"))
                    //{

                    progressBar1.Value = iop;
                    var fileUrl = TBL.GetAttribute("src");
                    string[] asd = fileUrl.Split('/');
                    var localFile = Properties.Settings.Default.Setting1 + "\\" + tuid + "\\" + asd[asd.Length - 1];
                    pyh = Properties.Settings.Default.Setting1 + "\\";

                    exists = System.IO.Directory.Exists(pyh + tuid);
                    try
                    {
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pyh + tuid);
                            //WebRequest ftpRequest = WebRequest.Create(ftpip + tuid);
                            //ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                            //ftpRequest.Credentials = new NetworkCredential(ftpun, ftppw);
                            //FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                        }
                    }
                    catch (Exception ex)
                    {
                        label1.Text = ex.ToString();

                    }

                    var client = new System.Net.WebClient();
                    // Download the image using WebClient:
                    // ebclient.DownloadFile(new Uri("http://mytestwebsite.com/temp/test.html"), @"D:\web\test.html");
                    try
                    {
                        client.DownloadFile(fileUrl, localFile);



                        //using (WebClient client2 = new WebClient())
                        //{
                        //    client2.Credentials = new NetworkCredential(ftpun, ftppw);

                        //    client2.UploadFile(ftpip + tuid + "/" + asd[asd.Length - 1], WebRequestMethods.Ftp.UploadFile, localFile);


                        //}

                        //////////////////////////////////////////////////////////////
                        try
                        {
                            // oSqlConnection = new SqlConnection(constr);
                            oSqlCommand = new SqlCommand();
                            sqlQuery = "INSERT INTO [dbo].[ProdImage] ([ProductId] ,[ImageName],[Active] )" +
                     "   VALUES (" + tuid + ",'" + tuid + "/" + asd[asd.Length - 1] + "'," + 1 + ") ";
                            //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                            oSqlCommand.Connection = oSqlConnection;
                            oSqlCommand.CommandText = sqlQuery;
                            //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                            //  oSqlConnection.Open();
                            oSqlCommand.ExecuteScalar();
                            //   oSqlConnection.Close();

                        }
                        catch (Exception ex)
                        {
                            label1.Text = ex.ToString();

                        }

                        ////////////////////////////////////////////////////////////



                    }
                    catch (Exception ex)
                    {
                        label1.Text = ex.ToString();

                    }
                    iop++;

                }
                if (exists)
                {
                  //  Directory.Delete(pyh + uril, true);
                }
                oSqlConnection.Close();
                istru = true;
                this.Dispose();

            }
            catch (Exception ex)
            {
                oSqlConnection.Close();
                label1.Text = ex.ToString();
            }


        }
        private void nativeBrowser_DocumentComplete(object pDisp, ref object URL)
        {

            this.Activated += AfterLoading;


        }

        private async void AfterLoading(object sender, EventArgs e)
        {

            this.Activated -= AfterLoading;
            //Write your code here.
            //  await c1();
            //   await Retry.Do(async () => await c1(), TimeSpan.FromSeconds(5));


        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    //nativeBrowser.NewWindow2 -= nativeBrowser_NewWindow2;
        //    //base.OnFormClosing(e);
        //}

        public static decimal Parse(string input)
        {
            try { 
            return decimal.Parse(Regex.Match(input, @"-?\d{1,3}(,\d{3})*(\.\d+)?").Value);
        }
             
            catch (Exception ex) {
                return 0;

    }
}

        public static String stParse(string input)
        {
            try
            {
                string noHTML4 = Regex.Replace(input, @"<[^>]+>|&nbsp;", "").Trim();
        string noHTMLNormalised4 = Regex.Replace(noHTML4, @"\s{2,}", " ");

                return noHTMLNormalised4;

            }
            catch (Exception ex)
            {
                return "0";

            }
        }



        public static int intParse(string input)
        {
            try
            {
                var modified = new StringBuilder();
                foreach (char c in input)
                {
                    if (Char.IsDigit(c) || c == '.')
                        modified.Append(c);
                }

                int number = int.Parse(modified.ToString());

                return number;
            }
            catch (Exception ex) {
                return 0;

            }

            
}



        void nativeBrowser_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            var popup = new Form2();
            popup.Show(this);
            ppDisp = popup.Browser.ActiveXInstance;


        }

        private async void Form2_ParentChanged(object sender, EventArgs e)
        {
            //await c1();
        }
       
        private async void button1_Click(object sender, EventArgs e)
        {
            //await c1();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
           
        }

      
       

        private async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try {
                while (true)
                {
                    HtmlDocument doc1 = webBrowser1.Document;
                    HtmlElement elem6 = doc1.GetElementById("gazou");
                    HtmlElementCollection tables = elem6.GetElementsByTagName("img");
                    int sdfgh = tables.Count;
                    // wait asynchronously, this will throw if cancellation requested
                    await Task.Delay(500);

                    // continue polling if the WebBrowser is still busy


                    if (this.webBrowser1.IsBusy || elem6 == null)
                        continue;


                    if (elem6 != null)
                        break; // no changes detected, end the poll loop


                }
            }
            catch (Exception ex)
            {


            }
            //  await c1();
            if (sts == "3")
            {
                await Retry.Do(async () => await c2(), TimeSpan.FromSeconds(5));
            }
            else
            {
                await Retry.Do(async () => await c1(), TimeSpan.FromSeconds(5));
            }
            
        }
    }
}
