using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Xml;

namespace WebApplication2.Models
{
    public class Certificate
    {
        public X509Certificate2 Cert;


        public void LoadCertificate(string certificatePath, string password)
        {
            Cert = new X509Certificate2();
            Cert.Import(certificatePath, password, X509KeyStorageFlags.DefaultKeySet);
        }

        public void LoadCertificate(string certificatePath)
        {
            Cert = new X509Certificate2();
            Cert.Import(certificatePath);
        }

        public void LoadCertificate(byte[] certificate)
        {
            Cert = new X509Certificate2();
            Cert.Import(certificate);
        }

        private byte[] StringToByteArray(string st)
        {
            byte[] bytes = new byte[st.Length];
            for (int i = 0; i < st.Length; i++)
            {
                bytes[i] = (byte)st[i];
            }
            return bytes;
        }
    }

    public class Response
    {
        private XmlDocument _xmlDoc;
        private Certificate _certificate;


        public XmlDocument xmlDoc
        {

            get { return _xmlDoc; }
            set { _xmlDoc = value; }
        }
        //public Certificate Encryptioncertificate { get; set; }


        public Response(string certificatePath, string certificatePassword)
        {
            //this.accountSettings = accountSettings;
            _certificate = new Certificate();
            _certificate.LoadCertificate(certificatePath, certificatePassword);
        }
        public Response(string certificatePath)
        {
            _certificate = new Certificate();
            _certificate.LoadCertificate(certificatePath);

        }
        public void LoadXml(string xml)
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.PreserveWhitespace = true;
            _xmlDoc.LoadXml(xml);
        }

        public void LoadXmlFromBase64(string response)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            LoadXml(enc.GetString(Convert.FromBase64String(response)));
        }
         

    }
}