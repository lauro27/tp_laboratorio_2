using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region variables y propiedades
        private string nombre, apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    nombre = value;
                }
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    apellido = value;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                dni = ValidarDni(nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                DNI = ValidarDni(nacionalidad, value);
            }
        }
        #endregion

        #region constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder r = new StringBuilder();
            r.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            r.AppendLine("Nacionalidad: " + this.Nacionalidad);
            return r.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((Nacionalidad == ENacionalidad.Argentino && dato <= 89999999 && dato >= 1) || (Nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int r, var;

            if (dato.Length > 0 && dato.Length < 9 && int.TryParse(dato, out var))
            {
                r = ValidarDni(nacionalidad, var);
                return r;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                {
                    return null;
                }
            }
            return dato;
        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
