using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.ViewModels.Patient;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Infrastucture.Services.Implementations
{
    public class CardPageService : ICardPageService
    {
        private readonly IRepository<CardPage, int> _repository;
        public CardPageService(IRepository<CardPage, int> repository)
        {
            _repository = repository;
        }
        public List<CardPage> GetAll()
        {
            return _repository.ReadAll();
        }

        public void Add(CardPage cardPage)
        {
            _repository.Create(cardPage);
        }

        public CardPage Delete(int id)
        {
            var cardPage = _repository.DeleteById(id);
            if (cardPage == null)
            {
                return null;
            }
            return cardPage;
        }

        public CardPage GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var cardPage = _repository.ReadById(id.Value);

            return cardPage;
        }

        public CardPage GetCardPageDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var cardPage = _repository.ReadById(id.Value);
            return cardPage;
        }

        public CardPage Update(int id, CardPage cardPage)
        {
            try
            {
                _repository.Update(cardPage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.IsExists(cardPage.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return cardPage;
        }

        public List<CardPage> GetAll(int patientId)
        {
            return _repository.Get(x => x.PatientId == patientId).ToList();
        }
    }
}
