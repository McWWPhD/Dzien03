﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziedziczenie.Pojazdy
{
    class Samochod : Pojazd
    {
        public void Uruchom()
        {
            Console.WriteLine("silnik start");
        }

        public void Zatankuj()
        {
            Console.WriteLine("Zalej PB/ON/LPG");
        }

        public void Zatrzymaj()
        {
            Console.WriteLine("silnik stop");
        }
    }
}
