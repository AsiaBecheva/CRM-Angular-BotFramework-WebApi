using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMSystem.Bot.Common;
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
            async Task onProcessGetInfo(IDialogContext context, GetInfoForm state)
            {
                var customer = GetDatabase.GetContext().Customers.Where(c => c.Name == state.ClientName)
                 .FirstOrDefault();

                StringBuilder sb = new StringBuilder();

                var id = customer.Id;
                var phone = customer.Phone;
                var email = customer.Email;
                DateTime addedOn = customer.AddedOn;
                var status = customer.Status;
                var salledProducts = customer.SalledProducts;

                sb.AppendLine($"ID: {id};  ");
                sb.AppendLine($"Phone: {phone};  ");
                sb.AppendLine($"Email: {email};  ");
                sb.AppendLine($"Added On: {addedOn};  ");
                sb.AppendLine($"Status: {status};  ");
                for (int i = 0; i < salledProducts.Count; i++)
                {
                    sb.AppendLine($"Product{i + 1}: {salledProducts[i].Product.Name}.");
                }

                await context.PostAsync(sb.ToString());
            }

            return new FormBuilder<GetInfoForm>()
               .Field(nameof(ClientName))
               .OnCompletion(onProcessGetInfo)
               .Build();
        }
    }
}