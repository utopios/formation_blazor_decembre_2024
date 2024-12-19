**Sujet de TP court en MVVM avec Blazor WebAssembly : Gestion d'une Liste de Tâches (To-Do List) avec State Partagé et Synchronisation en Temps Réel via SignalR**

---

### **Contexte**
Dans ce TP, vous allez **continuer à améliorer la To-Do List** réalisée dans les exercices précédents. Vous allez ajouter un nouveau mécanisme de **synchronisation en temps réel** des tâches entre plusieurs clients à l'aide de **SignalR**.

L'objectif est de permettre la **synchronisation en temps réel des To-Dos**. Cela signifie que lorsqu'un utilisateur ajoute, modifie ou supprime une tâche, tous les autres clients connectés verront la mise à jour instantanément.

Ce TP vous permettra de manipuler plusieurs concepts avancés :
- **Utilisation du State Partagé** pour la gestion des tâches.
- **Intégration de SignalR** pour la mise à jour en temps réel.
- **Communication avec une API distante** (via HTTP).

---

### **Travail demandé**

1. **Reprendre le TP précédent**
   - Reprenez le **TP précédent de la To-Do List** qui utilise un **State Partagé**.
   - Ajoutez les fonctionnalités de **synchronisation en temps réel via SignalR**.
   - La communication entre le client (Blazor) et le serveur (API) se fait via HTTP et WebSockets.

2. **Création de l'API distante**
   - Créez une **API ASP.NET Core** avec les endpoints suivants :
     - **GET /todos** : Récupère la liste des tâches.
     - **POST /todos** : Ajoute une nouvelle tâche.
     - **PUT /todos/{id}** : Met à jour une tâche (marquer terminée ou non).
     - **DELETE /todos/{id}** : Supprime une tâche.
   - Mettez en place un **hub SignalR** qui notifie tous les clients lorsque :
     - Une nouvelle tâche est ajoutée.
     - Une tâche est modifiée (cochée ou décochée).
     - Une tâche est supprimée.

3. **Ajout de la synchronisation via SignalR**
   - Connectez la **ToDoPage** au **Hub SignalR**.
   - Chaque fois qu'une tâche est ajoutée, modifiée ou supprimée, la **modification est envoyée au serveur**.
   - Le serveur **notifie tous les clients connectés** via **SignalR**.
   - Le **state partagé** se met automatiquement à jour pour que la liste des tâches reste synchrone.
