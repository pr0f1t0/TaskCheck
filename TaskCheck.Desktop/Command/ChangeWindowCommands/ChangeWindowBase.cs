using TaskCheck.Desktop.ViewModels;
using TaskCheckService.Query.Dto;
using TaskCheckStorage.Entities;
using Wpf.Ui.Controls;

namespace TaskCheck.Desktop.Command.ChangeWindowCommands
{
    public abstract class ChangeWindowBase : CommandBase
    {
        protected readonly MainWindowViewModel mainViewModel;
        protected readonly FluentWindow window;
        protected readonly Type type;
        protected readonly UserDto? userDto;
        protected readonly User? user;

        protected ChangeWindowBase(FluentWindow window, Type type, User user)
        {
            this.window = window;
            this.type = type;
            this.user = user;
        }

        protected ChangeWindowBase(FluentWindow window, Type type)
        {
            this.window = window;
            this.type = type;
            userDto = null;
        }

        protected ChangeWindowBase(FluentWindow window, Type type, UserDto user)
        {
            this.window = window;
            this.type = type;
            userDto = user;
        }

        protected ChangeWindowBase(FluentWindow window, Type type, User user, MainWindowViewModel mainViewModel)
        {
            this.window = window;
            this.type = type;
            this.user = user;
            this.mainViewModel = mainViewModel;
        }



        public override void Execute(object? parameter)
        {
            ChangeWindow();
        }

        protected virtual void ChangeWindow()
        {
            if (user is not null)
            {
                if(mainViewModel is null)
                    window.DataContext = Activator.CreateInstance(type, user);
                else
                    window.DataContext = Activator.CreateInstance(type, user, mainViewModel);
            }

            else
            {
                window.DataContext = userDto is null ? Activator.CreateInstance(type) : Activator.CreateInstance(type, userDto);

            }
        }
    }
}
