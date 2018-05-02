using System;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Bot.Common;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetPhoneForm : BaseForm<GetPhoneForm>
    {
        [Prompt("Please enter Client Name for phone number")]
        public string ClientName { get; set; }

        public override IForm<GetPhoneForm> BuildForm()
        {
            async Task onProcessGetPhone(IDialogContext context, GetPhoneForm state)
            {
                var customer = GetDatabase.GetContext().Customers.Where(c => c.Name == state.ClientName)
                .FirstOrDefault();

                var id = customer.Id;
                var phone = customer.Name;
                await context.PostAsync($"Client with ID: {id};" + $" Phone: {phone}");
            }

            return new FormBuilder<GetPhoneForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onProcessGetPhone)
                .Build();
        }
    }
}