<pre>@@@@@@@  @@@ @@@  @@@@@@@   @@@@@@@@      @@@@@@    @@@@@@   @@@  @@@  @@@        @@@@@@   
@@@@@@@  @@@ @@@  @@@@@@@@  @@@@@@@@     @@@@@@@   @@@@@@@@  @@@  @@@  @@@       @@@@@@@   
  @@!    @@! !@@  @@!  @@@  @@!          !@@       @@!  @@@  @@!  @@@  @@!       !@@       
  !@!    !@! @!!  !@!  @!@  !@!          !@!       !@!  @!@  !@!  @!@  !@!       !@!       
  @!!     !@!@!   @!@@!@!   @!!!:!       !!@@!!    @!@  !@!  @!@  !@!  @!!       !!@@!!    
  !!!      @!!!   !!@!!!    !!!!!:        !!@!!!   !@!  !!!  !@!  !!!  !!!        !!@!!!   
  !!:      !!:    !!:       !!:               !:!  !!:  !!!  !!:  !!!  !!:            !:!  
  :!:      :!:    :!:       :!:              !:!   :!:  !:!  :!:  !:!   :!:          !:!   
   ::       ::     ::        :: ::::     :::: ::   ::::: ::  ::::: ::   :: ::::  :::: ::   
    :        :      :         :::::       :::::     :::::     ::::::     :::::    :::::</pre>
Type Souls er et typingspill satt i Dark Souls universet, spesifikt Dark Souls 1. Hensikten med spillet er å tilby et typisk typing game, skrivespill på norsk, hvor man må skrive ord og setninger for å bekjempe fiender. Spillet har også RPG elementer i form av historie, stats og karakterbygging.

<details><summary># Generelle notater og tanker</summary>
- Bruke spectreconsole til grafikk
- Combat består av å skrive ord rett og fort
- Combat gir exp, ikke drops
- Exp kan brukes til å levle opp med
- Liste opp map som et hierarki-tre
- Områder skal kunne gjenspilles, dvs man kan farme exp ved å bevege seg mellom bonfires
- Bosser respawner IKKE

### Stats!

| Strength | Økt damage |
| --- | --- |
| Intellect | Mer tid til å skrive |
| Endurance | Økt HP |
| Faith | Øker maxhp når du ikke er human, gir sjanse for ressurection |
| Humanity | Av eller på. Ikke human gjør så du bare får 50% max hp, men er du human åpner det opp for invasions, som gjør at du må sloss mot flere fiender på vei til steder |
| Level | Flat bonus til alle stats per level |

Humanity kan fåes tilbake ved å drepe bosser. 

![Mind Map (1).jpg](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Mind_Map_(1).jpg)

Kartet består av en forenklet versjon av Dark Souls 1 mappet.
</details>


<details><summary>WOULD</summary>
  <details><summary>Walk through it</summary><blockquote>
    Et tekstbasert konsollspill satt til Dark Souls 1

Spilleren blir møtt av login screen, hvor spiller kan velge å starte nytt spill eller fortsette et påbegynt. Data lagres LOKALT til å begynne med, database utforskes

Starter man nytt spill vil du gå inn i en create character screen hvor du velger klasse og navn på karakteren. Klasser å velge mellom og deres bonuser er:

| Warrior/Kriger | Strength |
| --- | --- |
| Knight/Ridder | Endurance |
| Cleric/Troende | Faith |
| Sorcerer/Trollmann | Intellect |

Etter å ha laget karakter vil spilleren starte fra første “bonfire”, bål/lagringsplass.  disse bonfirene er rasteplasser hvor man gjør alle valg. Her kan du:

- Se på kartet, bestemme deg for hvor du skal gå
- Fylle opp healingflaskene dine
- Endre på utstyret, bytte våpen etc
- Lagre spillet
- Levle opp

Selve gameplayet vil skje når spilleren beveger seg fra en bonfire til en annen. 

Når spilleren beveger seg vil en funksjon kjøre for å se hvor mange fiender en må sloss mot før man er fremme. 5-10 stykker vil være normalt, pluss en invasjon hvis man er så uheldig. Mellom hver fiende vil man kunne få muligheten til å dra tilbake til forrige bonfire, men man mister da all progresjon til neste område og må sloss mot alle fiendene på nytt. Hvis området man går til har en boss vil man først måtte ta alle fiendene og så sloss mot bossen uten å kunne raste. Slår man bossen vil man få masse exp og også låse opp neste område. Bosser og områder er fargekodet, så en GRØNN boss vil låse opp GRØNNE områder. Levler man opp vil man få en liten bonus til alle attributter, og man vil også få  5 attributtpoeng man kan sette i hvem av statsene man vil. I Firelink Shrine vil man kunne få muligheten til å “respecce”, det vil si at man fjerner alle attributtpoeng man har satt ut for å kunne sette dem ut igjen der man ønsker.

Spillet er ferdig når spilleren har tatt siste boss, som befinner seg i Kiln of the First Flame, og for å komme seg dit må man ta bossen i Dukes Archives.
  </blockquote></details>
  
 <details><summary>Open up the requirements</summary><blockquote>
   
 
Open up the requirements

Hva har jeg behov for i dette spillet?

- Spectre Console for grafikk og funksjonalitet, spesifikt dele opp konsollen i bolker, vise graf for helse for spiller og fiender, tegne kart
- Hovedfunksjon for inputvalidation
- En form for lagringsløsning offline og lokalt, skrive til og lese fra fil
- Formler for damage og stats
- Arrow key menu, velge menyvalg ved å bruke piltaster eller WASD.
- En stabil timer for hvor lang tid man har på å skrive inn riktig ord i combat
   
 </blockquote></details>
  <details><summary>Ui design</summary><blockquote>
    
![Screenshot_6.png](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_6.png)

Start game screen, denne skjermen er det spilleren møter ved spillstart.

![Screenshot_5.png](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_5.png)

Ui for combat

![Screenshot_7.png](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_7.png)

Spilleren har her kommet til en bonfire og har her flere muligheter for hva den kan gjøre
 </blockquote></details>
  
   <details><summary>Logic design</summary><blockquote>
Logic design
 </blockquote></details>
  
   <details><summary>Data design</summary><blockquote>
     Data design
 </blockquote></details>

</details>


---
