using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransportManagement.Service.DAL.Data.Models;

[Table("models")]
[Index("Name", Name = "model_name_key", IsUnique = true)]
public partial class Model
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("make_id")]
    public int MakeId { get; set; }

    [ForeignKey("MakeId")]
    [InverseProperty("Models")]
    public virtual Make Make { get; set; } = null!;

    [InverseProperty("Model")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
