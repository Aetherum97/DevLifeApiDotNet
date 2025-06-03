using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Shared.Mapper
{
    public class CustomMapperService : ICustomMapper
    {
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return CustomMapper.Map<TSource, TTarget>(source);
        }
    }
}
