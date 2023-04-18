using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Net.Http.Headers;
using webapi.Controllers;
using webapi.Models;
using webapi.Services;

namespace Testing;

[TestClass]
public class AuthTest
{
    private AuthController _controller;
    private Mock<IHttpClientFactory> _httpFactoryMock;

    [TestInitialize]
    public void TestInitialize()
    {
        _httpFactoryMock = new Mock<IHttpClientFactory>();

        var client = new HttpClient();
        client.BaseAddress = new Uri("http://apiservicios.ecuasolmovsa.com:3009/api/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        _httpFactoryMock
            .Setup(x => x.CreateClient("Ecuasol"))
            .Returns(client);

        _controller = new AuthController(new AuthService(_httpFactoryMock.Object));
    }

    [TestMethod]
    public void Login_ReturnsTrue_When_CredentialsAreRight()
    {
        LoginRequest request = new("5004", "5004u", 2);
        RequestResult<bool> expected = new RequestResult<bool>()
        {
            Error = "",
            IsError = false,
            Result = true
        };
        var resp = _controller.LogIn(request).Result;
        Assert.AreEqual(resp.IsError, expected.IsError);
        Assert.AreEqual(resp.Error, expected.Error);
        Assert.AreEqual(resp.Result, expected.Result);
    }

    [TestMethod]
    public void Login_ReturnsFalse_When_AllCredentialsAreWrong()
    {
        LoginRequest request = new("50", "5004", 2);
        RequestResult<bool> expected = new RequestResult<bool>()
        {
            Error = "",
            IsError = true,
            Result = false
        };
        var resp = _controller.LogIn(request).Result;
        Assert.AreEqual(resp.IsError, expected.IsError);
        Assert.AreEqual(resp.Result, expected.Result);
    }

    [TestMethod]
    public void Login_ReturnsFalse_When_UserWrong()
    {
        LoginRequest request = new("50", "5004u", 2);
        RequestResult<bool> expected = new RequestResult<bool>()
        {
            Error = "",
            IsError = true,
            Result = false
        };
        var resp = _controller.LogIn(request).Result;
        Assert.AreEqual(resp.IsError, expected.IsError);
        Assert.AreEqual(resp.Result, expected.Result);
    }

    [TestMethod]
    public void Login_ReturnsFalse_When_PasswordWrong()
    {
        LoginRequest request = new("5004", "5004", 2);
        RequestResult<bool> expected = new RequestResult<bool>()
        {
            Error = "",
            IsError = true,
            Result = false
        };
        var resp = _controller.LogIn(request).Result;
        Assert.AreEqual(resp.IsError, expected.IsError);
        Assert.AreEqual(resp.Result, expected.Result);
    }

    [TestMethod]
    public void Login_ReturnsFalse_When_EmisorIsWrong()
    {
        LoginRequest request = new("5004", "5004u", 10);
        RequestResult<bool> expected = new RequestResult<bool>()
        {
            Error = "",
            IsError = true,
            Result = false
        };

        var resp = _controller.LogIn(request).Result;
        Assert.AreEqual(resp.IsError, expected.IsError);
        Assert.AreEqual(resp.Result, expected.Result);
    }
}