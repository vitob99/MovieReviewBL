# Movie Review BL

**Movie Review** è una piattaforma che consente agli utenti di registrarsi, autenticarsi e recensire i propri film preferiti. Il progetto nasce con l'obiettivo di integrare un backend solido in C# con un'interfaccia grafica interattiva sviluppata in Unity.

---

## 👥 Il Team
Il progetto è stato realizzato in collaborazione da:
* **Vito Bondanese**: Sviluppo lato Server (Logic, Database & API).
* **Marco Lanzillotta**: Sviluppo lato Client (Unity Engine & UI).

---

## 🛠️ Stack Tecnologico
* **Linguaggio:** C#
* **Backend:** ASP.NET (Console Application)
* **Frontend:** Unity
* **Database:** MySQL
* **ORM:** Entity Framework Core (per la persistenza dei dati)

---

## 📐 Architettura e Scelte Tecniche
Il progetto segue una struttura **Client-Server** separata:

1.  **Pattern Singleton:**
    * Utilizzato per la gestione centralizzata dei **Log** di sistema.
    * Implementato nel client Unity per mantenere l'istanza dell'**utente loggato** attraverso le diverse scene.
2.  **Gestione Media (Locandine):**
    * Il database contiene una tabella dedicata ai film con un campo `link`.
    * Il client Unity si connette a questi URL per scaricare e visualizzare dinamicamente le locandine all'interno dell'interfaccia.

---

## ⚠️ Limitazioni Attuali e Area di Miglioramento
Il progetto è attualmente un prototipo funzionale, ma presenta alcuni punti critici identificati per sviluppi futuri:

* **Sicurezza:** Mancanza di un sistema di *Authentication & Authorization* sulle API. Le chiamate non sono protette da token (es. JWT).
* **Ottimizzazione Network:** Il client effettua chiamate singole ridondanti per scaricare le locandine. Sarebbe necessaria l'implementazione di una struttura dati di **Caching** nel client Unity per memorizzare i file una volta scaricati ed evitare traffico inutile.

---

## 🚀 Configurazione iniziale 
1.  **Configurazione DB:** Configura il tuo server MySQL e aggiorna la stringa di connessione in Entity Framework.
2.  **Server:** Avvia il progetto Console C# per mettere in ascolto il server
3.  **Client:** Apri il progetto Unity e avvia la scena di "Check" per la connessione al server
