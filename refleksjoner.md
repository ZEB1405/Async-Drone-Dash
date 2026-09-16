# Refleksjoner

## Del A

Med `Join()` ventet hovedtråden på at alle drone-trådene skulle fullføre før den skrev at alle dronene var ferdige. Uten `Join()` fortsatte hovedtråden umiddelbart, slik at meldingen om at alle dronene var ferdige ble skrevet før selve droneflyvningen var fullført. Rekkefølgen på checkpoint-meldingene var derimot omtrent den samme, fordi `Join()` ikke styrer hvordan trådene kjører. Den bestemmer bare når hovedtråden får fortsette.

## Del B

Jeg brukte `async/await` og `Task.WhenAll` for å kjøre droneflyvningene asynkront. Jeg brukte `Task.Delay` i stedet for `Thread.Sleep`, slik at tråden ikke blokkeres under venting. Jeg testet også feilhåndtering ved å simulere motorfeil på et checkpoint og håndtere feilen med `try/catch` rundt `Task.WhenAll`. Jeg lærte hvordan `Task` og `await` fungerer, og forskjellen mellom asynkron venting og `Thread.Join`.

## ControlTowerService

Jeg laget en `ControlTowerService` som har ansvar for å koordinere flere droneflyvninger. Jeg brukte `Task.WhenAll` for å vente på alle flyvningene, og `try/catch` for å håndtere feil. Dette gjorde også koden mer ryddig siden `ControlTowerService` håndterer orkestreringen, mens `AsyncDroneService` kun har ansvar for selve flyvningen.

## Del C

I Del C brukte jeg `HttpClient` for å hente data fra et eksternt HTTP-API. Jeg laget en egen `DroneApiService` som har ansvar for API-kallet og deserialisering av JSON-data til en `TodoModel`.

Jeg brukte `async/await` også ved API-kallet, slik at programmet ikke blokkerer mens det venter på svar fra serveren. Jeg satte også en timeout på `HttpClient` for å unngå at programmet venter ubegrenset dersom API-et ikke svarer.

Data fra API-et brukes av `ControlTowerService` til å påvirke droneflyvningen. Dersom API-et returnerer at oppgaven er fullført, økes forsinkelsen til dronene med 500 ms. Jeg testet også feilhåndtering ved å bruke en ugyldig URL, og programmet håndterte da `HttpRequestException` uten at droneflyvningene startet.

Jeg lærte hvordan `HttpClient`, JSON-deserialisering og asynkrone API-kall kan brukes sammen med `Task` og `async/await`. Jeg fikk også bedre forståelse for hvordan man kan dele opp ansvar mellom forskjellige services, slik at API-kommunikasjon, droneflyvning og orkestrering ikke ligger i samme klasse.
