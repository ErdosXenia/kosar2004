using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccek = new List<Meccs>();

        static void feladat2()
        {
            StreamReader sr = new StreamReader("eredmenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                meccek.Add(new Meccs(sr.ReadLine()));
            }
            sr.Close();
        }

        static void feladat3()
        {
            Console.Write("3. feladat: Real Madrid: ");
            /*int megszamol = 0;
            foreach (var m in meccek)
            {
                if (m.Hazai == "Real Madrid")
                {
                    megszamol++;
                }

            }*/

            var hazai = from m in meccek
                        where m.Hazai == "Real Madrid"
                        select new { Hazai = m.Hazai };

            int hazadb = hazai.ToList().Count;

            var idegen = from m in meccek
                         where m.Idegen == "Real Madrid"
                         select new { Idegen = m.Idegen };

            int idegendb = idegen.ToList().Count;

            Console.WriteLine($"Hazai: {hazadb}, Idegen: {idegendb}");

            
        }

        static void feladat4()
        {
            Console.Write("4. Feladat: Volt döntetlen? ");
            var dontetlen = from m in meccek
                            where m.HPont == m.IPont
                            select m;
            int dontetlendb = dontetlen.ToList().Count;

            if (dontetlendb==0)
            {
                Console.WriteLine("Nem");

            }
            else
            {
                Console.WriteLine("Volt");
            }

        }

        static void feladat5()
        {
            Console.Write("5. Feladat: barcelonai csapat neve: ");
            var csapat = from m in meccek
                         where m.Hazai.Contains("Barcelona")
                         select new { Hazai=m.Hazai};
            var barcanev = csapat.ToArray()[0].Hazai;

            Console.WriteLine(barcanev);

            /*int i = 0;
            while (!meccek[i].Hazai.Contains("Barcelona"))
            {
                i++;
            }*/
        }

        static void feladat6()
        {
            Console.WriteLine("6. Feladat:");
            var mikor=from m in meccek
                      where m.Ido=="2004-11-22"
                      
                      select new { Hazai =m.Hazai, Idegen=m.Idegen, HP=m.HPont, IP=m.IPont };

            foreach (var m in mikor)
            {
                Console.WriteLine($"{m.Hazai} - {m.Idegen} ({m.HP} : {m.IP})");
            }
                      
        }

        static void feladat7()
        {
            Console.WriteLine("7. Feladat: ");
            var stadion = from m in meccek
                          group m by m.Hely into station
                          select station;

            foreach (var station in stadion)
            {
                if (stadion.Count() > 20)
                {
                    Console.WriteLine($"\t{station.Key}: {station.Count()}");
                }

            }
        }

        //fáljba meccseket mint a 6-osba
        static void feladat8()
        {
            StreamWriter sr = new StreamWriter("nyolcasfeladat.txt");
            foreach (var m in meccek)
            {
                sr.WriteLine(m.Atalakit());
            }
            sr.Close();
        }

        static void Main(string[] args)
        {
            feladat2();
            /*foreach (var m in meccek)
            {
                Console.WriteLine($"{m.Hazai} - {m.Idegen} {m.HPont} {m.IPont} {m.Hely} {m.Ido}");
            }*/
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            feladat8();
            

            Console.ReadKey();
        }
    }
}
