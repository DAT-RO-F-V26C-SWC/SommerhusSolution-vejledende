using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommerhusLib.model
{
    public class SommerhusRegister
    {
        // instans felter
        // aggregering
        private List<Sommerhus> _sommerhuse;

        // konstruktør
        public SommerhusRegister()
        {
            _sommerhuse = new List<Sommerhus>();
        }
        public SommerhusRegister(int noOftestdata)
        {
            _sommerhuse = new List<Sommerhus>();
            if (noOftestdata > 0)
            {
                PopulateWithTestData(noOftestdata);
            }
        }



        public SommerhusRegister(List<Sommerhus> sommerhuse)
        {
            _sommerhuse = sommerhuse;
        }

        // properties
        public List<Sommerhus> SommerhusListe
        {
            get { return _sommerhuse; }
            set { _sommerhuse = value; }
        }

        /*
         * CRUD
         */
        public void Add(Sommerhus sommerhus)
        {
            _sommerhuse.Add(sommerhus);
        }

        public List<Sommerhus> GetAll()
        {
            return new List<Sommerhus>(_sommerhuse);
        }

        public Sommerhus GetById(int id)
        {
            Sommerhus foundSommerhus = null;

            foreach (var sommerhus in _sommerhuse)
            {
                if (sommerhus.RentId == id)
                {
                    return sommerhus;
                }
            }

            return foundSommerhus;
        }

        public Sommerhus Update(int id, Sommerhus updatedSommerhus)
        {
            Sommerhus foundSommerhus = GetById(id);
            if (foundSommerhus != null)
            {
                foundSommerhus.StreetAndNumber = updatedSommerhus.StreetAndNumber;
                foundSommerhus.PostalNo = updatedSommerhus.PostalNo;
                foundSommerhus.City = updatedSommerhus.City;
                foundSommerhus.DistanceToBeach = updatedSommerhus.DistanceToBeach;
                foundSommerhus.Size = updatedSommerhus.Size;
                foundSommerhus.NoOfBeds = updatedSommerhus.NoOfBeds;
                foundSommerhus.Spa = updatedSommerhus.Spa;
                foundSommerhus.AllowPets = updatedSommerhus.AllowPets;
                foundSommerhus.DishWasher = updatedSommerhus.DishWasher;
                foundSommerhus.WashingMachine = updatedSommerhus.WashingMachine;
                foundSommerhus.PricePrWeek = updatedSommerhus.PricePrWeek;
            }

            return foundSommerhus;
        }

        public Sommerhus Remove(int id)
        {
            Sommerhus foundSommerhus = GetById(id);
            if (foundSommerhus != null)
            {
                _sommerhuse.Remove(foundSommerhus);
            }
            return foundSommerhus;
        }




        // help methods 
        private void PopulateWithTestData(int numberOfSommerhus)
        {
            var testData = new SommerhusTestData();
            testData.Populate(_sommerhuse, numberOfSommerhus);
        }
    }
}
