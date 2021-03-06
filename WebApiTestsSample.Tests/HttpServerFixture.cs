﻿using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Xunit;

namespace WebApiTestsSample.Tests
{
    [Collection("InMemoryHosting")]
    public class HttpServerFixture : IDisposable
    {
        private const string baseUrl = "http://dummyurl/";
        private readonly HttpServer httpServer;

        public HttpServerFixture()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiApplication.Configure(config);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            httpServer = new HttpServer(config);
        }

        public void Dispose()
        {
            if (httpServer != null)
            {
                httpServer.Dispose();
            }
        }

        public HttpRequestMessage CreateRequest(string url, string mthv, HttpMethod method)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri(baseUrl + url)
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;
            return request;
        }

        public HttpRequestMessage CreateRequest<T>(string url, string mthv, HttpMethod method, T content, MediaTypeFormatter formatter) where T : class
        {
            HttpRequestMessage request = CreateRequest(url, mthv, method);
            request.Content = new ObjectContent<T>(content, formatter);

            return request;
        }

        public HttpClient CreateServer()
        {
            // httpServer will be disposed after the 1st usage w/o second parameter
            // in order to use the server for several unit tests it should be set to False
            return new HttpClient(httpServer, false);
        }
    }
}