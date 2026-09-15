## Del A

Med `Join()` ventet hovedtråden på at alle drone-trådene skulle fullføre før den skrev at alle dronene var ferdige. Uten `Join()` fortsatte hovedtråden umiddelbart, slik at meldingen om at alle droner var ferdige ble skrevet før selve droneflyvningen var fullført. Rekkefølgen på checkpoint-meldingene var derimot omtrent den samme, fordi `Join()` ikke styrer hvordan trådene kjører, den bestemmer bare når hovedtråden får fortsette

## Del B

Jeg brukte `async/await` og `Task.WhenAll` for å kjøre droneflyvningene asynkront. Jeg brukte `Task.Delay` i stedet for `Thread.Sleep`, slik at tråden ikke blokkeres under venting. Jeg testet også feilhåndtering ved å simulere motorfeil på et checkpoint og håndtere feilen med `try/catch` rundt `Task.WhenAll`. Jeg lærte hvordan `Task` og `await` fungerer, og forskjellen mellom asynkron venting og `Thread.Join`.

## ControlTowerService

Jeg laget en `ControlTowerService` som har ansvar for å koordinere flere droneflyvninger. Jeg brukte `Task.WhenAll` for å vente på alle flyvningene, og `try/catch` for å håndtere feil. Dette gjorde også koden mer ryddig siden Control Tower håndterer orkestreringen, mens `AsyncDroneService` kun har ansvar for selve flyvningen.

## Del C
