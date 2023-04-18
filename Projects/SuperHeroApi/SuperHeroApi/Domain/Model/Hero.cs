using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi.Domain.Model;

public class Hero
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "O nome não pode ter mais que 50 caracteres")]
    public string Name { get; set; }

    [MaxLength(50, ErrorMessage = "O nome não pode ter mais que 50 caracteres")]
    public string? RealName { get; set; }

    [Required(ErrorMessage = "A idade é um campo obrigatório!")]
    [Range(0, 1000, ErrorMessage = "A idade deve estar entre 0 e 1000")]
    public int Age { get; set; }


    public bool IsRetired { get; set; } = false;

}
