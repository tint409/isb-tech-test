using ISBTest.Common.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBTest.DAL.Entities;

[Table(nameof(Property))]
public class Property : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Money Price { get; set; } = new Money(0);
    public DateTime? DateOfRegistration { get; set; }
}
