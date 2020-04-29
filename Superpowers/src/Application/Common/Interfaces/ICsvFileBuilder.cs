using Superpowers.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Superpowers.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
