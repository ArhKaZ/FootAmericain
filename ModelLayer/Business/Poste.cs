using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Poste
    {
        private int id;
        private string nom;
        private int escouade;

        public Poste(int id, string nom, int escouade)
        {
            this.id = id;
            this.nom = nom;
            this.escouade = escouade;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Escouade { get => escouade; set => escouade = value; }

        public Poste() { }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
