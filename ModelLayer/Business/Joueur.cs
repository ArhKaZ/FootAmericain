using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Joueur
    {
        private int id;
        private string nom;
        private DateTime dateEntree;
        private DateTime dateNaissance;
        private Pays pays;
        private Poste poste;
        //private Equipe equipe;

        public Joueur(int id= 0, string nom = "", DateTime dateEntree = new DateTime(), DateTime dateNaissance = new DateTime(), Pays pays = null, Poste poste = null)
        {
            this.id = id;
            this.nom = nom;
            this.dateEntree = dateEntree;
            this.dateNaissance = dateNaissance;
            this.pays = pays;
            this.poste = poste;
           // this.equipe = equipe;
        }

        public Joueur() { }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public Pays Pays { get => pays; set => pays = value; }
        public Poste Poste { get => poste; set => poste = value; }
        //public int Equipe { get => equipe.Id; set => equipe.Id = value; }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
