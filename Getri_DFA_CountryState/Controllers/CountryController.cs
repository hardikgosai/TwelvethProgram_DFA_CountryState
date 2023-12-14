using AutoMapper;
using Getri_DFA_CountryState.DTO;
using Getri_DFA_CountryState.Models;
using Getri_DFA_CountryState.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getri_DFA_CountryCountry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICountryRepository iCountryReposiory;
        public CountryController(IMapper _mapper, ICountryRepository _countryRepository) 
        {
            mapper = _mapper;
            iCountryReposiory = _countryRepository;
        }
        
        [HttpGet("CountryList")]
        public IActionResult GetCountries()
        {
            var Countries = iCountryReposiory.GetCountry().ToList();
            return Ok(Countries);
        }

        [HttpGet("GetAllCountryWithStates")]
        public IActionResult GetCountrywithStates()
        {
            var lstCountry = iCountryReposiory.GetCountrywithStates().ToList();
            List<CountryStateLstDTO> countryStateLstDTO = new List<CountryStateLstDTO>();
            foreach (var item in lstCountry)
            {
                CountryStateLstDTO countryStateLstDTO1 = new CountryStateLstDTO();
                countryStateLstDTO1.CountryId = item.CountryId;
                countryStateLstDTO1.Name = item.Name;
                countryStateLstDTO1.LstState = new List<StateDTO>();
                foreach(var state in item.States)
                {
                    StateDTO stateDTO = new StateDTO();
                    stateDTO.StateId = state.StateId;
                    stateDTO.Name = state.Name;
                    countryStateLstDTO1.LstState.Add(stateDTO);
                }

                countryStateLstDTO.Add(countryStateLstDTO1);
            }
            return Ok(countryStateLstDTO);
        }

        [HttpGet("SearchCountry")]
        public IActionResult SearchCountry(int id)
        {
            var Country = iCountryReposiory.SearchCountry(id);
            if (Country == null)
            {
                return NotFound("The Country record couldn't be found.");
            }
            return Ok(Country);
        }

        [HttpPost("CreateCountry")]
        public IActionResult CreateProduct(CreateCountryDTO createCountryDTO)
        {
            if (createCountryDTO == null)
            {
                return BadRequest("Country is null.");
            }
            var createdCountry = iCountryReposiory.CreateCountry(mapper.Map<Country>(createCountryDTO));
            return Ok(createdCountry);
        }

        [HttpPut("UpdateCountry")]
        public IActionResult UpdateProduct(UpdateCountryDTO updateCountryDTO)
        {
            if (updateCountryDTO == null)
            {
                return BadRequest("Country is null.");
            }
            var updatedCountry = iCountryReposiory.UpdateCountry(mapper.Map<Country>(updateCountryDTO));
            return Ok(updatedCountry);
        }

        [HttpDelete("DeleteCountry")]
        public IActionResult DeleteProduct(UpdateCountryDTO deleteCountryDTO)
        {
            var Country = iCountryReposiory.SearchCountry(deleteCountryDTO.CountryId);
            if (Country == null)
            {
                return NotFound("The Country record couldn't be found.");
            }
            var deletedCountry = iCountryReposiory.DeleteCountry(deleteCountryDTO.CountryId);
            return Ok(deletedCountry);
        }
    }
}
