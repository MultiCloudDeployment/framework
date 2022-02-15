using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.IO;
using System.Net.Http;


namespace framework
{
    [Cmdlet(VerbsCommon.Get, "Template")]
    public class GetTemplate : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        private string _Path;
        protected override async void ProcessRecord()
        {
            UriBuilder uriBuilder = new UriBuilder(Path);
            string result = "";

            if (uriBuilder.Scheme == "file")
            {
                WriteVerbose("filePath: " + Path);

                result = File.ReadAllText(Path);
            }
            else if (uriBuilder.Scheme == "http" || uriBuilder.Scheme == "https")
            {
                WriteVerbose("urlPath: " + uriBuilder.Uri.AbsoluteUri);
                
                using HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uriBuilder.Uri.AbsoluteUri);
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();

            }
            WriteObject(result);
            base.ProcessRecord();
        }
    }
}