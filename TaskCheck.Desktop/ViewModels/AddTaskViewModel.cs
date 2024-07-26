using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskCheck.Desktop.Command;
using TaskCheckService.Query.Dto;
using TaskCheckStorage.Entities;

namespace TaskCheck.Desktop.ViewModels
{
    public class AddTaskViewModel : ViewModelBase
    {
        private readonly User user;
        public readonly TaskDetailsDto userTask;
        private string taskTitle;
        private string? taskDescription;
        private DateTime taskDueDate = DateTime.UtcNow;
        private long categoryId = 1;
        private ObservableCollection<CategoryDto> categoryDtos;
        private bool isImportant;

        private string taskTitleErrMsg;
        private string taskDescriptionErrMsg;
        private string taskDueDateErrMsg;


        public string TaskTitle
        {
            get => taskTitle;
            set
            {
                taskTitle = value;
                userTask.Title = value;
                OnPropertyChanged(nameof(taskTitle));
            }
        }

        public string TaskDescription
        {
            get => taskDescription;
            set
            {
                taskDescription = value;
                userTask.Description = value;
                OnPropertyChanged(nameof(taskDescription));
            }

        }

        public DateTime TaskDueDate
        {
            get => taskDueDate;
            set
            {
                taskDueDate = value;
                userTask.DueDate = value;
                OnPropertyChanged(nameof(taskDueDate));
            }
        }

        //public long CategoryId
        //{
        //    get => categoryId;
        //    set
        //    {
        //        categoryId = value;
        //        userTask.CategoryId = value;
        //        OnPropertyChanged(nameof(categoryId));
        //    }
        //}

        public ObservableCollection<CategoryDto> CategoryDtos
        {
            get => categoryDtos;
            set
            {
                categoryDtos = value;
                OnPropertyChanged(nameof(categoryDtos));
            }
        }

        public bool IsImportant
        {
            get => isImportant;
            set
            {
                isImportant = value;
                userTask.IsImportant = value;
                OnPropertyChanged(nameof(isImportant));
            }
        }

        public string TaskTitleErrMsg
        {
            get => taskTitleErrMsg;
            set
            {
                taskTitleErrMsg = value;
                OnPropertyChanged(nameof(taskTitleErrMsg));
                OnPropertyChanged(nameof(IsTaskTitleErr));
            }
        }

        public string TaskDescriptionErrMsg
        {
            get => taskDescriptionErrMsg;
            set
            {
                taskDescriptionErrMsg = value;
                OnPropertyChanged(nameof(taskDescriptionErrMsg));
                OnPropertyChanged(nameof(IsTaskDescriptionErr));
            }
        }

        public string TaskDueDateErrMsg
        {
            get => taskDueDateErrMsg;
            set
            {
                taskDueDateErrMsg = value;
                OnPropertyChanged(nameof(taskDueDateErrMsg));
                OnPropertyChanged(nameof(IsTaskDueDateErr));
            }

        }

        public bool IsTaskTitleErr => !string.IsNullOrEmpty(TaskTitleErrMsg);

        public bool IsTaskDescriptionErr => !string.IsNullOrEmpty(TaskDescriptionErrMsg);

        public bool IsTaskDueDateErr => !string.IsNullOrEmpty(TaskDueDateErrMsg);

        public ICommand AddTask { get; }

        public AddTaskViewModel(User user, MainWindowViewModel mainViewModel)
        {
            userTask = new TaskDetailsDto();
            userTask.CategoryId = 1;
            this.user = user;
            AddTask = new AddTaskCommand(user, this, mainViewModel);
        }

        public void LoadCategories(IEnumerable<CategoryDto> categories)
        {
            CategoryDtos = new ObservableCollection<CategoryDto>(categories);
        }
    }
}
