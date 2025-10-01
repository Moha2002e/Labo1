using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblio_classe
{
    /// <summary>
    /// Entité représentant un utilisateur de l'application Todo
    /// Cette classe correspond à la table Users en base de données
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(40)]
        public string MotDePasse { get; set; } = string.Empty;

        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
