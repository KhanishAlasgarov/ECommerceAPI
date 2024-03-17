﻿namespace ECommerceAPI.Domain.Common.Paging;

public class PaginateRequest
{
    private int _page;
    private int _size;
    public string[]? Fields { get; set; }


    public int Page
    {
        get => this._page < 1 ? 1 : this._page;
        set
        {
            if (value < 1)
                return;

            this._page = value;

        }
    }
    public virtual int Size
    {
        get => this._size < 2 ? 2 : this._size;
        set
        {
            if (value < 1)
                return;

            this._size = value;

        }
    }
}