using System.ComponentModel.DataAnnotations;

namespace Domains.Models;
public class BaseEntity
{

    [Key]
    public Guid Id { get; set; }

    private DateTime? createAt;
    public DateTime? CreateAt
    {
        get => createAt;
        set => createAt = value == null ? DateTime.UtcNow : value;
    }

    public DateTime? UpdateAt { get; set; }

}