﻿namespace RecursosHumanos.App.Services.Http;

public interface IRestClientService
{
    public Task<T> Get<T>(string uri);
    public Task Post<T>(string uri, T obj);
    public Task<TResult> Post<TResult, TObj>(string uri, TObj obj);
    public Task Delete<TObj>(string uri, TObj obj);
}
