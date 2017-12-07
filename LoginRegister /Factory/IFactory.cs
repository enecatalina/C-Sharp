using LoginRegister.Models;
using System.Collections.Generic;

namespace LoginRegister.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}