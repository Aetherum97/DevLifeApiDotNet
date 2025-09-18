# 📌 DevLifeApiDotNet

API REST construite en **.NET 8.0** pour la gestion d’entreprises, contrats, employés et matériels.  
Le projet suit une architecture **Clean Architecture / Domain Driven Design (DDD)** avec séparation en couches :  
- **Application** : logique métier, DTOs, services.  
- **Domain** : entités métiers et règles fondamentales.  
- **Infrastructure** : persistance, repositories, EF Core, Identity.  
- **Shared** : utilitaires communs (mailer, mapper).  
- **Web** : API REST exposant les fonctionnalités.  

---

## 🚀 Fonctionnalités principales
- 🔑 **Authentification & autorisation** avec Identity + JWT  
- 🏢 Gestion des **entreprises et joueurs**  
- 📄 Gestion des **contrats et modèles de contrats**  
- 👩‍💻 Gestion des **employés et compétences**  
- ⚙️ Gestion des **matériaux et ressources**  
- 📧 **Confirmation d’email & envoi de mails**  
- 📊 Pagination et services utilitaires  

---

## 🛠️ Technologies utilisées
- [.NET 8.0](https://dotnet.microsoft.com/)  
- **Entity Framework Core** (SQL Server)  
- **FluentValidation** pour la validation des données  
- **ASP.NET Core Identity + JWT** pour la sécurité  
- **Docker & docker-compose** pour l’orchestration  
- **Automapper-like Custom Mapper**
  
---

## ⚙️ Installation & Lancement

### Prérequis
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [Docker](https://www.docker.com/) & Docker Compose  

### Étapes
1. **Cloner le repo**
   ```bash
   git clone https://github.com/ton-repo/devlife.git
   cd devlife
   ```

2. **Configurer les variables d’environnement**
   - Copier le fichier `appsettings.json` et ajuster si besoin (connexion SQL, JWT, mailer).  
   - Définir le mot de passe `SA_PASSWORD` dans `.env`.  

3. **Lancer avec Docker**
   ```bash
   docker-compose up --build
   ```

   Cela démarre :  
   - SQL Server (port `1433`)  
   - API Web (ports `8080`, `8081`)  

4. **Accéder à l’API**
   - Swagger disponible sur : [http://localhost:8080/swagger](http://localhost:8080/swagger)  

---

## 📖 Exemples d’API

- **Authentification**
  - `POST /api/auth/register`
  - `POST /api/auth/login`

- **Employés**
  - `GET /api/employees`
  - `POST /api/employees`

- **Contrats**
  - `GET /api/contracts`
  - `POST /api/contracts`

---
