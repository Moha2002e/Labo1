using Microsoft.EntityFrameworkCore;

namespace Biblio_classe
{
    /// <summary>
    /// Classe statique pour initialiser la base de données avec des données de test
    /// Cette classe contient une méthode pour ajouter des utilisateurs, projets et tâches
    /// </summary>
    public static class DbSeed
    {
        /// <summary>
        /// Méthode statique pour ajouter des données de test dans la base de données
        /// </summary>
        /// <param name="context">Le contexte de base de données ApplicationDbContext</param>
        public static void SeedData(ApplicationDbContext context)
        {
            // Vider la base de données pour s'assurer d'avoir des données propres
            context.Tasks.RemoveRange(context.Tasks);
            context.Projects.RemoveRange(context.Projects);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            // ===== CRÉATION DES UTILISATEURS =====
            var user1 = new User
            {
                Nom = "Dupont",
                Prenom = "Jean",
                Email = "jean.dupont@email.com",
                MotDePasse = "motdepasse123"
            };

            var user2 = new User
            {
                Nom = "Martin",
                Prenom = "Marie",
                Email = "marie.martin@email.com",
                MotDePasse = "motdepasse456"
            };

            var user3 = new User
            {
                Nom = "Bernard",
                Prenom = "Pierre",
                Email = "pierre.bernard@email.com",
                MotDePasse = "motdepasse789"
            };

            context.Users.AddRange(user1, user2, user3);
            context.SaveChanges(); // Sauvegarder pour obtenir les Id générés

            // ===== CRÉATION DES PROJETS =====
            var project1 = new Project
            {
                Titre = "Projet E-commerce",
                Description = "Développement d'une plateforme de vente en ligne",
                DateDebut = new DateTime(2024, 1, 15)
            };

            var project2 = new Project
            {
                Titre = "Application Mobile",
                Description = "Création d'une application mobile pour iOS et Android",
                DateDebut = new DateTime(2024, 2, 1)
            };

            var project3 = new Project
            {
                Titre = "Système de Gestion",
                Description = "Développement d'un système de gestion interne",
                DateDebut = new DateTime(2024, 3, 1)
            };

            context.Projects.AddRange(project1, project2, project3);
            context.SaveChanges(); // Sauvegarder pour obtenir les Id générés

            // ===== CRÉATION DES TÂCHES =====

            // Trois tâches assignées à l'utilisateur U1 dans le projet P1
            var task1 = new Task
            {
                Titre = "Conception de l'interface utilisateur",
                Description = "Créer les maquettes et wireframes pour l'interface e-commerce",
                Etat = "En cours",
                DateDebut = new DateTime(2024, 1, 20),
                DateEcheance = new DateTime(2024, 2, 15),
                ProjectId = project1.Id,
                UserId = user1.Id
            };

            var task2 = new Task
            {
                Titre = "Développement du panier d'achat",
                Description = "Implémenter la fonctionnalité d'ajout et suppression d'articles",
                Etat = "À faire",
                DateEcheance = new DateTime(2024, 2, 28),
                ProjectId = project1.Id,
                UserId = user1.Id
            };

            var task3 = new Task
            {
                Titre = "Intégration des paiements",
                Description = "Intégrer Stripe pour le traitement des paiements",
                Etat = "À faire",
                DateEcheance = new DateTime(2024, 3, 10),
                ProjectId = project1.Id,
                UserId = user1.Id
            };

            // Deux tâches non assignées dans le projet P1
            var task4 = new Task
            {
                Titre = "Tests unitaires",
                Description = "Écrire les tests unitaires pour les modules principaux",
                Etat = "À faire",
                DateEcheance = new DateTime(2024, 3, 20),
                ProjectId = project1.Id,
                UserId = null
            };

            var task5 = new Task
            {
                Titre = "Documentation technique",
                Description = "Rédiger la documentation technique du projet",
                Etat = "À faire",
                DateEcheance = new DateTime(2024, 3, 30),
                ProjectId = project1.Id,
                UserId = null
            };

            // Deux tâches non assignées dans le projet P2
            var task6 = new Task
            {
                Titre = "Analyse des besoins",
                Description = "Analyser les besoins fonctionnels de l'application mobile",
                Etat = "À faire",
                DateEcheance = new DateTime(2024, 2, 15),
                ProjectId = project2.Id,
                UserId = null
            };

            var task7 = new Task
            {
                Titre = "Choix de la technologie",
                Description = "Définir la stack technique (React Native, Flutter, etc.)",
                Etat = "À faire",
                DateEcheance = new DateTime(2024, 2, 20),
                ProjectId = project2.Id,
                UserId = null
            };

            // Une tâche assignée à l'utilisateur U2 dans le projet P1
            var task8 = new Task
            {
                Titre = "Optimisation des performances",
                Description = "Optimiser les requêtes de base de données et la vitesse de chargement",
                Etat = "En cours",
                DateDebut = new DateTime(2024, 2, 1),
                DateEcheance = new DateTime(2024, 2, 25),
                ProjectId = project1.Id,
                UserId = user2.Id
            };

            // Une tâche assignée à l'utilisateur U2 dans le projet P2
            var task9 = new Task
            {
                Titre = "Développement de l'API",
                Description = "Créer l'API REST pour l'application mobile",
                Etat = "En cours",
                DateDebut = new DateTime(2024, 2, 10),
                DateEcheance = new DateTime(2024, 3, 15),
                ProjectId = project2.Id,
                UserId = user2.Id
            };

            context.Tasks.AddRange(task1, task2, task3, task4, task5, task6, task7, task8, task9);

            // Sauvegarder toutes les modifications
            context.SaveChanges();
        }
    }
}
