using DevLife.Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Web.Api.Commons.Services.Pagination
{
    public class PagedListConverter<TSource, TDestination> where TDestination : new()
    {
        public PagedList<TDestination> Convert(PagedList<TSource> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            List<TDestination> destinationItems = source
                .ToList()
                .Select(item => CustomMapper.Map<TSource, TDestination>(item))
                .ToList();

            return new PagedList<TDestination>(
                destinationItems,
                source.TotalCount,
                source.CurrentPage,
                source.PageSize
                );
        }
    }
}
