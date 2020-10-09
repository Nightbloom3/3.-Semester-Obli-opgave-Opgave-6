using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace FanLibrary
{
    public class FanOutPut
    {
        // dette skal være instance felter da vi skal have input fra brugeren.
        private string _navn;
        private double _temp;
        private double _fugt;

        public int id { get; } = idcounter;

        public static int idcounter { get; set; } = 1;

        public string Navn
        {
            get => _navn;
            set
            {
                if (value.Length >= 2)
                {
                    _navn = value;
                }

                else
                {
                    throw new Exception("Fortæl brugeren at navnet er forkert");
                }

            }

        }

        public double Temp
        {
            get => _temp;
            set
            {
                if (value >= 15 && value <= 25)
                {
                    _temp = value;
                }

                else
                {
                    throw new Exception("Uden for scope");
                }
            }
        }

        public double Fugt
        {
            get => _fugt;
            set
            {
                if (value >= 30 && value <= 80)
                {
                    _fugt = value;
                }

                else
                {
                    throw new Exception("Uden for scope");
                }
            }
        }

        public FanOutPut(string navn, double temp, double fugt)
        {
            id = idcounter++;
            Navn = navn;
            Temp = temp;
            Fugt = fugt;
        }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(Navn)}: {Navn}, {nameof(Temp)}: {Temp}, {nameof(Fugt)}: {Fugt}";
        }

        public FanOutPut()
        {

        }
    }
}

