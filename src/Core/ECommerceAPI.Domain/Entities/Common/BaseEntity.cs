namespace ECommerceAPI.Domain.Entities.Common;

public abstract class BaseEntity<T> where T : unmanaged
{
    public T Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public  DateTime? UpdatedDate { get; set; }
}
