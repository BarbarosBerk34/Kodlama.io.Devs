using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(t => t.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language technology name exists.");
        }

        public void TechnologyShouldExistWhenRequested(Technology? technology)
        {
            if (technology == null) throw new BusinessException("Requested programming language technology does not exist.");
        }

        public async Task<Technology> TechnologyShouldExistWhenUpdated(int id)
        {
            Technology? technology = await _technologyRepository.GetAsync(t => t.Id == id); 
            if (technology == null) throw new BusinessException("To be updated programming language technology does not exist.");
            return technology;
        }

        public void TechnologyShouldExistWhenDeleted(Technology? technology)
        {
            if (technology == null) throw new BusinessException("To be deleted programming language technology does not exist.");
        }
    }
}
