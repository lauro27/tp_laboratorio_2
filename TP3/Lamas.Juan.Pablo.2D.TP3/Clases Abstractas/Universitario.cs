using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario: Persona
    {
        private int legajo;

        #region constructores
        public Universitario() : base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        public override bool Equals(object obj)
        {
            return (this.GetType() == obj.GetType());
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder r = new StringBuilder();
            r.AppendLine(base.ToString());
            r.AppendLine("\nLEGAJO NÚMERO: " + legajo);

            return r.ToString();
        }

        #region operators
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && ((pg1.legajo == pg2.legajo) || pg1.DNI == pg2.DNI);
        }
        #endregion

        public abstract string ParticiparEnClase();
    }
}
