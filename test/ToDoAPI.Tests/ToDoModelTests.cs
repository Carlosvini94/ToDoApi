using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoaPI.Models;

namespace ToDoAPI.Tests
{
    public class ToDoModelTests
    {
        [Fact]
        public void CanChangeName()        
        {
            //Arrange
            var testToDo = new ToDoItem
            {
                Name = "Task 1"
            };

            //Act
            testToDo.Name = "Task 2";

            //Assert
            Assert.Equal("Task 2", testToDo.Name);
        }
    }
}