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
    public class DaoEquipe
    {
        private Dbal mydbal;
        private DaoJoueur theDaoJoueur;

        public DaoEquipe(Dbal mydbal)
        {
            this.mydbal = mydbal;
        }
        public void Insert(Equipe uneEquipe)
        {
            string query = "Equipe (id,nom,dateCreation) VALUES ("
                + uneEquipe.Id + ",'"
                + uneEquipe.Nom.Replace("'", "''") + "','"
                + uneEquipe.DateCreation + "')";

            this.mydbal.Insert(query);
        }
            public void Update(Equipe uneEquipe)
            {
                string query = "Equipe set id = " + uneEquipe.Id
                    + ", nom = '" + uneEquipe.Nom.Replace("'", "''")
                    + "', dateCreation = '" + uneEquipe.DateCreation 
                    + "' Where id = " + uneEquipe.Id;
                this.mydbal.Update(query);
            }
        public Equipe SelectById(int id)
        {
            DataRow rowEquipe = this.mydbal.SelectById("Equipe", id);
            return new Equipe((int)rowEquipe["id"], (string)rowEquipe["nom"], (DateTime)rowEquipe["dateCreation"]);
        }
        public List<Equipe> SelectAll()
        {
            List<Equipe> listEquipe = new List<Equipe>();
            DataTable myTable = this.mydbal.SelectAll("Equipe");

            foreach (DataRow r in myTable.Rows)
            {
                listEquipe.Add(new Equipe((int)r["id"], (string)r["nom"], (DateTime)r["dateCreation"]));
            }

            return listEquipe;
        }

    }
}
