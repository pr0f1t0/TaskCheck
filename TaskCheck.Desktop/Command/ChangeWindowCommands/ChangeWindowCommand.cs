using System.Windows;
using TaskCheckService.Query.Dto;
using TaskCheckStorage.Entities;
using Wpf.Ui.Controls;


namespace TaskCheck.Desktop.Command.ChangeWindowCommands
{
    public class ChangeWindowCommand : ChangeWindowBase
    {
        public ChangeWindowCommand(FluentWindow window, Type type) : base(window, type)
        {
        }

        public ChangeWindowCommand(FluentWindow window, Type type, User user) : base(window, type, user)
        {
        }

        public ChangeWindowCommand(FluentWindow window, Type type, UserDto user) : base(window, type, user)
        {
        }

        protected override void ChangeWindow()
        {
            base.ChangeWindow();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = window;
            window.Show();
        }
    }
}
