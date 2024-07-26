using System.Windows;
using System.Windows.Controls;



namespace TaskCheck.Desktop.Components
{
    /// <summary>
    /// Interaction logic for CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {

        private bool isPasswordChanging;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }


        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordBox), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomPasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPasswordChanging = true;
            Password = passwordBox.Password;
            isPasswordChanging = false;
        }

        private void UpdatePassword()
        {
            if (!isPasswordChanging)
            {
                passwordBox.Password = Password;
            }
        }
        public CustomPasswordBox()
        {
            InitializeComponent();
        }
    }
}
