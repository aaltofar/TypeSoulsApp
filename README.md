Type Souls /\* cspell:disable-file \*/ /\* webkit printing magic: print all background colors \*/ html { -webkit-print-color-adjust: exact; } \* { box-sizing: border-box; -webkit-print-color-adjust: exact; } html, body { margin: 0; padding: 0; } @media only screen { body { margin: 2em auto; max-width: 900px; color: rgb(55, 53, 47); } } body { line-height: 1.5; white-space: pre-wrap; } a, a.visited { color: inherit; text-decoration: underline; } .pdf-relative-link-path { font-size: 80%; color: #444; } h1, h2, h3 { letter-spacing: -0.01em; line-height: 1.2; font-weight: 600; margin-bottom: 0; } .page-title { font-size: 2.5rem; font-weight: 700; margin-top: 0; margin-bottom: 0.75em; } h1 { font-size: 1.875rem; margin-top: 1.875rem; } h2 { font-size: 1.5rem; margin-top: 1.5rem; } h3 { font-size: 1.25rem; margin-top: 1.25rem; } .source { border: 1px solid #ddd; border-radius: 3px; padding: 1.5em; word-break: break-all; } .callout { border-radius: 3px; padding: 1rem; } figure { margin: 1.25em 0; page-break-inside: avoid; } figcaption { opacity: 0.5; font-size: 85%; margin-top: 0.5em; } mark { background-color: transparent; } .indented { padding-left: 1.5em; } hr { background: transparent; display: block; width: 100%; height: 1px; visibility: visible; border: none; border-bottom: 1px solid rgba(55, 53, 47, 0.09); } img { max-width: 100%; } @media only print { img { max-height: 100vh; object-fit: contain; } } @page { margin: 1in; } .collection-content { font-size: 0.875rem; } .column-list { display: flex; justify-content: space-between; } .column { padding: 0 1em; } .column:first-child { padding-left: 0; } .column:last-child { padding-right: 0; } .table\_of\_contents-item { display: block; font-size: 0.875rem; line-height: 1.3; padding: 0.125rem; } .table\_of\_contents-indent-1 { margin-left: 1.5rem; } .table\_of\_contents-indent-2 { margin-left: 3rem; } .table\_of\_contents-indent-3 { margin-left: 4.5rem; } .table\_of\_contents-link { text-decoration: none; opacity: 0.7; border-bottom: 1px solid rgba(55, 53, 47, 0.18); } table, th, td { border: 1px solid rgba(55, 53, 47, 0.09); border-collapse: collapse; } table { border-left: none; border-right: none; } th, td { font-weight: normal; padding: 0.25em 0.5em; line-height: 1.5; min-height: 1.5em; text-align: left; } th { color: rgba(55, 53, 47, 0.6); } ol, ul { margin: 0; margin-block-start: 0.6em; margin-block-end: 0.6em; } li > ol:first-child, li > ul:first-child { margin-block-start: 0.6em; } ul > li { list-style: disc; } ul.to-do-list { text-indent: -1.7em; } ul.to-do-list > li { list-style: none; } .to-do-children-checked { text-decoration: line-through; opacity: 0.375; } ul.toggle > li { list-style: none; } ul { padding-inline-start: 1.7em; } ul > li { padding-left: 0.1em; } ol { padding-inline-start: 1.6em; } ol > li { padding-left: 0.2em; } .mono ol { padding-inline-start: 2em; } .mono ol > li { text-indent: -0.4em; } .toggle { padding-inline-start: 0em; list-style-type: none; } /\* Indent toggle children \*/ .toggle > li > details { padding-left: 1.7em; } .toggle > li > details > summary { margin-left: -1.1em; } .selected-value { display: inline-block; padding: 0 0.5em; background: rgba(206, 205, 202, 0.5); border-radius: 3px; margin-right: 0.5em; margin-top: 0.3em; margin-bottom: 0.3em; white-space: nowrap; } .collection-title { display: inline-block; margin-right: 1em; } .simple-table { margin-top: 1em; font-size: 0.875rem; empty-cells: show; } .simple-table td { height: 29px; min-width: 120px; } .simple-table th { height: 29px; min-width: 120px; } .simple-table-header-color { background: rgb(247, 246, 243); color: black; } .simple-table-header { font-weight: 500; } time { opacity: 0.5; } .icon { display: inline-block; max-width: 1.2em; max-height: 1.2em; text-decoration: none; vertical-align: text-bottom; margin-right: 0.5em; } img.icon { border-radius: 3px; } .user-icon { width: 1.5em; height: 1.5em; border-radius: 100%; margin-right: 0.5rem; } .user-icon-inner { font-size: 0.8em; } .text-icon { border: 1px solid #000; text-align: center; } .page-cover-image { display: block; object-fit: cover; width: 100%; max-height: 30vh; } .page-header-icon { font-size: 3rem; margin-bottom: 1rem; } .page-header-icon-with-cover { margin-top: -0.72em; margin-left: 0.07em; } .page-header-icon img { border-radius: 3px; } .link-to-page { margin: 1em 0; padding: 0; border: none; font-weight: 500; } p > .user { opacity: 0.5; } td > .user, td > time { white-space: nowrap; } input\[type="checkbox"\] { transform: scale(1.5); margin-right: 0.6em; vertical-align: middle; } p { margin-top: 0.5em; margin-bottom: 0.5em; } .image { border: none; margin: 1.5em 0; padding: 0; border-radius: 0; text-align: center; } .code, code { background: rgba(135, 131, 120, 0.15); border-radius: 3px; padding: 0.2em 0.4em; border-radius: 3px; font-size: 85%; tab-size: 2; } code { color: #eb5757; } .code { padding: 1.5em 1em; } .code-wrap { white-space: pre-wrap; word-break: break-all; } .code > code { background: none; padding: 0; font-size: 100%; color: inherit; } blockquote { font-size: 1.25em; margin: 1em 0; padding-left: 1em; border-left: 3px solid rgb(55, 53, 47); } .bookmark { text-decoration: none; max-height: 8em; padding: 0; display: flex; width: 100%; align-items: stretch; } .bookmark-title { font-size: 0.85em; overflow: hidden; text-overflow: ellipsis; height: 1.75em; white-space: nowrap; } .bookmark-text { display: flex; flex-direction: column; } .bookmark-info { flex: 4 1 180px; padding: 12px 14px 14px; display: flex; flex-direction: column; justify-content: space-between; } .bookmark-image { width: 33%; flex: 1 1 180px; display: block; position: relative; object-fit: cover; border-radius: 1px; } .bookmark-description { color: rgba(55, 53, 47, 0.6); font-size: 0.75em; overflow: hidden; max-height: 4.5em; word-break: break-word; } .bookmark-href { font-size: 0.75em; margin-top: 0.25em; } .sans { font-family: ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol"; } .code { font-family: "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace; } .serif { font-family: Lyon-Text, Georgia, ui-serif, serif; } .mono { font-family: iawriter-mono, Nitti, Menlo, Courier, monospace; } .pdf .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK JP'; } .pdf:lang(zh-CN) .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK SC'; } .pdf:lang(zh-TW) .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK TC'; } .pdf:lang(ko-KR) .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK KR'; } .pdf .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK JP'; } .pdf:lang(zh-CN) .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK SC'; } .pdf:lang(zh-TW) .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK TC'; } .pdf:lang(ko-KR) .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK KR'; } .pdf .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK JP'; } .pdf:lang(zh-CN) .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK SC'; } .pdf:lang(zh-TW) .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK TC'; } .pdf:lang(ko-KR) .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK KR'; } .pdf .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK JP'; } .pdf:lang(zh-CN) .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK SC'; } .pdf:lang(zh-TW) .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK TC'; } .pdf:lang(ko-KR) .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK KR'; } .highlight-default { color: rgba(55, 53, 47, 1); } .highlight-gray { color: rgba(120, 119, 116, 1); fill: rgba(120, 119, 116, 1); } .highlight-brown { color: rgba(159, 107, 83, 1); fill: rgba(159, 107, 83, 1); } .highlight-orange { color: rgba(217, 115, 13, 1); fill: rgba(217, 115, 13, 1); } .highlight-yellow { color: rgba(203, 145, 47, 1); fill: rgba(203, 145, 47, 1); } .highlight-teal { color: rgba(68, 131, 97, 1); fill: rgba(68, 131, 97, 1); } .highlight-blue { color: rgba(51, 126, 169, 1); fill: rgba(51, 126, 169, 1); } .highlight-purple { color: rgba(144, 101, 176, 1); fill: rgba(144, 101, 176, 1); } .highlight-pink { color: rgba(193, 76, 138, 1); fill: rgba(193, 76, 138, 1); } .highlight-red { color: rgba(212, 76, 71, 1); fill: rgba(212, 76, 71, 1); } .highlight-gray\_background { background: rgba(241, 241, 239, 1); } .highlight-brown\_background { background: rgba(244, 238, 238, 1); } .highlight-orange\_background { background: rgba(251, 236, 221, 1); } .highlight-yellow\_background { background: rgba(251, 243, 219, 1); } .highlight-teal\_background { background: rgba(237, 243, 236, 1); } .highlight-blue\_background { background: rgba(231, 243, 248, 1); } .highlight-purple\_background { background: rgba(244, 240, 247, 0.8); } .highlight-pink\_background { background: rgba(249, 238, 243, 0.8); } .highlight-red\_background { background: rgba(253, 235, 236, 1); } .block-color-default { color: inherit; fill: inherit; } .block-color-gray { color: rgba(120, 119, 116, 1); fill: rgba(120, 119, 116, 1); } .block-color-brown { color: rgba(159, 107, 83, 1); fill: rgba(159, 107, 83, 1); } .block-color-orange { color: rgba(217, 115, 13, 1); fill: rgba(217, 115, 13, 1); } .block-color-yellow { color: rgba(203, 145, 47, 1); fill: rgba(203, 145, 47, 1); } .block-color-teal { color: rgba(68, 131, 97, 1); fill: rgba(68, 131, 97, 1); } .block-color-blue { color: rgba(51, 126, 169, 1); fill: rgba(51, 126, 169, 1); } .block-color-purple { color: rgba(144, 101, 176, 1); fill: rgba(144, 101, 176, 1); } .block-color-pink { color: rgba(193, 76, 138, 1); fill: rgba(193, 76, 138, 1); } .block-color-red { color: rgba(212, 76, 71, 1); fill: rgba(212, 76, 71, 1); } .block-color-gray\_background { background: rgba(241, 241, 239, 1); } .block-color-brown\_background { background: rgba(244, 238, 238, 1); } .block-color-orange\_background { background: rgba(251, 236, 221, 1); } .block-color-yellow\_background { background: rgba(251, 243, 219, 1); } .block-color-teal\_background { background: rgba(237, 243, 236, 1); } .block-color-blue\_background { background: rgba(231, 243, 248, 1); } .block-color-purple\_background { background: rgba(244, 240, 247, 0.8); } .block-color-pink\_background { background: rgba(249, 238, 243, 0.8); } .block-color-red\_background { background: rgba(253, 235, 236, 1); } .select-value-color-pink { background-color: rgba(245, 224, 233, 1); } .select-value-color-purple { background-color: rgba(232, 222, 238, 1); } .select-value-color-green { background-color: rgba(219, 237, 219, 1); } .select-value-color-gray { background-color: rgba(227, 226, 224, 1); } .select-value-color-opaquegray { background-color: rgba(255, 255, 255, 0.0375); } .select-value-color-orange { background-color: rgba(250, 222, 201, 1); } .select-value-color-brown { background-color: rgba(238, 224, 218, 1); } .select-value-color-red { background-color: rgba(255, 226, 221, 1); } .select-value-color-yellow { background-color: rgba(253, 236, 200, 1); } .select-value-color-blue { background-color: rgba(211, 229, 239, 1); } .checkbox { display: inline-flex; vertical-align: text-bottom; width: 16; height: 16; background-size: 16px; margin-left: 2px; margin-right: 5px; } .checkbox-on { background-image: url("data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%2216%22%20height%3D%2216%22%20viewBox%3D%220%200%2016%2016%22%20fill%3D%22none%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%3E%0A%3Crect%20width%3D%2216%22%20height%3D%2216%22%20fill%3D%22%2358A9D7%22%2F%3E%0A%3Cpath%20d%3D%22M6.71429%2012.2852L14%204.9995L12.7143%203.71436L6.71429%209.71378L3.28571%206.2831L2%207.57092L6.71429%2012.2852Z%22%20fill%3D%22white%22%2F%3E%0A%3C%2Fsvg%3E"); } .checkbox-off { background-image: url("data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%2216%22%20height%3D%2216%22%20viewBox%3D%220%200%2016%2016%22%20fill%3D%22none%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%3E%0A%3Crect%20x%3D%220.75%22%20y%3D%220.75%22%20width%3D%2214.5%22%20height%3D%2214.5%22%20fill%3D%22white%22%20stroke%3D%22%2336352F%22%20stroke-width%3D%221.5%22%2F%3E%0A%3C%2Fsvg%3E"); }

![](https://c4.wallpaperflare.com/wallpaper/557/1002/400/dark-souls-solaire-solaire-of-astora-video-games-wallpaper-preview.jpg)

Type Souls
==========

WOULD
=====

Walk through it
===============

Et tekstbasert konsollspill satt til Dark Souls 1

Spilleren blir møtt av login screen, hvor spiller kan velge å starte nytt spill eller fortsette et påbegynt. Data lagres LOKALT til å begynne med, database utforskes

Starter man nytt spill vil du gå inn i en create character screen hvor du velger klasse og navn på karakteren. Klasser å velge mellom og deres bonuser er:

Warrior/Kriger

Strength

Knight/Ridder

Endurance

Cleric/Troende

Faith

Sorcerer/Trollmann

Intellect

Etter å ha laget karakter vil spilleren starte fra første “bonfire”, bål/lagringsplass. disse bonfirene er rasteplasser hvor man gjør alle valg. Her kan du:

*   Se på kartet, bestemme deg for hvor du skal gå

*   Fylle opp healingflaskene dine

*   Lagre spillet

*   Levle opp

Selve gameplayet vil skje når spilleren beveger seg fra en bonfire til en annen.

Når spilleren beveger seg vil en funksjon kjøre for å se hvor mange fiender en må sloss mot før man er fremme. 5-10 stykker vil være normalt, pluss en invasjon hvis man er så uheldig. Mellom hver fiende vil man kunne få muligheten til å dra tilbake til forrige bonfire, men man mister da all progresjon til neste område og må sloss mot alle fiendene på nytt. Hvis området man går til har en boss vil man først måtte ta alle fiendene og så sloss mot bossen uten å kunne raste. Slår man bossen vil man få masse exp og også låse opp neste område. Bosser og områder er fargekodet, så en GRØNN boss vil låse opp GRØNNE områder. Levler man opp vil man få en liten bonus til alle attributter, og man vil også få 5 attributtpoeng man kan sette i hvem av statsene man vil. I Firelink Shrine vil man kunne få muligheten til å “respecce”, det vil si at man fjerner alle attributtpoeng man har satt ut for å kunne sette dem ut igjen der man ønsker.

Spillet er ferdig når spilleren har tatt siste boss, som befinner seg i Kiln of the First Flame, og for å komme seg dit må man ta bossen i Dukes Archives.

Open up the requirements
========================

Hva har jeg behov for i dette spillet?

*   Spectre Console for grafikk og funksjonalitet, spesifikt dele opp konsollen i bolker, vise graf for helse for spiller og fiender, tegne kart

*   Hovedfunksjon for inputvalidation

*   En form for lagringsløsning offline og lokalt, skrive til og lese fra fil

*   Formler for damage og stats

*   Arrow key menu, velge menyvalg ved å bruke piltaster eller WASD.

*   En stabil timer for hvor lang tid man har på å skrive inn riktig ord i combat

Ui design
=========

Ui design

[![](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_6.png)](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_6.png)

Start game screen, denne skjermen er det spilleren møter ved spillstart.

[![](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_5.png)](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_5.png)

Ui for combat

[![](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_7.png)](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Screenshot_7.png)

Spilleren har her kommet til en bonfire og har her flere muligheter for hva den kan gjøre

Logic design
============

Timer
=====

Timeren må ha en default tid, rundt 2 sekunder, men den må kunne endres for hvert poeng spilleren plasserer i sin Intelligence stat.

Timeren må også kunne resettes for hver gang spilleren skriver et ord rett i combat.

Words
=====

Når spilleren er i combat må den skrive inn ett ord for hver gang den skal gjøre skade på motstanderen. Ordet må skrives rett og være ferdig skrevet før timeren har gått ut. Jeg tenker at her er det lurt å lese hver enkelt bokstav spilleren skriver, readkey. Skriver spilleren feil bokstav går det fint så lenge man klarer å skrive rett bokstav etterpå, og ordet er ferdig skrevet før tiden går ut. Klarer man ikke dette vil fienden gjøre skade på spilleren. I bossfights vil det fungere litt annerledes. Skriver man feil bokstav i en bossfight vil bossen gjøre skade med en gang, og ordet kastes. Man er altså nødt til å ha 100% rettskrevenhet i bosskamper for å ikke miste liv. Når spilleren får opp ordet den skal skrive vil man kjøre en readkey i konsollen som sjekker om den er den samme som stringen WordToWrite på indeksplassering \[0\], er den rett vil man så skrive inn en ny bokstav som sjekkes mot indeksplassering\[1\] osv osv til ordet er ferdig skrevet.

Travel
======

Spilleren må kunne reise fra ett område til ett annet, så det trengs en sjekk for å liste opp alle områder som spilleren har mulighet til å reise til.

WorldMap
========

En litt stor utfordring her blir å tegne opp verdenskartet. Det skal tegnes som et hierarkitre, som illustrert i bildet over. Det skal gå fint å gjøre med spectreconsole så lenge jeg setter opp klassene riktig, og logikken her bør kanskje håndteres av en WorldMap klasse?

Data design
===========

MajorArea
=========

Class for alle områder som leder til sub-areas. Disse vil være Firelink Shrine, Depths, Undead Parish og Sen’s Fortress. Disse er Major Areas fordi de unlockes av en boss i et annet område og vises først i world mappet.

### Props:

*   string AreaName - Navn på området

*   list<SubArea> LeadsTo - Hvilke children den har, altså hvilke subareas dette main area har tilknytning til

*   string ReqBossKill - Hvilken boss man må ha drept for å kunne entre dette området

SubArea
=======

Class for alle områder under et MajorArea, de vil ha en property for ParentArea, en property for LeadsTo-området man kan gå videre til, og også navnet sitt.

### Props:

*   MajorArea ParentArea - Hvilket hovedområde dette subarea hører til

*   SubArea LeadsTo - hvilket område man kan gå til herfra

Spiller
=======

Spillerklassen vil det her bare finnes en eneste instans av i hvert spill.

### Props

*   int Level - spillerens level

*   int CurrentExp - hvor mye exp spilleren har

*   int MaxExp - hvor mye exp spilleren trenger for å levle opp, økes for hver level

*   MajorArea CurrentMajorArea - hvilket hovedområde spilleren befinner seg i

*   SubArea CurrentSubArea - hvilket område spesifikt spilleren er i

*   int Health - spillerens helse

*   int StatPointsToPlace - økes med fem hver gang spilleren levler opp, fjernes hver gang spilleren legger ett point inne i en stat i PlayerStats

*   PlayerStats stats - Et objekt med alle statsene til spilleren

*   int BossKills - antall bosser spilleren har drept, tilsier hvilke områder spilleren har låst opp

*   bool Humanity - om spilleren er menneskelig eller ikke. skrus til false når spilleren dør og til true når spilleren får et boss eller invasion kill

Enemy
=====

Klassen til fiendene, de er like men har noen forskjellige navn og helseverdier som trekkes når en ny fiende blir instansiert

### Props

*   list<string> EnemyNamesList - En liste over alle fiendetypene, alle mulige navn på fiende

*   string EnemyName - Trekkes tilfeldig fra EnemyNamesList

*   int EnemyLevel - denne propen er basert på Spilleren sin verdi av BossKills, som vil si at fiendene skalerer i level med spillerens fremgang

*   int EnemyHealth - Fiendens helse

*   int Damage - skaden fienden gjør om du den får sjans til å slå, skaleres med EnemyLevel

*   bool IsDead - Settes til true når EnemyHealth når 0

Battle
======

Klassen for kamp, instansieres hver gang spilleren møter en fiende

### Props

*   Enemy EnemyToFight - fienden spilleren møter i kamp, kampen varer til EnemyToFight ikke har mer Health

*   list<string> Words - ordene spilleren må skrive for å gjøre skade på motstanderen.

*   Timer TypeTimer - Tiden spilleren har på å skrive hvert ord. resettes for hvert ord man skal skrive

Timer
=====

Klassen for timer. instansieres i hvert battle og tar inn spilleren som en property. Sekundene til timeren vil avhenge av spilleren sin Intellect stat.

### Props

*   int Seconds - default=2sekunder og for hver tiende intellect spilleren har legges det til et halvt sekund

Generelle notater og tanker
===========================

*   Bruke spectreconsole til grafikk

*   Combat består av å skrive ord rett og fort

*   Combat gir exp, ikke drops

*   Exp kan brukes til å levle opp med

*   Liste opp map som et hierarki-tre

*   Områder skal kunne gjenspilles, dvs man kan farme exp ved å bevege seg mellom bonfires

*   Bosser respawner IKKE

### Stats!

Strength

Økt damage

Intellect

Mer tid til å skrive

Endurance

Økt HP

Faith

Øker maxhp når du ikke er human, gir sjanse for ressurection

Humanity

Av eller på. Ikke human gjør så du bare får 50% max hp, men er du human åpner det opp for invasions, som gjør at du må sloss mot flere fiender på vei til steder

Level

Flat bonus til alle stats per level

Humanity kan fåes tilbake ved å drepe bosser.

[![](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Mind_Map_(1).jpg)](Type%20Souls%208c7ad71f30c142838a629d56a741af1c/Mind_Map_(1).jpg)

Kartet består av en forenklet versjon av Dark Souls 1 mappet

* * *
