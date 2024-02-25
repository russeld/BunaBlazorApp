using Core.TodoAggregate;

namespace UnitTests.Core.TodoAggregate;

public class TodoConstructor
{

    private readonly string _title = "Test Title";
    private readonly TodoStatus _status = TodoStatus.NotStarted;
    private readonly DateOnly _dueDate = new(2022, 1, 1);
    private readonly DateOnly _createdAt = new(2021, 1, 1);

    private Todo? _testTodo;

    private Todo CreateTodo()
    {
        return new(_title, _status, _dueDate, _createdAt);
    }

    [Fact]
    public void GivenTitleAndStatus_WhenConstructed_ThenTitleAndStatusAreSet()
    {
        _testTodo = CreateTodo();

        Assert.Equal(_title, _testTodo.Title);
        Assert.Equal(_status, _testTodo.Status);
        Assert.Equal(_dueDate, _testTodo.DueDate);
        Assert.Equal(_createdAt, _testTodo.CreatedAt);
    }
}
