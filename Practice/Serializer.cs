using System.Runtime.Serialization;
using System.Xml;

namespace Portal
{
    public class Serializer<T>
    {
        private DataContractSerializer m_xmlSerializer { get; set; }
        public Serializer()
        {
            m_xmlSerializer = new DataContractSerializer(typeof(T));
        }
        public string SerializeXml<T>(T obj)
        {
            string serializedXml = "";
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (XmlTextWriter xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented })
                    {
                        this.m_xmlSerializer.WriteObject(xw, obj);
                    }
                    serializedXml = sw.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return serializedXml;
        }
        public T DeserializeXml(string serializedXml)
        {
            T deserializedXml = default(T);
            try
            {
                using (StringReader stringReader = new StringReader(serializedXml))
                {
                    using (XmlReader xmlReader = XmlReader.Create(stringReader))
                    {
                        deserializedXml = (T)this.m_xmlSerializer.ReadObject(xmlReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return deserializedXml;
        }
    }
}
