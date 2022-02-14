using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
class Program
{
    
    const string Characters = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%&*";
    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Console.WriteLine("début des test pour trouver un mot de passe de 7 char :");
        Parallel.For(0, 43, i =>
        {
            
            byte[] password = new byte[7];
            byte[] hash;
            //byte[] one = StringHashToByteArray("1115dd800feaacefdf481f1f9070374a2a81e27880f187396db67958b207cbad");
            //byte[] two = StringHashToByteArray("3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b");
            //byte[] three = StringHashToByteArray("74e1bb62f8dabb8125a58852b63bdf6eaef667cb56ac7f7cdba6d7305c50a22f");

            byte[] one = StringHashToByteArray("f02368945726d5fc2a14eb576f7276c0");
            byte[] two = StringHashToByteArray("2e771fe4f4354532dbc49c9c9a45e81f");
            byte[] three = StringHashToByteArray("cc03e747a6afbbcbf8be7668acfebee5");

            //byte[] one = StringHashToByteArray("098f6bcd4621d373cade4e832627b4f6");
            //byte[] two = StringHashToByteArray("455831477b82574f6bf871193f2f761d");
            //byte[] three = StringHashToByteArray("6737eda29c1f8a6f1dfececa8984ce49");

            password[0] = (byte)Characters[i];
            using (MD5 sha = MD5.Create())
            {
                for (int j = 0; j < Characters.Length; j++)
                {
                    password[1] = (byte)Characters[j];
                    for (int k = 0; k < Characters.Length; k++)
                    {
                        password[2] = (byte)Characters[k];
                        for (int l = 0; l < Characters.Length; l++)
                        {
                            password[3] = (byte)Characters[l];
                            for (int m = 0; m < Characters.Length; m++)
                            {
                                password[4] = (byte)Characters[m];
                                for (int n = 0; n < Characters.Length; n++)
                                {
                                    password[5] = (byte)Characters[n];
                                    for (int o = 0; o < Characters.Length; o++)
                                    {
                                        password[6] = (byte)Characters[o];
                                        hash = sha.ComputeHash(password);
                                        if (matches(one, hash) || matches(two, hash) || matches(three, hash))
                                        {
                                            Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                                + BitConverter.ToString(hash).ToLower().Replace("-", ""));
                                            Console.WriteLine(stopWatch.Elapsed);

                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        });
        stopWatch.Stop();
        Console.WriteLine(stopWatch.Elapsed);
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();
    }
    static byte[] StringHashToByteArray(string s)
    {
        return Enumerable.Range(0, s.Length / 2).Select(i => (byte)Convert.ToInt16(s.Substring(i * 2, 2), 16)).ToArray();
    }
    static bool matches(byte[] a, byte[] b)
    {
        for (int i = 0; i < 16; i++)
            if (a[i] != b[i])
                return false;
        return true;
    }
}