using System.Windows.Input;
using TaskCheck.Desktop.Command.ChangeWindowCommands;
using TaskCheck.Desktop.ViewModels;
using TaskCheckService;
using TaskCheckService.Command.User.Add;
using TaskCheckService.Query.Dto;
using TaskCheckStorage;
using TaskCheckStorage.Repository;

namespace TaskCheck.Desktop.Command
{
    public class RegisterCommand : CommandBase
    {
        private readonly RegisterDto registerDto;
        private readonly RegisterWindowViewModel viewModel;

        public RegisterCommand(RegisterDto registerDto, RegisterWindowViewModel viewModel)
        {
            this.registerDto = registerDto;
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            using (TaskCheckDbContext dbContext = new TaskCheckDbContext())
            {
                UserRepository userRepository = new UserRepository(dbContext);

                RegisterUserCommand command = new RegisterUserCommand(registerDto.Username, registerDto.Password, registerDto.PasswordRepeat, 
                    registerDto.Email);

                RegisterUserCommandHandler commandHandler = new RegisterUserCommandHandler(userRepository);

                Result handleResult = commandHandler.Handle(command);

                if (handleResult.IsSuccess)
                {
                    ICommand changeWindow = new ChangeWindowCommand(new LoginWindow(), typeof(LoginWindowViewModel));
                    changeWindow.Execute(null);
                }
                else
                {
                    Error? usernameErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "Username");
                    Error? passwordErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "Password");
                    Error? passwordRepeatErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "PasswordRepeat");
                    Error? emailErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "Email");


                    string usernameErrMsg = usernameErr?.Message;
                    string passwordErrMsg = passwordErr?.Message;
                    string passwordRepeatErrMsg = passwordRepeatErr?.Message;
                    string emailErrMsg = emailErr?.Message;

                    viewModel.UsernameErrMsg = usernameErrMsg;
                    viewModel.PasswordErrMsg = passwordErrMsg;
                    viewModel.PasswordRepeatErrMsg = passwordRepeatErrMsg;
                    viewModel.EmailErrMsg = emailErrMsg;
                }
            }
        }
    }
}
