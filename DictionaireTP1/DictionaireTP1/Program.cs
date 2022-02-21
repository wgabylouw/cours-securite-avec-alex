using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;

namespace DictionaireTP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            byte[] hash;
            byte[] one = StringHashToByteArray("4438a0153a4ffc2c6e2326151b0b5029");
            byte[] two = StringHashToByteArray("7c388e507fea9d165a4d6959dc5c2f54");
            byte[] three = StringHashToByteArray("2dda62a1d0552cf3ff9e6e074d8173fa");
            byte[] four = StringHashToByteArray("911c0e5042c610825f8446606f2291cc");
            byte[] five = StringHashToByteArray("855ac952590d3085f1743193e1163e4c");
            byte[] six = StringHashToByteArray("34f56416dc5a799172ab50705cc4aadd");
            byte[] seven = StringHashToByteArray("a7cac749a1e011a5663bf3a42f4a7a13");
            byte[] eight = StringHashToByteArray("89b9c47e1ade5aa59688100a783a88d1");
            byte[] nine = StringHashToByteArray("15d4f9b9c624e0f504140deffd7e91bf");
            byte[] ten = StringHashToByteArray("c849f1bbaaae7d63ac655e73e253d0ad");
            byte[] eleven = StringHashToByteArray("eab26669cdf592eb65350353950a45fa");
            byte[] twelve = StringHashToByteArray("4cb9e430d7cbdfa328f014703944dbd5");
            byte[] thirteen = StringHashToByteArray("4585eeabefc7ad380c42280c45b284de");
            byte[] fourteen = StringHashToByteArray("63de544a83b395469b8eeef2087f45e5");
            byte[] fifteen = StringHashToByteArray("7cdd22133b824547307865c5c03ca8f0");
            List<byte[]> globale = new List<byte[]> { one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen };

            using (StreamReader sr = File.OpenText("Dictionnaire.txt"))
            {
                while (!sr.EndOfStream)
                {
                    MD5 sha = MD5.Create();
                    string ligne = sr.ReadLine();
                    byte[] test = Encoding.ASCII.GetBytes(ligne);
                    hash = sha.ComputeHash(test);

                    foreach (var item in globale)
                    {
                        if (matches(item, hash))
                        Console.WriteLine((globale.IndexOf(item) + 1) +" : " +ligne + " => "
                                                + BitConverter.ToString(item).ToLower().Replace("-", ""));
                    }
                }
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            Console.ReadLine();
        }

        //fonction qui permet de comparer les mots de passe générés aux mots de passe désirés
        static bool matches(byte[] a, byte[] b)
        {
            for (int i = 0; i < 16; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }

        //décompose la chaine de charactère hexadecimal en un tableau de byte pour pouvoir utiliser.
        static byte[] StringHashToByteArray(string s)
        {
            return Enumerable.Range(0, s.Length / 2).Select(i => (byte)Convert.ToInt16(s.Substring(i * 2, 2), 16)).ToArray();
        }
    }
}
