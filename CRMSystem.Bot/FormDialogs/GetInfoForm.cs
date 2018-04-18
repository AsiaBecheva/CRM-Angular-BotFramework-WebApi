using System;
using System.Text;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetInfoForm : BaseForm<GetInfoForm>
    {
        [Prompt("Please enter Client Name for information.")]
        public string ClientName { get; set; }

        public override IForm<GetInfoForm> BuildForm()
        {
            OnCompletionAsyncDelegate<GetInfoForm> onProcessGetInfo = async (context, state) =>
            {
                ///getting client info from the database
                StringBuilder sb = new StringBuilder();
                
                var id = "454545";
                var phone = "0884616161";
                var email = "asyabeche@gmail.com";
                DateTime addedOn = DateTime.Now;
                var status = "active";
                var additionalInformation = "has multiple supermarkets.";
                
                sb.AppendLine($"ID: {id};  ");
                sb.AppendLine($"Phone: {phone};  ");
                sb.AppendLine($"Email: {email};  ");
                sb.AppendLine($"Added On: {addedOn};  ");
                sb.AppendLine($"Status: {status};  ");
                sb.AppendLine($"Additional information: {additionalInformation}.");

                await context.PostAsync(sb.ToString());
            };

            return new FormBuilder<GetInfoForm>()
               .Field(nameof(ClientName))
               .OnCompletion(onProcessGetInfo)
               .Build();
        }
    }
}