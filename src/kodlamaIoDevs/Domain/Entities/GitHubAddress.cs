using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GitHubAddress : Entity
    {
        public string Url { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public GitHubAddress()
        {

        }

        public GitHubAddress(int id, string url, int userId)
        {
            Id = id;
            Url = url;
            UserId = userId;
        }
    }
}
