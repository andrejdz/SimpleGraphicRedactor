using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SimpleGraphicRedactor.Model;

namespace SimpleGraphicRedactor.DAL
{
    class RhombDAL
    {
        public void Save(string path, List<RhombModel> list)
        {
            XmlSerializer xmlS = new XmlSerializer(typeof(List<RhombModel>));
            using(FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                xmlS.Serialize(fs, list);
            }
        }
    }
}