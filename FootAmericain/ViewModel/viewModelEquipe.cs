using FootAmericain.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ModelLayer.Business;
using ModelLayer.Data1;

namespace FootAmericain.ViewModel
{
    class viewModelEquipe : viewModelBase
    {
        //private DaoEquipe vmDaoEquipe;
        private DaoJoueur vmDaoJoueur;
        private DaoEquipe vmDaoEquipe;
        private ICommand insertCommand;
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ObservableCollection<Joueur> listJoueur;
        private ObservableCollection<Equipe> listEquipe;
        private Equipe selectEquipe = new Equipe();
        public ObservableCollection<Equipe> ListEquipe { get => listEquipe; set => listEquipe = value; }
        public ObservableCollection<Joueur> ListJoueur { get => listJoueur; set => listJoueur = value; }

        //Declaration BINDING
        public string Nom
        {
            get => selectEquipe.Nom;
            set
            {
                if (selectEquipe.Nom != value)
                {
                    selectEquipe.Nom = value;
                    OnPropertyChanged("Nom");
                }
            }
        }

        public DateTime DateCreation
        {
            get => selectEquipe.DateCreation;
            set
            {
                if (selectEquipe.DateCreation != value)
                {
                    selectEquipe.DateCreation = value;
                    OnPropertyChanged("DateCreation");
                }
            }
        }


        public Equipe SelectEquipe
        {
            get => selectEquipe;
            set
            {
                if (selectEquipe != value)
                {
                    selectEquipe = value;
                    OnPropertyChanged("Nom");
                    OnPropertyChanged("DateCreation");
                }
            }
        }


        //Constructeur VMEquipe
        public viewModelEquipe(DaoEquipe theDaoEquipe, DaoJoueur theDaoJoueur)
        {
            //liaison listevm et listenormale
            //vmDaoEquipe = theDaoEquipe;
            vmDaoJoueur = theDaoJoueur;
            vmDaoEquipe = theDaoEquipe;

            listEquipe = new ObservableCollection<Equipe>(theDaoEquipe.SelectAll());

        }
    }
}

//        public ICommand InsertCommand
//        {
//            get
//            {
//                if (this.insertCommand == null)
//                {
//                    this.insertCommand = new RelayCommand(() => InsertJoueur(), () => true);
//                }
//                return this.insertCommand;

//            }
//        }

//        public ICommand UpdateCommand
//        {
//            get
//            {
//                if (this.updateCommand == null)
//                {
//                    this.updateCommand = new RelayCommand(() => UpdateJoueur(), () => true);
//                }
//                return this.updateCommand;
//            }
//        }

//        public ICommand DeleteCommand
//        {
//            get
//            {
//                if (this.deleteCommand == null)
//                {
//                    this.deleteCommand = new RelayCommand(() => DeleteJoueur(), () => true);
//                }
//                return this.deleteCommand;
//            }
//        }

//        public void InsertJoueur()
//        {
//            int idl = 0;
//            vmDaoJoueur.Insert(unJoueur);
//            foreach (Joueur j in listJoueur)
//            {
//                idl = idl + 1;
//            }
//            listJoueur.Insert(idl + 1, unJoueur);
//        }

//        public void UpdateJoueur()
//        {
//            Joueur joueursvg = new Joueur();
//            vmDaoJoueur.Update(UnJoueur);
//            int index = listJoueur.IndexOf(SelectJoueur);
//            joueursvg = SelectJoueur;
//            listJoueur.Insert(index, UnJoueur);
//            listJoueur.RemoveAt(index + 1);
//            SelectJoueur = joueursvg;
//        }

//        public void DeleteJoueur()
//        {
//            int index = listJoueur.IndexOf(SelectJoueur);
//            vmDaoJoueur.Delete(unJoueur);
//            listJoueur.Remove(SelectJoueur);
//        }
//    }
//}
//}
