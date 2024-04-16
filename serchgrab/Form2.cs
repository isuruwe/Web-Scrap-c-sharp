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
using Microsoft.Win32;
using System.Diagnostics;

namespace serchgrab
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form2 : Form
    {
        public Form2()
        {
            SetBrowserFeatureControl();
            InitializeComponent();

        }
        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }
        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_NINPUT_LEGACYMODE", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                default:
                    // use IE10 mode by default
                    break;
            }

            return mode;
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
                HtmlElement elem6 = doc1.GetElementById("frmInvView");
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
        private string tuid;
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
                string hob = "";
                string ship1 = "";
                string ship2 = "";
                string addr = "";
                string pcd = "";
                string city = "";
                string town = "";
                string cntry = "";
                string mobile = "";
                string tele = "";
                string nic = "";
                string email = "";
                string consee1 = "";
                string consee2 = "";
                string addr1 = "";
                string addr2 = "";
                string town1 = "";
                string cntry1 = "";
                string mobile1 = "";
                string tele1 = "";
                string nic1 = "";
                string email1 = "";
                string father = "";
                string volume = "";
                string weight = "";
                string packages = "";
                string trby = "";
                string slab = "";
                string subone = "";
                string warehouse = "";
                string canceldate = "";
                string cancelreason = "";
                string canceledby = "";
                string dtodoor = "";
                string invoiceno = "";
                string invoicedate = "";
                string sector = "";
                string branch = "";
                string freightby = "";
                string represent = "";
                string entryby = "";
                string onstorage = "";
                string directshipment = "";
                string freight = "";
                string packing = "";
                string coll = "";
                string delivery = "";
                string clearance = "";
                string storage = "";
                string extra = "";
                string gross = "";
                string discount = "";
                string nett = "";
                string paymentstatus = "";
                string jobadvance = "";
                string totalpaid = "";
                string totaldue = "";
                string cargodesc = "";
                string remarks = "";
                string nos = "";
                string paymentno = "";
                string paidamount = "";
                string advance = "";
                string cash = "";
                string ccard = "";
                string chq = "";
                string dbank = "";
                string paiddate = "";
                string lLedgeref = "";
                string pnos = "";
                string package = "";
                string plength = "";
                string pwidth = "";
                string pheight = "";
                string pvolume = "";
                string pweight = "";
                string runingno = "";
                string shipmentno = "";
                string shipno = "";
                string pkgno = "";




                oSqlConnection = new SqlConnection(constr);

             


                while (true)
                {
                    
                        HtmlDocument doc1 = webBrowser1.Document;
                        HtmlElement elem6 = doc1.GetElementById("frmInvView");
                        HtmlElementCollection tables1 = elem6.GetElementsByTagName("img");
                        int sdfgh = tables1.Count;
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(1000);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null )
                            break; // no changes detected, end the poll loop

                       
                   
                }
                HtmlDocument doc2 = webBrowser1.Document;
                HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                int cnt = 1;
                int cnt2 = 1;
                int cnt3 = 1;
                int cnt4 = 1;
                bool shp= false;
                bool pyy = false;
                bool pey = false;



                foreach (HtmlElement TBL in tables)
                {
                   
                        
                        

                    foreach (HtmlElement ROW in TBL.GetElementsByTagName("tr"))
                    {
                        //HtmlElement btnElement1 = ROW.GetAttribute("td");
                        //Form2.modelyr = btnElement1.InnerText;
                       
                        


                        foreach (HtmlElement ROW1 in TBL.GetElementsByTagName("td"))
                        {
                           

                           
                            if (ROW1.InnerHtml==("Hand-Over By"))
                            {
                                
                                
                            }
                            if (cnt==10)
                            {
                                hob = ROW1.InnerHtml;
                            }

                            if (cnt == 12)
                            {
                                ship1 = ROW1.InnerHtml;
                            }
                            if (cnt == 14)
                            {
                                ship2 = ROW1.InnerHtml;
                            }
                            if (cnt == 16)
                            {
                                addr = ROW1.InnerHtml;
                            }
                            if (cnt == 18)
                            {
                                pcd = ROW1.InnerHtml;
                            }
                            if (cnt == 20)
                            {
                                city = ROW1.InnerHtml;
                            }
                            if (cnt == 22)
                            {
                                town = ROW1.InnerHtml;
                            }
                            if (cnt == 24)
                            {
                                cntry = ROW1.InnerHtml;
                            }
                            if (cnt == 26)
                            {
                                mobile = ROW1.InnerHtml;
                            }
                            if (cnt == 28)
                            {
                                tele = ROW1.InnerHtml;
                            }
                            if (cnt == 30)
                            {
                                nic = ROW1.InnerHtml;
                            }
                            if (cnt == 32)
                            {
                                email = ROW1.InnerHtml;
                            }
                            if (cnt == 35)
                            {
                                consee1 = ROW1.InnerHtml;
                            }
                            if (cnt == 37)
                            {
                                consee2 = ROW1.InnerHtml;
                            }
                            if (cnt == 39)
                            {
                                addr1 = ROW1.InnerHtml;
                            }
                            if (cnt == 41)
                            {
                                addr2 = ROW1.InnerHtml;
                            }
                            if (cnt == 43)
                            {
                                town1 = ROW1.InnerHtml;
                            }

                            if (cnt == 45)
                            {
                                cntry1 = ROW1.InnerHtml;
                            }
                            if (cnt == 47)
                            {
                                mobile1 = ROW1.InnerHtml;
                            }
                            if (cnt == 49)
                            {
                                tele1 = ROW1.InnerHtml;
                            }
                            if (cnt == 51)
                            {
                                nic1 = ROW1.InnerHtml;
                            }
                            if (cnt == 53)
                            {
                                email1 = ROW1.InnerHtml;
                            }
                            if (cnt == 55)
                            {
                                father = ROW1.InnerHtml;

                                int index = father.IndexOf("<");
                                if (index > 0)
                                    father = father.Substring(0, index);

                                father = getBetween(father, "<FONT color=#ff0000>", "</FONT>");
                                
                            }
                            if (cnt == 59)
                            {
                                volume = ROW1.InnerHtml;
                            }
                            if (cnt == 61)
                            {
                                weight = ROW1.InnerHtml;
                            }
                            if (cnt == 63)
                            {
                                packages = ROW1.InnerHtml;
                            }
                            if (cnt == 65)
                            {
                                trby = ROW1.InnerHtml;
                                trby=getBetween(trby, "selected value=", ">");
                            }
                            if (cnt == 67)
                            {
                                slab = ROW1.InnerHtml;
                            }
                            if (cnt == 69)
                            {
                                subone = ROW1.InnerHtml;
                            }
                            if (cnt == 71)
                            {
                                warehouse = ROW1.InnerHtml;
                            }
                            if (cnt == 73)
                            {
                                canceldate = ROW1.InnerHtml;
                            }
                            if (cnt == 75)
                            {
                                cancelreason = ROW1.InnerHtml;
                            }
                            if (cnt == 77)
                            {
                                canceledby = ROW1.InnerHtml;
                            }
                            if (cnt == 79)
                            {
                                dtodoor = ROW1.InnerHtml;
                                dtodoor=getBetween(dtodoor, "selected value=",">");

                            }
                            if (cnt == 82)
                            {
                                invoiceno = ROW1.InnerHtml;
                                int index = invoiceno.IndexOf("<");
                                if (index > 0)
                                    invoiceno = invoiceno.Substring(0, index);
                            }
                            if (cnt == 84)
                            {
                                invoicedate = ROW1.InnerHtml;
                            }
                            if (cnt == 86)
                            {
                                sector = ROW1.InnerHtml;
                            }
                            if (cnt == 88)
                            {
                                branch = ROW1.InnerHtml;
                            }
                            if (cnt == 90)
                            {
                                freightby = ROW1.InnerHtml;
                            }
                            if (cnt == 92)
                            {
                                represent = ROW1.InnerHtml;
                            }
                            if (cnt == 94)
                            {
                                entryby = ROW1.InnerHtml;
                            }
                            if (cnt == 96)
                            {
                                onstorage = ROW1.InnerHtml;
                            }
                            if (cnt == 98)
                            {
                                directshipment = ROW1.InnerHtml;
                                directshipment = getBetween(directshipment, "selected value=", ">");
                            }
                            if (cnt == 101)
                            {
                                freight = ROW1.InnerHtml;
                            }
                            if (cnt == 103)
                            {
                                packing = ROW1.InnerHtml;
                            }
                            if (cnt == 105)
                            {
                                coll = ROW1.InnerHtml;
                            }
                            if (cnt == 107)
                            {
                                delivery = ROW1.InnerHtml;

                            }
                            if (cnt ==109)
                            {
                                clearance = ROW1.InnerHtml;
                            }
                            if (cnt == 111)
                            {
                                storage = ROW1.InnerHtml;
                            }
                            if (cnt == 113)
                            {
                                extra = ROW1.InnerHtml;
                            }
                            if (cnt == 115)
                            {
                                gross = ROW1.InnerHtml;
                            }
                            if (cnt == 117)
                            {
                                discount = ROW1.InnerHtml;
                            }
                            if (cnt == 119)
                            {
                                nett = ROW1.InnerHtml;
                            }
                            if (cnt == 121)
                            {
                                paymentstatus = ROW1.InnerHtml;
                            }
                            if (cnt == 123)
                            {
                                jobadvance = ROW1.InnerHtml;
                            }
                            if (cnt == 125)
                            {
                                totalpaid = ROW1.InnerHtml;
                            }
                            if (cnt == 127)
                            {
                                totaldue = ROW1.InnerHtml;
                            }
                            if (cnt == 129)
                            {
                                cargodesc = ROW1.InnerHtml;
                                int index = cargodesc.IndexOf("<");
                                if (index > 0)
                                    cargodesc = cargodesc.Substring(0, index);
                                
                            }
                            if (cnt == 131)
                            {
                                remarks = ROW1.InnerHtml;
                                cnt++;
                                break;
                               
                            }



                            cnt++;


                        }

                       


                        }

                        }

                HtmlElementCollection rws = this.webBrowser1.Document.GetElementsByTagName("td");
                foreach (HtmlElement TBL in rws)
                {
                    if (TBL.InnerHtml == ("Ledger Ref.No"))
                    {

                        shp = true;
                        cnt2 = 1;
                    }
                    if (shp == true && cnt2 == 2)
                    {
                        nos = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 3)
                    {
                        paymentno = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 4)
                    {
                        paidamount = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 5)
                    {
                        advance = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 6)
                    {
                        cash = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 7)
                    {
                        ccard = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 8)
                    {
                        chq = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 9)
                    {
                        dbank = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 10)
                    {
                        paiddate = TBL.InnerHtml;
                    }
                    if (shp == true && cnt2 == 11)
                    {
                        lLedgeref = TBL.InnerHtml;
                    }

                    if (shp == true && cnt2 > 10)
                    {
                        try
                        {
                            oSqlConnection = new SqlConnection(constr);
                            oSqlCommand = new SqlCommand();
                            sqlQuery = "INSERT INTO [dbo].[paymentd] ([invoiceno] ,[nos],[paymentno],[paidamount],[advance],[cash],[ccard],[chq],[dbank] ,[paiddate],[ledgerefno] )" +
                     "   VALUES ('" + invoiceno + "','" + nos + "','" + paymentno + "','" + paidamount + "','" + advance + "','" + cash + "','" + ccard + "','" + chq + "','" + dbank + "','" + paiddate + "','" + lLedgeref + "') ";
                            

                            oSqlCommand.Connection = oSqlConnection;
                            oSqlCommand.CommandText = sqlQuery;
                            oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                            oSqlConnection.Open();
                            oSqlCommand.ExecuteScalar();
                            oSqlConnection.Close();
                            cnt2 = 1;
                        }
                        catch (Exception ex)
                        {
                            label1.Text = ex.ToString();

                        }
                    }


                    if (TBL.InnerHtml == ("Packages Description"))
                    {

                        shp = false;

                    }
                    cnt2++;

                    //////////////////////////////////
                    if (TBL.InnerHtml == ("Shipment No"))
                    {

                        pyy = true;
                        cnt3 = 1;
                    }
                    if (pyy == true && cnt3 == 2)
                    {
                        pnos = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 3)
                    {
                        package = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 4)
                    {
                        plength = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 5)
                    {
                        pwidth = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 6)
                    {
                        pheight = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 7)
                    {
                        pvolume = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 8)
                    {
                        pweight = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 9)
                    {
                        runingno = TBL.InnerHtml;
                    }
                    if (pyy == true && cnt3 == 10)
                    {
                        shipmentno = TBL.InnerHtml;
                    }
                   

                    if (pyy == true && cnt3 > 9&&!pnos.Equals("Name"))
                    {
                        try
                        {
                            oSqlConnection = new SqlConnection(constr);
                            oSqlCommand = new SqlCommand();
                            sqlQuery = "INSERT INTO [dbo].[pkgdet] ([invoiceno]      ,[nos]      ,[package]      ,[plength]      ,[pwidth]      ,[pheight]      ,[pvolume]      ,[pweight]      ,[runingno]      ,[shipmentno] )" +
                     "   VALUES ('" + invoiceno + "','" + pnos + "','" + package + "','" + plength + "','" + pwidth + "','" + pheight + "','" + pvolume + "','" + pweight + "','" + runingno + "','" + shipmentno + "') ";


                            oSqlCommand.Connection = oSqlConnection;
                            oSqlCommand.CommandText = sqlQuery;
                            oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                            oSqlConnection.Open();
                            oSqlCommand.ExecuteScalar();
                            oSqlConnection.Close();
                            cnt3 = 1;
                        }
                        catch (Exception ex)
                        {
                            label1.Text = ex.ToString();

                        }
                    }


                    if (TBL.InnerHtml == ("Shipment Details"))
                    {

                        pyy = false;

                    }
                    cnt3++;
                    //////////////////////////////////
                    if (TBL.InnerHtml == ("Package Numbers"))
                    {

                        pey = true;
                        cnt4 = 1;
                    }
                    if (pey == true && cnt4 == 2)
                    {
                        shipno = TBL.InnerHtml;
                    }
                    if (pey == true && cnt4 == 3)
                    {
                        pkgno = TBL.InnerHtml;
                    }
                   

                    if (pey == true && cnt4 > 2 && !shipno.Equals("&nbsp;")  )
                    {
                        try
                        {
                            oSqlConnection = new SqlConnection(constr);
                            oSqlCommand = new SqlCommand();
                            sqlQuery = "INSERT INTO [dbo].[loadpkd] ([invoiceno],[shipno]      ,[pkno] )" +
                     "   VALUES ('" + invoiceno + "','" + shipno + "','" + pkgno + "') ";


                            oSqlCommand.Connection = oSqlConnection;
                            oSqlCommand.CommandText = sqlQuery;
                            oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                            oSqlConnection.Open();
                            oSqlCommand.ExecuteScalar();
                            oSqlConnection.Close();
                            cnt4 = 1;
                        }
                        catch (Exception ex)
                        {
                            label1.Text = ex.ToString();

                        }
                    }


                    if (TBL.InnerHtml == ("Warehouse Office"))
                    {

                        pey = false;

                    }
                    cnt4++;

                }
                //    HtmlElement elem5 = doc2.GetElementById("gazou");
                //    HtmlElement elemt6 = doc2.GetElementById("syamei");
                //    HtmlElement elemt7 = doc2.GetElementById("sp0500");

                //    string noHTMLNormalised = stParse(elemt7.InnerText);
                //    // HtmlElement elemt8 = doc2.GetElementById("start");

                //    HtmlElement elemt8 = doc2.GetElementById("st_kakaku");
                //    string noHTMLNormalised14 = stParse(elemt8.InnerText);
                //    string numberOnly = Regex.Replace(noHTMLNormalised14, "[^0-9.]", "");
                //    Decimal starp = Convert.ToDecimal(numberOnly);
                //    HtmlElement elemt9 = doc2.GetElementById("sp0800");

                //    string noHTMLNormalised1 = stParse(elemt9.InnerText);
                //    Decimal milage = Parse(noHTMLNormalised1);
                //    HtmlElement elemt10 = doc2.GetElementById("sp4000");

                //    string noHTMLNormalised2 = stParse(elemt10.InnerText);
                //    int modely = intParse(noHTMLNormalised2);
                //    HtmlElement elemt11 = doc2.GetElementById("sp0600");

                //    string noHTMLNormalised3 = stParse(elemt11.InnerText);
                //    HtmlElement elemt12 = doc2.GetElementById("sno");
                //    HtmlElement elemt13 = doc2.GetElementById("simekiri");
                //    HtmlElement elemt14 = doc2.GetElementById("seriyoso");
                //    HtmlElement elemt15 = doc2.GetElementById("kaijo_name");
                //    HtmlElement elemt16 = doc2.GetElementById("kaisaibi");
                //    HtmlElement elemt17 = doc2.GetElementById("kaisu");
                //HtmlElement elemt18 = null;
                //HtmlElement elemt19 = null;
                //string current = "";
                //string currenthaba = "";
                //try
                //{
                //     elemt18 = doc2.GetElementById("current");
                //     elemt19 = doc2.GetElementById("currenthaba");
                //    current = elemt18.InnerText;
                //    currenthaba = elemt19.InnerText;
                //}
                //catch (Exception ex)
                //{

                //}
                //HtmlElement elemt20 = doc2.GetElementById("sp0400");

                //    string noHTMLNormalised4 = stParse(elemt20.InnerText);


                //    HtmlElement elemt21 = doc2.GetElementById("sp07000");

                //    string noHTMLNormalised5 = stParse(elemt21.InnerText);
                //    HtmlElement elemt22 = doc2.GetElementById("sp0900");

                //    string noHTMLNormalised6 = stParse(elemt22.InnerText);
                //    HtmlElement elemt23 = doc2.GetElementById("sp3000");

                //    string noHTMLNormalised7 = stParse(elemt23.InnerText);
                //    HtmlElement elemt24 = doc2.GetElementById("sp1000");

                //    string noHTMLNormalised8 = stParse(elemt24.InnerText);
                //    HtmlElement elemt25 = doc2.GetElementById("sp3100");

                //    string noHTMLNormalised9 = stParse(elemt25.InnerText);
                //    HtmlElement elemt26 = doc2.GetElementById("sp3200");

                //    string noHTMLNormalised10 = stParse(elemt26.InnerText);
                //    HtmlElement elemt27 = doc2.GetElementById("sp1100");

                //    string noHTMLNormalised11 = stParse(elemt27.InnerText);

                //    HtmlElement elemt28 = doc2.GetElementById("notify");

                //    string noHTMLNormalised12 = stParse(elemt28.InnerText);

                //    noHTMLNormalised12 = noHTMLNormalised12.Replace("'", "");

                //    HtmlElement elemt29 = doc2.GetElementById("teisei_detail");

                //    string noHTMLNormalised13 = stParse(elemt29.InnerText);



                /////////////////////////////////

                //   try {
                //    DataSet odsvoltxndata = new DataSet();


                //    oSqlCommand = new SqlCommand();
                //    sqlQuery = "SELECT  [UId] ,[Category]  FROM [dbo].[ProdCategory] where [ParentUId]!=0 ";
                //    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                //    oSqlCommand.Connection = oSqlConnection;
                //    oSqlCommand.CommandText = sqlQuery;
                //    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                //    oSqlConnection.Open();
                //    //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                //    oSqlDataAdapter.Fill(odsvoltxndata);
                //   // oSqlConnection.Close();
                //    for (int i = 0; i < odsvoltxndata.Tables[0].Rows.Count; i++)
                //    {
                //        if (odsvoltxndata.Tables[0].Rows[i]["Category"].ToString().ToLower().Trim()== elemt6.InnerText.ToLower().Trim())
                //        {
                //            catid = odsvoltxndata.Tables[0].Rows[i]["Uid"].ToString();
                //        }




                //    }
                //}
                //catch (Exception ex)
                //{
                //        label1.Text = ex.ToString();

                //    }
                /////////////////////////////////////////////////////////////////////
                try
                {
                    oSqlConnection = new SqlConnection(constr);
                    oSqlCommand = new SqlCommand();
                    sqlQuery = "INSERT INTO [dbo].[invoice] ([invoiceno] ,[hob],[ship1],[ship2],[addr],[pcd],[city],[town],[cntry]"+
     " ,[mobile]      ,[tele]      ,[nic]      ,[email]      ,[consee1]      ,[consee2]      ,[addr1]      ,[addr2]      ,[town1] " +
   "   ,[cntry1]      ,[mobile1]      ,[tele1]      ,[nic1]      ,[email1]      ,[father]      ,[volume]      ,[weight]      ,[packages] " +
   "   ,[trby]      ,[slab]      ,[subone]      ,[warehouse]      ,[canceldate]      ,[cancelreason]      ,[canceledby]      ,[dtodoor] "+
  "    ,[invoicedate]      ,[sector]      ,[branch]      ,[freightby]      ,[represent]      ,[entryby]      ,[onstorage]      ,[directshipment] "+
   "   ,[freight]      ,[packing]      ,[coll]      ,[delivery]      ,[clearance]      ,[storage]      ,[extra]      ,[gross]      ,[discount] " +
   "   ,[nett]      ,[paymentstatus]      ,[jobadvance]      ,[totalpaid]      ,[totaldue]      ,[cargodesc]      ,[remarks]) " +
             
             "   VALUES ('"+invoiceno+"' ,'"+hob + "','" + ship1 + "','" + ship2 + "','" + addr + "','" + pcd + "','" + city + "','" + town + "','" + cntry + "'" +
     " ,'" + mobile + "'      ,'" + tele + "'     ,'" + nic + "'      ,'" + email + "'      ,'" + consee1 + "'     ,'" + consee2 + "'      ,'" +addr1 + "'      ,'" + addr2 + "'      ,'" + town1 + "' " +
   "   ,'" + cntry1 + "'      ,'" + mobile1+"'      ,'"+tele1+"'      ,'" + nic1 + "'     ,'" + email1+"'      ,'"+father+"'     ,'" + volume + "'     ,'" + weight + "'      ,'" + packages + "' " +
   "   ,'" + trby + "'     ,'" + slab + "'      ,'" + subone + "'      ,'" + warehouse + "'     ,'" + canceldate + "'      ,'" + cancelreason + "'     ,'" + canceledby+"'      ,'" + dtodoor+"' " +
  "    ,'" + invoicedate + "'      ,'" + sector + "'      ,'" + branch + "'      ,'" + freightby + "'      ,'" + represent + "'      ,'" + entryby + "'      ,'" + onstorage + "'     ,'" + directshipment + "' " +
   "   ,'" + freight + "'     ,'" + packing + "'      ,'" + coll + "'     ,'" + delivery + "'      ,'" + clearance + "'      ,'" + storage + "'     ,'" + extra+"'     ,'" + gross + "'      ,'" + discount + "' " +
   "   ,'" + nett + "'      ,'" + paymentstatus + "'      ,'" + jobadvance + "'      ,'" + totalpaid + "'      ,'" + totaldue + "'     ,'" + cargodesc + "'     ,'" + remarks + "') ";

                    oSqlCommand.Connection = oSqlConnection;
                    oSqlCommand.CommandText = sqlQuery;
                    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlConnection.Open();
                   oSqlCommand.ExecuteScalar();
                    oSqlConnection.Close();
                    istru = true;
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    label1.Text = ex.ToString();

                }



                ///////////////////////////////////////////////////////////////////

                //HtmlElementCollection tables = elem5.GetElementsByTagName("img");
                //progressBar1.Maximum = tables.Count;
                //progressBar1.Step = 1;
                //progressBar1.Value = 0;
                //int iop = 0;
                //foreach (HtmlElement TBL in tables)
                //{
                //    //if (TBL.GetAttribute("src").Contains(".jp/IL"))
                //    //{

                //    progressBar1.Value = iop;
                //    var fileUrl = TBL.GetAttribute("src");
                //    string[] asd = fileUrl.Split('/');
                //    string[] flp = asd[asd.Length - 1].Replace("?", "").Split('.');
                //    var localFile = Properties.Settings.Default.Setting1 + "\\" + tuid + "\\" + flp[0]+".jpg";
                //     pyh = Properties.Settings.Default.Setting1 + "\\";

                //     exists = System.IO.Directory.Exists(pyh + tuid);
                //    try
                //    {
                //        if (!exists)
                //        {
                //            System.IO.Directory.CreateDirectory(pyh + tuid);
                //            //WebRequest ftpRequest = WebRequest.Create(ftpip + tuid);
                //            //ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                //            //ftpRequest.Credentials = new NetworkCredential(ftpun, ftppw);
                //            //FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        label1.Text = ex.ToString();

                //    }

                //   var client = new System.Net.WebClient();
                //    // Download the image using WebClient:
                //    // ebclient.DownloadFile(new Uri("http://mytestwebsite.com/temp/test.html"), @"D:\web\test.html");
                //    try
                //    {

                //        //int index = fileUrl.IndexOf("?");
                //        //if (index > 0)
                //        //    fileUrl = fileUrl.Substring(0, index);

                //        //int index2 = localFile.IndexOf("?");
                //        //if (index2 > 0)
                //        //    localFile = localFile.Substring(0, index);
                //        client.DownloadFile(fileUrl, localFile);



                //        //using (WebClient client2 = new WebClient())
                //        //{
                //        //    client2.Credentials = new NetworkCredential(ftpun, ftppw);

                //        //    client2.UploadFile(ftpip + tuid + "/" + asd[asd.Length - 1], WebRequestMethods.Ftp.UploadFile, localFile);


                //        //}

                //        //////////////////////////////////////////////////////////////
                //        try
                //        {
                //           // oSqlConnection = new SqlConnection(constr);
                //            oSqlCommand = new SqlCommand();
                //            sqlQuery = "INSERT INTO [dbo].[ProdImage] ([ProductId] ,[ImageName],[Active] )" +
                //     "   VALUES (" + tuid + ",'" + tuid + "/" + flp[0] + ".jpg" + "',"+1+") ";
                //            //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                //            oSqlCommand.Connection = oSqlConnection;
                //            oSqlCommand.CommandText = sqlQuery;
                //            //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                //          //  oSqlConnection.Open();
                //            oSqlCommand.ExecuteScalar();
                //         //   oSqlConnection.Close();

                //        }
                //        catch (Exception ex)
                //        {
                //            label1.Text = ex.ToString();

                //        }

                //        ////////////////////////////////////////////////////////////



                //    }
                //    catch (Exception ex)
                //    {
                //        label1.Text = ex.ToString();

                //    }
                //    iop++;

                //}
                //if (exists)
                //{
                //   // Directory.Delete(pyh + uril, true);
                //}
                //    oSqlConnection.Close();
                //    istru = true;
                //    this.Dispose();

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
                    //tuid = (int)oSqlCommand.ExecuteScalar();
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
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
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
                    HtmlElement elem6 = doc1.GetElementById("frmInvView");
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
            //if (sts == "3")
            //{
            //    await Retry.Do(async () => await c2(), TimeSpan.FromSeconds(5));
            //}
            //else
            //{
                await Retry.Do(async () => await c1(), TimeSpan.FromSeconds(5));
            //}
            
        }
    }
}
