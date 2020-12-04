using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Equipe
    {
        private int id;
        private string nom;
        private DateTime dateCreation;
        List<Joueur> listJoueur;
        public Equipe(int id = 0, string nom = "", DateTime dateCreation = new DateTime())
        {
            this.id = id;
            this.nom = nom;
            this.dateCreation = dateCreation;
            listJoueur = new List<Joueur>();
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public List<Joueur> ListJoueur { get => listJoueur; set => listJoueur = value; }

        public Equipe() { }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
