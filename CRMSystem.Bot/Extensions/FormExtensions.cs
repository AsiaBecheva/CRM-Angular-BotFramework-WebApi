using Microsoft.Bot.Builder.FormFlow;
using CRMSystem.Bot.FormDialogs.Base;

namespace CRMSystem.Bot.Extensions
{
    public static class FormExtensions
    {
        public static FormDialog<T> BuildFormDialog<T>(this T form, FormOptions formOptions = FormOptions.PromptInStart) where T : class, IBaseForm<T>
        {
            return new FormDialog<T>(form, form.BuildForm, formOptions);
        }
    }
}