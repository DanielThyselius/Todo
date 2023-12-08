using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Services;

namespace Todo.Tests.Unit
{
    public class TodoServiceTests
    {
        [Theory]
        [InlineData("Tvätta", true)]
        [InlineData("tvätta", true)]
        [InlineData("Ta in tvätten", false)]
        [InlineData("Diska ",true)]
        [InlineData(" Diska",true)]
        [InlineData("Diska!",true)]
        [InlineData("Diska?",true)]
        [InlineData("Diska.",true)]
        public async Task WillRecogniseExistingTodoNamesAsync(string test, bool expected)
        {
            // Arrange 
            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
            optionsBuilder.UseInMemoryDatabase("Todos");
            var context = new TodoDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var sut = new TodoService(context);


            //Debugg
            var todos = await sut.GetAllTodosAsync();
            // Act 
            var actual = await sut.TodoExists(test);

            // Assert
            Assert.Equal(expected, actual);

        }

        //[Theory]
        //public void WontAddSameNameTodo()
        //{

        //}
    }
}