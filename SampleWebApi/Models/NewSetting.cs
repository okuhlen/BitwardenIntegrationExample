using System.ComponentModel.DataAnnotations;

namespace SampleWebApi.Models;

public sealed class NewSetting
{
    [Required]
    public string Key { get; set; }
    
    [Required]
    public string Value { get; set; }
    
    public string Note { get; set; }
}