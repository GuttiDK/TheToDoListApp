using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Moq;
using TheToDoListApp.Repository.Enums;
using TheToDoListApp.Repository.Models;
using TheToDoListApp.Service.DataTransferObjects;
using TheToDoListApp.Service.Interfaces;
using Xunit;

namespace TheToDoListApp.UnitTest
{
    public class ToDoItemTests
    {
        [Fact]
        public void Can_Create_ToDoItem_With_Required_Fields()
        {
            var item = new ToDoItem
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.UtcNow,
                TaskDescription = "Test task",
                Priority = PrioryEnum.High,
                IsCompleted = false
            };

            Assert.NotEqual(Guid.Empty, item.Id);
            Assert.Equal("Test task", item.TaskDescription);
            Assert.Equal(PrioryEnum.High, item.Priority);
            Assert.False(item.IsCompleted);
        }
    }

    public class ToDoItemServiceTests
    {
        [Fact]
        public async Task GetAllCompletedAsync_Returns_Completed_Items()
        {
            // Arrange
            var mockService = new Mock<IToDoItemService>();
            var completedItems = new ObservableCollection<ToDoItemDto>
            {
                new ToDoItemDto { Id = Guid.NewGuid(), IsCompleted = true }
            };
            mockService.Setup(s => s.GetAllCompletedAsync()).ReturnsAsync(completedItems);

            // Act
            var result = await mockService.Object.GetAllCompletedAsync();

            // Assert
            Assert.Single(result);
            Assert.True(result[0].IsCompleted);
        }

        [Fact]
        public async Task GetByIDAsync_Returns_Correct_Item()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockService = new Mock<IToDoItemService>();
            var item = new ToDoItemDto { Id = id, TaskDescription = "Find me" };
            mockService.Setup(s => s.GetByIDAsync(id)).ReturnsAsync(item);

            // Act
            var result = await mockService.Object.GetByIDAsync(id);

            // Assert
            Assert.Equal(id, result.Id);
            Assert.Equal("Find me", result.TaskDescription);
        }
    }
}