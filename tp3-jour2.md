**Sujet de TP court en MVVM avec Blazor WebAssembly : Gestion d'une Liste de Tâches (To-Do List) avec Communication via un State Partagé**

---

### **Contexte**
Dans ce TP, vous allez reprendre le **TP précédent sur la gestion de la To-Do List** et le **modifier pour utiliser un state partagé** au lieu de la communication par événements entre les composants. Ce changement permettra d'améliorer la synchronisation des données et de simplifier la gestion des interactions entre les composants.

Avec ce **state partagé**, tous les composants de l'application partageront automatiquement la **même source de données**. Cela signifie qu'une modification de la liste des tâches (ajout, suppression, mise à jour) dans n'importe quel composant sera immédiatement visible dans tous les autres composants, sans avoir besoin de passer des événements entre eux.

---

### **Travail demandé**

1. **Réutilisation du TP précédent**
   - Reprenez le TP précédent sur la **To-Do List en Blazor WebAssembly**.
   - Vous allez **remplacer le système de communication entre composants (Parent-Enfant, Enfant-Parent, Frère-Frère) par un mécanisme de State Partagé**.

2. **Création d'un State Partagé**
   - Créez un **service de State partagé** qui contiendra la liste des tâches.
   - Ce service sera enregistré comme **Singleton** dans **Program.cs**.
   - Ce service doit exposer :
     - Une **liste des tâches** partagée et accessible à tous les composants.
     - Des **méthodes pour ajouter, modifier et supprimer** les tâches.
     - Un **mécanisme de notification** (EventCallback, Action, ou autre) pour que tous les composants abonnés soient notifiés des changements de la liste.

3. **Modification des composants**
   - **ToDoPage** :
     - Supprimez toute la logique liée à la gestion locale de la liste des tâches.
     - Connectez la **TaskListComponent** et le **TaskFormComponent** au **state partagé**.
   
   - **TaskFormComponent** :
     - Lorsqu'une tâche est ajoutée, elle est envoyée au **state partagé** via sa méthode `AddTask()`.
     - Le composant ne communique plus directement avec **ToDoPage**.

   - **TaskListComponent** :
     - Ce composant affiche directement la liste des tâches du **state partagé**.
     - Lorsqu'une tâche est modifiée ou supprimée par un **TaskItemComponent**, la modification est transmise au **state partagé**.

   - **TaskItemComponent** :
     - Lorsqu'une tâche est cochée/décochée ou supprimée, le composant **TaskItemComponent** met à jour le **state partagé** au lieu d'envoyer un événement au parent.
     - La modification de l'état de la tâche est directement visible par tous les autres composants qui se synchronisent automatiquement grâce au **state partagé**.

