using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCheck.Desktop.ViewModels;
using TaskCheckService.Query.Category;
using TaskCheckService.Query.Dto;
using TaskCheckStorage;
using TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheck.Desktop.Command
{
    public class LoadCategoriesCommand : CommandBase
    {
        private readonly User user;
        private readonly AddTaskViewModel viewModel;

        public LoadCategoriesCommand(User user, AddTaskViewModel viewModel)
        {
            this.user = user;
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            using TaskCheckDbContext dbContext = new TaskCheckDbContext();
            TaskRepository taskRepository = new TaskRepository(dbContext);

            GetAllCategoriesQuery getAllCategoriesQuery = new GetAllCategoriesQuery();
            GetAllCategoriesQueryHandler getAllCategoriesQueryHandler = new GetAllCategoriesQueryHandler(taskRepository, user);

            IEnumerable<CategoryDto> categories = getAllCategoriesQueryHandler.Handle(getAllCategoriesQuery);
        }
    }
}
