// See https://aka.ms/new-console-template for more information
using System.Windows.Threading;

namespace DokaponFileReader
{
    public static class MainProgram
    {
        public static bool exit = false;

        static int Main()
        {
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.InitializeComponent();
                mainWindow.Show();

                Dispatcher.Run();
            }));

            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();

            while (!exit)
            {
                Thread.Sleep(10);
            }

            return 0;
        }
    }
}