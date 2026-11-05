using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransportManagement.Service.DAL.Data.Models;

[Table("vehicles")]
[Index("PlateNumber", Name = "vehicles_plate_number_key", IsUnique = true)]
public partial class Vehicle
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("plate_number")]
    [StringLength(20)]
    public string PlateNumber { get; set; } = null!;

    [Column("fabrication_year")]
    public DateOnly FabricationYear { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("model_id")]
    public int ModelId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("ModelId")]
    [InverseProperty("Vehicles")]
    public virtual Model Model { get; set; } = null!;
}
