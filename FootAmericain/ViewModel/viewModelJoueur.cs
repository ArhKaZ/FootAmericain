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
    class viewModelJoueur : viewModelBase
    {
        //private DaoEquipe vmDaoEquipe;
        private DaoJoueur vmDaoJoueur;
        private DaoPays vmDaoPays;
        private DaoPoste vmDaoPoste;
        private DaoEquipe vmDaoEquipe;
        private ICommand insertCommand;
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ObservableCollection<Joueur> listJoueur;
        private ObservableCollection<Equipe> listEquipe;
        private ObservableCollection<Poste> listPoste;
        private ObservableCollection<Pays> listPays;
        private Joueur selectJoueur = new Joueur();
        private Equipe selectEquipe = new Equipe();
        public ObservableCollection<Joueur> ListJoueur { get => listJoueur; set => listJoueur = value; }
        public ObservableCollection<Equipe> ListEquipe { get => listEquipe; set => listEquipe = value; }
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Poste> ListPoste { get => listPoste; set => listPoste = value; }

        public Equipe SelectEquipe
        {
            
            get => selectEquipe;
            set
            {
                if (selectEquipe != value)
                {
                    DaoJoueur theDaoJoueur = vmDaoJoueur;
                    selectEquipe = value;
                    ListJoueur = new ObservableCollection<Joueur>(theDaoJoueur.SelectbyTeam(selectEquipe));
                    foreach (Joueur j in listJoueur)
                    {
                        foreach (Poste p in listPoste)
                        {
                            if (j.Poste.Nom == p.Nom)
                            {
                                j.Poste = p;
                            }
                        }

                        foreach (Pays p in listPays)
                        {
                            if (j.Pays.Nom == p.Nom)
                            {
                                j.Pays = p;
                            }
                        }
                    }
                }
            }
        }
        public Joueur SelectJoueur
        {
            get => selectJoueur;
            set
            {
                if (selectJoueur != value)
                {
                    selectJoueur = value;
                    OnPropertyChanged("Nom");
                    OnPropertyChanged("DateNaissance");
                    OnPropertyChanged("DateEntree");
                    OnPropertyChanged("Pays");
                    OnPropertyChanged("Poste");
                }
            }

        }

        //Declaration BINDING
        public string Nom
        {

            get {
                if (selectJoueur == null)
                {
                    return null;
                }
                else
                    return selectJoueur.Nom;
            }
            set
            {
                if (selectJoueur == null)
                {
                    selectJoueur = null;
                }
                    if (selectJoueur.Nom != value)
                    {
                        selectJoueur.Nom = value;
                        OnPropertyChanged("Nom");
                    }
                
            }
        }

        public DateTime DateNaissance
        {
            get
            {
               if (selectJoueur == null)
               {
                    return new DateTime();
                }
               else
                    return selectJoueur.DateNaissance;
            }
            set
            {
                if (selectJoueur.DateNaissance != value)
                {
                    selectJoueur.DateNaissance = value;
                    OnPropertyChanged("DateNaissance");
                }
            }
        }

        public DateTime DateEntree
        {
            get
            {
                if (selectJoueur == null)
                {
                    return new DateTime();
                }
                else
                    return selectJoueur.DateEntree;
            }
            set
            {
                if (selectJoueur.DateEntree != value)
                {
                    selectJoueur.DateEntree = value;
                    OnPropertyChanged("DateEntree");
                }
            }
        }

        public Pays Pays
        {
            get
            {
                if (selectJoueur == null)
                {
                    return null;
                }
                else
                    return selectJoueur.Pays;
            }
            set
            {
                if (selectJoueur.Pays != value)
                {
                    selectJoueur.Pays = value;
                    OnPropertyChanged("Pays");
                }
            }
        }

        public Poste Poste
        {
            get
            {
                if (selectJoueur == null)
                {
                    return null;
                }
                else
                    return selectJoueur.Poste;
            }
            set
            {
                if (selectJoueur.Poste != value)
                {
                    selectJoueur.Poste = value;
                    OnPropertyChanged("Poste");
                }
            }
        }

        

        public MouseBinding SetNull
        {
            set
            {
                SelectJoueur = null;
            }
        }

       

       

        //Constructeur VMJoueur
       public viewModelJoueur(DaoEquipe theDaoEquipe, DaoJoueur theDaoJoueur, DaoPays theDaoPays, DaoPoste theDaoPoste)
       {
            //liaison listevm et listenormale
            //vmDaoEquipe = theDaoEquipe;
            vmDaoJoueur = theDaoJoueur;
            vmDaoPays = theDaoPays;
            vmDaoPoste = theDaoPoste;
            vmDaoEquipe = theDaoEquipe;
            listPays = new ObservableCollection<Pays>(theDaoPays.SelectAll());

            listPoste = new ObservableCollection<Poste>(theDaoPoste.SelectAll());

            listJoueur = new ObservableCollection<Joueur>(theDaoJoueur.SelectAll());
            
            
            listEquipe = new ObservableCollection<Equipe>(theDaoEquipe.SelectAll());
            foreach (Joueur j in listJoueur)
            {
                foreach (Poste p in listPoste)
                {
                    if (j.Poste.Nom == p.Nom)
                    {
                        j.Poste = p;
                    }
                }

                foreach (Pays p in listPays)
                {
                    if (j.Pays.Nom == p.Nom)
                    {
                        j.Pays = p;
                    }
                }
            }
       }

        public ICommand InsertCommand
        {
            get
            {
                if (this.insertCommand == null)
                {
                    this.insertCommand = new RelayCommand(() => InsertJoueur(selectJoueur, selectEquipe), () => true);
                }
                return this.insertCommand;

            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateJoueur(), () => true);
                }
                return this.updateCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(() => DeleteJoueur(), () => true);
                }
                return this.deleteCommand;
            }
        }

        public void InsertJoueur(Joueur unJoueur, Equipe uneEquipe)
        {
            int idl = 0;
            vmDaoJoueur.Insert(unJoueur, uneEquipe);
            foreach (Joueur j in listJoueur)
            {
                idl = idl + 1;
            }
            listJoueur.Add(selectJoueur);
        }

        public void UpdateJoueur()
        {
            Joueur joueursvg = new Joueur();
            vmDaoJoueur.Update(selectJoueur);
            int index = listJoueur.IndexOf(SelectJoueur);
            joueursvg = SelectJoueur;
            listJoueur.Insert(index, selectJoueur);
            listJoueur.RemoveAt(index + 1);
            SelectJoueur = joueursvg;
        }

        public void DeleteJoueur()
        {
            int index = listJoueur.IndexOf(SelectJoueur);
            vmDaoJoueur.Delete(selectJoueur);
            listJoueur.Remove(SelectJoueur);
        }
    }
}
