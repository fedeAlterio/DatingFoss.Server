using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Repositories.Abstractions;
public interface IQueryableCrud<T> : ICrud<T> where T : class
{
    IQueryable<T> Entities { get; }
}
