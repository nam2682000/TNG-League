using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class GiaiDauBangDau : BaseEntity<int>
{
    public int? BangDauId { get; set; }
    public int? GiaiDauId { get; set; }
    public GiaiDau? GiaiDau { get; set; }
    public BangDau? BangDau { get; set; } 
}
