using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Scheduler;
using CMS.EventLog;
using CMS.Base;
using CMS.Helpers;
using CMS.OnlineForms;
using CMS.DataEngine;
using CMS.SiteProvider;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;
using RestSharp;
using RestSharp.Authenticators;

namespace DancingGoat.CustomScheduledTask
{
    public class CoffeeSampleListSubmissions: ITask
    {
        public string Execute(TaskInfo ti)
        {
            DateTime lastRun = ti.TaskLastRunTime;
            int numberProcessed = 0;
            string result = "";
            // Gets the form info object for the form
            BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo("DancingGoatMvcCoffeeSampleList", SiteContext.CurrentSiteID);

            // Gets the class name of the form
            DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(formObject.FormClassID);
            string className = formClass.ClassName;

            // Loads the form's data
            ObjectQuery<BizFormItem> data = BizFormItemProvider.GetItems(className);

            // Checks whether the form contains any records
            if (!DataHelper.DataSourceIsEmpty(data))
            {
                var allFields = (dynamic)new JsonObject();
                allFields.List = new List<string>();
                List<string> idList = new List<string>();

                // Loops through the form's data records
                foreach (BizFormItem item in data)
                {
                    int id = item.GetIntegerValue("DancingGoatMvcCoffeeSampleListID", 0);
                    string firstNameFieldValue = item.GetStringValue("FirstName", "");
                    string lastNameFieldValue = item.GetStringValue("LastName", "");
                    string emailFieldValue = item.GetStringValue("Email", "");
                    string addressFieldValue = item.GetStringValue("Address", "");
                    string cityFieldValue = item.GetStringValue("City", "");
                    string zipCodeFieldValue = item.GetStringValue("ZIPCode", "");
                    string stateFieldValue = item.GetStringValue("State", "");
                    string countryFieldValue = item.GetStringValue("Country", "");
                    bool processedFieldValue = item.GetBooleanValue("Processed", false);

                    if (processedFieldValue == false)
                    {
                        allFields.Add(firstNameFieldValue, lastNameFieldValue, emailFieldValue, addressFieldValue, cityFieldValue, zipCodeFieldValue, stateFieldValue, countryFieldValue);
                        idList.Add(id.ToString());

                        item.SetValue("Processed", true);
                        item.SubmitChanges(false);

                        numberProcessed++;
                    }
                }
                try
                {
                    var client = new RestClient("http://192.168.0.1");
                    var request = new RestRequest("api/item/", Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(allFields);
                    client.Execute(request);
                    result = "IDs Added: {0}" + idList + "Task time: {1}" + (DateTime.Now - lastRun) + "Success";
                }
                catch (Exception e)
                {
                    result = "Failure " + e.Message;
                }



            }
            //string details = "Number of items processed: {0}" + numberProcessed;

            EventLogProvider.LogInformation("CoffeeSampleListSubmissions", "Execute", result);
            return result;

        }
    }
}