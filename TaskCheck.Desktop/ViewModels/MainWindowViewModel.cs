using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskCheck.Desktop.Command;
using TaskCheck.Desktop.Command.ChangeWindowCommands;
using TaskCheck.Desktop.Views;
using TaskCheckService.Query.Dto;
using TaskCheckStorage.Entities;

namespace TaskCheck.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string taskNumText;
        //private List<UserTask> tasks;
        private ObservableCollection<TaskDto> taskDtos;
        private ObservableCollection<TaskDto> importantTaskDtos;
        private readonly User user;

        public string TaskNumText
        {
            get => taskNumText;
            set
            {
                taskNumText = value;
                OnPropertyChanged(nameof(taskNumText));
            }
        }


        public ObservableCollection<TaskDto> TaskDtos
        {
            get => taskDtos;
            set
            {
                taskDtos = value;
                OnPropertyChanged(nameof(taskDtos));
            }
        }

        public ObservableCollection<TaskDto> ImportantTaskDtos
        {
            get => importantTaskDtos;
            set
            {
                importantTaskDtos = value;
                OnPropertyChanged(nameof(importantTaskDtos));
            }
        }


        public ICommand OpenAddTaskDialogCmd { get; private set; }

        public MainWindowViewModel(User user)
        {
            this.user = user;
            UpdateTasks();
            OpenAddTaskDialogCmd = new OpenDialogWindowCommand(new AddTaskWindow(), typeof(AddTaskViewModel), user, this);
        }

        public void LoadTasks(IEnumerable<TaskDto> tasks)
        {
            TaskDtos = new ObservableCollection<TaskDto>(tasks);
            TaskNumText = $"{TaskDtos.Count}";
        }


        public void UpdateTasks()
        {
            ICommand LoadTasksCmd = new LoadTasksCommand(user, this);
            LoadTasksCmd.Execute(null);
        }

        public void ShowImportantTasks(IEnumerable<TaskDto> tasks)
        {
            ImportantTaskDtos = (ObservableCollection<TaskDto>)new ObservableCollection<TaskDto>(tasks).Select(t => t.IsImportant == true);
        }


    }
}
