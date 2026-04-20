using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommerhusLib.model
{
    public class Sommerhus
    {
        // instans felter
        private int _rentId;
        private string _streetAndNumber;
        private int _postalNo;
        private string _city;
        private int _distanceToBeach;
        private int _size;
        private int _noOfBeds;
        private bool _spa;
        private bool _allowPets;
        private bool _dishwasher;
        private bool _washingMachine;
        private int _pricePrWeek;

        // konstruktør
        public Sommerhus()
        {
            RentId =0;
            _streetAndNumber ="";
            _postalNo =0;
            _city ="";
            _distanceToBeach =0;
            _size =0;
            _noOfBeds =0;
            _spa =false;
            _allowPets =false;
            _dishwasher =false;
            _washingMachine =false;
            _pricePrWeek =0;
        }

        public Sommerhus(int rentId, string streetAndNumber, int postalNo, string city, int distanceToBeach, int size, int noOfBeds, bool spa, 
                          bool allowPets, bool dishwasher, bool washingMachine, int price)
        {
            RentId =rentId;
            _streetAndNumber =streetAndNumber;
            _postalNo =postalNo;
            _city =city;
            _distanceToBeach =distanceToBeach;
            _size =size;
            _noOfBeds =noOfBeds;
            _spa =spa;
            _allowPets =allowPets;
            _dishwasher =dishwasher;
            _washingMachine =washingMachine;
            _pricePrWeek =price;
        }

        public int RentId
        {
            get { return _rentId; }
            set { 
                if (value < 0)
                {
                    throw new ArgumentException("RentId skal være positivt");
                }
                
                _rentId =value; 
            
            }
        }

        public string StreetAndNumber
        {
            get { return _streetAndNumber; }
            set { _streetAndNumber =value; }
        }
        public int PostalNo
        {
            get { return _postalNo; }
            set { _postalNo =value; }
        }
        public string City
        {
            get { return _city; }
            set { _city =value; }
        }

        public int DistanceToBeach
        {
            get { return _distanceToBeach; }
            set { _distanceToBeach =value; }
        }
        public int Size
        {
            get { return _size; }
            set { _size =value; }
        }
        public int NoOfBeds
        {
            get { return _noOfBeds; }
            set {_noOfBeds =value; }
        }
        public bool Spa
        {
            get { return _spa; }
            set { _spa =value; }
        }
        public bool AllowPets
        {
            get { return _allowPets; }
            set { _allowPets =value; }
        }
        public bool DishWasher
        {
            get { return _dishwasher; }
            set { _dishwasher =value; }
        }
        public bool WashingMachine
        {
            get { return _washingMachine; }
            set { _washingMachine =value; }
        }
        public int PricePrWeek
        {
            get { return _pricePrWeek; }
            set { _pricePrWeek =value; }
        }

        public override string ToString()
        {
            return "RentId=" + RentId + ", StreetAndNumber=" + StreetAndNumber + ", PostalNo=" + PostalNo +
                ", City=" + City + ", DistanceToBeach=" + DistanceToBeach + ", Size=" + Size + ", NoOfBeds=" + NoOfBeds +
                ", Spa=" + Spa + ", AllowPets=" + AllowPets + ",DishWasher=" + DishWasher +
                ", WashingMachine=" + WashingMachine + ", PricePrWeek=" + PricePrWeek;
        }
    }
}
