using Wall.Models;
using System.Collections.Generic;
namespace Wall.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}