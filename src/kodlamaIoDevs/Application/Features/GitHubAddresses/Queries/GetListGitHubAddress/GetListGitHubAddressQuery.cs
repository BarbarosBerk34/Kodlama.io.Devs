using Application.Features.GitHubAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Queries.GetListGitHubAddress
{
    public class GetListGitHubAddressQuery : IRequest<GitHubAddressListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGitHubAddressQueryHandler : IRequestHandler<GetListGitHubAddressQuery, GitHubAddressListModel>
        {
            private readonly IGitHubAddressRepository _gitHubAddressRepository;
            private readonly IMapper _mapper;

            public GetListGitHubAddressQueryHandler(IGitHubAddressRepository gitHubAddressRepository, IMapper mapper)
            {
                _gitHubAddressRepository = gitHubAddressRepository;
                _mapper = mapper;
            }

            public async Task<GitHubAddressListModel> Handle(GetListGitHubAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubAddress> gitHubAddresses = await _gitHubAddressRepository.GetListAsync(
                                                                 include: g => g.Include(c => c.User),
                                                                 index: request.PageRequest.Page,
                                                                 size: request.PageRequest.PageSize
                                                                 );
                GitHubAddressListModel model = _mapper.Map<GitHubAddressListModel>(gitHubAddresses);
                return model;
            }
        }
    }
}
