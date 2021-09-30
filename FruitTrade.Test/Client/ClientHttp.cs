using FruitTrade.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

public class ClientHttp
    {
        private static TestServer _server;
        private static HttpClient _client;
        private static int _apiVersion = 1;

        public static HttpClient GetClient() 
        {
            if (_server is null) InitializeClient();
            return _client;
        }

        private static void InitializeClient()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public static string GetUrl(string controllerName) =>
            $"{GetClient().BaseAddress}api/v{_apiVersion}/{controllerName}";

        public static IEnumerable<T> GetValues<T>(string jsonString) where T : class =>
            JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
    }