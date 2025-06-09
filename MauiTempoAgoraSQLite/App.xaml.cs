using MauiTempoAgoraSQLite;
using MauiTempoAgoraSQLite.Helpers;

namespace MauiTempoAgoraSQLite
{
    public partial class App : Application
    {
        static SQliteDatabaseHelper _db;

        public static SQliteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_tempo.db3");
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}