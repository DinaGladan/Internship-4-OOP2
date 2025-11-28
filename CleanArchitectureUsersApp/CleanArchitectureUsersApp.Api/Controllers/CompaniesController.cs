using CleanArchitectureUsersApp.Api.Common;
using CleanArchitectureUsersApp.Application.Features.Companies.Commands.CreateCompany;
using CleanArchitectureUsersApp.Application.Features.Companies.Commands.DeleteCompany;
using CleanArchitectureUsersApp.Application.Features.Companies.Commands.UpdateCompany;
using CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanies;
using CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanyById;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureUsersApp.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly GetCompaniesQueryHandler _getCompanies;
        private readonly GetCompanyByIdQueryHandler _getCompanyById;
        private readonly CreateCompanyCommandHelper _createCompany;
        private readonly UpdateCompanyCommandHandler _updateCompany;
        private readonly DeleteCompanyCommandHandler _deleteCompany;

        public CompaniesController(GetCompaniesQueryHandler getCompanies, GetCompanyByIdQueryHandler getCompanyById, CreateCompanyCommandHelper createCompany, UpdateCompanyCommandHandler updateCompany, DeleteCompanyCommandHandler deleteCompany)
        {
            _getCompanies = getCompanies;
            _getCompanyById = getCompanyById;
            _createCompany = createCompany;
            _updateCompany = updateCompany;
            _deleteCompany = deleteCompany;
        }

        private void Check(string username, string password)
        {
            if(username!="test" || password!="test")
            {
                throw new UnauthorizedAccessException("Podaci nisu ispravni");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string username,
            [FromQuery] string password)
        {
            Check(username, password);

            var result = await _getCompanies.Handle();
            return result.ToActionResult(this);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            int id,
            [FromQuery] string username,
            [FromQuery] string password)
        {
            Check(username, password);

            var result = await _getCompanyById.Handle(new GetCompanyByIdQuery(id));
            return result.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            var result = await _createCompany.Handle(command);
            return result.ToActionResult(this);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyCommand command)
        {
            command.Request.Id = id;
            var result = await _updateCompany.Handle(command);
            return result.ToActionResult(this);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id,
            [FromQuery] string username,
            [FromQuery] string password)
        {
            Check(username, password);

            var result = await _deleteCompany.Handle(new DeleteCompanyCommand(id));
            return result.ToActionResult(this);
        }
    }
}
