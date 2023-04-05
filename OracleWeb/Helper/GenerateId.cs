using System.Security.Cryptography;
using System.Text;

namespace OracleWeb.Helper
{
    public class StringHepler
    {
        public static decimal GenerateId()
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();
            int intId = BitConverter.ToInt32(bytes, 0);
            decimal id = new decimal(intId);
            return id;
        }
    }
}
