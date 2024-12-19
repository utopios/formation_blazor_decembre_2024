**Sujet de TP court en MVVM avec Blazor WebAssembly : Gestion d'une Liste de Tâches (To-Do List)**

---

### **Contexte**
Vous devez développer une application web de gestion de tâches (To-Do List) en utilisant le pattern **MVVM** avec **Blazor WebAssembly**. Cette application permettra de lister, ajouter, cocher/décocher et supprimer des tâches.

---

### **Travail demandé**
1. **Création de la structure du projet** : 
   - Créez un projet Blazor WebAssembly nommé **BlazorTodoApp**.
   - Organisez le projet avec les dossiers suivants :
     - **Models** : Contiendra la définition des données de la tâche.
     - **ViewModels** : Contiendra la logique de gestion des tâches.
     - **Pages** : Contiendra la page principale de la To-Do List.

2. **Modélisation des données** :
   - Créez une classe représentant une tâche avec les informations suivantes :
     - **Id** unique de la tâche.
     - **Titre** de la tâche.
     - **Statut d'achèvement** (terminée ou non terminée).

3. **Création de l'interface utilisateur (View)** :
   - Affichez la liste des tâches avec leur titre et un bouton de suppression.
   - Ajoutez un champ d'entrée permettant de saisir le titre d'une nouvelle tâche.
   - Ajoutez un bouton pour **ajouter** la tâche à la liste.
   - Ajoutez un moyen de **cocher/décocher** les tâches terminées.

4. **Logique métier (ViewModel)** :
   - Implémentez la logique de **création de tâche** : Lorsqu'un titre est saisi et que le bouton "Ajouter" est cliqué, une nouvelle tâche est ajoutée.
   - Implémentez la logique de **suppression de tâche** : Chaque tâche doit avoir un bouton "Supprimer" qui la retire de la liste.
   - Implémentez la logique de **marquage des tâches** : Lorsqu'une tâche est cochée, elle est considérée comme terminée (affichée barrée, par exemple).

5. **Respect de l'architecture MVVM** :
   - La **View** (page Blazor) ne doit pas contenir de logique métier.
   - La **ViewModel** doit contenir la logique de gestion des tâches (ajout, suppression, mise à jour).