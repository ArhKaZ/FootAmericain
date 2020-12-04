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
    public class DaoPoste
    {
        private Dbal mydbal;

        public DaoPoste(Dbal mydbal)
        {
            this.mydbal = mydbal;
        }
        public void Insert(Poste unPoste)
        {
            string query = "Poste (id,nom,escouade) VALUES ("
                + unPoste.Id + ",'"
                + unPoste.Nom.Replace("'", "''") + "',"
                + unPoste.Escouade + ")";

            this.mydbal.Insert(query);
        }
        public void Update(Poste unPoste)
        {
          string query = "Poste set id = " + unPoste.Id
                + ", nom = '" + unPoste.Nom.Replace("'", "''")
                + "', escouade = " + unPoste.Escouade
                + "Where id = " + unPoste.Id;
          this.mydbal.Update(query);
        }
        public Poste SelectById(int id)
        {
            DataRow rowPoste = this.mydbal.SelectById("Poste", id);
            return new Poste((int)rowPoste["id"], (string)rowPoste["nom"], (int)rowPoste["escouade"]);
        }
        public List<Poste> SelectAll()
        {
            List<Poste> listPoste = new List<Poste>();
            DataTable myTable = this.mydbal.SelectAll("Poste");

            foreach (DataRow r in myTable.Rows)
            {
                listPoste.Add(new Poste((int)r["id"], (string)r["nom"], (int)r["escouade"]));
            }

            return listPoste;
        }
    }
}
