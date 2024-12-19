**Sujet de TP court en MVVM avec Blazor WebAssembly : Gestion d'une Liste de Tâches (To-Do List) avec Communication entre Composants**


### **Mécanismes de communication à implémenter**

#### **1. Communication Parent → Enfant**
- Le **composant parent** est la page principale de la To-Do List.
- Les **composants enfants** sont :
  - **TaskListComponent** : Affiche la liste de toutes les tâches.
  - **TaskItemComponent** : Affiche chaque tâche avec ses détails (titre, statut, bouton de suppression).
  - **TaskFormComponent** : Permet de saisir et d'ajouter une nouvelle tâche.
- Le **Parent (ToDoPage)** envoie la liste des tâches au **TaskListComponent**, qui à son tour passe chaque tâche au **TaskItemComponent**.

**À faire :**
- Le **Parent** doit passer la liste des tâches en **paramètre** au **TaskListComponent**.
- Le **TaskListComponent** doit ensuite passer chaque tâche au **TaskItemComponent**.

---

#### **2. Communication Enfant → Parent**
- Lorsqu'une tâche est ajoutée, le composant **TaskFormComponent** doit notifier le **composant parent** qu'une nouvelle tâche a été ajoutée.
- Lorsqu'une tâche est supprimée ou marquée comme terminée, le **TaskItemComponent** doit notifier le **composant parent** qu'une modification a eu lieu.

**À faire :**
- Le **TaskFormComponent** doit émettre un événement au parent pour indiquer qu'une nouvelle tâche a été ajoutée.
- Le **TaskItemComponent** doit émettre un événement pour signaler au **parent** qu'une tâche a été cochée/décochée ou supprimée.
- Le **Parent** doit mettre à jour la liste des tâches lorsqu'il reçoit ces événements.

---

#### **3. Communication Frère ↔ Frère**
- Lorsque le **TaskFormComponent** ajoute une nouvelle tâche, la **TaskListComponent** doit se mettre à jour automatiquement.
- Lorsque le **TaskItemComponent** supprime ou met à jour une tâche, la **TaskListComponent** doit se mettre à jour pour refléter ce changement.

**À faire :**
- Le **TaskFormComponent** et le **TaskItemComponent** ne se communiquent pas directement. 
- Pour établir la communication entre les composants frères, utilisez la **propagation d'événements via le Parent**.
- Le **Parent (ToDoPage)** agit comme un médiateur entre les deux composants.
  - Le **TaskFormComponent** notifie le **Parent** lorsqu'une tâche est ajoutée.
  - Le **Parent** met à jour la liste et la transmet au **TaskListComponent**.
  - De même, lorsqu'une tâche est modifiée ou supprimée par le **TaskItemComponent**, le **Parent** transmet les modifications au **TaskListComponent**.

---

### **Structure des composants**

#### **1. Composant Parent : ToDoPage**
- Ce composant contient les composants enfants :
  - **TaskFormComponent** (formulaire d'ajout)
  - **TaskListComponent** (liste des tâches)
- Il **gère la liste des tâches** et la met à jour en fonction des événements provenant des composants enfants.

#### **2. Composant Enfant : TaskFormComponent**
- Ce composant contient un **champ de saisie** et un **bouton "Ajouter"**.
- Lorsqu'une nouvelle tâche est saisie, il **notifie le composant parent**.
- Ce composant ne connaît pas la liste des tâches, il se contente de transmettre les informations au parent.

#### **3. Composant Enfant : TaskListComponent**
- Ce composant reçoit la liste des tâches du **Parent (ToDoPage)**.
- Il affiche chaque tâche à l’aide du **TaskItemComponent**.
- Il agit comme un simple conteneur qui transfère la liste de tâches au composant **TaskItemComponent**.

#### **4. Composant Enfant : TaskItemComponent**
- Ce composant affiche chaque **tâche individuelle** (avec son titre, statut de complétion et un bouton de suppression).
- Lorsqu'une tâche est cochée ou supprimée, il **notifie le parent** de la modification.
- Il ne connaît pas l'ensemble des tâches, il ne gère qu'une seule tâche.

---

### **Travail technique**

1. **Création des composants**
   - Créez **TaskFormComponent**, **TaskListComponent** et **TaskItemComponent** dans le dossier **Components**.
   - Créez la page **ToDoPage.razor** dans le dossier **Pages**.

2. **Communication Parent → Enfant**
   - Le **Parent (ToDoPage)** doit transmettre la liste des tâches à **TaskListComponent** via un **[Parameter]**.
   - Le **TaskListComponent** doit transmettre les détails de chaque tâche à **TaskItemComponent** via un **[Parameter]**.

3. **Communication Enfant → Parent**
   - Le **TaskFormComponent** doit utiliser la directive **EventCallback** pour notifier le parent qu'une nouvelle tâche a été ajoutée.
   - Le **TaskItemComponent** doit également utiliser **EventCallback** pour notifier le parent des suppressions ou modifications de tâches.

4. **Communication Frère ↔ Frère**
   - Lorsqu'une tâche est ajoutée via **TaskFormComponent**, le **Parent (ToDoPage)** doit informer le **TaskListComponent** que la liste des tâches a changé.
   - Lorsqu'une tâche est modifiée dans **TaskItemComponent**, le **Parent (ToDoPage)** met à jour la liste et la transmet au **TaskListComponent**.

---

### **Exemple d'interface**

**To-Do List**
- Formulaire d'ajout (champ de saisie + bouton "Ajouter")
- Liste de tâches
  - Chaque tâche a un bouton "Supprimer" et une case à cocher pour marquer la tâche comme terminée.
  - Les tâches terminées apparaissent barrées.

---

### **Critères de validation**
1. **Communication Parent → Enfant** : 
   - La liste des tâches est transmise correctement au **TaskListComponent**.
   - Chaque tâche est transmise au **TaskItemComponent**.

2. **Communication Enfant → Parent** : 
   - Lorsque l'utilisateur ajoute une tâche, elle apparaît immédiatement dans la liste.
   - Lorsqu'une tâche est cochée ou supprimée, elle est mise à jour dans la liste.

3. **Communication Frère ↔ Frère** : 
   - Lorsqu'une tâche est ajoutée, le **TaskListComponent** se met à jour automatiquement.
   - Lorsqu'une tâche est supprimée ou modifiée, la liste est mise à jour automatiquement.

4. **Séparation des responsabilités** :
   - La logique est correctement divisée entre le **Parent (ToDoPage)** et les composants enfants.

