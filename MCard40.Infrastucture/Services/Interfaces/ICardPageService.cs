using MCard40.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Infrastucture.Services.Interfaces
{
    public interface ICardPageService
    {
        public List<CardPage> GetAll();
        public List<CardPage> GetAll(int patientId);
        void Add(CardPage cardPage);
        CardPage GetById(int? id);
        CardPage Update(int id, CardPage cardPage);
        CardPage GetCardPageDetails(int? id);
        CardPage Delete(int id);
    }
}
