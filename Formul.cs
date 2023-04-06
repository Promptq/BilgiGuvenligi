using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bitmod
{
    class Formul
    {
        private int Sayi;
        private int Us;
        private int Mod;
        private int BitSayisi;
        private List<int> KatList = new List<int>();
        public Formul(int sayi, int us, int mod, int bitSayisi)
        {
            this.Sayi = sayi;
            this.Us = us;
            this.Mod = mod;
            this.BitSayisi = bitSayisi;

            KatList.Add(1);
            for (int i = 1; i < Math.Pow(2, bitSayisi); ++i)
            {
                KatList.Add((KatList[i - 1] * Sayi) % Mod);
            }
            foreach (int i in KatList)
            {
                Console.WriteLine(i);
            }
        }

        public void hesap()
        {
            var uzunluk = Convert.ToString(Us, 2).Length;
            var fark = (uzunluk % BitSayisi) != 0 ? BitSayisi - (uzunluk % BitSayisi) : 0;
            
            var bits = Convert.ToString(Us, 2).PadLeft(uzunluk + fark, '0').ToCharArray();
            List<int> list = new List<int>();
            string oge = "";
            foreach (var arg in bits)
            {
                if (oge.Length == BitSayisi - 1)
                {
                    oge += arg;
                    list.Add(Convert.ToInt32(oge, 2));

                    oge = "";
                }
                else
                {
                    oge += arg;
                }
            }
            double ans = -1;
            double stepA = 0;
            

            foreach (var b in list)
            {

                if (ans == -1)
                {
                    ans = Math.Pow(Sayi, b) % Mod;
                    Console.WriteLine($"Adım 1: ----   |   Adım 2: {KatList[b]} = {ans}");
                }
                else
                {
                    stepA = Math.Pow(ans, Math.Pow(2, BitSayisi)) % Mod;

                   // ans = Math.Pow(ans, Math.Pow(2, BitSayisi)) % Mod;
                    Console.Write($"Adım 1: {ans}^{Math.Pow(2, BitSayisi)} mod {Mod} = {stepA}   |   ");


                    ans = stepA * KatList[b] % Mod;
                    Console.WriteLine($"Adım 2: {stepA} * {KatList[b]} = {ans}");
                }

                
            }

        }
    }
}
