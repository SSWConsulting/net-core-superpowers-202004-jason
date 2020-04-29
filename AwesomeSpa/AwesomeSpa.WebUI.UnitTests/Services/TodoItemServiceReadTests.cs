using AwesomeSpa.WebUI.Services;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace AwesomeSpa.WebUI.UnitTests.Services
{
    [Collection("ReadTests")]
    public class TodoItemServiceReadTests
    {
        private readonly TestFixture _fixture;

        public TodoItemServiceReadTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllTodoItems()
        {
            // Arrange
            var service = new TodoItemService(_fixture.Context);

            // Act
            var result = await service.GetAll();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }
    }
}
