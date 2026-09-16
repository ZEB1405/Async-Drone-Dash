# Async Drone Dash

Async Drone Dash er en C# console-applikasjon som simulerer droneflyvninger og demonstrerer forskjellen mellom tradisjonelle tråder og asynkron programmering.

## Funksjoner

Programmet har en meny med tre deler:

### Del A – Thread + Join

Bruker `Thread` for å kjøre flere droneflyvninger samtidig.

* Hver drone kjører i sin egen tråd.
* `Thread.Sleep()` brukes for å simulere tid mellom checkpoints.
* `Thread.Join()` brukes for å vente på at alle trådene skal fullføre.

### Del B – async/await + Task.WhenAll

Bruker asynkron programmering for å kjøre flere droneflyvninger.

* `async/await` brukes for asynkrone operasjoner.
* `Task.Delay()` brukes i stedet for `Thread.Sleep()`.
* `Task.WhenAll()` brukes for å vente på at alle droneflyvningene skal fullføre.
* Feilhåndtering testes ved å simulere motorfeil på et checkpoint.

### ControlTowerService

`ControlTowerService` fungerer som et orkestreringslag mellom droneflyvningene og API-et.

Ansvar er blant annet:

* Starte flere droneflyvninger.
* Vente på alle flyvningene med `Task.WhenAll()`.
* Håndtere feil fra droneflyvninger.
* Hente data fra API-et gjennom `DroneApiService`.

### Del C – HTTP API

Bruker `HttpClient` for å hente data fra et eksternt HTTP-API.

* API-data hentes asynkront.
* JSON-responsen deserialiseres til en `TodoModel`.
* API-data brukes til å påvirke droneflyvningen.
* Dersom API-et returnerer `completed: true`, økes droneforsinkelsen med 500 ms.
* HTTP-feil håndteres med `try/catch`.
* `HttpClient` har en timeout på 5 sekunder.

## Teknologier

* C#
* .NET
* `Thread`
* `Thread.Join()`
* `async/await`
* `Task`
* `Task.WhenAll()`
* `HttpClient`
* JSON deserialisering

## Prosjektstruktur

```text
Async-Drone-Dash/
├── Models/
│   ├── DroneModel.cs
│   └── TodoModel.cs
├── Services/
│   ├── AsyncDroneService.cs
│   ├── ControlTowerService.cs
│   ├── DroneApiService.cs
│   └── ThreadDroneService.cs
├── Program.cs
├── refleksjoner.md
└── README.md
```

## Hvordan kjøre

Klon repositoryet og kjør prosjektet med:

```bash
dotnet run
```

Programmet viser deretter en meny hvor du kan velge mellom Del A, Del B og Del C.

## API

Del C bruker JSONPlaceholder som et eksternt demo-API.

Endpointet som brukes er:

```text
https://jsonplaceholder.typicode.com/todos/4
```

Responsen brukes til å demonstrere hvordan eksterne API-data kan påvirke programflyten.
