using System;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetPhoneForm: BaseForm<GetPhoneForm>
    {
        [Prompt("Please enter Client Name for phone number")]
        public string ClientName { get; set; }

        public override IForm<GetPhoneForm> BuildForm()
        {
            OnCompletionAsyncDelegate<GetPhoneForm> onProcessGetPhone = async (context, state) =>
            {
                ///getting phone from the database
                var id = "454544";
                var phone = "0886547822";
                await context.PostAsync($"Client with ID: {id};" + $" Phone: {phone}");
            };

            return new FormBuilder<GetPhoneForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onProcessGetPhone)
                .Build();
        }
    }
}