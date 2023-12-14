using Getri_DFA_CountryState.EntityFramework;
using Getri_DFA_CountryState.Models;

namespace Getri_DFA_CountryState.Repository
{
    public class StateRepository : IStateReposiory
    {
        private readonly GetricountryStateDbContext dbContext;

        public StateRepository(GetricountryStateDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public State CreateState(State state)
        {
           dbContext.State.Add(state);
           dbContext.SaveChanges();
           return state;
        }

        public bool DeleteState(int id)
        {
            State state = dbContext.State.Where(x => x.StateId == id).FirstOrDefault();
            if (state == null)
            {
                return false;
            }
            else
            {
                dbContext.State.Remove(state);
                dbContext.SaveChanges();
                return true;
            }
        }

        public IEnumerable<State> GetStates()
        {
            return dbContext.State.ToList();
        }

        public State SearchState(int id)
        {
            State state = dbContext.State.Where(x => x.StateId == id).FirstOrDefault();
            return state;
        }

        public State UpdateState(State state)
        {
            State state1 = dbContext.State.Where(x => x.StateId == state.StateId).FirstOrDefault();
            if (state1 != null)
            {
                dbContext.State.Update(state);
                dbContext.SaveChanges();
            }
            return state;
        }
    }
}
