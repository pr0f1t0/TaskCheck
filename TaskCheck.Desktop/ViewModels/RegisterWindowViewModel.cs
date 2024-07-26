using System.Windows.Input;
using TaskCheck.Desktop.Command;
using TaskCheck.Desktop.Command.ChangeWindowCommands;
using TaskCheckService.Query.Dto;

namespace TaskCheck.Desktop.ViewModels
{
    public class RegisterWindowViewModel : ViewModelBase
    {
        private RegisterDto registerDto;

        private string username;
        private string password;
        private string passwordRepeat;
        private string email;

        private string usernameErrMsg;
        private string passwordErrMsg;
        private string passwordRepeatErrMsg;
        private string emailErrMsg;



        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
                registerDto.Username = value;
            }
        }


        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
                registerDto.Password = value;
            }
        }

        
        public string PasswordRepeat
        {
            get => passwordRepeat;
            set
            {
                passwordRepeat = value;
                OnPropertyChanged(nameof(PasswordRepeat));
                registerDto.PasswordRepeat = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
                registerDto.Email = value;
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

        public string PasswordRepeatErrMsg
        {
            get => passwordRepeatErrMsg;

            set
            {
                passwordRepeatErrMsg = value;
                OnPropertyChanged(nameof(PasswordRepeatErrMsg));
                OnPropertyChanged(nameof(IsPasswordRepeatErr));
            }
        }

        public string EmailErrMsg
        {
            get => emailErrMsg;

            set
            {
                emailErrMsg = value;
                OnPropertyChanged(nameof(EmailErrMsg));
                OnPropertyChanged(nameof(IsEmailErr));
            }
        }


        public bool IsUsernameErr => !string.IsNullOrEmpty(UsernameErrMsg);
        public bool IsPasswordErr => !string.IsNullOrEmpty(PasswordErrMsg);
        public bool IsPasswordRepeatErr => !string.IsNullOrEmpty(PasswordRepeatErrMsg);
        public bool IsEmailErr => !string.IsNullOrEmpty(EmailErrMsg);


        public ICommand Register { get; } 
        public ICommand ChangeToLoginWindow { get; }
        public RegisterWindowViewModel()
        {
            registerDto = new RegisterDto();

            Register = new RegisterCommand(registerDto, this);
            ChangeToLoginWindow = new ChangeWindowCommand(new LoginWindow(), typeof(LoginWindowViewModel));

        }
    }
}
