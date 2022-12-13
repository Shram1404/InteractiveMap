namespace InteractiveMap.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Audience
{
    public int Id { get; set; }
    [Required]
    public string SvgCode { get; set; }
    public string? aud { get; set; }
    public string imgWay { get; set; }
    public string imgSvg { get; set; }
}
