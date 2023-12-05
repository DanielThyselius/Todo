namespace Todo.Core.Models;

public class TodoItem : Entity
{
    public TodoItem(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public string Descrption { get; set; } = "...";
    public bool Done { get; set; } = false;
}
