using System.Linq.Dynamic.Core;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.Extensions
{
    public static class PaginationExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            BaseQueryCriteria criteriaDto,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedModel<TModel>();

            paged.CurrentPage = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.PageSize = criteriaDto.Limit;

            if (!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
                !string.IsNullOrEmpty(criteriaDto.SortColumn))
            {
                var sortOrder = criteriaDto.SortOrder == (int)SortOrderEnumDto.Accsending ?
                                    PagingSortingConstants.ASC :
                                    PagingSortingConstants.DESC;
                var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                query = query.OrderBy(orderString);
            }

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                        .Skip(startRow)
                        .Take(paged.PageSize)
                        .ToListAsync(cancellationToken);

            paged.TotalItems = await query.CountAsync(cancellationToken);
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
    }
}