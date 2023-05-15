using Microsoft.JSInterop;
using System.Text.Json;

namespace RecursosHumanos.Client.Services.Storage;

public class LocalStorageService : ILocalStorageService
{
    private IJSRuntime _jsRuntime;

    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<T?> GetJsonAsync<T>(string key)
    {
        string objStr = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
        return JsonSerializer.Deserialize<T>(objStr);
    }

    public async Task<string?> GetAsync(string key)
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
    }

    public async Task SaveJsonAsync<T>(string key, T obj)
    {
        string objStr = JsonSerializer.Serialize(obj);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, objStr);
    }

    public async Task SaveAsync(string key, string obj)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, obj);
    }

    public async Task RemoveAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
}
