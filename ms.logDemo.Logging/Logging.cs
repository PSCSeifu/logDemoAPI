using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms.logDemo.Logging
{
    //Incompatatible with .net core framework!
    public interface IPSCLogging
    {
        void InitLogging();
    }
    public class PSCLogging : IPSCLogging
    {
        public  void InitLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("LogDemoAPI", "FetchContacts")
                            .MinimumLevel.Verbose()
                            .WriteTo.Seq("http://localhost:5341/")
                            .CreateLogger();
        }
    }
}
