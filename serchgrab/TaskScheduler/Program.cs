using serchgrab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskScheduler
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            TimerCallback callback = new TimerCallback(Tick);

            Console.WriteLine("Creating timer: {0}\n",
                               DateTime.Now.ToString("h:mm:ss"));
            CallApp();
            // create a one second timer tick
            Timer stateTimer = new Timer(callback, null, 0, 1000);

            // loop here forever
            for (;;)
            {
                // add a sleep for 100 mSec to reduce CPU usage
                Thread.Sleep(100);
            }
        }
        static public void Tick(Object stateInfo)
        {
            Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
        }
        static void CallApp()
        {
            // Display the date/time when this method got called.
            DateTime date=DateTime.Now;
            Console.WriteLine("In TimerCallback: " + date);
            DateTime FromDate = date.Date;
            DateTime ToDate = date.Date.AddDays(1).AddTicks(-1);
            TaskData oTaskData = new DataAccess().SelectTaskData(FromDate, ToDate);
            //if (oTaskData != null)
            //{
            //    if (oTaskData.UId > 0)
            //    {

                   // Form1 f=new Form1(oTaskData.Code);
                   // f.ShowDialog();

            //    }
            //}
            
        }
    }
}
