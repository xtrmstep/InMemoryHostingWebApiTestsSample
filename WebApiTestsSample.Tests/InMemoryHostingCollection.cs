using Xunit;

namespace WebApiTestsSample.Tests
{
    [CollectionDefinition("InMemoryHosting")]
    public class InMemoryHostingCollection : ICollectionFixture<HttpServerFixture>
    {

    }
}