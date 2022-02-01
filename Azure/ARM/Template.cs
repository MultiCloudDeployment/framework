using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.Azure.ARM
{
    public class Template
    {
        public string Schema;
        public string ContentVersion;
        public List<Deployment> Resources;
        public Output Outputs;
    }
    public class Deployment
    {
        public Deployment(string ContentVersion)
        {
            this.Type = "Microsoft.Resources/deployments";
            this.ApiVersion = "2021-04-01";
            this.Name = @"[concat(parameters('name'), '-deployment')]";
            Properties = new(ContentVersion);
        }
        public string Type { get; set; }
        public string ApiVersion { get; set; }
        public string Name { get; set; }
        public DeploymentProperties Properties { get; set; }
    }
    public class DeploymentProperties
    {
        public DeploymentProperties(string ContentVersion)
        {
            this.Mode = "Incremental";
            this.Template = new(ContentVersion);
        }
        public string Mode { get; set; }
        public DeploymentTemplate Template { get; set; }
    }
    public class DeploymentTemplate
    {
        public DeploymentTemplate(string ContentVersion)
        {
            this.Schema = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#";
            this.ContentVersion = ContentVersion;
            this.Resources = @"[createArray(variables('ArmResource'))]";
        }
        public string Schema { get; set; }
        public string ContentVersion { get; set; }
        public object Parameters { get; set; }
        public object Variables { get; set; }
        public string Resources { get; set; }
        public object Outputs { get; set; }
    }
    public class Output
    {
        public Output(string ContentVersion)
        {
            ArmTemplate = new(ContentVersion);
        }
        public OutputTemplate ArmTemplate;
    }
    public class OutputTemplate
    {
        public OutputTemplate(string ContentVersion)
        {
            Type = "object";
            Value = new(ContentVersion);
        }
        public string Type { get; set; }
        public OutputValue Value;
    }
    public class OutputValue
    {
        public OutputValue(string ContentVersion)
        {
            this.Schema = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#";
            this.ContentVersion = ContentVersion;
            this.Resources = @"[createArray(variables('ArmResource'))]";
        }
        public string Schema { get; set; }
        public string ContentVersion { get; set; }
        public object Parameters { get; set; }
        public object Variables { get; set; }
        public string Resources { get; set; }
        public object Outputs { get; set; }
    }
}