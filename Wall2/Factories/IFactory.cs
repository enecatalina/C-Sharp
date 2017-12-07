using Wall2.Models;
using System.Collections.Generic;
namespace Wall2.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}