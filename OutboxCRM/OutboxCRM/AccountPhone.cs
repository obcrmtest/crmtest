using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm;
using Microsoft.Crm.Sdk.Messages;
using OutboxCRM.Models;

namespace OutboxCRM
{
    public class AccountPhone
    {
        public static List<Phone> GetAccountPhones(string accountnumber)
        {
            List<Phone> phones = new List<Phone>();
            IOrganizationService service = myCRMService.CreateIOrganizationService();

            ConditionExpression condition = new ConditionExpression("accountnumber", ConditionOperator.Equal, accountnumber);
            FilterExpression filter = new FilterExpression();
            filter.Conditions.Add(condition);
            QueryExpression query = new QueryExpression();
            query.EntityName = "account";
            query.ColumnSet = new ColumnSet(new string[] { "name", "accountid", "telephone1", "telephone2", "telephone3" });
            query.Criteria = filter;
            EntityCollection result = service.RetrieveMultiple(query);

            foreach (Entity account in result.Entities)
            {
                Guid accountId = account.Id;
                if (account.Attributes.Contains("telephone1"))
                {
                    Phone p = new Phone();
                    p.PhoneNumber = account.Attributes["telephone1"].ToString();
                    phones.Add(p);
                }
                if (account.Attributes.Contains("telephone2"))
                {
                    Phone p = new Phone();
                    p.PhoneNumber = account.Attributes["telephone2"].ToString();
                    phones.Add(p);
                }
                if (account.Attributes.Contains("telephone3"))
                {
                    Phone p = new Phone();
                    p.PhoneNumber = account.Attributes["telephone3"].ToString();
                    phones.Add(p);
                }

                ConditionExpression condition2 = new ConditionExpression("parentcustomerid", ConditionOperator.Equal, accountId);
                FilterExpression filter2 = new FilterExpression();
                filter2.Conditions.Add(condition2);
                QueryExpression query2 = new QueryExpression();
                query2.EntityName = "contact";
                query2.ColumnSet = new ColumnSet(new string[] { "telephone1", "telephone2", "telephone3" });
                query2.Criteria = filter2;
                EntityCollection result2 = service.RetrieveMultiple(query2);
                foreach (Entity contact in result2.Entities)
                {
                    if (contact.Attributes.Contains("telephone1"))
                    {
                        Phone p = new Phone();
                        p.PhoneNumber = contact.Attributes["telephone1"].ToString();
                        phones.Add(p);
                    }
                    if (contact.Attributes.Contains("telephone2"))
                    {
                        Phone p = new Phone();
                        p.PhoneNumber = contact.Attributes["telephone2"].ToString();
                        phones.Add(p);
                    }
                    if (contact.Attributes.Contains("telephone3"))
                    {
                        Phone p = new Phone();
                        p.PhoneNumber = contact.Attributes["telephone3"].ToString();
                        phones.Add(p);
                    }
                }
            }
            return phones;
        }
    }
}