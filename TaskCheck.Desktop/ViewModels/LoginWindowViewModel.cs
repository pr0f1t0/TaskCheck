using System.Windows.Input;
using TaskCheck.Desktop.Command;
using TaskCheck.Desktop.Command.ChangeWindowCommands;
using TaskCheckService.Query.Dto;
namespace TaskCheck.Desktop.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private readonly UserDto userDto;

        private string username;
        private string password;
        private string usernameErrMsg;
        private string passwordErrMsg;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
                userDto.Username = value;
            }
        }


        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
                userDto.Password = value;
            }
        }



        public string UsernameErrMsg
        {
            get => usernameErrMsg;

            set
            {
                usernameErrMsg = value;
                OnPropertyChanged(nameof(UsernameErrMsg));
                OnPropertyChanged(nameof(IsUsernameErr));

            }
        }


        public string PasswordErrMsg
        {
            get => passwordErrMsg;

            set
            {
                passwordErrMsg = value;
                OnPropertyChanged(nameof(PasswordErrMsg));
                OnPropertyChanged(nameof(IsPasswordErr));

            }
        }

        public bool IsUsernameErr => !string.IsNullOrEmpty(UsernameErrMsg);
        public bool IsPasswordErr => !string.IsNullOrEmpty(PasswordErrMsg);



        public ICommand Login { get; }
        public ICommand ChangeToRegisterWindow { get; }

        public LoginWindowViewModel()
        {
            userDto = new UserDto();
            ChangeToRegisterWindow = new ChangeWindowCommand(new RegisterWindow(), typeof(RegisterWindowViewModel));
            Login = new LoginCommand(this, userDto);
        }


    }
}
