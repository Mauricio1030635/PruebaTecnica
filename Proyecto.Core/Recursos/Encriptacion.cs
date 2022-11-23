using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Recursos
{
    public class Encriptacion
    {
        public string Encriptar(string str)
        {
            SHA256 Sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();            
            StringBuilder sb = new StringBuilder();
            byte[]  stream = Sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
