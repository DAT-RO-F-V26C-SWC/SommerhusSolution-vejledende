using SommerhusLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SommerhusLib
{
    public class SommerhusService
    {
        private SommerhusRegister _register;

        public SommerhusService(SommerhusRegister register)
        {
            _register = register;
        }

        /*
        * Forretningslogik
        */
        public Sommerhus GetById(int id)
        {
            Sommerhus NotFound = null;
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.RentId == id)
                {
                    return sommerhus;
                }
            }
            return NotFound;
        }
        public List<Sommerhus> GetByPostal(int code)
        {
            List<Sommerhus> sommerhuse = new List<Sommerhus>();
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.PostalNo == code)
                {
                    sommerhuse.Add(sommerhus);
                }
            }
            return sommerhuse;

        }
        public List<Sommerhus> GetMinBeds(int minBeds)
        {
            List<Sommerhus> sommerhuse = new List<Sommerhus>();
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.NoOfBeds >= minBeds)
                {
                    sommerhuse.Add(sommerhus);
                }
            }
            return sommerhuse;
        }
        public List<Sommerhus> GetMaxPrice(int maxPrice)
        {
            List<Sommerhus> sommerhuse = new List<Sommerhus>();
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.PricePrWeek <= maxPrice)
                {
                    sommerhuse.Add(sommerhus);
                }
            }
            return sommerhuse;
        }
        public List<Sommerhus> GetAllowPets()
        {
            List<Sommerhus> sommerhuse = new List<Sommerhus>();
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.AllowPets)
                {
                    sommerhuse.Add(sommerhus);
                }
            }
            return sommerhuse;
        }
        public List<Sommerhus> GetPetsAndDish()
        {
            List<Sommerhus> sommerhuse = new List<Sommerhus>();
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.AllowPets && sommerhus.DishWasher)
                {
                    sommerhuse.Add(sommerhus);
                }
            }
            return sommerhuse;
        }
        public List<Sommerhus> GetMinBedsMaxDistance(int minBeds, int maxDist)
        {
            List<Sommerhus> sommerhuse = new List<Sommerhus>();
            foreach (Sommerhus sommerhus in _register.GetAll())
            {
                if (sommerhus.NoOfBeds >= minBeds && sommerhus.DistanceToBeach <= maxDist)
                {
                    sommerhuse.Add(sommerhus);
                }
            }
            return sommerhuse;

        }




        /*
         * sortering
         */

        public List<Sommerhus> SortByPrice()
        {
            List<Sommerhus> sommerhuse = _register.GetAll();
            List<Sommerhus> resultat = new List<Sommerhus>();

            while (sommerhuse.Count > 0)
            {
                Sommerhus mindstPrisHus = getMindstePris(sommerhuse);

                resultat.Add(mindstPrisHus);
                sommerhuse.Remove(mindstPrisHus);
            }

            return resultat;
        }

        private Sommerhus getMindstePris(List<Sommerhus> sommerhuse)
        {
            Sommerhus resultatHus = sommerhuse.First();

            foreach (Sommerhus hus in sommerhuse)
            {
                if (hus.PricePrWeek < resultatHus.PricePrWeek)
                {
                    resultatHus = hus;
                }
            }

            return resultatHus;
        }


        /* 
         * Ekstra
         */
        public List<Sommerhus> GetByFilter(Filter filter)
        {
            List<Sommerhus> sommerhuse = _register.GetAll();
            List<Sommerhus> temp = new List<Sommerhus>();

            // Filtrer på postalNo
            if (filter.PostalNo != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.PostalNo == filter.PostalNo)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.City != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.City == filter.City)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MinDistance != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.DistanceToBeach >= filter.MinDistance)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MaxDistance != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.DistanceToBeach <= filter.MaxDistance)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MinSize != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.Size >= filter.MinSize)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MaxSize != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.Size <= filter.MaxSize)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MinBeds != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.NoOfBeds >= filter.MinBeds)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MaxBeds != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.NoOfBeds <= filter.MaxBeds)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.Spa != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.Spa)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.AllowPets != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.AllowPets)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.Dishwasher != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.DishWasher)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.WashingMachine != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.WashingMachine)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MinPrice != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.PricePrWeek >= filter.MinPrice)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }
            if (filter.MaxPrice != null)
            {
                foreach (Sommerhus sommerhus in sommerhuse)
                {
                    if (sommerhus.PricePrWeek <= filter.MaxPrice)
                    {
                        temp.Add(sommerhus);
                    }
                }
                sommerhuse = temp;
                temp = new List<Sommerhus>();
            }

            return sommerhuse;
        }


        /*
         * Ekstra sort
         */
        public List<Sommerhus> SortByDistance()
        {
            List<Sommerhus> resultatHuse = _register.GetAll();


            for (int i = 0; i < resultatHuse.Count; i++)
            {
                int maxIx = resultatHuse.Count - i - 1;
                for (int j = 0; (j < maxIx); j++)
                {
                    if (resultatHuse[j].DistanceToBeach > resultatHuse[j + 1].DistanceToBeach)
                    {
                        Swap(resultatHuse, j, j + 1);
                    }
                }
            }
            return resultatHuse;
        }


        public List<Sommerhus> SortByBeds()
        {
            List<Sommerhus> resultatHuse = _register.GetAll();

            for (int i = 0; i < resultatHuse.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (resultatHuse[j].NoOfBeds < resultatHuse[j - 1].NoOfBeds)
                    {
                        Swap(resultatHuse, j, j - 1);
                    }
                }
            }
            return resultatHuse;
        }


        private void Swap(List<Sommerhus> resultatHuse, int x, int y)
        {
            Sommerhus tmp = resultatHuse[x];
            resultatHuse[x] = resultatHuse[y];
            resultatHuse[y] = tmp;
        }


        // Meget ekstra
        public List<Sommerhus> SortBySize()
        {
            List<Sommerhus> resultatHuse = _register.GetAll();

            resultatHuse = MergeSort(resultatHuse, 0, resultatHuse.Count - 1);

            return resultatHuse;
        }
        
        private List<Sommerhus> MergeSort(List<Sommerhus> resultatHuse, int left, int right)
        {
            int midt = (left + right) / 2;
            MergeSort(resultatHuse, left, midt);
            MergeSort(resultatHuse, midt + 1, right);

            Merge(resultatHuse, left, midt, right);

            return resultatHuse;
        }

        private void Merge(List<Sommerhus> resultatHuse, int left, int midt, int right)
        {
            if (left < right)
            {
                List<Sommerhus> temp = new List<Sommerhus>();
                int i = left;
                int j = midt + 1;
                while (i <= midt && j <= right)
                {
                    if (resultatHuse[i].Size < resultatHuse[j].Size)
                    {
                        temp.Add(resultatHuse[i]);
                        i++;
                    }
                    else
                    {
                        temp.Add(resultatHuse[j]);
                        j++;
                    }
                }
                while (i <= midt)
                {
                    temp.Add(resultatHuse[i]);
                    i++;
                }
                while (j <= right)
                {
                    temp.Add(resultatHuse[j]);
                    j++;
                }
                for (int k = left; k <= right; k++)
                {
                    resultatHuse[k] = temp[k - left];
                }
            }
        }
    }
}
