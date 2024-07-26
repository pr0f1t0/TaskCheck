using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskCheck.Desktop.Components
{
    /// <summary>
    /// Interaction logic for TaskListItem.xaml
    /// </summary>
    public partial class TaskListItem : UserControl
    {
        public TaskListItem()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TaskTitleProperty =
            DependencyProperty.Register("TaskTitle", typeof(string), typeof(TaskListItem), new PropertyMetadata("TaskTitle"));

        public static readonly DependencyProperty TaskDescriptionProperty =
            DependencyProperty.Register("TaskDescription", typeof(string), typeof(TaskListItem), new PropertyMetadata("TaskDescription"));

        public static readonly DependencyProperty TaskDueToProperty =
            DependencyProperty.Register("TaskDueTo", typeof(string), typeof(TaskListItem), new PropertyMetadata("TaskDueTo"));

        public string TaskTitle
        {
            get { return (string)GetValue(TaskTitleProperty);}
            set { SetValue(TaskTitleProperty, value); }
        }

        public string TaskDescription
        {
            get { return (string)GetValue(TaskDescriptionProperty);}
            set { SetValue(TaskDescriptionProperty, value); }
        }

        public string TaskDueTo
        {
            get { return(string)GetValue(TaskDueToProperty);}
            set { SetValue(TaskDueToProperty, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaskTitleBlock.Text = TaskTitle;
            TaskDescriptionBlock.Text = TaskDescription;
            TaskDueToBlock.Text = TaskDueTo;
        }
    }
}
