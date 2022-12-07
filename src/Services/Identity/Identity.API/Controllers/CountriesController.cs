using Microsoft.AspNetCore.Mvc;
using sattec.Identity.Application.Common.Models;
using sattec.Identity.Application.Users.Commands.City.CreateCity;
using sattec.Identity.Application.Users.Commands.City.UpdateCity;
using sattec.Identity.Application.Users.Commands.Country.CreateCountry;
using sattec.Identity.Application.Users.Commands.Country.UpdateCountry;
using sattec.Identity.Application.Users.Queries.CityInformation;
using sattec.Identity.Application.Users.Queries.CountryInformation;
using sattec.Identity.Application.Users.Queries.OrganizationBranchesInformation;
using sattec.Identity.WebUI.Controllers;

namespace Identity.API.Controllers
{
    public class CountriesController : ApiControllerBase
    {
        [Route("Country"), HttpPost]
        public async Task<ActionResult<Result>> PostCountry(CreateCountryCommand command)
        {
            return await Mediator.Send(command);
        } 
        [Route("Country"), HttpPut]
        public async Task<ActionResult<Result>> PutCountry(UpdateCountryCommand command)
        {
            return await Mediator.Send(command);
        }
        [Route("Country"), HttpGet]
        public async Task<ActionResult<CountryInformation>> GetCountryInformation()
        {
            return await Mediator.Send(new GetCountryInformationQuery());
        }
        [Route("City"), HttpPost]
        public async Task<ActionResult<Result>> PostCity(CreateCityCommand command)
        {
            return await Mediator.Send(command);
        } 
        [Route("City"), HttpPut]
        public async Task<ActionResult<Result>> PutCity(UpdateCityCommand command)
        {
            return await Mediator.Send(command);
        }
        [Route("City"), HttpGet]
        public async Task<ActionResult<CityInformation>> GetCityInformation()
        {
            return await Mediator.Send(new GetCityInformationQuery());
        }
    }
}
