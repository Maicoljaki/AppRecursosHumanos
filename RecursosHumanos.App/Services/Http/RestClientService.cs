using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;

namespace RecursosHumanos.App.Services.Http;

public class RestClientService : IRestClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RestClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T> Get<T>(string uri)
    {
        using var client = _httpClientFactory.CreateClient("EcuasolApi");
        var response = await client.GetAsync(uri);
        return await _ManageResponse<T>(response);
    }

    public async Task Post<T>(string uri, T obj)
    {
        using var client = _httpClientFactory.CreateClient("EcuasolApi");
        var response = await client.PostAsJsonAsync(uri, obj);
        await _ManageResponse(response);
    }

    public async Task<TResult> Post<TResult, TObj>(string uri, TObj obj)
    {
        using var client = _httpClientFactory.CreateClient("EcuasolApi");
        var response = await client.PostAsJsonAsync(uri, obj);
        return await _ManageResponse<TResult>(response);
    }
    public async Task Delete<TObj>(string uri, TObj obj)
    {
        using var client = _httpClientFactory.CreateClient("EcuasolApi");
        var response = await client.PostAsJsonAsync(uri, obj);
        await _ManageResponse(response);
    }

    private async Task _ManageResponse(HttpResponseMessage? response)
    {
        if (response is null)
        {
            throw new Exception($"Ha ocurrido un problema de conexión con la api");
        }

        if (response.IsSuccessStatusCode)
        {
            return;
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errors = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            if (errors is not null)
            {
                var errorList = errors.Errors
                    .Where(x => x.Value.Count() > 0)
                    .SelectMany(x => x.Value)
                    .Select(x => x)
                    .ToList();
                if (errorList.Count() == 1)
                {
                    throw new Exception($"Ha ocurrido un problema: {errorList.First()}");
                }
                else if (errorList.Count() is not 0)
                {
                    var errorStr = string.Join("; ", errorList);
                    throw new Exception($"Han ocurrido algunos problemas: {errorStr}");
                }
            }
        }
        else
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            if (problemDetails is not null)
            {
                throw new Exception($"Ha ocurrido un problema: {problemDetails.Detail ?? problemDetails.Title}");
            }
        }
        throw new Exception($"Ha ocurrido un problema indeterminado.");
    }

    private async Task<TResult> _ManageResponse<TResult>(HttpResponseMessage? response)
    {
        if(response is null)
        {
            throw new Exception($"Ha ocurrido un problema de conexión con la api");
        }

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<TResult>() ??
                throw new Exception($"Ha ocurrido un problema de conexión con la api");
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errors = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            if (errors is not null)
            {
                var errorList = errors.Errors
                    .Where(x => x.Value.Count() > 0)
                    .SelectMany(x => x.Value)
                    .Select(x => x)
                    .ToList();
                if (errorList.Count() == 1)
                {
                    throw new Exception($"Ha ocurrido un problema: {errorList.First()}");
                }
                else if (errorList.Count() is not 0)
                {
                    var errorStr = string.Join("; ", errorList);
                    throw new Exception($"Han ocurrido algunos problemas: {errorStr}");
                }
            }
        }
        else
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            if (problemDetails is not null)
            {
                throw new Exception($"Ha ocurrido un problema: {problemDetails.Detail ?? problemDetails.Title}");
            }
        }

        throw new Exception($"Ha ocurrido un problema indeterminado.");
    }
}

public class ApiError
{
    public string Message { get; set; } = "Uknown";
}