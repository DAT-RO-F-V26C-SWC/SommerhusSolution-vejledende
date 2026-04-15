using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommerhusLib.model
{
    internal class SommerhusTestData

    {
        private int nextId = 1;

        public SommerhusTestData() { }

        public void Populate(List<Sommerhus> liste, int numberOfSommerhus)
        {
            // Tilpasset AI-genereret

            Random rng = new Random();
            string[] streets = new[]
            {
                "Strandvejen", "Kystvej", "Havblik", "Bøgevænget", "Skovstien",
                "Søndergade", "Nørregade", "Lærkevej", "Klippevej", "Mosevej"
            };
            string[] cities = new[]
            {
                "Blokhus", "Hvide Sande", "Rømø", "Skagen", "Sønderborg",
                "Aarhus", "Odense", "København", "Aalborg", "Ribe"
            };
            int[] postalNos = new[]
            {
                9492, 6960, 6792, 9990, 6400,
                8000, 5000, 1050, 9000, 6760
            };


            for (var i = 0; i < numberOfSommerhus; i++)
            {
                int id = nextId++;
                string street = streets[rng.Next(streets.Length)];
                string streetAndNumber = $"{street} {rng.Next(1, 201)}";
                int rndCity = rng.Next(cities.Length);
                int postalNo = postalNos[rndCity];
                string city = cities[rndCity];
                int distanceToBeach = rng.Next(0, 3001); // meters
                int size = rng.Next(30, 201); // square meters
                int noOfBeds = rng.Next(1, 13);
                bool spa = rng.NextDouble() < 0.2; // ~20% have spa
                bool allowPets = rng.NextDouble() < 0.3; // ~30% allow pets
                bool dishwasher = rng.NextDouble() < 0.8; // ~80% have dishwasher
                bool washingMachine = rng.NextDouble() < 0.7; // ~70% have washing machine

                // Base price formula with some randomness
                var basePrice = 500 + (size * 10) + (noOfBeds * 300) + (spa ? 2000 : 0);
                var pricePrWeek = basePrice + rng.Next(-500, 2001);

                var sommerhus = new Sommerhus(
                    id,
                    streetAndNumber,
                    postalNo,
                    city,
                    distanceToBeach,
                    size,
                    noOfBeds,
                    spa,
                    allowPets,
                    dishwasher,
                    washingMachine,
                    pricePrWeek
                );

                liste.Add(sommerhus);
            }
        }
    }
}
