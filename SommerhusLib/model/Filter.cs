using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommerhusLib.model
{
    public class Filter
    {
        // instans felter
        private int? _postalNo;
        private string? _city;
        private int? _minDistance;
        private int? _maxDistance;
        private int? _minSize;
        private int? _maxSize;
        private int? _minBeds;
        private int? _maxBeds;
        private bool? _spa;
        private bool? _allowPets;
        private bool? _dishwasher;
        private bool? _washingMachine;
        private int? _minPrice;
        private int? _maxPrice;

        // konstruktør NB kun default
        public Filter()
        {
            _postalNo = null;
            _city = null;
            _minDistance = null;
            _maxDistance = null;
            _minSize = null;
            _maxSize = null;
            _minBeds = null;
            _maxBeds = null;
            _spa = null;
            _allowPets = null;
            _dishwasher = null;
            _washingMachine = null;
            _minPrice = null;
            _maxPrice = null;
        }

        // properties
        public int? PostalNo
        {
            get { return _postalNo; }
            set { _postalNo = value; }
        }

        public string? City
        {
            get { return _city; }
            set { _city = value; }
        }
        public int? MinDistance
        {
            get { return _minDistance; }
            set { _minDistance = value; }
        }
        public int? MaxDistance
        {
            get { return _maxDistance; }
            set { _maxDistance = value; }
        }
        public int? MinSize
        {
            get { return _minSize; }
            set { _minSize = value; }
        }
        public int? MaxSize
        {
            get { return _maxSize; }
            set { _maxSize = value; }
        }
        public int? MinBeds
        {
            get { return _minBeds; }
            set { _minBeds = value; }
        }
        public int? MaxBeds
        {
            get { return _maxBeds; }
            set { _maxBeds = value; }
        }
        public bool? Spa
        {
            get { return _spa; }
            set { _spa = value; }
        }
        public bool? AllowPets
        {
            get { return _allowPets; }
            set { _allowPets = value; }
        }
        public bool? Dishwasher
        {
            get { return _dishwasher; }
            set { _dishwasher = value; }
        }
        public bool? WashingMachine
        {
            get { return _washingMachine; }
            set { _washingMachine = value; }
        }
        public int? MinPrice
        {
            get { return _minPrice; }
            set { _minPrice = value; }
        }
        public int? MaxPrice
        {
            get { return _maxPrice; }
            set { _maxPrice = value; }
        }

        // ToString
        public override string ToString()
        {
            return "PostalNo=" + PostalNo+ ", City=" + City+ ", MinDistance=" + MinDistance+ ", MaxDistance=" + MaxDistance+ ", MinSize=" + MinSize
                + ", MaxSize=" + MaxSize+ ", MinBeds=" + MinBeds+ ", MaxBeds=" + MaxBeds
                + ", Spa=" + Spa+ ", AllowPets=" + AllowPets+ ", Dishwasher=" + Dishwasher
                + ", WashingMachine=" + WashingMachine+ ", MinPrice=" + MinPrice+ ", MaxPrice=" + MaxPrice;
        }

       

    }
}
