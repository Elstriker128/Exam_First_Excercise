using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace E1_Excercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k1, k2;
            double p1, p2;

            Console.WriteLine("Input miminum room number:");
            k1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input maximum room number:");
            k2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input miminum area number:");
            p1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input maximum area number:");
            p2 = int.Parse(Console.ReadLine());

            City A = InOutUtils.Read("Duomenys.txt");

            City B = Split(k1, k2, p1, p2, A);

            InOutUtils.Print(B);
        }
        /// <summary>
        /// This method finds the required flat according to the specified info
        /// </summary>
        /// <param name="k1">miminum room number</param>
        /// <param name="k2">maximum room number</param>
        /// <param name="p1">miminum area number</param>
        /// <param name="p2">maximum area number</param>
        /// <param name="A">The object of the City class</param>
        /// <returns></returns>
        public static City Split(int k1, int k2, double p1, double p2, City A)
        {
            City B = new City();
            for (int i = 0; i < A.Count; i++)
            {
                Flat flat = A.Get(i);
                if(flat.Area>=p1 && flat.Area<=p2 && flat.Rooms>=k1 && flat.Rooms<=k2)
                {
                    B.Add(flat);
                }
            }
            return B;
        }
    }
    class Flat
    {
        public string Address { get; set; }
        public double Area { get; set; }
        public int Rooms { get; set; }

        public Flat(string address, double area, int rooms)
        {
            Address = address;
            Area = area;
            Rooms = rooms;
        }
    }
    class City
    {
        private Flat[] flats;
        private int Capacity;
        public int Count { get; set; }
        public City(int capacity=16)
        {
            this.Capacity = capacity;
            this.flats = new Flat[capacity];
        }
        public Flat Get(int index)
        {
            return this.flats[index];
        }
        public void Add(Flat flat)
        {
            if(this.Count==this.Capacity)
            {
                this.Capacity *= 2;
            }
            this.flats[this.Count++]=flat;

        }
    }
    class InOutUtils
    {
        public static City Read(string filename)
        {
            City city = new City();
            string[] lines = File.ReadAllLines(filename);
            foreach(string line in lines)
            {
                string[] values = line.Split(';');
                string address = values[0];
                double area = double.Parse(values[1]);
                int rooms = int.Parse(values[2]);

                Flat flat = new Flat(address, area, rooms);
                city.Add(flat);
            }
            return city;
        }
        public static void Print(City B)
        {
            for (int i= 0; i < B.Count; i++)
            {
                Flat flat = B.Get(i);
                Console.WriteLine($"| {flat.Address} | {flat.Area} | {flat.Rooms} | ");
            }
        }
    }
}
