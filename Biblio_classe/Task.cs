using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblio_classe
{
    /// <summary>
    /// Entité représentant une tâche dans l'application Todo
    /// Cette classe correspond à la table Tasks en base de données
    /// Une tâche appartient obligatoirement à un projet et peut être assignée à un utilisateur
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Identifiant unique de la tâche (clé primaire)
        /// Généré automatiquement par la base de données
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Titre de la tâche
        /// Champ obligatoire, limité à 100 caractères
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Titre { get; set; } = string.Empty;

        /// <summary>
        /// Description détaillée de la tâche
        /// Champ optionnel, limité à 512 caractères
        /// Peut être null si aucune description n'est fournie
        /// </summary>
        [MaxLength(512)]
        public string? Description { get; set; }

        /// <summary>
        /// État actuel de la tâche (ex: "À faire", "En cours", "Terminée")
        /// Champ obligatoire, limité à 50 caractères
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Etat { get; set; } = string.Empty;

        /// <summary>
        /// Date de début de la tâche
        /// Champ optionnel, peut être null si la tâche n'a pas encore commencé
        /// </summary>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin de la tâche
        /// Champ optionnel, peut être null si la tâche n'est pas encore terminée
        /// </summary>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Date d'échéance de la tâche
        /// Champ optionnel, peut être null si aucune échéance n'est définie
        /// </summary>
        public DateTime? DateEcheance { get; set; }

        // ===== CLÉS ÉTRANGÈRES =====
        // Ces propriétés établissent les relations avec les autres entités

        /// <summary>
        /// Identifiant du projet auquel appartient cette tâche
        /// Clé étrangère obligatoire vers la table Projects
        /// </summary>
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur assigné à cette tâche
        /// Clé étrangère optionnelle vers la table Users
        /// Peut être null si la tâche n'est pas encore assignée
        /// </summary>
        [ForeignKey("User")]
        public int? UserId { get; set; }

        // ===== PROPRIÉTÉS DE NAVIGATION =====
        // Ces propriétés permettent d'accéder aux entités liées sans faire de requêtes supplémentaires

        /// <summary>
        /// Projet auquel appartient cette tâche
        /// Propriété de navigation vers l'entité Project
        /// Obligatoire (ne peut pas être null)
        /// </summary>
        public virtual Project Project { get; set; } = null!;

        /// <summary>
        /// Utilisateur assigné à cette tâche
        /// Propriété de navigation vers l'entité User
        /// Optionnel (peut être null si non assignée)
        /// </summary>
        public virtual User? User { get; set; }
    }
}
