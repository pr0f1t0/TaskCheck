using System.Windows.Input;
using TaskCheck.Desktop.Command.ChangeWindowCommands;
using TaskCheck.Desktop.ViewModels;
using TaskCheckService;
using TaskCheckService.Command.User.Login;
using TaskCheckService.Query.Dto;
using TaskCheckService.Query.User;
using TaskCheckStorage;
using TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheck.Desktop.Command
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginWindowViewModel viewModel;
        private readonly UserDto userDto;

        public LoginCommand(LoginWindowViewModel viewModel, UserDto userDto)
        {
            this.viewModel = viewModel;
            this.userDto = userDto;
        }

        public override void Execute(object? parameter)
        {
            using (TaskCheckDbContext dbContext = new TaskCheckDbContext())
            {
                UserRepository userRepository = new UserRepository(dbContext);

                LoginUserCommand loginCommand = new LoginUserCommand(userDto.UserId, userDto.Username, userDto.Password);
                LoginUserCommandHandler loginCommandHandler = new LoginUserCommandHandler(userRepository);
                Result handleResult = loginCommandHandler.Handle(loginCommand);

                if (handleResult.IsSuccess)
                {
                    GetUserQuery getUserQuery = new GetUserQuery();
                    GetUserQueryHandler getUserQueryHandler = new GetUserQueryHandler(userRepository, userDto);
                    User user = getUserQueryHandler.Handle(getUserQuery);

                    ICommand changeWindow = new ChangeWindowCommand(new MainWindow(), typeof(MainWindowViewModel), user);
                    changeWindow.Execute(null);
                }
                else
                {
                    Error? usernameErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "Username");
                    Error? passwordErr = handleResult.Errors.FirstOrDefault(err => err.PropertyName == "Password");

                    string usernameErrMsg = usernameErr?.Message;
                    string passwordErrMsg = passwordErr?.Message;

                    viewModel.UsernameErrMsg = usernameErrMsg;
                    viewModel.PasswordErrMsg = passwordErrMsg;
                }
            }
        }
    }
}
