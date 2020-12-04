using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ModelLayer.Business;
using System.Data;
using System.Runtime.CompilerServices;

namespace ModelLayer.Data1
{
    public class DaoJoueur
    {
        private Dbal mydbal;
        DaoEquipe theDaoEquipe;
        DaoPays theDaoPays;
        DaoPoste theDaoPoste;

        public DaoJoueur(Dbal mydbal, DaoPays theDaoPays, DaoPoste theDaoPoste, DaoEquipe theDaoEquipe)
        {
            this.mydbal = mydbal;
            this.theDaoEquipe = theDaoEquipe;
            this.theDaoPays = theDaoPays;
            this.theDaoPoste = theDaoPoste;
        }

        
        public void Insert(Joueur unJoueur, Equipe uneEquipe)
        {
            int id = 0;
            List<Joueur> listj = new List<Joueur>(SelectAll());
            foreach(Joueur j in listj)
            {
                id = id + 1;
            }
            string query = "Joueur (id,nom,dateEntree,dateNaissance,pays,poste,equipe) VALUES ("
                + id + ",'"
                + unJoueur.Nom.Replace("'", "''") + "','"
                + unJoueur.DateEntree.Date.ToString("yyyy-MM-dd") + "','"
                + unJoueur.DateNaissance.ToString("yyyy-MM-dd") + "',"
                + unJoueur.Pays.Id + ","
                + unJoueur.Poste.Id + ","
                + uneEquipe.Id + ")";
               

            this.mydbal.Insert(query);
        }
        public List<Joueur> SelectAll()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            DataTable myTable = this.mydbal.SelectAll("Joueur");

            foreach (DataRow r in myTable.Rows)
            {
                Poste unPoste = this.theDaoPoste.SelectById((int)r["poste"]);
                Pays unPays = this.theDaoPays.SelectById((int)r["pays"]);
                listJoueur.Add(new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateEntree"], (DateTime)r["dateNaissance"], unPays, unPoste));
            }

            return listJoueur;
        }

        public void Update(Joueur unJoueur)
        {
                string query = "Joueur set id = " + unJoueur.Id
                + ", nom = '" + unJoueur.Nom.Replace("'", "''")
                + "', dateEntree = '" + unJoueur.DateEntree.ToString("yyyy-MM-dd")
                + "', dateNaissance = '" + unJoueur.DateNaissance.ToString("yyyy-MM-dd")
                + "', pays = " + unJoueur.Pays.Id
                + ", poste = " + unJoueur.Poste.Id
                + " Where id = " + unJoueur.Id;
            this.mydbal.Update(query);
        }

        public void Delete(Joueur unJoueur)
        {
            string query = "Joueur Where id = " + unJoueur.Id;
            mydbal.Delete(query);
        }

        //public void BindListJoueurListPays()
        //{
        //    List<Joueur> listJ = new List<Joueur>();
        //    DataTable myTable = this.mydbal.SelectAll("Joueur");
        //    foreach (DataRow r in myTable.Rows)
        //    {
        //        Pays unPays = this.theDaoPays.SelectById((int))
        //    }
        //}
        public List<Joueur> SelectbyTeam(Equipe uneEkip)
        {
            List<Joueur> listJ = new List<Joueur>();
            DataTable myTable = this.mydbal.SelectByField("Joueur", " equipe = " + uneEkip.Id);
            foreach (DataRow r in myTable.Rows)
            {
                Poste unPoste = this.theDaoPoste.SelectById((int)r["poste"]);
                Pays unPays = this.theDaoPays.SelectById((int)r["pays"]);
                listJ.Add(new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateEntree"], (DateTime)r["dateNaissance"], unPays, unPoste));
            }

            return listJ;
        }

        public Joueur SelectById(int id)
        {
            DataRow rowJoueur = this.mydbal.SelectById("Joueur", id);
            Poste unPoste = this.theDaoPoste.SelectById((int)rowJoueur["poste"]);
            Pays unPays = this.theDaoPays.SelectById((int)rowJoueur["pays"]);
            return new Joueur((int)rowJoueur["id"], (string)rowJoueur["nom"], (DateTime)rowJoueur["dateEntree"], (DateTime)rowJoueur["dateNaissance"], unPays, unPoste);
        }
    }
}
