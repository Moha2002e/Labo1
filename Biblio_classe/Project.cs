using System.ComponentModel.DataAnnotations;

namespace Biblio_classe
{
    /// <summary>
    /// Entité représentant un projet dans l'application Todo
    /// Cette classe correspond à la table Projects en base de données
    /// Un projet peut contenir plusieurs tâches
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Identifiant unique du projet (clé primaire)
        /// Généré automatiquement par la base de données
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Titre du projet
        /// Champ obligatoire, limité à 100 caractères
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Titre { get; set; } = string.Empty;

        /// <summary>
        /// Description détaillée du projet
        /// Champ optionnel, limité à 512 caractères
        /// Peut être null si aucune description n'est fournie
        /// </summary>
        [MaxLength(512)]
        public string? Description { get; set; }

        /// <summary>
        /// Date de début du projet
        /// Champ optionnel, peut être null si la date n'est pas encore définie
        /// </summary>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Collection des tâches appartenant à ce projet
        /// Propriété de navigation vers l'entité Task
        /// Permet d'accéder facilement aux tâches d'un projet
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
