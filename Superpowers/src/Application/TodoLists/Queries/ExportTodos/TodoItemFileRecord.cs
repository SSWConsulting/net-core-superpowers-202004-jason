using Superpowers.Application.Common.Mappings;
using Superpowers.Domain.Entities;

namespace Superpowers.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
