using TaskCheck.Desktop.ViewModels;
using TaskCheckService.Query.Dto;
using TaskCheckStorage.Entities;
using Wpf.Ui.Controls;

namespace TaskCheck.Desktop.Command.ChangeWindowCommands
{
    public class OpenDialogWindowCommand : ChangeWindowBase
    {
        public OpenDialogWindowCommand(FluentWindow window, Type type) : base(window, type)
        {
        }

        public OpenDialogWindowCommand(FluentWindow window, Type type, User user) : base(window, type, user)
        {
        }

        public OpenDialogWindowCommand(FluentWindow window, Type type, UserDto user) : base(window, type, user)
        {
        }

        public OpenDialogWindowCommand(FluentWindow window, Type type, User user, MainWindowViewModel mainViewModel) : base(window, type, user, mainViewModel)
        {
        }

        protected override void ChangeWindow()
        {
            base.ChangeWindow();
            window.ShowDialog();
        }


    }
}
