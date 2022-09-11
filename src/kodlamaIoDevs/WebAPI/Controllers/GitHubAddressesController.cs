using Application.Features.GitHubAddresses.Commands.CreateGitHubAddress;
using Application.Features.GitHubAddresses.Commands.DeleteGitHubAddress;
using Application.Features.GitHubAddresses.Commands.UpdateGitHubAddress;
using Application.Features.GitHubAddresses.Dtos;
using Application.Features.GitHubAddresses.Models;
using Application.Features.GitHubAddresses.Queries.GetListGitHubAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GitHubAddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGitHubAddressCommand createGitHubAddressCommand)
        {
            CreatedGitHubAddressDto result = await Mediator.Send(createGitHubAddressCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGitHubAddressQuery getListGitHubAddressQuery = new() { PageRequest = pageRequest };
            GitHubAddressListModel result = await Mediator.Send(getListGitHubAddressQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGitHubAddressCommand updateGitHubAddressCommand)
        {
            UpdatedGitHubAddressDto result = await Mediator.Send(updateGitHubAddressCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGitHubAddressCommand deleteGitHubAddressCommand)
        {
            DeletedGitHubAddressDto result = await Mediator.Send(deleteGitHubAddressCommand);
            return Ok(result);
        }
    }
}
