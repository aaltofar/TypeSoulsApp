<pre>
@@@@@@@  @@@ @@@  @@@@@@@   @@@@@@@@      @@@@@@    @@@@@@   @@@  @@@  @@@        @@@@@@   
@@@@@@@  @@@ @@@  @@@@@@@@  @@@@@@@@     @@@@@@@   @@@@@@@@  @@@  @@@  @@@       @@@@@@@   
  @@!    @@! !@@  @@!  @@@  @@!          !@@       @@!  @@@  @@!  @@@  @@!       !@@       
  !@!    !@! @!!  !@!  @!@  !@!          !@!       !@!  @!@  !@!  @!@  !@!       !@!       
  @!!     !@!@!   @!@@!@!   @!!!:!       !!@@!!    @!@  !@!  @!@  !@!  @!!       !!@@!!    
  !!!      @!!!   !!@!!!    !!!!!:        !!@!!!   !@!  !!!  !@!  !!!  !!!        !!@!!!   
  !!:      !!:    !!:       !!:               !:!  !!:  !!!  !!:  !!!  !!:            !:!  
  :!:      :!:    :!:       :!:              !:!   :!:  !:!  :!:  !:!   :!:          !:!   
   ::       ::     ::        :: ::::     :::: ::   ::::: ::  ::::: ::   :: ::::  :::: ::   
    :        :      :         :::::       :::::     :::::     ::::::     :::::    :::::</pre>



#WOULD

  <details><summary>##Walk through it</summary>

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
- Lagre spillet
- Levle opp

Selve gameplayet vil skje når spilleren beveger seg fra en bonfire til en annen. 

Når spilleren beveger seg vil en funksjon kjøre for å se hvor mange fiender en må sloss mot før man er fremme. 5-10 stykker vil være normalt, pluss en invasjon hvis man er så uheldig. Mellom hver fiende vil man kunne få muligheten til å dra tilbake til forrige bonfire, men man mister da all progresjon til neste område og må sloss mot alle fiendene på nytt. Hvis området man går til har en boss vil man først måtte ta alle fiendene og så sloss mot bossen uten å kunne raste. Slår man bossen vil man få masse exp og også låse opp neste område. Bosser og områder er fargekodet, så en GRØNN boss vil låse opp GRØNNE områder. Levler man opp vil man få en liten bonus til alle attributter, og man vil også få  5 attributtpoeng man kan sette i hvem av statsene man vil. I Firelink Shrine vil man kunne få muligheten til å “respecce”, det vil si at man fjerner alle attributtpoeng man har satt ut for å kunne sette dem ut igjen der man ønsker.

Spillet er ferdig når spilleren har tatt siste boss, som befinner seg i Kiln of the First Flame, og for å komme seg dit må man ta bossen i Dukes Archives.
  </details>
    <details><summary>##Open up the requirements</summary>

Hva har jeg behov for i dette spillet?

- Spectre Console for grafikk og funksjonalitet, spesifikt dele opp konsollen i bolker, vise graf for helse for spiller og fiender, tegne kart
- Hovedfunksjon for inputvalidation
- En form for lagringsløsning offline og lokalt, skrive til og lese fra fil
- Formler for damage og stats
- Arrow key menu, velge menyvalg ved å bruke piltaster eller WASD.
- En stabil timer for hvor lang tid man har på å skrive inn riktig ord i combat
  </details>
      <details><summary>##Ui design</summary>

Ui design

![Screenshot_6.png](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_6.png)

Start game screen, denne skjermen er det spilleren møter ved spillstart.

![Screenshot_5.png](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_5.png)

Ui for combat

![Screenshot_7.png](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_7.png)

Spilleren har her kommet til en bonfire og har her flere muligheter for hva den kan gjøre
</details>
    <details><summary># Logic design</summary>

###Timer

Timeren må ha en default tid, rundt 2 sekunder, men den må kunne endres for hvert poeng spilleren plasserer i sin Intelligence stat.

Timeren må også kunne resettes for hver gang spilleren skriver et ord rett i combat.

###Words

Når spilleren er i combat må den skrive inn ett ord for hver gang den skal gjøre skade på motstanderen. Ordet må skrives rett og være ferdig skrevet før timeren har gått ut. Jeg tenker at her er det lurt å lese hver enkelt bokstav spilleren skriver, readkey. Skriver spilleren feil bokstav går det fint så lenge man klarer å skrive rett bokstav etterpå, og ordet er ferdig skrevet før tiden går ut. Klarer man ikke dette vil fienden gjøre skade på spilleren. I bossfights vil det fungere litt annerledes. Skriver man feil bokstav i en bossfight vil bossen gjøre skade med en gang, og ordet kastes. Man er altså nødt til å ha 100% rettskrevenhet i bosskamper for å ikke miste liv. Når spilleren får opp ordet den skal skrive vil man kjøre en readkey i konsollen som sjekker om den er den samme som stringen WordToWrite på indeksplassering [0], er den rett vil man så skrive inn en ny bokstav som sjekkes mot indeksplassering[1] osv osv til ordet er ferdig skrevet. 

###Travel

Spilleren må kunne reise fra ett område til ett annet, så det trengs en sjekk for å liste opp alle områder som spilleren har mulighet til å reise til. 

##WorldMap

En litt stor utfordring her blir å tegne opp verdenskartet. Det skal tegnes som et hierarkitre, som illustrert i bildet over. Det skal gå fint å gjøre med spectreconsole så lenge jeg setter opp klassene riktig, og logikken her bør kanskje håndteres av en WorldMap klasse?
</details>
      <details><summary>##Data design</summary>

##MajorArea

Class for alle områder som leder til sub-areas. Disse vil være Firelink Shrine, Depths, Undead Parish og Sen’s Fortress. Disse er Major Areas fordi de unlockes av en boss i et annet område og vises først i world mappet.

###Props:

- string AreaName - Navn på området
- list<SubArea> LeadsTo - Hvilke children den har, altså hvilke subareas dette main area har tilknytning til
- string ReqBossKill - Hvilken boss man må ha drept for å kunne entre dette området

##SubArea

Class for alle områder under et MajorArea, de vil ha en property for ParentArea, en property for LeadsTo-området man kan gå videre til, og også navnet sitt.

###Props:

- MajorArea ParentArea - Hvilket hovedområde dette subarea hører til
- SubArea LeadsTo - hvilket område man kan gå til herfra
  
##Spiller

Spillerklassen vil det her bare finnes en eneste instans av i hvert spill.

###Props

- int Level - spillerens level
- int CurrentExp - hvor mye exp spilleren har
- int MaxExp - hvor mye exp spilleren trenger for å levle opp, økes for hver level
- MajorArea CurrentMajorArea - hvilket hovedområde spilleren befinner seg i
- SubArea CurrentSubArea - hvilket område spesifikt spilleren er i
- int Health - spillerens helse
- int StatPointsToPlace - økes med fem hver gang spilleren levler opp, fjernes hver gang spilleren legger ett point inne i en stat i PlayerStats
- PlayerStats stats - Et objekt med alle statsene til spilleren
- int BossKills - antall bosser spilleren har drept, tilsier hvilke områder spilleren har låst opp
- bool Humanity - om spilleren er menneskelig eller ikke. skrus til false når spilleren dør og til true når spilleren får et boss eller invasion kill

##Enemy

Klassen til fiendene, de er like men har noen forskjellige navn og helseverdier som trekkes når en ny fiende blir instansiert

###Props

- list<string> EnemyNamesList - En liste over alle fiendetypene, alle mulige navn på fiende
- string EnemyName - Trekkes tilfeldig fra EnemyNamesList
- int EnemyLevel - denne propen er basert på Spilleren sin verdi av BossKills, som vil si at fiendene skalerer i level med spillerens fremgang
- int EnemyHealth - Fiendens helse
- int Damage - skaden fienden gjør om du den får sjans til å slå, skaleres med EnemyLevel
- bool IsDead - Settes til true når EnemyHealth når 0

##Battle

Klassen for kamp, instansieres hver gang spilleren møter en fiende

###Props

- Enemy EnemyToFight - fienden spilleren møter i kamp, kampen varer til EnemyToFight ikke har mer Health
- list<string> Words - ordene spilleren må skrive for å gjøre skade på motstanderen.
- Timer TypeTimer - Tiden spilleren har på å skrive hvert ord. resettes for hvert ord man skal skrive
  
##Timer

Klassen for timer. instansieres i hvert battle og tar inn spilleren som en property. Sekundene til timeren vil avhenge av spilleren sin Intellect stat. 

###Props

- int Seconds - default=2sekunder og for hver tiende intellect spilleren har legges det til et halvt sekund
  </details>
<details><summary>#Generelle notater og tanker</summary>

- Bruke spectreconsole til grafikk
- Combat består av å skrive ord rett og fort
- Combat gir exp, ikke drops
- Exp kan brukes til å levle opp med
- Liste opp map som et hierarki-tre
- Områder skal kunne gjenspilles, dvs man kan farme exp ved å bevege seg mellom bonfires
- Bosser respawner IKKE

###Stats!

| Strength | Økt damage |
| --- | --- |
| Intellect | Mer tid til å skrive |
| Endurance | Økt HP |
| Faith | Øker maxhp når du ikke er human, gir sjanse for ressurection |
| Humanity | Av eller på. Ikke human gjør så du bare får 50% max hp, men er du human åpner det opp for invasions, som gjør at du må sloss mot flere fiender på vei til steder |
| Level | Flat bonus til alle stats per level |

Humanity kan fåes tilbake ved å drepe bosser. 

![Mind Map (1).jpg](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Mind_Map_(1).jpg)

Kartet består av en forenklet versjon av Dark Souls 1 mappet

---
