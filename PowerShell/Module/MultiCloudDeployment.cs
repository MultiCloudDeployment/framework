using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using framework;

namespace framework.PowerShell.Module
{
    [Cmdlet(VerbsCommon.New, "McdResource")]
    public class NewMcdResource : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Cloud
        {
            get { return _Cloud; }
            set { _Cloud = value; }
        }
        private string _Cloud;
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }
    }
}