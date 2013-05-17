using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RegExTester
{
    public class RegExProj
    {
        private string _RegularExpression;
        public string RegularExpression
        {
            get { return _RegularExpression; }
            set { _RegularExpression = value; }
        }

        private string _TestText;
        public string TestText
        {
            get { return _TestText; }
            set { _TestText = value; }
        }

        private string _ReplaceText;
        public string ReplaceText
        {
            get { return _ReplaceText; }
            set { _ReplaceText = value; }
        }

        private bool _Replace;
        public bool Replace
        {
            get { return _Replace; }
            set { _Replace = value; }
        }

        private bool _IgnoreCase;
        public bool IgnoreCase
        {
            get { return _IgnoreCase; }
            set { _IgnoreCase = value; }
        }

        private bool _MultiLine;
        public bool MultiLine
        {
            get { return _MultiLine; }
            set { _MultiLine = value; }
        }

        public void Save(string filename)
        {
            XmlSerializer serial = new XmlSerializer(typeof(RegExProj));

            if (File.Exists(filename))
                File.Delete(filename);

            FileStream fs = File.Open(filename, FileMode.OpenOrCreate);
            serial.Serialize(fs, this);

            fs.Close();
        }

        public static RegExProj Open(string filename)
        {
            XmlSerializer serial = new XmlSerializer(typeof(RegExProj));
            FileStream fs = File.OpenRead(filename);
            RegExProj ret = (RegExProj)serial.Deserialize(fs);
            fs.Close();

            return ret;
        }
    }
}
