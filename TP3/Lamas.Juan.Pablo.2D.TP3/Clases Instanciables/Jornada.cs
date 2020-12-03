using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos { get { return alumnos; } set { alumnos = value; } }
        public Universidad.EClases Clase { get { return clase; } set { clase = value; } }
        public Profesor Instructor { get { return instructor; } set { instructor = value; } }

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\jornada.txt", jornada.ToString());
        }

        private Jornada() { this.alumnos = new List<Alumno>(); }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public string Leer()
        {
            string r;
            Texto texto = new Texto();
            if (texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt", out r))
            {
                return r;
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder r = new StringBuilder();
            r.AppendLine(" CLASE DE: " + this.Clase);
            r.AppendLine(" POR " + this.Instructor);
            r.AppendLine(" Alumnos: ");
            foreach (Alumno a in this.Alumnos)
            {
                r.Append(a.ToString());
            }

            return r.ToString();
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
