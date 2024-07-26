using TaskCheck.Desktop.ViewModels;
using TaskCheckService.Query.Dto;
using TaskCheckService.Query.Task;
using TaskCheckStorage;
using TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheck.Desktop.Command
{
    public class LoadTasksCommand : CommandBase
    {
        private readonly User user;
        private readonly MainWindowViewModel viewModel;

        public LoadTasksCommand(User user, MainWindowViewModel viewModel)
        {
            this.user = user;
            this.viewModel = viewModel; 
        }

        public override void Execute(object parameter)
        {
            using TaskCheckDbContext dbContext = new TaskCheckDbContext();
            TaskRepository taskRepository = new TaskRepository(dbContext);

            GetAllTasksQuery getAllTasksQuery = new GetAllTasksQuery();
            GetAllTasksQueryHandler getAllTasksQueryHandler = new GetAllTasksQueryHandler(taskRepository, user);

            IEnumerable<TaskDto> tasks = getAllTasksQueryHandler.Handle(getAllTasksQuery);

            viewModel.LoadTasks(tasks);

        }

    }
}
