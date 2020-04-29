using AwesomeSpa.WebUI.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeSpa.WebUI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public DateTime? Completed { get; set; }

        public override string ToString()
        {
            if (!Done)
            {
                return $"Id: {Id}, Title: {Title}, Done: Not Complete";
            }

            return $"Id: {Id}, Title: {Title}, Done: {Completed.Value.ToShortDateString()}";
        }
    }

    public class TodoItemValidator : AbstractValidator<TodoItem>
    {
        private readonly ApplicationDbContext _context;

        public TodoItemValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .MaximumLength(250)
                .NotEmpty()
                .MustAsync(BeUniqueTitle)
                .WithMessage("Title must be unique.");

            RuleFor(v => v.Done)
                .Must(HaveCompletedDateWhenDone)
                .WithMessage("Please specify the date/time this item was done!");
        }

        public bool HaveCompletedDateWhenDone(TodoItem item, bool done)
        {
            return !item.Done ||
                    item.Completed.HasValue;
        }

        public async Task<bool> BeUniqueTitle(TodoItem item, string title, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Where(t => t.Id != item.Id)
                .AllAsync(l => l.Title != title);
        }
    }
}
