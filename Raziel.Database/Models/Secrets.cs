using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raziel.Database.Models;

[Table("Secrets")]
public class Secrets
{

    [Key]
    public int Id { get; set; }

    public string Topic { get; set; }

    public string Secret { get; set; }

    public string Metadata { get; set; }

}
