using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += OnDefaultAppDomainUnhandledException;

            base.OnStartup(e);
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args)
        {
            this.ShowError(args.Exception);
        }

        private void OnDefaultAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            this.ShowError(args.ExceptionObject as Exception);
        }

        private void ShowError(Exception exception)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    string message = string.Format("At {0} an uncatched exception of type {1} occured in the application\n The message was:\n {2}", DateTime.Now, exception.GetType(), exception.ToString());
                    MessageBox.Show(message);
                }));
            }
            catch (Exception)
            {
            }
            finally
            {

            }
        }
    }
}
