﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    class Program
    {
        static void Main(string[] args)
        {
            Samochod samochod = new Samochod("FIAT", 180);
            //samochod.UstawPredkoscMax(200);
            samochod.Predkosc = -10;
            samochod.LiczbaDrzwi = 4;
            Console.WriteLine(samochod.Predkosc);
            Console.ReadKey();
        }
    }
}
