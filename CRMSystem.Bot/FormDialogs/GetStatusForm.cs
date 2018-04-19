using System;
using System.Threading.Tasks;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetStatusForm : BaseForm<GetStatusForm>
    {
        [Prompt("Please enter Client Name for status")]
        public string ClientName { get; set; }

        public override IForm<GetStatusForm> BuildForm()
        {
            async Task onCompletionAsyncDelegate(IDialogContext context, GetStatusForm state)
            {
                ///getting id and status from the database
                var id = "454212";
                var status = "active";
                await context.PostAsync($"Client with ID: {id};" + $" Status: {status}");
            }

            return new FormBuilder<GetStatusForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onCompletionAsyncDelegate)
                .Build();
        }
    }
}