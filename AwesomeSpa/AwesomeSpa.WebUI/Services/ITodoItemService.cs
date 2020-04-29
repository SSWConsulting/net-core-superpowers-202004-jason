using AwesomeSpa.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeSpa.WebUI.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAll();

        Task<TodoItem> Get(long id);

        Task Add(TodoItem todoItem);

        Task<TodoItem> Update(long id, TodoItem todoItem);

        Task<TodoItem> Delete(long id);
    }
}
