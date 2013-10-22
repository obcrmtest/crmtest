using OutboxCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OutboxCRM
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchCS_Click(object sender, EventArgs e)
        {
            phonescs.Text = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://xxx.x.xx.xxx/apitest/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/phone/" + acouuntnumbercs.Text).Result;  // Blocking call!

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var phones = response.Content.ReadAsAsync<IEnumerable<Phone>>().Result;
                foreach (Phone phone in phones)
                {
                    phonescs.Text += phone.PhoneNumber + "<br />";
                }
            }
            else
            {
                phonescs.Text = response.ReasonPhrase;
            }

        }
    }
}