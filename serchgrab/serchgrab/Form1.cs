using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskScheduler;

namespace serchgrab
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
        }
       
        int isbypage = 0;
        bool isLoaded = false;
        bool isnw = false;
        bool isdelect = false;
        bool isentrymet = false;
        string uyt = "";
        private bool exists;
        private string pyh;
        SqlConnection oSqlConnection;
        SqlCommand oSqlCommand;
        SqlDataAdapter oSqlDataAdapter;
        public string sqlQuery;
        string constr = ConfigurationManager.AppSettings["constr"];
        //private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
        //{


        //}
        
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            CallApp();
        }
        public void CallApp()
        {
            // Display the date/time when this method got called.
            DateTime date = DateTime.Now;
            Console.WriteLine("In TimerCallback: " + date);
            DateTime FromDate = date;
            DateTime ToDate = date.Date.AddMinutes(1);
            TaskData oTaskData = new DataAccess().SelectTaskData(FromDate, ToDate);
            if (oTaskData != null)
            {
                if (oTaskData.UId > 0)
                {

                    DoDataFeed(oTaskData.Code);

                }
            }

        }
        public void DoDataFeed(int ID)
        {
            if (ID==1)
            {
                livefeed();
            }
            if (ID == 2)
            {
                livefeeddelete();
            }
            if (ID == 3)
            {
                livefeedupdate();
            }
            if (ID == 4)
            {
                updateprice();
            }
        }

        //private void Wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        //{

        //}
        //        private void WebBrowserNavigating(object sender, WebBrowserNavigatingEventArgs e)
        //{


        //            uyt= e.Url.ToString();



        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = Properties.Settings.Default.Setting1;
            //SHDocVw.WebBrowser axBrowser = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
            //axBrowser.NewWindow3 += new DWebBrowserEvents2_NewWindow3EventHandler(Browser_NewWindow3);
            //this.webBrowser1.Navigating += WebBrowserNavigating;
            //this.webBrowser1.NewWindow += WebBrowser1_NewWindow;
            //this.webBrowser1.Navigated += Wb_Navigated;
            bool IsLive = new DALSetting().GetLiveStatus();
            if (IsLive)
                btnLive.Text = "The Video is Live";
            else
                btnLive.Text = "The Video is offline";
            if (!WBEmulator.IsBrowserEmulationSet())
            {
                WBEmulator.SetBrowserEmulationVersion();
            }
            this.webBrowser1.Navigate("http://www.araiaa.jp/en/");
            radioButton2.Checked = true;
          //  webBrowser1.ScriptErrorsSuppressed = true;
        }
        SHDocVw.WebBrowser nativeBrowser;
        private bool isstartfrom;
        private bool lgoff=false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            nativeBrowser = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
            nativeBrowser.NewWindow2 += nativeBrowser_NewWindow2;
            nativeBrowser.DocumentComplete += nativeBrowser_DocumentComplete;
        }

        private void nativeBrowser_DocumentComplete(object pDisp, ref object URL)
        {
          
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            nativeBrowser.NewWindow2 -= nativeBrowser_NewWindow2;
            base.OnFormClosing(e);
        }

        void nativeBrowser_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            var popup = new Form2();
            popup.Show(this);
            ppDisp = popup.Browser.ActiveXInstance;
        }
        //private void Browser_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        //{
           

        //    //Form2 WebForm = new Form2();
        //    //  Form2.uril = bstrUrl;
        //    //   WebForm.ShowDialog();
        //  //  webBrowser1.Navigate(bstrUrl);
        //   // Cancel = true;
        //    //   throw new NotImplementedException();
        //}

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {

                    isLoaded = true;


                }







            }
            catch (Exception ex)
            {

            }
            // HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("a");


        }

        public async Task f10(HtmlElement btnElement)
        {
            try { 
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                        btnElement.InvokeMember("click");
                        while (true)
                        {
                            await Task.Delay(500);
                            if (Form2.istru)
                                break; 
                               
                            if (Form2.istru == false)
                                continue;
                        }
                        }
                }
        }
                catch(Exception ex) {


                    }

}


        public async Task f11()
        {
           
                if (webBrowser1.Document != null)
                {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btResetFilter");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    try {
                        while (true)
                        {
                            HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                            foreach (System.Windows.Forms.HtmlElement link in elem2)
                            {


                                if (link.OuterHtml.Contains("cmSyuppinList.Scroll.nextPage(cmSyuppinList)"))
                                {
                                    // link.Click();
                                    HtmlElement btnElement = link;
                                    btnElement.InvokeMember("click");
                                    await Task.Delay(2000);
                                    //  await f9();
                                    await Retry.Do(async () => await f9(), TimeSpan.FromSeconds(5));
                                    //await f11();
                                    await Retry.Do(async () => await f11(), TimeSpan.FromSeconds(5));
                                }

                                
                            }
                            HtmlElement fromto = doc.GetElementById("from_to");
                            HtmlElement endto = doc.GetElementById("total_count");
                            string endno = fromto.InnerText.Trim().ToLower().Replace(" ", "").Split('-')[1];
                            string finalno = endto.InnerText.Trim().ToLower().Replace(" ", "");
                            if (endno == finalno)
                            {
                                break;
                            }
                        }
                }
                catch(Exception ex) {


                    }

                    }
                }
            

        }


        public async Task f9()
        {
            try {

                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                        HtmlDocument doc1 = webBrowser1.Document;
                        HtmlDocument doc = webBrowser1.Document;

                        while (true)
                        {
                            HtmlElement elem6 = doc1.GetElementById("btResetFilter");
                            HtmlElement elem7 = doc1.GetElementById("loading");

                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem6 == null || elem7 != null)
                                continue;


                            if (elem6 != null && elem7 == null)
                                break; // no changes detected, end the poll loop


                        }
                        await Task.Delay(3000);
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                      
                        //foreach (System.Windows.Forms.HtmlElement link in elem2)
                        //{
                        //    link.SetAttribute("target", "_self");

                        //        if (link.InnerText=="502")
                        //    {


                        //        HtmlElement btnElement = link;
                        //        btnElement.InvokeMember("click");


                        //    }

                        //}
                        
                        try { 
                        HtmlDocument doc3 = webBrowser1.Document;
                        HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                        int rcnnt = 0;
                        String scnt = "";
                        foreach (HtmlElement TBL in tables)
                        {
                                if (lgoff == true)
                                {
                                    break;
                                }

                                HtmlElement fromto = doc3.GetElementById("from_to");
                                HtmlElement endto = doc3.GetElementById("total_count");
                                string endno = fromto.InnerText.Trim().ToLower().Replace(" ", "").Split('-')[1];
                                string finalno = endto.InnerText.Trim().ToLower().Replace(" ", "");
                                if (endno == finalno)
                                {
                                    break;
                                }

                                foreach (HtmlElement ROW in TBL.GetElementsByTagName("tr"))
                            {
                                //HtmlElement btnElement1 = ROW.GetAttribute("td");
                                //Form2.modelyr = btnElement1.InnerText;
                                foreach (HtmlElement ROW1 in TBL.GetElementsByTagName("td"))
                                {
                                        DataSet odsvoltxndata1 = new DataSet();
                                        HtmlElementCollection elem3 = ROW1.GetElementsByTagName("a");

                                    foreach (System.Windows.Forms.HtmlElement link in elem3)
                                    {


                                            if (link.GetAttribute("href").Contains("cmSyuppinList.onClickSno") && ROW1.OuterHtml.Contains("sp03"))
                                            {

                                                if (rcnnt.ToString().Length == 1)
                                                {
                                                    scnt = "0" + rcnnt.ToString();
                                                }
                                                else
                                                {
                                                    scnt = rcnnt.ToString();
                                                }
                                                rcnnt++;
                                                HtmlElement btnElement1 = doc3.GetElementById("sp04" + scnt);
                                                Form2.modelyr = btnElement1.InnerText;
                                                Form2.sts ="2";
                                                HtmlElement btnElement = link;
                                                Form2.uril = link.InnerText;
                                                HtmlElement btnElement1x = doc3.GetElementById("sp12" + scnt);
                                                string[] newcat = btnElement1x.InnerText.Split('\r');
                                                string newcat2 = newcat[0];
                                                string replacement = Regex.Replace(newcat[1], @"\t|\n|\r", "");
                                                string noHTMLNormalised14 = stParse(newcat2);
                                                string numberOnly = Regex.Replace(noHTMLNormalised14, "[^0-9.]", "");
                                                Decimal starp = Convert.ToDecimal(numberOnly);
                                                Form2.buynp = starp;
                                                if (replacement.Equals("sold"))
                                                {
                                                    Form2.issolds = 1;
                                                }
                                                if (replacement.Equals("not sold"))
                                                {
                                                    Form2.issolds = 0;
                                                }

                                                    ////////////////////////////////////////////
                                                    try
                                                {

                                                    String catid = "";
                                                    oSqlConnection = new SqlConnection(constr);
                                                    oSqlCommand = new SqlCommand();
                                                    sqlQuery = "  SELECT EntryNo FROM [dbo].[ProductInfo]  where   EntryNo='" + link.InnerText+ "' and Status=2 ";
                                                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                    oSqlCommand.Connection = oSqlConnection;
                                                    oSqlCommand.CommandText = sqlQuery;
                                                    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                    oSqlConnection.Open();
                                                    // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                    oSqlDataAdapter.Fill(odsvoltxndata1);
                                                    oSqlConnection.Close();
                                                }
                                                catch (Exception ex)
                                                {


                                                }
                                                ///////////////////////////////////////////////////

                                                if (isstartfrom == true)
                                                {
                                                    if (odsvoltxndata1.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (Convert.ToInt32(odsvoltxndata1.Tables[0].Rows[0]["EntryNo"].ToString()) == Convert.ToInt32(link.InnerText))
                                                        {
                                                            //await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                            //await Task.Delay(500);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                        await Task.Delay(500);
                                                    }
                                                }
                                                else
                                                {
                                                    try {
                                                        if (odsvoltxndata1.Tables[0].Rows.Count > 0)
                                                        {
                                                            if (Convert.ToInt32(odsvoltxndata1.Tables[0].Rows[0]["EntryNo"].ToString()) == Convert.ToInt32(link.InnerText))
                                                            {
                                                                isentrymet = false;
                                                                //await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                                //await Task.Delay(500);
                                                            }
                                                            else
                                                            {
                                                                isentrymet = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            isentrymet = true;
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {

                                                    }
                                                    if (isentrymet==true)
                                                    {
                                                        await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                        await Task.Delay(500);
                                                    }
                                                }
                                            // await f10(btnElement);


                                        }

                                    }

                                }

                                //break;
                            }


                        }
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task f8()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {



                        HtmlDocument doc = webBrowser1.Document;

                       
                        while (true)
                        {
                            HtmlElement elem6 = doc.GetElementById("k2");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem6 == null)
                                continue;


                            if (elem6 != null)
                                break; // no changes detected, end the poll loop


                        }

                       


                        HtmlElement elem4 = doc.GetElementById("k2");
                        elem4.InvokeMember("click");
                        await Task.Delay(3000);
                        HtmlElement elem5 = doc.GetElementById("btKindSelected");
                        elem5.InvokeMember("click");

                    }
                }
            
        }
        public async Task f7()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                       

                        HtmlDocument doc = webBrowser1.Document;
                      
                      
                        while (true)
                        {
                            HtmlElement elem6 = doc.GetElementById("btDetailSelected");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem6 == null)
                                continue;


                            if (elem6 != null)
                                break; // no changes detected, end the poll loop


                        }


                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {
                            
                            if (link.OuterHtml.Contains("detail_all")&& link.OuterHtml.Contains("d_category") )
                            {
                                // link.Click();
                                await Task.Delay(1000);
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");
                                await Task.Delay(1000);

                            }

                        }

                        await Task.Delay(3000);
                        HtmlElement elem5 = doc.GetElementById("btDetailSelected");
                        elem5.InvokeMember("click");


                    }
                }
            

        }
        public async Task f6()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                        HtmlDocument doc = webBrowser1.Document;

                      
                     
                        while (true)
                        {
                            HtmlElement elem4 = doc.GetElementById("allcheck_kenkis");

                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy
                           
                         
                            if (this.webBrowser1.IsBusy || elem4 == null)
                                continue;


                            if (elem4 != null)
                            {
                                await Task.Delay(2000);
                                elem4.InvokeMember("click");
                                break; // no changes detected, end the poll loop
                            }
                               

                           
                        }


                       
                      
                        while (true)
                        {
                            HtmlElement elem5 = doc.GetElementById("btSyasyuSelected");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem5 == null)
                                continue;


                            if (elem5 != null)
                            {
                                await Task.Delay(2000);
                                elem5.InvokeMember("click");
                                break; // no changes detected, end the poll loop
                            }

                        }
                      



                    }
                }
            
        }
        public async Task f5()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                        

                          HtmlDocument doc = webBrowser1.Document;
                    
                      
                        while (true)
                        {
                            HtmlElement elem5 = doc.GetElementById("username");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem5 == null)
                                continue;


                            if (elem5 != null)
                                break; // no changes detected, end the poll loop


                        }
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {
                            

                            if (link.InnerText.Contains(" Construction Machinery"))
                            {
                                // link.Click();
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");


                            }

                        }
                    }
                }
            

        }
        public async Task f4()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                        

                        HtmlDocument doc = webBrowser1.Document;
                        
                            
                        while (true)
                        {
                            HtmlElement elem5 = doc.GetElementById("next");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem5==null)
                                continue;


                            if (elem5!=null)
                                break; // no changes detected, end the poll loop


                        }
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {
                          

                            if (link.InnerText.Contains("Quick Search"))
                            {
                                // link.Click();
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");


                            }

                        }
                    }
                }
            

        }
        public async Task f3()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                       


                        HtmlDocument doc = webBrowser1.Document;
                       

                        while (true)
                        {
                            HtmlElement elem5 = doc.GetElementById("btAgree");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem5==null)
                                continue;


                            if (elem5!= null)
                                elem5.InvokeMember("click");
                            break; // no changes detected, end the poll loop


                        }


                       

                    }
                }
            
        }
        public async Task f2()
        {
           
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                       

                        HtmlDocument doc = webBrowser1.Document;
                  
                       
                      
                   

                        while (true)
                        {
                            HtmlElement elem1 = doc.GetElementById("btLogin");
                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem1 == null)
                                continue;


                            if (elem1 != null)
                                break; // no changes detected, end the poll loop


                        }
                       
                        HtmlElement elem2 = doc.GetElementById("txLogin");
                    elem2.SetAttribute("value", "OY14412");
                    //elem2.SetAttribute("value", "OY13356");
                        // elem1.InnerText = "OY13356";

                        HtmlElement elem3 = doc.GetElementById("txPasswd");
                    elem3.SetAttribute("value", "12saku14");
                    //elem3.SetAttribute("value", "SA201001");
                        // elem3.InnerText = "SA201001";

                        HtmlElement elem4 = doc.GetElementById("txUser");
                    elem4.SetAttribute("value", "OYAMA925");
                    //elem4.SetAttribute("value", "SLNET118");
                        //elem4.InnerText = "CESSNA7M";
                       // await Task.Delay(3000);
                        HtmlElement elem5 = doc.GetElementById("btLogin");
                        elem5.InvokeMember("click");
                       // await Task.Delay(1000);
                        //elem5.Document.InvokeScript("Login.onClickSend()", new object[] { "btLogin" });

                        // HtmlElement btnElement = webBrowser1.Document.All.GetElementsByName("btLogin")[0];
                        //  btnElement.InvokeMember("click");
                        //  webBrowser1.Document.GetElementById("btLogin").InvokeMember("click");

                        //HtmlElementCollection elem2 = doc.GetElementsByTagName("input");

                        //foreach (System.Windows.Forms.HtmlElement link in elem2)
                        //{


                        //    if (link.GetAttribute("id").Equals("btLogin"))
                        //    {
                        //        // link.Click();
                        //        HtmlElement btnElement1 = link;
                        //        btnElement1.SetAttribute("value", " Login ");
                        //        btnElement1.InvokeMember("click");


                        //    }

                        //}

                        // webBrowser1.Document.InvokeScript("Login.onClickSend();");
                        // webBrowser1.Navigate("https://www.araiaa-net.jp/confirm_en.html");
                    }
                }
            
        }

        public async Task f1()
        {
            
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {



                        HtmlDocument doc = webBrowser1.Document;
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {
                            link.SetAttribute("target", "_self");

                            if (link.GetAttribute("href").Equals("https://www.araiaa-net.jp/index_en.html"))
                            {
                                // link.Click();
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");


                            }

                        }
                    }
                }
           

        }

        /// ////////////////////////////////////////////////////////////////////////
        public async Task t10(HtmlElement btnElement)
        {
            try
            {
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                        btnElement.InvokeMember("click");
                        while (true)
                        {
                            await Task.Delay(500);
                            if (Form2.istru)
                                break;

                            if (Form2.istru == false)
                                continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }


        public async Task t11()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btResetFilter");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    try
                    {
                        while (true)
                        {
                            HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                            foreach (System.Windows.Forms.HtmlElement link in elem2)
                            {


                                if (link.OuterHtml.Contains("cmSyuppinList.Scroll.nextPage(cmSyuppinList)"))
                                {
                                    // link.Click();
                                    HtmlElement btnElement = link;
                                    btnElement.InvokeMember("click");
                                    await Task.Delay(3000);
                                    //  await f9();
                                    await Retry.Do(async () => await t9(), TimeSpan.FromSeconds(5));
                                    //await f11();
                                    await Retry.Do(async () => await t11(), TimeSpan.FromSeconds(5));
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {


                    }

                }
            }


        }


        public async Task t9()
        {
            try
            {

                if (webBrowser1.Document != null)

                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                        HtmlDocument doc1 = webBrowser1.Document;
                        HtmlDocument doc = webBrowser1.Document;

                        while (true)
                        {
                            HtmlElement elem6 = doc1.GetElementById("btResetFilter");
                            HtmlElement elem7 = doc1.GetElementById("loading");

                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem6 == null || elem7 != null)
                                continue;


                            if (elem6 != null && elem7 == null)
                                break; // no changes detected, end the poll loop


                        }
                        await Task.Delay(3000);
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                       
                        //foreach (System.Windows.Forms.HtmlElement link in elem2)
                        //{
                        //    link.SetAttribute("target", "_self");

                        //        if (link.InnerText=="502")
                        //    {


                        //        HtmlElement btnElement = link;
                        //        btnElement.InvokeMember("click");


                        //    }

                        //}

                        try
                        {
                            HtmlDocument doc3 = webBrowser1.Document;
                            HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                            int rcnnt = 0;
                            String scnt = "";
                            foreach (HtmlElement TBL in tables)
                            {
                                if (lgoff == true)
                                {
                                    break;
                                }
                                foreach (HtmlElement ROW in TBL.GetElementsByTagName("tr"))
                                {
                                    //HtmlElement btnElement1 = ROW.GetAttribute("td");
                                    //Form2.modelyr = btnElement1.InnerText;
                                    foreach (HtmlElement ROW1 in TBL.GetElementsByTagName("td"))
                                    {

                                        HtmlElementCollection elem3 = ROW1.GetElementsByTagName("a");

                                        foreach (System.Windows.Forms.HtmlElement link in elem3)
                                        {
                                            DataSet odsvoltxndata1 = new DataSet();

                                            if (link.GetAttribute("href").Contains("cmSyuppinList.onClickSno") && ROW1.OuterHtml.Contains("sp03"))
                                            {

                                                if (rcnnt.ToString().Length == 1)
                                                {
                                                    scnt = "0" + rcnnt.ToString();
                                                }
                                                else
                                                {
                                                    scnt = rcnnt.ToString();
                                                }
                                                rcnnt++;
                                                HtmlElement btnElement1 = doc3.GetElementById("sp12" + scnt);
                                               
                                                //Form2.modelyr = btnElement1.InnerText;

                                                HtmlElement btnElement = link;
                                                Form2.uril = link.InnerText;
                                                ////////////////////////////////////////////
                                                try
                                                {
                                                   
                                                    String catid = "";
                                                    oSqlConnection = new SqlConnection(constr);
                                                    oSqlCommand = new SqlCommand();
                                                    sqlQuery = "  SELECT EntryNo,UId FROM [dbo].[ProductInfo]  where   EntryNo='" + link.InnerText + "' and Status=2 ";
                                                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                    oSqlCommand.Connection = oSqlConnection;
                                                    oSqlCommand.CommandText = sqlQuery;
                                                    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                    oSqlConnection.Open();
                                                    // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                    oSqlDataAdapter.Fill(odsvoltxndata1);
                                                    oSqlConnection.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    label3.Text = ex.ToString();

                                                }
                                                ///////////////////////////////////////////////////

                                               
                                                    if (odsvoltxndata1.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (Convert.ToInt32(odsvoltxndata1.Tables[0].Rows[0]["EntryNo"].ToString()) == Convert.ToInt32(link.InnerText))
                                                        {
                                                        try
                                                        {
                                                            string[] newcat = btnElement1.InnerText.Split('\r');
                                                            string newcat2 = newcat[0];
                                                            string replacement = Regex.Replace(newcat[1], @"\t|\n|\r", "");
                                                            string noHTMLNormalised14 = stParse(newcat2);
                                                            string numberOnly = Regex.Replace(noHTMLNormalised14, "[^0-9.]", "");
                                                            Decimal starp = Convert.ToDecimal(numberOnly);
                                                            // oSqlConnection = new SqlConnection(constr);

                                                            if (replacement.Equals("sold"))
                                                            {

                                                                oSqlCommand = new SqlCommand();
                                                                sqlQuery = "update [dbo].[ProductInfo] set BuynowPrice='" + starp + "',notify='" + replacement + "',IsSold=1 where EntryNo='" + link.InnerText + "' and Status=2  ";
                                                                //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                                oSqlCommand.Connection = oSqlConnection;
                                                                oSqlCommand.CommandText = sqlQuery;
                                                                //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                                oSqlConnection.Open();
                                                                oSqlCommand.ExecuteScalar();
                                                                oSqlConnection.Close();

                                                            }
                                                            else
                                                            {
                                                               
                                                                try
                                                                {

                                                                    oSqlCommand = new SqlCommand();
                                                                    sqlQuery = "update [dbo].[ProductInfo] set BuynowPrice='" + starp + "',notify='" + replacement + "',IsSold=0 where EntryNo='" + link.InnerText + "' and Status=2  ";
                                                                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                                    oSqlCommand.Connection = oSqlConnection;
                                                                    oSqlCommand.CommandText = sqlQuery;
                                                                    //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                                    oSqlConnection.Open();
                                                                    oSqlCommand.ExecuteScalar();
                                                                    oSqlConnection.Close();
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    label3.Text = ex.ToString();
                                                                }
                                                            }

                                                          

                                                            




                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            label3.Text = ex.ToString();

                                                        }
                                                    }
                                                    }
                                                    else
                                                    {
                                                        
                                                    }
                                                
                                               
                                                // await f10(btnElement);


                                            }

                                        }

/////////////////////////////



                                        

                                    }

                                    //break;
                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            label3.Text = ex.ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                label3.Text = ex.ToString();
            }
        }
        public async Task t8()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem6 = doc.GetElementById("k2");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null)
                            break; // no changes detected, end the poll loop


                    }




                    HtmlElement elem4 = doc.GetElementById("k2");
                    elem4.InvokeMember("click");
                    await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btKindSelected");
                    elem5.InvokeMember("click");

                }
            }

        }
        public async Task t7()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem6 = doc.GetElementById("btDetailSelected");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null)
                            break; // no changes detected, end the poll loop


                    }


                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {

                        if (link.OuterHtml.Contains("detail_all") && link.OuterHtml.Contains("d_category"))
                        {
                            // link.Click();
                            await Task.Delay(1000);
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");
                            await Task.Delay(1000);

                        }

                    }

                    await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btDetailSelected");
                    elem5.InvokeMember("click");


                }
            }


        }
        public async Task t6()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {
                    HtmlDocument doc = webBrowser1.Document;



                    while (true)
                    {
                        HtmlElement elem4 = doc.GetElementById("allcheck_kenkis");

                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem4 == null)
                            continue;


                        if (elem4 != null)
                        {
                            await Task.Delay(2000);
                            elem4.InvokeMember("click");
                            break; // no changes detected, end the poll loop
                        }



                    }




                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btSyasyuSelected");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                        {
                            await Task.Delay(2000);
                            elem5.InvokeMember("click");
                            break; // no changes detected, end the poll loop
                        }

                    }




                }
            }

        }
        public async Task t5()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("username");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {


                        if (link.InnerText.Contains(" Construction Machinery"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        public async Task t4()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("next");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {


                        if (link.InnerText.Contains("Quick Search"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        public async Task t3()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btAgree");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            elem5.InvokeMember("click");
                        break; // no changes detected, end the poll loop


                    }




                }
            }

        }
        public async Task t2()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;





                    while (true)
                    {
                        HtmlElement elem1 = doc.GetElementById("btLogin");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem1 == null)
                            continue;


                        if (elem1 != null)
                            break; // no changes detected, end the poll loop


                    }

                    HtmlElement elem2 = doc.GetElementById("txLogin");
                    elem2.SetAttribute("value", "OY13356");
                    // elem1.InnerText = "OY13356";

                    HtmlElement elem3 = doc.GetElementById("txPasswd");
                    elem3.SetAttribute("value", "SA201001");
                    // elem3.InnerText = "SA201001";

                    HtmlElement elem4 = doc.GetElementById("txUser");
                    elem4.SetAttribute("value", "SLNET118");
                    //elem4.InnerText = "CESSNA7M";
                    // await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btLogin");
                    elem5.InvokeMember("click");
                    // await Task.Delay(1000);
                    //elem5.Document.InvokeScript("Login.onClickSend()", new object[] { "btLogin" });

                    // HtmlElement btnElement = webBrowser1.Document.All.GetElementsByName("btLogin")[0];
                    //  btnElement.InvokeMember("click");
                    //  webBrowser1.Document.GetElementById("btLogin").InvokeMember("click");

                    //HtmlElementCollection elem2 = doc.GetElementsByTagName("input");

                    //foreach (System.Windows.Forms.HtmlElement link in elem2)
                    //{


                    //    if (link.GetAttribute("id").Equals("btLogin"))
                    //    {
                    //        // link.Click();
                    //        HtmlElement btnElement1 = link;
                    //        btnElement1.SetAttribute("value", " Login ");
                    //        btnElement1.InvokeMember("click");


                    //    }

                    //}

                    // webBrowser1.Document.InvokeScript("Login.onClickSend();");
                    // webBrowser1.Navigate("https://www.araiaa-net.jp/confirm_en.html");
                }
            }

        }

        public async Task t1()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {
                        link.SetAttribute("target", "_self");

                        if (link.GetAttribute("href").Equals("https://www.araiaa-net.jp/index_en.html"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        //////////////////////////////////////////////////////////////////////////////
        public async Task v10(HtmlElement btnElement)
        {
            try
            {
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                        btnElement.InvokeMember("click");
                        while (true)
                        {
                            await Task.Delay(500);
                            if (Form2.istru)
                                break;

                            if (Form2.istru == false)
                                continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }


        public async Task v11()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btResetFilter");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    try
                    {

                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {


                            if (link.OuterHtml.Contains("cmSyuppinList.Scroll.nextPage(cmSyuppinList)"))
                            {
                                // link.Click();
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");
                                await Task.Delay(1000);
                                //  await f9();
                                await Retry.Do(async () => await v9(), TimeSpan.FromSeconds(5));
                                //await f11();
                                await Retry.Do(async () => await v11(), TimeSpan.FromSeconds(5));
                            }

                        }
                    }
                    catch (Exception ex)
                    {


                    }

                }
            }


        }


        public async Task v9()
        {
            try
            {

                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                        HtmlDocument doc1 = webBrowser1.Document;
                        HtmlDocument doc = webBrowser1.Document;

                        while (true)
                        {
                            HtmlElement elem6 = doc1.GetElementById("btResetFilter");
                            HtmlElement elem7 = doc1.GetElementById("loading");

                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem6 == null || elem7 != null)
                                continue;


                            if (elem6 != null && elem7 == null)
                                break; // no changes detected, end the poll loop


                        }
                        await Task.Delay(3000);
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        //foreach (System.Windows.Forms.HtmlElement link in elem2)
                        //{
                        //    link.SetAttribute("target", "_self");

                        //        if (link.InnerText=="502")
                        //    {


                        //        HtmlElement btnElement = link;
                        //        btnElement.InvokeMember("click");


                        //    }

                        //}

                        try
                        {
                            HtmlDocument doc3 = webBrowser1.Document;
                            HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                            int rcnnt = 0;
                            String scnt = "";
                            foreach (HtmlElement TBL in tables)
                            {
                                foreach (HtmlElement ROW in TBL.GetElementsByTagName("tr"))
                                {
                                    //HtmlElement btnElement1 = ROW.GetAttribute("td");
                                    //Form2.modelyr = btnElement1.InnerText;
                                    foreach (HtmlElement ROW1 in TBL.GetElementsByTagName("td"))
                                    {
                                        DataSet odsvoltxndata1 = new DataSet();
                                        HtmlElementCollection elem3 = ROW1.GetElementsByTagName("a");

                                        foreach (System.Windows.Forms.HtmlElement link in elem3)
                                        {


                                            if (link.GetAttribute("href").Contains("cmSyuppinList.onClickSno") && ROW1.OuterHtml.Contains("sp03"))
                                            {

                                                if (rcnnt.ToString().Length == 1)
                                                {
                                                    scnt = "0" + rcnnt.ToString();
                                                }
                                                else
                                                {
                                                    scnt = rcnnt.ToString();
                                                }
                                                rcnnt++;
                                                HtmlElement btnElement1 = doc3.GetElementById("sp04" + scnt);
                                                Form2.modelyr = btnElement1.InnerText;
                                                Form2.sts = "2";
                                                HtmlElement btnElement = link;
                                                Form2.uril = link.InnerText;
                                                ////////////////////////////////////////////
                                               
                                                ///////////////////////////////////////////////////

                                                
                                                   
                                                        if (textBox1.Text == link.InnerText)
                                                        {
                                                    await Retry.Do(async () => await v10(btnElement), TimeSpan.FromSeconds(5));
                                                    await Task.Delay(500);
                                                }
                                                   
                                                // await f10(btnElement);


                                            }

                                        }

                                    }

                                    break;
                                }


                            }
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task v8()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem6 = doc.GetElementById("k2");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null)
                            break; // no changes detected, end the poll loop


                    }




                    HtmlElement elem4 = doc.GetElementById("k2");
                    elem4.InvokeMember("click");
                    await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btKindSelected");
                    elem5.InvokeMember("click");

                }
            }

        }
        public async Task v7()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem6 = doc.GetElementById("btDetailSelected");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null)
                            break; // no changes detected, end the poll loop


                    }


                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {

                        if (link.OuterHtml.Contains("detail_all") && link.OuterHtml.Contains("d_category"))
                        {
                            // link.Click();
                            await Task.Delay(1000);
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");
                            await Task.Delay(1000);

                        }

                    }

                    await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btDetailSelected");
                    elem5.InvokeMember("click");


                }
            }


        }
        public async Task v6()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {
                    HtmlDocument doc = webBrowser1.Document;



                    while (true)
                    {
                        HtmlElement elem4 = doc.GetElementById("allcheck_kenkis");

                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem4 == null)
                            continue;


                        if (elem4 != null)
                        {
                            await Task.Delay(2000);
                            elem4.InvokeMember("click");
                            break; // no changes detected, end the poll loop
                        }



                    }




                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btSyasyuSelected");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                        {
                            await Task.Delay(2000);
                            elem5.InvokeMember("click");
                            break; // no changes detected, end the poll loop
                        }

                    }




                }
            }

        }
        public async Task v5()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("username");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {


                        if (link.InnerText.Contains(" Construction Machinery"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        public async Task v4()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("next");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {


                        if (link.InnerText.Contains("Quick Search"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        public async Task v3()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btAgree");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            elem5.InvokeMember("click");
                        break; // no changes detected, end the poll loop


                    }




                }
            }

        }
        public async Task v2()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;





                    while (true)
                    {
                        HtmlElement elem1 = doc.GetElementById("btLogin");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem1 == null)
                            continue;


                        if (elem1 != null)
                            break; // no changes detected, end the poll loop


                    }

                    HtmlElement elem2 = doc.GetElementById("txLogin");
                    elem2.SetAttribute("value", "OY13356");
                    // elem1.InnerText = "OY13356";

                    HtmlElement elem3 = doc.GetElementById("txPasswd");
                    elem3.SetAttribute("value", "SA201001");
                    // elem3.InnerText = "SA201001";

                    HtmlElement elem4 = doc.GetElementById("txUser");
                    elem4.SetAttribute("value", "SLNET118");
                    //elem4.InnerText = "CESSNA7M";
                    // await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btLogin");
                    elem5.InvokeMember("click");
                    // await Task.Delay(1000);
                    //elem5.Document.InvokeScript("Login.onClickSend()", new object[] { "btLogin" });

                    // HtmlElement btnElement = webBrowser1.Document.All.GetElementsByName("btLogin")[0];
                    //  btnElement.InvokeMember("click");
                    //  webBrowser1.Document.GetElementById("btLogin").InvokeMember("click");

                    //HtmlElementCollection elem2 = doc.GetElementsByTagName("input");

                    //foreach (System.Windows.Forms.HtmlElement link in elem2)
                    //{


                    //    if (link.GetAttribute("id").Equals("btLogin"))
                    //    {
                    //        // link.Click();
                    //        HtmlElement btnElement1 = link;
                    //        btnElement1.SetAttribute("value", " Login ");
                    //        btnElement1.InvokeMember("click");


                    //    }

                    //}

                    // webBrowser1.Document.InvokeScript("Login.onClickSend();");
                    // webBrowser1.Navigate("https://www.araiaa-net.jp/confirm_en.html");
                }
            }

        }

        public async Task v1()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {
                        link.SetAttribute("target", "_self");

                        if (link.GetAttribute("href").Equals("https://www.araiaa-net.jp/index_en.html"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        /// //////////////////////////////////////////////////////////////////////////////////

        public async Task b10(HtmlElement btnElement)
        {
            try
            {
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {
                        btnElement.InvokeMember("click");
                        while (true)
                        {
                            await Task.Delay(500);
                            if (Form2.istru)
                                break;

                            if (Form2.istru == false)
                                continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }


        public async Task b11()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btResetFilter");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    try
                    {

                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {


                            if (link.OuterHtml.Contains("soubaList.Scroll.nextPage(soubaList)"))
                            {
                                // link.Click();
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");
                                await Task.Delay(1000);
                                //  await f9();
                                await Retry.Do(async () => await b9(), TimeSpan.FromSeconds(5));
                                //await f11();
                                await Retry.Do(async () => await b11(), TimeSpan.FromSeconds(5));
                            }

                        }
                    }
                    catch (Exception ex)
                    {


                    }

                }
            }


        }


        public async Task b9()
        {
            try
            {

                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {

                        HtmlDocument doc1 = webBrowser1.Document;
                        HtmlDocument doc = webBrowser1.Document;

                        while (true)
                        {
                            HtmlElement elem6 = doc1.GetElementById("btResetFilter");
                            HtmlElement elem7 = doc1.GetElementById("loading");

                            // wait asynchronously, this will throw if cancellation requested
                            await Task.Delay(500);

                            // continue polling if the WebBrowser is still busy


                            if (this.webBrowser1.IsBusy || elem6 == null || elem7 != null)
                                continue;


                            if (elem6 != null && elem7 == null)
                                break; // no changes detected, end the poll loop


                        }
                        await Task.Delay(3000);
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        //foreach (System.Windows.Forms.HtmlElement link in elem2)
                        //{
                        //    link.SetAttribute("target", "_self");

                        //        if (link.InnerText=="502")
                        //    {


                        //        HtmlElement btnElement = link;
                        //        btnElement.InvokeMember("click");


                        //    }

                        //}

                        try
                        {
                            HtmlDocument doc3 = webBrowser1.Document;
                            HtmlElementCollection tables = this.webBrowser1.Document.GetElementsByTagName("table");
                            int rcnnt = 0;
                            String scnt = "";
                            foreach (HtmlElement TBL in tables)
                            {
                                foreach (HtmlElement ROW in TBL.GetElementsByTagName("tr"))
                                {
                                    //HtmlElement btnElement1 = ROW.GetAttribute("td");
                                    //Form2.modelyr = btnElement1.InnerText;
                                    foreach (HtmlElement ROW1 in TBL.GetElementsByTagName("td"))
                                    {
                                        DataSet odsvoltxndata1 = new DataSet();
                                        HtmlElementCollection elem3 = ROW1.GetElementsByTagName("a");

                                        foreach (System.Windows.Forms.HtmlElement link in elem3)
                                        {


                                            if (link.GetAttribute("href").Contains("cmSyuppinList.onClickSno") && ROW1.OuterHtml.Contains("sp03"))
                                            {

                                                if (rcnnt.ToString().Length == 1)
                                                {
                                                    scnt = "0" + rcnnt.ToString();
                                                }
                                                else
                                                {
                                                    scnt = rcnnt.ToString();
                                                }
                                                rcnnt++;
                                                HtmlElement btnElement1 = doc3.GetElementById("sp04" + scnt);
                                                Form2.modelyr = btnElement1.InnerText;
                                                Form2.sts = "3";
                                                HtmlElement btnElement = link;
                                                Form2.uril = link.InnerText;
                                                HtmlElement btnElement3= doc3.GetElementById("sp12" + scnt);
                                                HtmlElement btnElement5 = doc3.GetElementById("sp02" + scnt);
                                                Form2.loc = btnElement5.InnerText; 
                                                string noHTMLNormalised14 = stParse(btnElement3.InnerText);
                                                string numberOnly = Regex.Replace(noHTMLNormalised14, "[^0-9.]", "");
                                                Decimal starp = Convert.ToDecimal(numberOnly);
                                                Form2.starp = starp;
                                                ////////////////////////////////////////////
                                                //try
                                                //{

                                                //    String catid = "";
                                                //    oSqlConnection = new SqlConnection(constr);
                                                //    oSqlCommand = new SqlCommand();
                                                //    sqlQuery = "  SELECT EntryNo FROM [dbo].[ProductInfo]  where   EntryNo='" + link.InnerText + "' and Status=3 ";
                                                //    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                //    oSqlCommand.Connection = oSqlConnection;
                                                //    oSqlCommand.CommandText = sqlQuery;
                                                //    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                //    oSqlConnection.Open();
                                                //    // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                //    oSqlDataAdapter.Fill(odsvoltxndata1);
                                                //    oSqlConnection.Close();
                                                //}
                                                //catch (Exception ex)
                                                //{


                                                //}
                                                ///////////////////////////////////////////////////

                                                //if (isstartfrom == true)
                                                //{
                                                //    if (odsvoltxndata1.Tables[0].Rows.Count > 0)
                                                //    {
                                                //        if (Convert.ToInt32(odsvoltxndata1.Tables[0].Rows[0]["EntryNo"].ToString()) == Convert.ToInt32(link.InnerText))
                                                //        {
                                                //            //await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                //            //await Task.Delay(500);
                                                //        }
                                                //    }
                                                //    else
                                                //    {
                                                //        await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                //        await Task.Delay(500);
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //if (odsvoltxndata1.Tables[0].Rows.Count > 0)
                                                //{
                                                //    if (Convert.ToInt32(odsvoltxndata1.Tables[0].Rows[0]["EntryNo"].ToString()) == Convert.ToInt32(link.InnerText))
                                                //    {
                                                //        //await Retry.Do(async () => await f10(btnElement), TimeSpan.FromSeconds(5));
                                                //        //await Task.Delay(500);
                                                //    }
                                                //}
                                                //else
                                                //{
                                                
                                                     HtmlElement fromto = doc3.GetElementById("from_to");
                                                if (fromto.InnerText.Trim().ToLower().Replace(" ","")==textBox2.Text&& isbypage==1) {
                                                    isdelect = true;
                                                }
                                                string dte = btnElement5.InnerText.Split(' ')[2].Trim().ToLower().Replace(" ", "");
                                                if (dte == textBox2.Text && isbypage == 2)
                                                {
                                                    await Retry.Do(async () => await b10(btnElement), TimeSpan.FromSeconds(5));
                                                    await Task.Delay(500);
                                                }
                                                if (dte == textBox2.Text && isbypage == 3)
                                                {
                                                    try
                                                    {

                                                        String catid = "";
                                                        oSqlConnection = new SqlConnection(constr);
                                                        oSqlCommand = new SqlCommand();
                                                        sqlQuery = "  SELECT EntryNo,UId FROM [dbo].[ProductInfo]  where   EntryNo='" + link.InnerText + "' and Status=3 ";
                                                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                        oSqlCommand.Connection = oSqlConnection;
                                                        oSqlCommand.CommandText = sqlQuery;
                                                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                        oSqlConnection.Open();
                                                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                        oSqlDataAdapter.Fill(odsvoltxndata1);
                                                        oSqlConnection.Close();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        label3.Text = ex.ToString();

                                                    }
                                                    ///////////////////////////////////////////////////


                                                    if (odsvoltxndata1.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (Convert.ToInt32(odsvoltxndata1.Tables[0].Rows[0]["EntryNo"].ToString()) == Convert.ToInt32(link.InnerText))
                                                        {
                                                            try
                                                            {
                                                                string[] newcat = btnElement3.InnerText.Split('\r');
                                                                string newcat2 = newcat[0];
                                                                string replacement = Regex.Replace(newcat[1], @"\t|\n|\r", "");
                                                               
                                                                // oSqlConnection = new SqlConnection(constr);

                                                                if (replacement.Equals("sold"))
                                                                {
                                                                    oSqlCommand = new SqlCommand();
                                                                    sqlQuery = "update [dbo].[ProductInfo] set BuynowPrice='" + starp + "',notify='" + replacement + "',Status=3,IsSold=1 where EntryNo='" + link.InnerText + "' and Status=3  ";
                                                                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                                                                    oSqlCommand.Connection = oSqlConnection;
                                                                    oSqlCommand.CommandText = sqlQuery;
                                                                    //oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                                                                    oSqlConnection.Open();
                                                                    oSqlCommand.ExecuteScalar();
                                                                    oSqlConnection.Close();

                                                                }
                                                                








                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                label3.Text = ex.ToString();

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                if (isdelect == true)
                                                {
                                                    await Retry.Do(async () => await b10(btnElement), TimeSpan.FromSeconds(5));
                                                    await Task.Delay(500);
                                                }
                                                    //}
                                                //}
                                                // await f10(btnElement);


                                            }

                                        }

                                    }

                                    break;
                                }


                            }
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task b8()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem6 = doc.GetElementById("k2");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null)
                            break; // no changes detected, end the poll loop


                    }




                    HtmlElement elem4 = doc.GetElementById("k2");
                    elem4.InvokeMember("click");
                    await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btKindSelected");
                    elem5.InvokeMember("click");

                }
            }

        }
        public async Task b7()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem6 = doc.GetElementById("btDetailSelected");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem6 == null)
                            continue;


                        if (elem6 != null)
                            break; // no changes detected, end the poll loop


                    }


                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {

                        if (link.OuterHtml.Contains("detail_all") && link.OuterHtml.Contains("d_category"))
                        {
                            // link.Click();
                            await Task.Delay(1000);
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");
                            await Task.Delay(1000);

                        }
                        if (link.OuterHtml.Contains("detail_all") && link.OuterHtml.Contains("d_maker"))
                        {
                            // link.Click();
                            await Task.Delay(1000);
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");
                            await Task.Delay(1000);

                        }
                        if (link.OuterHtml.Contains("detail_all") && link.OuterHtml.Contains("d_size"))
                        {
                            // link.Click();
                            await Task.Delay(1000);
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");
                            await Task.Delay(1000);

                        }
                    }

                    await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btDetailSelected");
                    elem5.InvokeMember("click");


                }
            }


        }
        public async Task b6()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {
                    HtmlDocument doc = webBrowser1.Document;



                    while (true)
                    {
                        HtmlElement elem4 = doc.GetElementById("allcheck_kenkis");

                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem4 == null)
                            continue;


                        if (elem4 != null)
                        {
                            await Task.Delay(2000);
                            elem4.InvokeMember("click");
                            break; // no changes detected, end the poll loop
                        }



                    }




                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btSyasyuSelected");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                        {
                            await Task.Delay(2000);
                            elem5.InvokeMember("click");
                            break; // no changes detected, end the poll loop
                        }

                    }




                }
            }

        }
        public async Task b5()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("username");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    
 HtmlElement elemf = doc.GetElementById("souba");
                    elemf.InvokeMember("click");
                    await Task.Delay(500);
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");
                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {


                        if (link.InnerText.Contains(" Construction Machinery"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        public async Task b4()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {


                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("next");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            break; // no changes detected, end the poll loop


                    }
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {


                        if (link.InnerText.Contains("Quick Search"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }
        public async Task b3()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;


                    while (true)
                    {
                        HtmlElement elem5 = doc.GetElementById("btAgree");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem5 == null)
                            continue;


                        if (elem5 != null)
                            elem5.InvokeMember("click");
                        break; // no changes detected, end the poll loop


                    }




                }
            }

        }
        public async Task b2()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;





                    while (true)
                    {
                        HtmlElement elem1 = doc.GetElementById("btLogin");
                        // wait asynchronously, this will throw if cancellation requested
                        await Task.Delay(500);

                        // continue polling if the WebBrowser is still busy


                        if (this.webBrowser1.IsBusy || elem1 == null)
                            continue;


                        if (elem1 != null)
                            break; // no changes detected, end the poll loop


                    }

                    HtmlElement elem2 = doc.GetElementById("txLogin");
                    elem2.SetAttribute("value", "OY13356");
                    // elem1.InnerText = "OY13356";

                    HtmlElement elem3 = doc.GetElementById("txPasswd");
                    elem3.SetAttribute("value", "SA201001");
                    // elem3.InnerText = "SA201001";

                    HtmlElement elem4 = doc.GetElementById("txUser");
                    elem4.SetAttribute("value", "SLNET118");
                    //elem4.InnerText = "CESSNA7M";
                    // await Task.Delay(3000);
                    HtmlElement elem5 = doc.GetElementById("btLogin");
                    elem5.InvokeMember("click");
                    // await Task.Delay(1000);
                    //elem5.Document.InvokeScript("Login.onClickSend()", new object[] { "btLogin" });

                    // HtmlElement btnElement = webBrowser1.Document.All.GetElementsByName("btLogin")[0];
                    //  btnElement.InvokeMember("click");
                    //  webBrowser1.Document.GetElementById("btLogin").InvokeMember("click");

                    //HtmlElementCollection elem2 = doc.GetElementsByTagName("input");

                    //foreach (System.Windows.Forms.HtmlElement link in elem2)
                    //{


                    //    if (link.GetAttribute("id").Equals("btLogin"))
                    //    {
                    //        // link.Click();
                    //        HtmlElement btnElement1 = link;
                    //        btnElement1.SetAttribute("value", " Login ");
                    //        btnElement1.InvokeMember("click");


                    //    }

                    //}

                    // webBrowser1.Document.InvokeScript("Login.onClickSend();");
                    // webBrowser1.Navigate("https://www.araiaa-net.jp/confirm_en.html");
                }
            }

        }

        public async Task b1()
        {

            if (webBrowser1.Document != null)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                {



                    HtmlDocument doc = webBrowser1.Document;
                    HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                    foreach (System.Windows.Forms.HtmlElement link in elem2)
                    {
                        link.SetAttribute("target", "_self");

                        if (link.GetAttribute("href").Equals("https://www.araiaa-net.jp/index_en.html"))
                        {
                            // link.Click();
                            HtmlElement btnElement = link;
                            btnElement.InvokeMember("click");


                        }

                    }
                }
            }


        }

        /// ///////////////////////////////////////////////////////////////////////////////////


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
        private void WorkerMethod(object sender, WaitWindowEventArgs e)
        {
            System.Threading.Thread.Sleep(4000);
            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                e.Result = "Hello World";
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.label1.Text))
            {
                MessageBox.Show("Please Select Temperory Download Location!");
            }
            else
            {
                if (isstartfrom == true &&( radioButton1.Checked != true || radioButton2.Checked != true))
                {

                }
                    if (isstartfrom == true&&radioButton1.Checked == true)
                {

                   
                    ////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery = "delete FROM [dbo].[ProdImage] WHERE ProductId IN(   SELECT e.UId  FROM [dbo].[ProductInfo]  e  WHERE e.Status = 2)";
                            //" delete FROM [dbo].[ProductInfo] as a inner join [dbo].[ProdImage] as b on a.UId=b.ProductId where  a.Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                    ///////////////////////////////////////////////////
                    ////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery = "delete FROM   [dbo].[ProductInfo]    WHERE Status = 2";
                        //" delete FROM [dbo].[ProductInfo] as a inner join [dbo].[ProdImage] as b on a.UId=b.ProductId where  a.Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                    ///////////////////////////////////////////////////
                    ////////////////////////////////////////////
                    //try
                    //{

                    //    String catid = "";
                    //    oSqlConnection = new SqlConnection(constr);
                    //    oSqlCommand = new SqlCommand();
                    //    sqlQuery = "  delete FROM [netauction_sakuraijp].[dbo].[ProdImage] ";
                    //    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                    //    oSqlCommand.Connection = oSqlConnection;
                    //    oSqlCommand.CommandText = sqlQuery;
                    //    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    //    oSqlConnection.Open();
                    //    // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    //    oSqlCommand.ExecuteNonQuery();
                    //    oSqlConnection.Close();
                    //}
                    //catch (Exception ex)
                    //{


                    //}
                    ///////////////////////////////////////////////////

                    /////////////////////////////////////////////////////

                }
                if (isstartfrom == true && radioButton2.Checked == true)
                {
                    ////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery = "  update  [dbo].[ProductInfo] set  Status=3 where  Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                    ///////////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery = "delete FROM [dbo].[ProdImage] WHERE ProductId IN(   SELECT e.UId  FROM [dbo].[ProductInfo]  e  WHERE e.Status = 2 AND e.IsSold IS NULL)";
                        //" delete FROM [dbo].[ProductInfo] as a inner join [dbo].[ProdImage] as b on a.UId=b.ProductId where  a.Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                    ///////////////////////////////////////////////////
                    ////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery = "delete FROM   [dbo].[ProductInfo]    WHERE Status = 2  AND IsSold IS NULL ";
                        //" delete FROM [dbo].[ProductInfo] as a inner join [dbo].[ProdImage] as b on a.UId=b.ProductId where  a.Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                    ///////////////////////////////////////////////////
                    ////////////////////////////////////////////
                    /////////////////////////////////////////////////////

                }
                button1.Enabled = false;
                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //  await f1();

                await Retry.Do(async () => await f1(), TimeSpan.FromSeconds(5));
                isLoaded = false;


                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                // await f2();
                await Retry.Do(async () => await f2(), TimeSpan.FromSeconds(5));
                isLoaded = false;

                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //await f3();
                await Retry.Do(async () => await f3(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                // await f4();
                await Retry.Do(async () => await f4(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                //await f5();
                await Retry.Do(async () => await f5(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                //await f6();
                await Retry.Do(async () => await f6(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;

                //await Task.Delay(3000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                // await f7();
                await Retry.Do(async () => await f7(), TimeSpan.FromSeconds(5));
                // await Task.Delay(3000);
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                //  await f8();
                await Retry.Do(async () => await f8(), TimeSpan.FromSeconds(5));
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                // await f9();
                await Retry.Do(async () => await f9(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;
                // await f11();
                await Retry.Do(async () => await f11(), TimeSpan.FromSeconds(5));
            }
        }
        public async void livefeed()
        {
            if (String.IsNullOrEmpty(this.label1.Text))
            {
                MessageBox.Show("Please Select Temperory Download Location!");
            }
            else
            {
               
                
                button1.Enabled = false;
                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //  await f1();

                await Retry.Do(async () => await f1(), TimeSpan.FromSeconds(5));
                isLoaded = false;


                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                // await f2();
                await Retry.Do(async () => await f2(), TimeSpan.FromSeconds(5));
                isLoaded = false;

                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //await f3();
                await Retry.Do(async () => await f3(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                // await f4();
                await Retry.Do(async () => await f4(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                //await f5();
                await Retry.Do(async () => await f5(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                //await f6();
                await Retry.Do(async () => await f6(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;

                //await Task.Delay(3000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                // await f7();
                await Retry.Do(async () => await f7(), TimeSpan.FromSeconds(5));
                // await Task.Delay(3000);
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                //  await f8();
                await Retry.Do(async () => await f8(), TimeSpan.FromSeconds(5));
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                // await f9();
                await Retry.Do(async () => await f9(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;
                // await f11();
                await Retry.Do(async () => await f11(), TimeSpan.FromSeconds(5));
            }

        }
        public async void livefeeddelete()
        {
            if (String.IsNullOrEmpty(this.label1.Text))
            {
                MessageBox.Show("Please Select Temperory Download Location!");
            }
            else
            {

                ////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery =  "delete FROM [dbo].[ProdImage]  WHERE ProductId IN(SELECT e.UId FROM [dbo].[ProductInfo]  e WHERE e.Status = 2)";
                        //" delete FROM [dbo].[ProductInfo] as a inner join [dbo].[ProdImage] as b on a.UId=b.ProductId where  a.Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                ///////////////////////////////////////////////////
                ////////////////////////////////////////////
                try
                {

                    String catid = "";
                    oSqlConnection = new SqlConnection(constr);
                    oSqlCommand = new SqlCommand();
                    sqlQuery = "delete FROM   [dbo].[ProductInfo]    WHERE Status = 2";
                    //" delete FROM [dbo].[ProductInfo] as a inner join [dbo].[ProdImage] as b on a.UId=b.ProductId where  a.Status=2 ";
                    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                    oSqlCommand.Connection = oSqlConnection;
                    oSqlCommand.CommandText = sqlQuery;
                    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlConnection.Open();
                    // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlCommand.ExecuteNonQuery();
                    oSqlConnection.Close();
                }
                catch (Exception ex)
                {


                }
                ///////////////////////////////////////////////////
                ////////////////////////////////////////////
                //try
                //{

                //    String catid = "";
                //    oSqlConnection = new SqlConnection(constr);
                //    oSqlCommand = new SqlCommand();
                //    sqlQuery = "  delete FROM [netauction_sakuraijp].[dbo].[ProdImage] ";
                //    //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                //    oSqlCommand.Connection = oSqlConnection;
                //    oSqlCommand.CommandText = sqlQuery;
                //    oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                //    oSqlConnection.Open();
                //    // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                //    oSqlCommand.ExecuteNonQuery();
                //    oSqlConnection.Close();
                //}
                //catch (Exception ex)
                //{


                //}
                ///////////////////////////////////////////////////

                /////////////////////////////////////////////////////


                button1.Enabled = false;
                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //  await f1();

                await Retry.Do(async () => await f1(), TimeSpan.FromSeconds(5));
                isLoaded = false;


                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                // await f2();
                await Retry.Do(async () => await f2(), TimeSpan.FromSeconds(5));
                isLoaded = false;

                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //await f3();
                await Retry.Do(async () => await f3(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                // await f4();
                await Retry.Do(async () => await f4(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                //await f5();
                await Retry.Do(async () => await f5(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                //await f6();
                await Retry.Do(async () => await f6(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;

                //await Task.Delay(3000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                // await f7();
                await Retry.Do(async () => await f7(), TimeSpan.FromSeconds(5));
                // await Task.Delay(3000);
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                //  await f8();
                await Retry.Do(async () => await f8(), TimeSpan.FromSeconds(5));
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                // await f9();
                await Retry.Do(async () => await f9(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;
                // await f11();
                await Retry.Do(async () => await f11(), TimeSpan.FromSeconds(5));
            }

        }
        public async void livefeedupdate()
        {
            if (String.IsNullOrEmpty(this.label1.Text))
            {
                MessageBox.Show("Please Select Temperory Download Location!");
            }
            else
            {

               
                    ////////////////////////////////////////////
                    try
                    {

                        String catid = "";
                        oSqlConnection = new SqlConnection(constr);
                        oSqlCommand = new SqlCommand();
                        sqlQuery = "  update  [dbo].[ProductInfo] set  Status=3 where  Status=2 ";
                        //select SUM(km) as tkm,SUM (cal) as tcal from fit where year(dtval)='" + dt + "' and devid='" + devid + "'";

                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.CommandText = sqlQuery;
                        oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlConnection.Open();
                        // oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                        oSqlCommand.ExecuteNonQuery();
                        oSqlConnection.Close();
                    }
                    catch (Exception ex)
                    {


                    }
                    ///////////////////////////////////////////////////
                 
                button1.Enabled = false;
                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //  await f1();

                await Retry.Do(async () => await f1(), TimeSpan.FromSeconds(5));
                isLoaded = false;


                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                // await f2();
                await Retry.Do(async () => await f2(), TimeSpan.FromSeconds(5));
                isLoaded = false;

                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //await f3();
                await Retry.Do(async () => await f3(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                // await f4();
                await Retry.Do(async () => await f4(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                //await f5();
                await Retry.Do(async () => await f5(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                //await f6();
                await Retry.Do(async () => await f6(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;

                //await Task.Delay(3000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                // await f7();
                await Retry.Do(async () => await f7(), TimeSpan.FromSeconds(5));
                // await Task.Delay(3000);
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                //  await f8();
                await Retry.Do(async () => await f8(), TimeSpan.FromSeconds(5));
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                // await f9();
                await Retry.Do(async () => await f9(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;
                // await f11();
                await Retry.Do(async () => await f11(), TimeSpan.FromSeconds(5));
            }

        }


        public async void updateprice()
        {
            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //  await f1();

            await Retry.Do(async () => await t1(), TimeSpan.FromSeconds(5));
            isLoaded = false;


            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            // await f2();
            await Retry.Do(async () => await t2(), TimeSpan.FromSeconds(5));
            isLoaded = false;

            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //await f3();
            await Retry.Do(async () => await t3(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            // await f4();
            await Retry.Do(async () => await t4(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            //await f5();
            await Retry.Do(async () => await t5(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            //await f6();
            await Retry.Do(async () => await t6(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;

            //await Task.Delay(3000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            // await f7();
            await Retry.Do(async () => await t7(), TimeSpan.FromSeconds(5));
            // await Task.Delay(3000);
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            //  await f8();
            await Retry.Do(async () => await t8(), TimeSpan.FromSeconds(5));
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            // await f9();
            await Retry.Do(async () => await t9(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;
            // await f11();
            await Retry.Do(async () => await t11(), TimeSpan.FromSeconds(5));

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (isLoaded)
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logot();
        }

        public async Task<bool> check1()
        {
            try
            {
                var documentElement = this.webBrowser1.Document.GetElementsByTagName("html")[0];
                HtmlDocument doc = webBrowser1.Document;
                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    await Task.Delay(500);

                    // continue polling if the WebBrowser is still busy
                    var documentElement1 = this.webBrowser1.Document.GetElementsByTagName("html")[0];
                    var htmlNow = documentElement1.OuterHtml;
                    if (this.webBrowser1.IsBusy|| html == htmlNow)
                        continue;

                  
                    if (html != htmlNow)
                        break; // no changes detected, end the poll loop

                    html = htmlNow;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async void logot()
        {
            try
            {
                lgoff = true;
                await Task.Delay(1000);
                if (webBrowser1.Document != null)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !webBrowser1.IsBusy)
                    {



                        //HtmlDocument doc1 = webBrowser1.Document;


                        //while (true)
                        //{
                        //    HtmlElement elem5 = doc1.GetElementById(" Logout");
                        //    // wait asynchronously, this will throw if cancellation requested
                        //    await Task.Delay(500);

                        //    // continue polling if the WebBrowser is still busy


                        //    if (this.webBrowser1.IsBusy || elem5 == null)
                        //        continue;


                        //    if (elem5 != null)
                        //        break; // no changes detected, end the poll loop


                        //}
                        HtmlDocument doc = webBrowser1.Document;
                        HtmlElementCollection elem2 = doc.GetElementsByTagName("a");

                        foreach (System.Windows.Forms.HtmlElement link in elem2)
                        {


                            if (link.InnerText.Contains("Logout"))
                            {
                                // link.Click();
                                HtmlElement btnElement = link;
                                btnElement.InvokeMember("click");
                                button1.Enabled = true;
                                do
                                {
                                    await Task.Delay(1000);
                                }
                                while ((!isLoaded));
                                this.webBrowser1.Navigate("http://www.araiaa.jp/en/");
                                lgoff = false;
                            }

                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string strfilename = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Setting1 = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
               this.label1.Text=  Properties.Settings.Default.Setting1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logot();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Setting2 = checkBox1.Checked.ToString();
            Properties.Settings.Default.Save();
            isstartfrom =  bool.Parse(Properties.Settings.Default.Setting2);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //  await f1();

            await Retry.Do(async () => await t1(), TimeSpan.FromSeconds(5));
            isLoaded = false;


            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            // await f2();
            await Retry.Do(async () => await t2(), TimeSpan.FromSeconds(5));
            isLoaded = false;

            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //await f3();
            await Retry.Do(async () => await t3(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            // await f4();
            await Retry.Do(async () => await t4(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            //await f5();
            await Retry.Do(async () => await t5(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            //await f6();
            await Retry.Do(async () => await t6(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;

            //await Task.Delay(3000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            // await f7();
            await Retry.Do(async () => await t7(), TimeSpan.FromSeconds(5));
            // await Task.Delay(3000);
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            //  await f8();
            await Retry.Do(async () => await t8(), TimeSpan.FromSeconds(5));
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            // await f9();
            await Retry.Do(async () => await t9(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;
            // await f11();
            await Retry.Do(async () => await t11(), TimeSpan.FromSeconds(5));
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //  await f1();

            await Retry.Do(async () => await b1(), TimeSpan.FromSeconds(5));
            isLoaded = false;


            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            // await f2();
            await Retry.Do(async () => await b2(), TimeSpan.FromSeconds(5));
            isLoaded = false;

            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //await f3();
            await Retry.Do(async () => await b3(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            // await f4();
            await Retry.Do(async () => await b4(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            //await f5();
            await Retry.Do(async () => await b5(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            //await f6();
            await Retry.Do(async () => await b6(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;

            //await Task.Delay(3000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            // await f7();
            await Retry.Do(async () => await b7(), TimeSpan.FromSeconds(5));
            // await Task.Delay(3000);
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            //  await f8();
            await Retry.Do(async () => await b8(), TimeSpan.FromSeconds(5));
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            // await f9();
            await Retry.Do(async () => await b9(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;
            // await f11();
            await Retry.Do(async () => await b11(), TimeSpan.FromSeconds(5));
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Entry no!");
            }
            else
            {
                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //  await f1();

                await Retry.Do(async () => await v1(), TimeSpan.FromSeconds(5));
                isLoaded = false;


                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                // await f2();
                await Retry.Do(async () => await v2(), TimeSpan.FromSeconds(5));
                isLoaded = false;

                await Task.Delay(3000);

                do
                {
                    await Task.Delay(1000);
                }
                while ((!isLoaded));
                //await f3();
                await Retry.Do(async () => await v3(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                // await f4();
                await Retry.Do(async () => await v4(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                //await f5();
                await Retry.Do(async () => await v5(), TimeSpan.FromSeconds(5));
                //isLoaded = false;

                //await Task.Delay(1000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));
                //await f6();
                await Retry.Do(async () => await v6(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;

                //await Task.Delay(3000);

                //do
                //{
                //    await Task.Delay(1000);
                //}
                //while ((!isLoaded));

                // await f7();
                await Retry.Do(async () => await v7(), TimeSpan.FromSeconds(5));
                // await Task.Delay(3000);
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                //  await f8();
                await Retry.Do(async () => await v8(), TimeSpan.FromSeconds(5));
                //// isLoaded = false;
                // do
                // {
                //     await Task.Delay(1000);
                // }
                // while ((!isLoaded));

                // await f9();
                await Retry.Do(async () => await v9(), TimeSpan.FromSeconds(5));
                //   isLoaded = false;
                // await f11();
                await Retry.Do(async () => await v11(), TimeSpan.FromSeconds(5));
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            isbypage = 1;

            await Retry.Do(async () => await b9(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;
            // await f11();
            await Retry.Do(async () => await b11(), TimeSpan.FromSeconds(5));
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //  await f1();

            await Retry.Do(async () => await b1(), TimeSpan.FromSeconds(5));
            isLoaded = false;


            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            // await f2();
            await Retry.Do(async () => await b2(), TimeSpan.FromSeconds(5));
            isLoaded = false;

            await Task.Delay(3000);

            do
            {
                await Task.Delay(1000);
            }
            while ((!isLoaded));
            //await f3();
            await Retry.Do(async () => await b3(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            // await f4();
            await Retry.Do(async () => await b4(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            //await f5();
            await Retry.Do(async () => await b5(), TimeSpan.FromSeconds(5));
            //isLoaded = false;

            //await Task.Delay(1000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));
            //await f6();
            await Retry.Do(async () => await b6(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;

            //await Task.Delay(3000);

            //do
            //{
            //    await Task.Delay(1000);
            //}
            //while ((!isLoaded));

            // await f7();
            await Retry.Do(async () => await b7(), TimeSpan.FromSeconds(5));
            // await Task.Delay(3000);
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            //  await f8();
            await Retry.Do(async () => await b8(), TimeSpan.FromSeconds(5));
            //// isLoaded = false;
            // do
            // {
            //     await Task.Delay(1000);
            // }
            // while ((!isLoaded));

            // await f9();
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            isbypage = 2;
            await Retry.Do(async () => await b9(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;
            // await f11();
            await Retry.Do(async () => await b11(), TimeSpan.FromSeconds(5));
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            isbypage = 3;
            await Retry.Do(async () => await b9(), TimeSpan.FromSeconds(5));
            //   isLoaded = false;
            // await f11();
            await Retry.Do(async () => await b11(), TimeSpan.FromSeconds(5));
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            try
            {
                bool updateState = false;
                bool IsLive = new DALSetting().GetLiveStatus();
                if (IsLive)
                {
                    updateState = false;
                }
                else
                {
                    updateState = true;
                }
                new DALSetting().UpdateLiveStatus(updateState);
                if (updateState)
                {
                    btnLive.Text = "The Video is Live";
                }
                else
                {
                    btnLive.Text = "The Video is offline";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
