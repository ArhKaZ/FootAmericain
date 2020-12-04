using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ModelLayer.Business;
using ModelLayer.Data1;
namespace FootAmericain

{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DaoEquipe theDaoEquipe, DaoJoueur theDaoJoueur, DaoPays theDaoPays, DaoPoste theDaoPoste)
        {
            InitializeComponent();
            Globale.DataContext = new ViewModel.viewModelJoueur(theDaoEquipe, theDaoJoueur, theDaoPays, theDaoPoste);
        }
    }
}
