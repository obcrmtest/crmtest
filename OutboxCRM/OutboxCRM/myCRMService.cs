using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm;
using Microsoft.Crm.Sdk.Messages;

namespace OutboxCRM
{
    public class myCRMService
    {
        public static IOrganizationService CreateIOrganizationService()
        {
            try
            {
                string UserName = "xxxxxxxxx";
                string Password = "xxxxxxxxx";

                IOrganizationService service = null;
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = UserName;
                clientCredentials.UserName.Password = Password;
                ClientCredentials deviceCredentials = null;
                Uri OrganizationUri = new Uri("https://xxxxxxxx.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
                Uri HomeRealmUri = null;
                OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(OrganizationUri, HomeRealmUri, clientCredentials, deviceCredentials);
                service = (IOrganizationService)serviceProxy;
                return service;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}