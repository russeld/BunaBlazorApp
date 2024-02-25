using Core.TodoAggregate;

namespace UnitTests.Core.TodoAggregate;

public class TodoMethods
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

    [Fact]
    public void GivenNewTitle_WhenUpdated_ThenTitleIsUpdated()
    {
        _testTodo = CreateTodo();
        var newTitle = "New Title";

        _testTodo.UpdateTitle(newTitle);

        Assert.Equal(newTitle, _testTodo.Title);
    }

    [Fact]
    public void GivenNewDueDate_WhenUpdated_ThenDueDateIsUpdated()
    {
        _testTodo = CreateTodo();
        var newDueDate = new DateOnly(2022, 2, 2);

        _testTodo.UpdateDueDate(newDueDate);

        Assert.Equal(newDueDate, _testTodo.DueDate);
    }

    [Fact]
    public void GivenNotStartedStatus_WhenMarkedComplete_ThenStatusIsCompleted()
    {
        _testTodo = CreateTodo();

        _testTodo.MarkComplete();

        Assert.Equal(TodoStatus.Completed, _testTodo.Status);
    }

    [Fact]
    public void GivenInProgressStatus_WhenMarkedNotStarted_ThenStatusIsNotStarted()
    {
        _testTodo = CreateTodo();
        _testTodo.MarkInProgress();

        _testTodo.MarkNotStarted();

        Assert.Equal(TodoStatus.NotStarted, _testTodo.Status);
    }

    [Fact]
    public void GivenCompletedStatus_WhenMarkedInProgress_ThenStatusIsInProgress()
    {
        _testTodo = CreateTodo();
        _testTodo.MarkComplete();

        _testTodo.MarkInProgress();

        Assert.Equal(TodoStatus.InProgress, _testTodo.Status);
    }
}
