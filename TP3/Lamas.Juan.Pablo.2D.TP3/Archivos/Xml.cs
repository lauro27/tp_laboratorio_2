using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(writer, datos);
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return true;
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader("url");
                datos = (T)(serializer.Deserialize(reader));
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return true;
        }
    }
}
