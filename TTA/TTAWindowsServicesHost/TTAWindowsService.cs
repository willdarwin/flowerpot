using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using TTAService;

namespace TTAWindowsServicesHost
{
    public partial class TTAWindowsService : ServiceBase
    {
        ServiceHost host = new ServiceHost(typeof(TTAService.TTAService));

        public TTAWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
