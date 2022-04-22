using System.Linq.Dynamic.Core;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.Extensions
{
    public static class PaginationExtension
    {
        public static async Task<PagedResponseModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            BaseQueryCriteria criteriaDto,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedResponseModel<TModel>();

            paged.Page = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.Limit = criteriaDto.Limit;

            if (!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
                !string.IsNullOrEmpty(criteriaDto.SortColumn))
            {
                var sortOrder = criteriaDto.SortOrder == (int)SortOrderEnumDto.Accsending ?
                                    PagingSortingConstants.ASC :
                                    PagingSortingConstants.DESC;
                var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                query = query.OrderBy(orderString);
            }

            var startRow = (paged.Page - 1) * paged.Limit;

            paged.Items = await query
                        .Skip(startRow)
                        .Take(paged.Limit)
                        .ToListAsync(cancellationToken);

            paged.TotalRecord= await query.CountAsync(cancellationToken);

            return paged;
        }
    }
}