namespace RecursosHumanos.App.Services.Storage;

public interface ILocalStorageService
{
    public Task<T?> GetJsonAsync<T>(string key);
    public Task<string?> GetAsync(string key);
    public Task SaveJsonAsync<T>(string key, T obj);
    public Task SaveAsync(string key, string obj);
    public Task RemoveAsync(string key);
}
