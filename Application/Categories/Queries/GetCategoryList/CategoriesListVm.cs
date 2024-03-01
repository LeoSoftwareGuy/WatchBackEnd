using System.Collections.Generic;

namespace Application.Categories.Queries.GetCategoryList
{
    public class CategoriesListVm
    {
        public IList<CategoryDto> Categories { get; set; }

        public int Count { get; set; }
    }
}
