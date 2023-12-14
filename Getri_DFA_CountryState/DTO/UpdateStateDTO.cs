namespace Getri_DFA_CountryState.DTO
{
    public class UpdateStateDTO
    {
        public int StateId { get; set; }

        public string Name { get; set; } = null!;

        public int? CountryId { get; set; }
    }
}
