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
using Autofac;
using Student;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RunTask RunTask { get; set; }
        public IContainer Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterModule<StudentModule>();
            this.Container = builder.Build();

            this.RunTask = new RunTask();

            this.AddTab();
        }

        private void AddTab()
        {
            var studentInformation = this.Container.Resolve<StudentInformation>();
            studentInformation.BorderBrush = Brushes.AliceBlue;
            studentInformation.BorderThickness = new Thickness(1);
            studentInformation.Background = Brushes.Azure;

            var tab = new TabItem();
            tab.Content = studentInformation;
            tab.Header = "Employee";
            tab.Loaded += Tab_Loaded;
            tab.Unloaded += Tab_Unloaded;

            this.tabCtrl.Items.Add(tab);
        }

        private void Tab_Unloaded(object sender, RoutedEventArgs e)
        {
            this.RunTask.Terminate();
        }

        private void Tab_Loaded(object sender, RoutedEventArgs e)
        {
            this.RunTask.Run();
        }

        private void OnTabAdd(object sender, RoutedEventArgs e)
        {
            this.AddTab();
        }

        private void OnTabClose(object sender, RoutedEventArgs e)
        {
            if (this.tabCtrl.Items.Count > 1)
            {
                this.tabCtrl.Items.RemoveAt(0);
            }
        }
    }
}
