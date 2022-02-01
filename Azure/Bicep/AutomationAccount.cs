using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace framework.Azure.Bicep
{
    public class AutomationAccount
    {
        public AutomationAccount(string Name)
        {
            Schema = @"'Microsoft.Automation/automationAccounts@2021-06-22'";
            this.Name = Name;
            this.Location = @"resourceGroup().location";
            Properties = new();
        }
        public AutomationAccount(string Name, string Location)
        {
            Schema = @"'Microsoft.Automation/automationAccounts@2021-06-22'";
            this.Name = Name;
            this.Location = Location;
            Properties = new();
        }
        public AutomationAccount(string Name, string Location, string SkuName)
        {
            Schema = @"'Microsoft.Automation/automationAccounts@2021-06-22'";
            this.Name = Name;
            this.Location = Location;
            Properties = new(SkuName);
        }
        public string Schema { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Properties Properties { get; set; }
    }
    public class Properties
    {
        public Properties()
        {
            DisableLocalAuth = false;
            PublicNetworkAccess = true;
            Sku = new();
        }
        public Properties(bool DisableLocalAuth, bool PublicNetworkAccess)
        {
            this.DisableLocalAuth = DisableLocalAuth;
            this.PublicNetworkAccess = PublicNetworkAccess;
            Sku = new();
        }
        public Properties(bool DisableLocalAuth, bool PublicNetworkAccess, string SkuName)
        {
            this.DisableLocalAuth = DisableLocalAuth;
            this.PublicNetworkAccess = PublicNetworkAccess;
            this.Sku = new(SkuName);
        }
        public Properties(string SkuName)
        {
            DisableLocalAuth = false;
            PublicNetworkAccess = true;
            Sku = new(SkuName);
        }
        public bool DisableLocalAuth { get; set; }
        public bool PublicNetworkAccess { get; set; }
        public Sku Sku { get; set; }
    }
    public class Sku
    {
        public Sku ()
        {
            Name = "Free";
        }
        public Sku (string SkuName)
        {
            Name = SkuName;
        }
        public string Name { get; set; }
    }
}