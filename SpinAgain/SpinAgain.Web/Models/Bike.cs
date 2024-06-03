using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinAgain.Web.Models;

public class Bike
{
    public int Id { get; set; }

    [Required]
    public string ModelName { get; set; } = string.Empty;

    [Required]
    public string Brand { get; set; } = string.Empty;

    [DataType(DataType.Currency)]
    [Range(0, 10000000)]
    public long Price { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal CC { get; set; }

    [Url]
    public string ImageUrl { get; set; } = string.Empty;
    
    public int MeterReading { get; set; }
    //[Required]
    public string RegistrationNo { get; set; } = string.Empty;


}
