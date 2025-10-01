using Biblio_classe;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("=== Application de Gestion de Tâches ===\n");

// Initialiser le contexte de base de données
var context = new ApplicationDbContext();

// S'assurer que la base de données est créée et que les migrations sont appliquées
context.Database.EnsureCreated();

// Ajouter les données de test
DbSeed.SeedData(context);

Console.WriteLine("Données de test ajoutées avec succès !\n");

// Appeler les méthodes d'affichage
AfficherUtilisateursEtTaches(context);
AfficherProjetsEtTaches(context);
AfficherTachesAvecDetails(context);

Console.WriteLine("\nAppuyez sur une touche pour quitter...");
Console.ReadKey();

/// <summary>
/// Affiche tous les utilisateurs et leurs tâches associées
/// </summary>
/// <param name="context">Le contexte de base de données</param>
static void AfficherUtilisateursEtTaches(ApplicationDbContext context)
{
    Console.WriteLine("=== UTILISATEURS ET LEURS TÂCHES ===\n");
    
    var usersWithTasks = context.Users
        .Include(u => u.Tasks)
        .ThenInclude(t => t.Project)
        .ToList();

    foreach (var user in usersWithTasks)
    {
        Console.WriteLine($"👤 {user.Prenom} {user.Nom} ({user.Email})");
        
        if (user.Tasks.Any())
        {
            Console.WriteLine("   📋 Tâches assignées :");
            foreach (var task in user.Tasks)
            {
                Console.WriteLine($"      • {task.Titre} - Projet: {task.Project.Titre} - État: {task.Etat}");
            }
        }
        else
        {
            Console.WriteLine("   📋 Aucune tâche assignée");
        }
        Console.WriteLine();
    }
}

/// <summary>
/// Affiche tous les projets et leurs tâches associées
/// </summary>
/// <param name="context">Le contexte de base de données</param>
static void AfficherProjetsEtTaches(ApplicationDbContext context)
{
    Console.WriteLine("=== PROJETS ET LEURS TÂCHES ===\n");
    
    var projectsWithTasks = context.Projects
        .Include(p => p.Tasks)
        .ThenInclude(t => t.User)
        .ToList();

    foreach (var project in projectsWithTasks)
    {
        Console.WriteLine($"📁 {project.Titre}");
        Console.WriteLine($"   📝 Description: {project.Description}");
        Console.WriteLine($"   📅 Date de début: {project.DateDebut?.ToString("dd/MM/yyyy") ?? "Non définie"}");
        
        if (project.Tasks.Any())
        {
            Console.WriteLine("   📋 Tâches :");
            foreach (var task in project.Tasks)
            {
                var assignee = task.User != null ? $"{task.User.Prenom} {task.User.Nom}" : "Non assignée";
                Console.WriteLine($"      • {task.Titre} - Assignée à: {assignee} - État: {task.Etat}");
            }
        }
        else
        {
            Console.WriteLine("   📋 Aucune tâche");
        }
        Console.WriteLine();
    }
}

/// <summary>
/// Affiche toutes les tâches avec leurs utilisateurs et projets associés
/// </summary>
/// <param name="context">Le contexte de base de données</param>
static void AfficherTachesAvecDetails(ApplicationDbContext context)
{
    Console.WriteLine("=== TÂCHES AVEC DÉTAILS ===\n");
    
    var tasksWithDetails = context.Tasks
        .Include(t => t.User)
        .Include(t => t.Project)
        .OrderBy(t => t.Project.Titre)
        .ThenBy(t => t.Titre)
        .ToList();

    foreach (var task in tasksWithDetails)
    {
        Console.WriteLine($"📋 {task.Titre}");
        Console.WriteLine($"   📁 Projet: {task.Project.Titre}");
        Console.WriteLine($"   👤 Assignée à: {(task.User != null ? $"{task.User.Prenom} {task.User.Nom}" : "Non assignée")}");
        Console.WriteLine($"   📊 État: {task.Etat}");
        Console.WriteLine($"   📝 Description: {task.Description ?? "Aucune description"}");
        
        if (task.DateDebut.HasValue)
            Console.WriteLine($"   🚀 Date de début: {task.DateDebut.Value:dd/MM/yyyy}");
        
        if (task.DateEcheance.HasValue)
            Console.WriteLine($"   ⏰ Échéance: {task.DateEcheance.Value:dd/MM/yyyy}");
        
        if (task.DateFin.HasValue)
            Console.WriteLine($"   ✅ Date de fin: {task.DateFin.Value:dd/MM/yyyy}");
        
        Console.WriteLine();
    }
}
