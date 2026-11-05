using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransportManagement.Service.DAL.Data.Models;

[Table("makes")]
[Index("Name", Name = "make_name_key", IsUnique = true)]
public partial class Make
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Make")]
    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
