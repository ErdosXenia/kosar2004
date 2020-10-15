using System;

namespace kosar2004
{
    internal class Meccs
    {
        public string Hazai { get; private set; }
        public string Idegen { get; private set; }
        public int HPont { get; private set; }
        public int IPont { get; private set; }
        public string Hely { get; private set; }
        public string Ido { get; private set; }

        public Meccs(string hazai, string idegen, int hPont, int iPont, string hely, string ido)
        {
            this.Hazai = hazai;
            this.Idegen = idegen;
            this.HPont = hPont;
            this.IPont = iPont;
            this.Hely = hely;
            this.Ido = ido;
        }

        public Meccs(string sor)
        {
            string[] a = sor.Split(';');
            Hazai = a[0];
            Idegen = a[1];
            HPont = Convert.ToInt32(a[2]);
            IPont = Convert.ToInt32(a[3]);
            Hely = a[4];
            Ido = a[5];
        }

        public string Atalakit()
        {
            string tmp=Hazai+" - "+Idegen+" "+"("+Convert.ToInt32(HPont)+":"+Convert.ToInt32(IPont)+")";
            return tmp;
        }
    }
}