using AwesomeSpa.WebUI.Models;
using AwesomeSpa.WebUI.Services;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace AwesomeSpa.WebUI.UnitTests.Services
{
    public class TodoItemServiceWriteTests : TestFixture
    {
        [Fact]
        public async Task Add_ShouldCreateTodoItem()
        {
            // Arrange
            var service = new TodoItemService(Context);

            // Act
            var newTodoItem = new TodoItem { Title = "Flour" };

            await service.Add(newTodoItem);

            // Assert
            newTodoItem.Id.Should().NotBe(0);
        }

        [Fact]
        public async Task Delete_ShouldRemoveTodoItem()
        {
            var service = new TodoItemService(Context);

            await service.Delete(1);

            Assert.Empty(Context.TodoItems);
        }
    }
}
