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
        byte[] one = StringHashToByteArray("eab26669cdf592eb65350353950a45fa");
        //byte[] two = StringHashToByteArray("4cb9e430d7cbdfa328f014703944dbd5");
        byte[] three = StringHashToByteArray("4585eeabefc7ad380c42280c45b284de");
        byte[] four = StringHashToByteArray("63de544a83b395469b8eeef2087f45e5");
        //byte[] five = StringHashToByteArray("7cdd22133b824547307865c5c03ca8f0");
        Console.WriteLine("début des tests pour trouver un mot de passe de longueur de 1 à 8 caractères :");
        //longueur1(one, two, three, four, five);
        //longueur2(one, two, three, four, five);
        //longueur3(one, two, three, four, five);
        //longueur4(one, two, three, four, five);
        //longueur5(one, two, three, four, five);
        longueur6(one, three, four, stopWatch);
        longueur7(one, three, four, stopWatch);
        longueur8(one, three, four, stopWatch);
        stopWatch.Stop();
        Console.WriteLine(stopWatch.Elapsed);
        Console.ReadLine();

        //Parallel.For(0, 43, i =>
        //{

            //byte[] password = new byte[7];
            //byte[] hash;

            //password[0] = (byte)Characters[i];
            //using (MD5 sha = MD5.Create())
            //{
                //for (int j = 0; j < Characters.Length; j++)
                //{
                    //password[1] = (byte)Characters[j];
                    //for (int k = 0; k < Characters.Length; k++)
                    //{
                        //password[2] = (byte)Characters[k];
                        //for (int l = 0; l < Characters.Length; l++)
                        //{
                            //password[3] = (byte)Characters[l];
                            //for (int m = 0; m < Characters.Length; m++)
                            //{
                                //password[4] = (byte)Characters[m];
                                //for (int n = 0; n < Characters.Length; n++)
                                //{
                                    //password[5] = (byte)Characters[n];
                                    //for (int o = 0; o < Characters.Length; o++)
                                    //{
                                        //password[6] = (byte)Characters[o];
                                        //hash = sha.ComputeHash(password);
                                        //if (matches(one, hash) || matches(two, hash) || matches(three, hash))
                                        //{
                                            //Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                                //+ BitConverter.ToString(hash).ToLower().Replace("-", ""));
                                            //Console.WriteLine(stopWatch.Elapsed);

                                        //}
                                    //}
                                //}
                            //}
                        //}
                    //}

                //}
            //}
        //});
        //stopWatch.Stop();
        //Console.WriteLine(stopWatch.Elapsed);
        //Console.WriteLine("Press enter to close...");
        //Console.ReadLine();
    }

    static void longueur1(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    {
        byte[] hash;
        for (int i = 0; i < 43; i++)
        {
            using (MD5 sha = MD5.Create())
            {
                byte[] password = new byte[1];
                password[0] = (byte)Characters[i];
                hash = sha.ComputeHash(password);
                if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four,hash) || matches(five,hash))
                {
                    Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                        + BitConverter.ToString(hash).ToLower().Replace("-", ""));

                }
            }
        }
        Console.WriteLine("aucun mots de passe a une lettre a été trouver");
        return;
    }
    static void longueur2(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    {
        byte[] hash;
        for (int i = 0; i < 43; i++)
        {
            using (MD5 sha = MD5.Create())
            {
                byte[] password = new byte[2];
                password[0] = (byte)Characters[i];
                for (int j = 0; j < Characters.Length; j++)
                {
                    password[1] = (byte)Characters[j];
                    hash = sha.ComputeHash(password);
                    if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                    {
                        Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                            + BitConverter.ToString(hash).ToLower().Replace("-", ""));

                    }
                }
            }
        }
        Console.WriteLine("aucun mots de passe de 2 lettres a été trouver");
        return;
    }
    static void longueur3(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    {
        byte[] hash;
        for (int i = 0; i < 43; i++)
        {
            using (MD5 sha = MD5.Create())
            {
                byte[] password = new byte[3];
                password[0] = (byte)Characters[i];
                for (int j = 0; j < Characters.Length; j++)
                {
                    password[1] = (byte)Characters[j];
                    for (int k = 0; k < Characters.Length; k++)
                    {
                        password[2] = (byte)Characters[k];
                        hash = sha.ComputeHash(password);
                        if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                + BitConverter.ToString(hash).ToLower().Replace("-", ""));

                        }
                    }
                }
            }
        }
        Console.WriteLine("aucun mots de passe de 3 lettres a été trouver");
        return;
    }
    static void longueur4(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    {
        byte[] hash;
        for (int i = 0; i < 43; i++)
        {
            using (MD5 sha = MD5.Create())
            {
                byte[] password = new byte[4];
                password[0] = (byte)Characters[i];
                for (int j = 0; j < Characters.Length; j++)
                {
                    password[1] = (byte)Characters[j];
                    for (int k = 0; k < Characters.Length; k++)
                    {
                        password[2] = (byte)Characters[k];
                        for (int l = 0; l < Characters.Length; l++)
                        {
                            password[3] = (byte)Characters[l];
                            hash = sha.ComputeHash(password);
                            if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                            {
                                Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                    + BitConverter.ToString(hash).ToLower().Replace("-", ""));

                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine("aucun mots de passe de 4 lettres a été trouver");
        return;
    }
    static void longueur5(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    {
        Parallel.For(0, 43, i =>
        {

            byte[] password = new byte[5];
            byte[] hash;
            

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
                                hash = sha.ComputeHash(password);
                                if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                                {
                                    Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                        + BitConverter.ToString(hash).ToLower().Replace("-", ""));

                                }
                                    
                                
                            }
                        }
                    }

                }
            }
        });
        Console.WriteLine("aucun mots de passe de 5 lettres a été trouver");
    }
    //static void longueur6(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    static void longueur6(byte[] one, byte[] three, byte[] four, Stopwatch stopwatch6)
    {
        Parallel.For(0, 43, i =>
        {

            byte[] password = new byte[6];
            byte[] hash;


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
                                    hash = sha.ComputeHash(password);
                                    //if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                                    if (matches(one, hash) || matches(three, hash) || matches(four, hash) )
                                    {
                                        Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                            + BitConverter.ToString(hash).ToLower().Replace("-", ""));
                                        Console.WriteLine(stopwatch6.Elapsed);
                                    }
                                }

                            }
                        }
                    }

                }
            }
        });
        Console.WriteLine("aucun mots de passe de 6 lettres a été trouver");
    }
    //static void longueur7(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    static void longueur7(byte[] one, byte[] three, byte[] four,Stopwatch stopwatch7)
    {
        Parallel.For(0, 43, i =>
        {

            byte[] password = new byte[7];
            byte[] hash;


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
                                        //if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                                        if (matches(one, hash) || matches(three, hash) || matches(four, hash))
                                        {
                                            Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                                + BitConverter.ToString(hash).ToLower().Replace("-", ""));
                                            Console.WriteLine(stopwatch7.Elapsed);
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
            }
        });
        Console.WriteLine("aucun mots de passe de 7 lettres a été trouver");
    }
    //static void longueur8(byte[] one, byte[] two, byte[] three, byte[] four, byte[] five)
    static void longueur8(byte[] one, byte[] three, byte[] four,Stopwatch stopwatch8)
    {
        Parallel.For(0, 43, i =>
        {

            byte[] password = new byte[8];
            byte[] hash;


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
                                        for (int p = 0; p < Characters.Length; p++)
                                        {
                                            password[7] = (byte)Characters[p];
                                            hash = sha.ComputeHash(password);
                                            //if (matches(one, hash) || matches(two, hash) || matches(three, hash) || matches(four, hash) || matches(five, hash))
                                            if (matches(one, hash) || matches(three, hash) || matches(four, hash))
                                            {
                                                Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                                    + BitConverter.ToString(hash).ToLower().Replace("-", ""));
                                                Console.WriteLine(stopwatch8.Elapsed);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
            }
        });
        Console.WriteLine("aucun mots de passe de 8 lettres a été trouver");
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