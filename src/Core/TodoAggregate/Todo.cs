using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Core.TodoAggregate;

public class Todo : EntityBase, IAggregateRoot
{
    public string Title { get; private set; } = string.Empty;

    public TodoStatus Status { get; private set; } = TodoStatus.NotStarted;

    public DateOnly? DueDate { get; private set; }

    public DateOnly? CreatedAt { get; private set; }

    public Todo(string title, TodoStatus status, DateOnly? dueDate, DateOnly? createdAt)
    {
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
        Status = Guard.Against.Null(status, nameof(status));
        DueDate = dueDate;
        CreatedAt = createdAt; 
    }

    public void UpdateTitle(string title)
    {
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
    }

    public void UpdateDueDate(DateOnly? dueDate)
    {
        DueDate = dueDate;
    }

    public void MarkComplete()
    {
        if (Status == TodoStatus.Completed) return;

        Status = TodoStatus.Completed;
    }

    public void MarkInProgress()
    {
        if (Status == TodoStatus.InProgress) return;

        Status = TodoStatus.InProgress;
    }

    public void MarkNotStarted()
    {
        if (Status == TodoStatus.NotStarted) return;

        Status = TodoStatus.NotStarted;
    }
}
