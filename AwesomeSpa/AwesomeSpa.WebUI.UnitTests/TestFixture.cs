using AwesomeSpa.WebUI.Data;
using AwesomeSpa.WebUI.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using Xunit;

namespace AwesomeSpa.WebUI.UnitTests
{
    public class TestFixture : IDisposable
    {
        public TestFixture() // Test Set up
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            Context = new ApplicationDbContext(options, operationalStoreOptions);

            Context.TodoItems.Add(new TodoItem
            {
                Title = "Do this thing."
            });

            Context.SaveChanges();
        }

        public ApplicationDbContext Context { get; }

        public void Dispose() // Test Clean up
        {
            Context.Dispose();
        }
    }

    [CollectionDefinition("ReadTests")]
    public class ReadCollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}