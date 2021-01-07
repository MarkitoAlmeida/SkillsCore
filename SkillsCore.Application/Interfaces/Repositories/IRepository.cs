using SkillsCore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsCore.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
