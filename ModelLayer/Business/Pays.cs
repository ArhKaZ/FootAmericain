using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Pays
    {

        private int id;
        private string nom;

        public Pays(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Pays() { }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
