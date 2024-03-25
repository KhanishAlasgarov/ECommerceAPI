using ECommerceAPI.Domain.Entities.Common;
using System.Collections;

namespace ECommerceAPI.Domain.Common.Paging;

public class Paginate : IPaginate
{ 
    public void SetValue(int page, int size, int count)
    {
        Size = size;
        Count = count;
        Pages = (int)Math.Ceiling(this.Count * 1D / this.Size);

        Page = page > Pages ? this.Pages : page;
    }

    public int Page { get; private set; }

    public int Size { get; private set; }

    public int Count { get; private set; }

    public int Pages { get; private set; }

    public bool HasPrevious => this.Page > 1;

    public bool HasNext => this.Page < this.Pages;

    public IEnumerable? Items { get; set; }
}
