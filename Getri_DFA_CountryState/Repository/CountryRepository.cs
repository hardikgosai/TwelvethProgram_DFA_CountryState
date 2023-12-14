using Getri_DFA_CountryState.EntityFramework;
using Getri_DFA_CountryState.Models;

namespace Getri_DFA_CountryState.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly GetricountryStateDbContext dbContext;

        public CountryRepository(GetricountryStateDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Country CreateCountry(Country country)
        {
            dbContext.Country.Add(country);
            dbContext.SaveChanges();
            return country;
        }

        public bool DeleteCountry(int id)
        {
            Country country = dbContext.Country.Where(x=> x.CountryId == id).FirstOrDefault();
            if (country == null)
            {
                return false;
            }
            else
            {
                dbContext.Country.Remove(country);
                dbContext.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Country> GetCountry()
        {
            return dbContext.Country.ToList();
        }

        public Country SearchCountry(int id)
        {
            Country country = dbContext.Country.Where(x => x.CountryId == id).FirstOrDefault();
            return country;
        }

        public Country UpdateCountry(Country country)
        {
            Country country1 = dbContext.Country.Where(x => x.CountryId == country.CountryId).FirstOrDefault();
            if (country1 != null)
            {
                dbContext.Country.Update(country);
                dbContext.SaveChanges();
            }
            return country;
        }

        public IEnumerable<Country> GetCountrywithStates()
        {
            List<Country> country = dbContext.Country.ToList();
            foreach (var item in country)
            {
                item.States = dbContext.State.Where(x => x.CountryId == item.CountryId).ToList();
            }
            
            return country;
        }
    }
}
