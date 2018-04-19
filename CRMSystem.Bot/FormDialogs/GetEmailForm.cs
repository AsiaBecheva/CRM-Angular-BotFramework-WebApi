using System;
using System.Threading.Tasks;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetEmailForm: BaseForm<GetEmailForm>
    {
        [Prompt("Please enter Client Name for email.")]
        public string ClientName { get; set; }

        public override IForm<GetEmailForm> BuildForm()
        {
            async Task onProcessGetEmail(IDialogContext context, GetEmailForm state)
            {
                ///getting email from the database
                var id = "45612";
                var email = "asya@gmail.com";
                await context.PostAsync($"Client with ID: {id};" + $" Email: {email}");
            }

            return new FormBuilder<GetEmailForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onProcessGetEmail)
                .Build();
        }
    }
}