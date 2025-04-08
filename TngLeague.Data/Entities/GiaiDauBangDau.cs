using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

public class GiaiDauBangDau : BaseEntity<int>
{
    public int BangDauId { get; set; }
    public int GiaiDauId { get; set; }
    public GiaiDau GiaiDau { get; set; } = new GiaiDau();
    public BangDau BangDau { get; set; } = new BangDau();
}
