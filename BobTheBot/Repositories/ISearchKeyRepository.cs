using BobTheBot.Entities;
using RJ.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BobTheBot.Repositories
{
    public interface ISearchKeyRepository : IRepository<SearchKey>
    {
        Task<IReadOnlyList<SearchKey>> GetAllWords();
        Task<SearchKey> GetWordById(int id);
    }
}
