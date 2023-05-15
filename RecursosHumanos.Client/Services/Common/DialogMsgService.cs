using MudBlazor;
using RecursosHumanos.Client.Components.Dialogs;

namespace RecursosHumanos.Client.Services.Common;

public class DialogMsgService
{
    private IDialogService _service;

    public DialogMsgService(IDialogService service)
    {
        _service = service;
    }

    public async Task ShowDialogAsync(string text, bool isError = false)
    {
        bool? result = await _service.ShowMessageBox(
           isError ? "Advertencia" : "Info",
           text);
    }

    public async Task ShowOkCancelDialogAsync(
        string text,
        Action? Ok = null,
        Action? Cancel = null,
        Func<Task>? OkAsync = null,
        Func<Task>? CancelAsync = null)
    {
        var parameters = new DialogParameters
        {
            { "Message", text }
        };

        var dialog = await _service.ShowAsync<ConfirmationDialog>("text", parameters);
        DialogResult result = await dialog.Result;

        if (result.Canceled)
        {
            Cancel?.Invoke();
            if (CancelAsync is not null)
                await CancelAsync.Invoke();
        }

        if (result.Canceled)
        {
            Ok?.Invoke();
            if (OkAsync is not null)
                await OkAsync.Invoke();
        }
    }
}
