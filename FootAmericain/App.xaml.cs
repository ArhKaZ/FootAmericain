using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ModelLayer.Business;
using ModelLayer.Data1;
namespace FootAmericain
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal mydbal;
        private DaoEquipe theDaoEquipe;
        private DaoJoueur theDaoJoueur;
        private DaoPays theDaoPays;
        private DaoPoste theDaoPoste;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Instancier DBAL ET DAO ICI
            mydbal = new Dbal("dsfootamericain");
            theDaoEquipe = new DaoEquipe(mydbal);
            theDaoPays = new DaoPays(mydbal);
            theDaoPoste = new DaoPoste(mydbal);
            theDaoJoueur = new DaoJoueur(mydbal, theDaoPays, theDaoPoste, theDaoEquipe);

            MainWindow wnd = new MainWindow(theDaoEquipe, theDaoJoueur, theDaoPays, theDaoPoste);
            wnd.Show();

        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
