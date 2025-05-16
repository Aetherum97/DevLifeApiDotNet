using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Shared.Mapper
{
    public interface ICustomMapper
    {
        TTarget Map<TSource, TTarget>(TSource source);
    }
}
