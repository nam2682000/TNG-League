using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class GiaiDauVongDau : BaseEntity<int>
{
    public int? VongDauId { get; set; }
    public int? GiaiDauId { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsKnockout { get; set; }
    public int Order { get; set; }
    public GiaiDau? GiaiDau { get; set; }
    public VongDau? VongDau { get; set; } 

}
