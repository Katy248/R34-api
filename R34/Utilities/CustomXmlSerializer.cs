using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace R34.Utilities;
public static class CustomXmlSerializer
{
    public static T? DeserializeXml<T>(this Stream stream) where T : class
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        var result = xmlSerializer.Deserialize(stream);

        return result as T ?? default(T);
    }
}
