using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno: Universitario
    {
        EEstadoCuenta estadoCuenta;
        Universidad.EClases claseQueToma;

        #region constructores
        public Alumno():base()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        protected override string MostrarDatos()
        {
            StringBuilder r = new StringBuilder();
            r.Append(base.MostrarDatos());
            r.AppendLine(" ESTADO DE CUENTA: \n" + estadoCuenta);
            r.AppendLine(this.ParticiparEnClase());

            return r.ToString();
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return ((a.claseQueToma == clase) && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        public override string ParticiparEnClase()
        {
            StringBuilder r = new StringBuilder();
            r.AppendLine(" TOMA CLASES DE: " + claseQueToma);

            return r.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
