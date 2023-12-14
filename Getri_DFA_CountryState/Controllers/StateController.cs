using AutoMapper;
using Getri_DFA_CountryState.DTO;
using Getri_DFA_CountryState.Models;
using Getri_DFA_CountryState.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getri_DFA_CountryState.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IStateReposiory iStateReposiory;
        private readonly ICountryRepository iCountryReposiory;
        public StateController(IMapper _mapper, IStateReposiory _iStateRepository, ICountryRepository _iCountryRepository)
        {
            mapper = _mapper;
            iStateReposiory = _iStateRepository;
            iCountryReposiory = _iCountryRepository;
        }

        [HttpGet("StateList")]
        public IActionResult GetStates()
        {
            var states = iStateReposiory.GetStates().ToList();
            return Ok(states);
        }

        [HttpGet("SearchState")]
        public IActionResult SearchState(int id)
        {
            var state = iStateReposiory.SearchState(id);
            if (state == null)
            {
                return NotFound("The state record couldn't be found.");
            }
            return Ok(state);
        }

        [HttpPost("CreateState")]
        public IActionResult CreateProduct(CreateStateDTO createStateDTO)
        {
            if (createStateDTO == null)
            {
                return BadRequest("State is null.");
            }
            var createdState = iStateReposiory.CreateState(mapper.Map<State>(createStateDTO));
            return Ok(createdState);
        }

        [HttpPut("UpdateState")]
        public IActionResult UpdateProduct(UpdateStateDTO updateStateDTO)
        {
            if (updateStateDTO == null)
            {
                return BadRequest("State is null.");
            }
            var updatedState = iStateReposiory.UpdateState(mapper.Map<State>(updateStateDTO));
            return Ok(updatedState);
        }

        [HttpDelete("DeleteState")]
        public IActionResult DeleteProduct(UpdateStateDTO deleteStateDTO)
        {
            var state = iStateReposiory.SearchState(deleteStateDTO.StateId);
            if (state == null)
            {
                return NotFound("The state record couldn't be found.");
            }
            var deletedState = iStateReposiory.DeleteState(deleteStateDTO.StateId);
            return Ok(deletedState);
        }

        [HttpGet("GetAllCountryWithStates")]
        public IActionResult GetAllCountryWithStates()
        {
            List<CountryStateLstDTO> countryStateDTOs = new List<CountryStateLstDTO>();
            var lstCountry = iCountryReposiory.GetCountry();

            foreach (var country in lstCountry)
            {
                var countryItem = country.CountryId;
                var lstStateWithAllStates = iStateReposiory.GetStates();
                var lstState = iStateReposiory.GetStates().Where(x => x.CountryId == countryItem);
                CountryStateLstDTO countryStateDTO = new CountryStateLstDTO();
                countryStateDTO.CountryId = country.CountryId;
                countryStateDTO.Name = country.Name;
                countryStateDTO.LstState = new List<StateDTO>();
                foreach(var item in lstState)
                {
                    StateDTO stateDTO = new StateDTO();
                    stateDTO.StateId = item.StateId;
                    stateDTO.Name = item.Name;
                    countryStateDTO.LstState.Add(stateDTO);
                }

                countryStateDTOs.Add(countryStateDTO);
            }

            return Ok(countryStateDTOs);
        }
    }
}
