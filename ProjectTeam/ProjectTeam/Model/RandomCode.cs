using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam.Model
{
    public class RandomCode
    {
        public RandomCode() { }

        public string TaoMaCode(int SokyTu)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            string code = new string(Enumerable.Repeat(chars, SokyTu).Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }
    }
}
