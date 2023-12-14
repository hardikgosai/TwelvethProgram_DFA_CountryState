using Getri_DFA_CountryState.Models;

namespace Getri_DFA_CountryState.Repository
{
    public interface IStateReposiory
    {
        IEnumerable<State> GetStates();

        State SearchState(int id);

        State CreateState(State state);

        State UpdateState(State state);

        bool DeleteState(int id);
    }
}
