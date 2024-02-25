using Ardalis.SmartEnum;

namespace Core.TodoAggregate;

public class TodoStatus : SmartEnum<TodoStatus>
{
    public static readonly TodoStatus NotStarted = new(nameof(NotStarted), 1);
    public static readonly TodoStatus InProgress = new(nameof(InProgress), 2);
    public static readonly TodoStatus Completed = new(nameof(Completed), 3);

    protected TodoStatus(string name, int value) : base(name, value) { }
}
