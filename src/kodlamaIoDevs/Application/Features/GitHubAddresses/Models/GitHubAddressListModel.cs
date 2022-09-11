using Application.Features.GitHubAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Models
{
    public class GitHubAddressListModel : BasePageableModel
    {
        public IList<GitHubAddressListDto> Items { get; set; }
    }
}
