using Service = TaskCheckService.Command.Task.Add;
using TaskCheck.Desktop.ViewModels;
using TaskCheckStorage;
using TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;
using TaskCheckService;
using TaskCheck.Desktop.Views;
using TaskCheckService.Query.Dto;
using System.Windows;

namespace TaskCheck.Desktop.Command
{
    public class AddTaskCommand : CommandBase
    {
        private readonly User user;
        private TaskDetailsDto task;
        private readonly AddTaskViewModel viewModel;
        private readonly MainWindowViewModel mainViewModel;


        public AddTaskCommand(User user, AddTaskViewModel viewModel, MainWindowViewModel mainViewModel)
        {
            this.user = user;
            this.viewModel = viewModel;
            this.mainViewModel = mainViewModel;

        }

        public override void Execute(object? parameter)
        {
            task = viewModel.userTask;
            using (TaskCheckDbContext dbContext = new TaskCheckDbContext())
            {
                TaskRepository taskRepository = new TaskRepository(dbContext);
                Service.AddTaskCommand command = new Service.AddTaskCommand(user.Id, task.CategoryId, task.Title, task.Description, task.IsImportant,
                    task.IsCompleted, task.CreateDate, task.DueDate);
                Service.AddTaskCommandHandler commandHandler = new Service.AddTaskCommandHandler(taskRepository);
                Result handleResult = commandHandler.Handle(command);

                if (handleResult.IsSuccess)
                {
                    Window addTaskWindow = (Window)parameter;
                    mainViewModel.UpdateTasks();
                    addTaskWindow.Visibility = Visibility.Hidden;
                }
                else
                {
                    Error? taskTitleErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "Title");
                    Error? taskDueDateErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "DueDate");
                    Error? descriptionErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName== "Description");

                    string taskTitleErrMsg = taskTitleErr?.Message;
                    string taskDueDateErrMsg = taskDueDateErr?.Message;
                    string taskDescriptionErrMsg = descriptionErr?.Message;

                    viewModel.TaskTitleErrMsg = taskTitleErrMsg;
                    viewModel.TaskDueDateErrMsg = taskDueDateErrMsg;
                    viewModel.TaskDescriptionErrMsg = taskDescriptionErrMsg;
                }

            }
            
        }
    }
}
