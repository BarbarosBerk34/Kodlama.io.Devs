using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Dtos
{
    public class GitHubAddressListDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
