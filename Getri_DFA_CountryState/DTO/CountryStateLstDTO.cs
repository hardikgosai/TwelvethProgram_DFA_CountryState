namespace Getri_DFA_CountryState.DTO
{
    public class CountryStateLstDTO
    {
        public int CountryId { get; set; }

        public string Name { get; set; } = null!;

        public List<StateDTO> LstState { get; set; } = null!;
    }
}
