using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor() : base() { }

        static Profesor() { random = new Random(); }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        private void _randomClases()
        {
            int r = random.Next(0, 4);
            switch (r)
            {
                case 0:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;

                default:
                    this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }
        protected override string MostrarDatos()
        {
            StringBuilder r = new StringBuilder();
            r.Append(base.MostrarDatos());
            r.Append(this.ParticiparEnClase());
            return r.ToString();
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ParticiparEnClase()
        {
            StringBuilder r = new StringBuilder();
            r.AppendLine("Clases del día:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                r.AppendLine(clase.ToString());
            }
            return r.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
