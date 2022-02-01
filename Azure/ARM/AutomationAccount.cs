using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using framework.Azure.Arm;

namespace framework.Azure.Arm
{
    public class AutomationAccount : Template
    {
        public Parameters Parameters { get; set; }
        public Variables Variables { get; set; }
        public AutomationAccount()
        {
            this.Schema = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#";
            this.ContentVersion = "1.0.0.2";
            Parameters = new();
            Variables = new();
            Resources = new()
            { 
                new (this.ContentVersion)
            };
            Outputs = new Output(this.ContentVersion);
        }
        public AutomationAccount(string Name, string Location, string SkuName)
        {
            this.Schema = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#";
            this.ContentVersion = "1.0.0.2";
            Parameters = new(Name, Location, SkuName);
            Variables = new();
            Resources = new()
            {
                new(this.ContentVersion)
            };
            Outputs = new Output(this.ContentVersion);
        }
    }
    public class Parameters
    {
        public Parameters()
        {
            this.Name = "";
            this.Location = "";
            this.SkuName = "";
            DisableLocalAuth = false;
            PublicNetworkAccess = true;
        }
        public Parameters(string Name, string Location, string SkuName)
        {
            DisableLocalAuth = false;
            PublicNetworkAccess = true;
            this.Name = Name;
            this.Location = Location;
            this.SkuName = SkuName;
        }
        public string Name { get; set; }
        public string Location { get; set; }
        public string SkuName { get; set; }
        public bool DisableLocalAuth { get; set; }
        public bool PublicNetworkAccess { get; set; }
    }
    public class Variables
    {
        public Variables()
        {
            ArmResource = new();
        }
        public ArmResource ArmResource { get; set; }
    }
    public class ArmResource
    {
        public ArmResource()
        {
            Type = "Microsoft.Automation/automationAccounts";
            ApiVersion = "2021-06-22";
            Name = @"[parameters('name')]";
            Location = @"[parameters('location')]";
            Properties = new();
        }
        public string Type { get; set; }
        public string ApiVersion { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Properties Properties { get; set; }
    }
    public class Properties
    {
        public Properties()
        {
            DisableLocalAuth = @"[parameters('DisableLocalAuth')]";
            PublicNetworkAccess = @"[parameters('PublicNetworkAccess')]";
            Sku = new();
        }
        public string DisableLocalAuth { get; set; } 
        public string PublicNetworkAccess { get; set; }
        public Sku Sku { get; set; }
    }
    public class Sku
    {
        public Sku()
        {
            Name = @"[parameters('SkuName')]";
        }
        public string Name { get; set; }
    }
}