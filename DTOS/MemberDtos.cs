using System.Security.Cryptography;
using System.Text;

namespace ShoppingModule.DTOS
{
    public class MemberLoginDtos
    {
        public string email { get; set; }

        private string pswd = "";

        public string password
        {
            get
            {
                MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pswd.ToString() + "Th!$|sKey"));
                // Create a new Stringbuilder to collect the bytes // and create a string.
                StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
          
                return sBuilder.ToString();
            }
            set { pswd = value; }
        }
    }
    public class MemberRegisterDtos
    {
        public string memberName { get; set; }
        public string memberTel { get; set; }
        public string address { get; set; }
        public string email { get; set; }

        private string pswd = "";

        public string password
        {
            get
            {
                MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pswd.ToString() + "Th!$|sKey"));
                // Create a new Stringbuilder to collect the bytes // and create a string.
                StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
            set { pswd = value; }
        }

    }
}