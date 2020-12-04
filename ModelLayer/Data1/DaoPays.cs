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
    public class DaoPays
    {
        private Dbal mydbal;

        public DaoPays(Dbal mydbal)
        {
            this.mydbal = mydbal;
        }

        public void Insert(Pays unPays)
        {
            string query = "Fromage (id,name,origin, creation , image) VALUES ("
                + unPays.Id + ",'"
                + unPays.Nom.Replace("'", "''") + "')";

            this.mydbal.Insert(query);
        }

        public void Update(Pays unPays)
        {
            string query = "Poste set id = " + unPays.Id
                + ", nom = '" + unPays.Nom.Replace("'", "''")
                + "Where id = " + unPays.Id;
            this.mydbal.Update(query);
        }
        public Pays SelectById(int id)
        {
            DataRow rowPays = this.mydbal.SelectById("pays", id);
            return new Pays((int)rowPays["id"], (string)rowPays["nom"]);
        }

        public List<Pays> SelectAll()
        {
            List<Pays> listPays = new List<Pays>();
            DataTable myTable = this.mydbal.SelectAll("Pays");

            foreach (DataRow r in myTable.Rows)
            {
                listPays.Add(new Pays((int)r["id"], (string)r["nom"]));
            }

            return listPays;
        }
    }
}