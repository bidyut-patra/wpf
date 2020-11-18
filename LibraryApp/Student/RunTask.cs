using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Student
{
    public class RunTask
    {
        private CancellationTokenSource tokenSource;
        private Data data;

        public RunTask()
        {
            data = new Data();
        }

        public void Run()
        {
            if (tokenSource != null) tokenSource.Dispose();

            tokenSource = new CancellationTokenSource();
            var token = this.tokenSource.Token;
            Task.Factory.StartNew(() =>
            {
                var t = new Task(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        while ((data != null) && data.CanExecute) ;
                    }
                    //while ((data != null) && data.CanExecute) ;
                });
                t.Start();
            });
        }

        public void Terminate()
        {
            this.data = null;
            this.tokenSource.Cancel();
        }

        private class Data
        {
            public bool CanExecute { get; set; }

            public Data()
            {
                this.CanExecute = true;
            }
        }
    }
}
