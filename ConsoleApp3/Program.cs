using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {

        class Car
        {
            [SensitiveData(DataType.Family)]
            public string Fio { get; set; }
            public string Name { get; set; }
            [SensitiveData(DataType.VinCode)]
            public string VinCode { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cars = new List<Car>
            {
                new Car(){ Name="Opel",VinCode= "1234CA" },
                new Car(){ Name="Vaz",VinCode= "3211AA" },
            };

            var requestString = JsonConvert.SerializeObject(cars,
                new JsonSerializerSettings() { ContractResolver = new SensitiveDataResolver() });
        }
    }
}
