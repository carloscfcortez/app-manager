using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AppManager.IntegrationTests
{
    [CollectionDefinition(nameof(FixtureCollection))]
    public class FixtureCollection: ICollectionFixture<Fixture<StartupApiTests>>
    {
    }

    public class Fixture<T> : IDisposable where T : class
    {
        public readonly AppFactory<T> factory;
        public HttpClient client;

        public Fixture()
        {
            var options = new WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost:5000"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            factory = new AppFactory<T>();
            client = factory.CreateClient(options);

        }

        public void Dispose()
        {
            client.Dispose();
            factory.Dispose();
        }

    }
}
