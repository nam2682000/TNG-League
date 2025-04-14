using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

public class GiaiDauVongDau : BaseEntity<int>
{
    public int VongDauId { get; set; }
    public int GiaiDauId { get; set; }
    public GiaiDau GiaiDau { get; set; } = null!;
    public VongDau VongDau { get; set; } = null!;

}
