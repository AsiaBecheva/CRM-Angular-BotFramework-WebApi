using System;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetStatusForm : BaseForm<GetStatusForm>
    {
        [Prompt("Please enter Client Name")]
        public string ClientName { get; set; }

        public override IForm<GetStatusForm> BuildForm()
        {
            OnCompletionAsyncDelegate<GetStatusForm> onCompletionAsyncDelegate = async (context, state) =>
            {
                ///getting id and status from the database
                var id = "454212";
                var status = "active";
                await context.PostAsync($"Client with ID: {id} " + Environment.NewLine  +  $" Status: {status}");
            };
            
            return new FormBuilder<GetStatusForm>()
            .Field(nameof(ClientName))
            .OnCompletion(onCompletionAsyncDelegate)
            .Build();
        }
    }
}