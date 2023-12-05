# ROADMAP



# Cahier des charges JeBalance

## Concept

Face au probl�me de l'�vasion fiscale et de la dissimulation de revenus, les pouvoirs publics souhaitent d�velopper un r�seau de d�nonciation citoyenne.

Pour inciter les citoyens � participer, l'administration fiscale est pr�te � r�mun�rer chaque d�nonciateur en fonction du montant r�cup�r� gr�ce � la d�nonciation.

Un nouveau site internet, **jebalance.gouv.fr**, doit permettre � chaque citoyen de d�noncer facilement les cas d'�vasion fiscale et de r�colter sa part de l'argent r�cup�r�.

Cependant, certains *VIP* au dessus de tout soup�on ne doivent pas �tre la cible de contr�les fiscaux. Le syst�me doit bien �videmment ignorer les d�nonciations *calomnieuses* dont elles pourraient faire l'objet.

Votre soci�t� a remport� l'appel d'offre des pouvoirs publics et vous �tes charg�s de **concevoir** et **d�velopper** l'application.

## Objectifs

jebalance.gouv.fr comportera trois points d'entr�e :
* Une interface Web publique sans authentification
  * Cr�ation des d�nonciations
  * Consultation du statut de la d�nonciation
* Une API interne s�curis�e r�serv�e � l'inspection fiscale
  * Collecte de la liste des d�nonciations non trait�es
  * R�ponse aux d�nonciations
* Une API secr�te s�curis�e r�serv�e aux administrateurs de l'application
  * Administration de la liste des VIP

## Contraintes techniques

L'appel d'offre comporte les contraintes techniques suivantes :
- L'application doit �tre �crite en C# et doit s'appuyer sur le framework .NET 6 ou sup�rieur
- L'application doit �tre modulaire afin de pouvoir adapter pour chaque composant :
  - Le niveau de s�curit�
  - Les ressources mat�rielles (CPU, bande passante, m�moire...)
  - La fr�quence des mises � jour
- Le code m�tier doit respecter les principes de l'approche **DDD**
- L'architecture technique de chaque composant doit �tre maitenable et testable
- Les API doivent �tre des Web Services respectant l'approche **REST**
- L'acc�s aux API s�curis�es doit n�cessiter un **JWT** sign� par l'algorithme **HMACSHA256**
- La base de donn�es utilis�e doit �tre **SQLite**
- L'acc�s � la base doit se faire � traver l'ORM **Entity Framework**

## Vocabulaire commun (en fran�ais)

**JeBalance** : l'application dans son ensemble.

**Personne** : individu identifi� de mani�re unique par les �lements suivants :
- Un **Pr�nom**
- Un **Nom**
- Une **Adresse** compos�e de 
  - Un **Num�ro (de voie)**
  - Un **Nom de voie**
  - Un **Code postal**
  - Un **Nom de commune**

**D�nonciation** : d�claration cr��e par un *Informateur* non authentifi� accusant un *Suspect* de dissimulation de revenus ou d'�vasion fiscale.

**Identifiant de d�nonciation** : cha�ne de caract�res qui identifie de mani�re unique une d�nonciation et gr�ce � laquelle un *Informateur* peut consulter sa *D�nonciation* et la possible *R�ponse* associ�e.

**Informateur** : *Personne* correspondant � un utilisateur non authentifi� mais identifi�, cr�ateur d'au moins une *D�nonciation*.
  
**Suspect** : *Personne* accus�e par une *D�nonciation* de *Dissimulation de revenus* ou d'*Evasion fiscale*.

**D�lit** : attribut d'une *D�nonciation* indiqu� par l'*Informateur* qui lors de sa cr�ation. Les valeurs possibles sont :
* **DissimulationDeRevenus**
* **EvasionFiscale**

**Pays d'�vasion** : attribut obligatoire d'une *D�nonciation* de type *EvasionFiscale* indiquant dans quel pays le *Suspect* a dissimul� son argent.

**Administration fiscale** : entit� capable de consulter la liste des *D�nonciations* sans r�ponse et de cr�er des *R�ponses* � travers l'API d�di�e.

**R�ponse (� une D�nonciation)** : retour unique et facultatif effectu� sur une *D�nonciation* par l'*Administration fiscale*.

**Type (de R�ponse)** : caract�rise une *R�ponse* donn�e par l'*Administration fiscale*. Les types possibles sont :
* *Confirmation*
* *Rejet*

**D�nonciation non trait�e** : *D�nonciation* qui ne poss�de pas de *R�ponse*.

**Retribution** : attribut obligatoire d'une *R�ponse* de type *Confirmation* qui indique le montant en euro vers� par l'*Administration fiscale* � l'*Informateur* de la *D�nonciation* confirm�e.

**Calomniateur** : *Personne* qui n'est plus autoris�e � cr�er de nouvelles d�nonciations en tant qu'*Informateur*.

**VIP** : *Personne* dont qui ne peut pas appara�tre en tant que *Suspect* dans la liste des *D�nonciations* retourn�es � l'*Administration fiscale*.

**Administrateur** : utilisateur sp�cial pouvant administrer la liste des *VIP*.

## R�gles de gestion

Le cahier des charges fourni par les pouvoirs publics comporte les r�gles list�es ci-dessous.

### Cr�ation d'une d�nonciation

- Les utilisateur doivent passer par l'interface Web sans authentification pour cr�er les *D�nonciations*.
- A la fin de la cr�ation de la *D�nonciation*, on indique � l'utilisateur l'*Identifiant de la d�nonciation*.
- L'*Identifiant de la d�nonciation* doit �tre opaque et non pr�dictif.

### Suivi d'une d�nonciation

- Un utilisateur peut consulter une *D�nonciation* en utilisant l'*Identifiant de d�nonciation* sur l'interface Web sans authentification.
- La consultation d'une *D�nonciation* doit restituer les �lements suivants :
  - L'horodatage de la *D�nonciation*
  - Les informations identifiant l'*Informateur*
  - Les informations identifiant le *Suspect*
  - Le *D�lit*
  - Si applicable, le *Pays d'�vasion*
  - Si applicable la *R�ponse* :
    - L'horodatage de la *R�ponse*
    - Le *Type de R�ponse*
    - Si applicable, le montant de la *R�tribution*

### Consultation des d�nonciations non trait�es

- Seule l'*Administration fiscale* peut consulter la liste des *D�nonciations non trait�es*.
- L'*Administration fiscale* peut consulter la liste des *D�nonciations non trait�es* en utilisant l'API REST s�curis�e d�di�e.
- La liste des *D�nonciations* sans *R�ponse* doit �tre pagin�e.
- La liste des *D�nonciations* sans *R�ponse* doit comporter l'horodatage de sa cr�ation, l'*Informateur*, le *Suspect*, le *D�lit* et le *Pays d'�vasion* si applicable.
- La liste des *D�nonciations non trait�es* doit �tre tri�e par ordre d'horodatage cr�ation.
- Les *D�nonciations* dont le *Suspect* est un *VIP* ne doivent pas �tre restitu�es dans la liste.

### R�pondre � une d�nonciation

- Seule l'*Administration fiscale* peut cr�er des *R�ponses* sur les *D�nonciations*.
- L'*Administration fiscale* peut cr�er une *R�ponse* sur une *D�nonciations* en utilisant l'API REST s�curis�e d�di�e.
- Il n'est pas possible de r�pondre � une *D�nonciation* qui poss�de d�j� une *R�ponse*.

### Administration de la liste des VIP

- Seuls les *Administrateurs* peuvent modifier la liste des *VIP*.
- Les *Administrateurs* peuvent consulter la liste des *VIP* en utilisant l'API s�curis�e d�di�e.
- Les *Administrateurs* peuvent ajouter ou supprimer des *Personnes* � la liste des *VIP* en utilisant l'API s�curis�e d�di�e.

### Traitement des calomniateurs

- Il n'est pas possible de cr�er une *D�nonciation* avec un *Informateur* appartenant � la liste des *Calomniateurs*. Si un utilisateur tente de cr�er une telle *D�nonciation*, l'application lui restitue une message d'erreur lui indiquant qu'il n'est plus autoris� � cr�er des *D�nonciations*.
- Tout *Informateur* ayant cr�� au moins 3 *D�nonciations* ayant re�u une *R�ponse* de type *Rejet* est automatiquement ajout� � la liste des *Calomniateurs*.
- Tout *Informateur* ayant cr�� au moins une *D�nonciation* dont le *Suspect* faisait partie de la liste des *VIP* au moment de sa cr�ation est automatiquement ajout� � la liste des *Calomniateurs*.