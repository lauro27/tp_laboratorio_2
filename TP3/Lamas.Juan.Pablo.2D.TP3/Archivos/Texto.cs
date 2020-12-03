using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    string[] l = datos.Split('\n');
                    foreach (string lw in l)
                    {
                        writer.WriteLine(lw);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}
