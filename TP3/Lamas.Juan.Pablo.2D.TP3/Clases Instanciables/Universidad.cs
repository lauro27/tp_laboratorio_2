using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos = new List<Alumno>();
        private List<Jornada> jornada = new List<Jornada>();
        private List<Profesor> profesores = new List<Profesor>();

        public List<Alumno> Alumnos { get { return alumnos; } set { alumnos = value; } }
        public List<Profesor> Instructores { get { return profesores; } set { profesores = value; } }
        public List<Jornada> Jornadas { get { return jornada; } set { jornada = value; } }
        public Jornada this[int i] { get { return this.Jornadas[i]; } set { this.Jornadas[i] = value; } }

        #region operadores
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlGuardar = new Xml<Universidad>();
            return (xmlGuardar.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\miUniversidad.Xml", uni));
        }

        public Universidad Leer()
        {
            Universidad r;
            Xml<Universidad> read = new Xml<Universidad>();
            read.Leer(AppDomain.CurrentDomain.BaseDirectory + "miUniversidad.Xml", out r);
            return r;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder r = new StringBuilder();
            foreach (Jornada j in uni.Jornadas)
            {
                r.AppendLine("Jornada: " + j.ToString());
                r.AppendLine("<-------------------------------------->");
            }
            return r.ToString();
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.Instructores)
            {
                return true;
            }
            return false;
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                { return p; }
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada added;
            Profesor profesor = (g == clase);
            added = new Jornada(clase, profesor);
            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    added += a;
                }
            }
            g.Jornadas.Add(added);
            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                { return true; }
            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }
        #endregion

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public Universidad()
        { }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
