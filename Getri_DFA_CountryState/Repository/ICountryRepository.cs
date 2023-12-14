using Getri_DFA_CountryState.Models;

namespace Getri_DFA_CountryState.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetCountry();

        Country SearchCountry(int id);

        Country CreateCountry(Country country);

        Country UpdateCountry(Country country);

        IEnumerable<Country> GetCountrywithStates();

        bool DeleteCountry(int id);
    }
}
