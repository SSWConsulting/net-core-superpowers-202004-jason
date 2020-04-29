using AwesomeSpa.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace AwesomeSpa.WebUI.UnitTests.Models
{
    public class TodoItemTests
    {
        [Fact]
        public void ToString_GivenValidTodoItem_WhenNotDone_ReturnsCorrectResult()
        {
            // Arrange
            var todoItem = new TodoItem
            {
                Id = 1,
                Title = "Tuna"
            };

            // Act
            var result = todoItem.ToString();

            // Assert
            result.Should().Be("Id: 1, Title: Tuna, Done: Not Complete");
        }
    }
}
