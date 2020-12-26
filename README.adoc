= NationalParks backend application (.NET)
This application is a backend that provides geolocation information about NationalParks. The information is stored in a mongodb


== Installation

Assuming you're using the project `workshop`:

----
oc new-project workshop
----

=== Deploy from source code

----
oc new-app https://github.com/openshift-roadshow/nationalparks-dotnet.git
----

== Dataset

National Parks data comes from link:https://protectedplanet.net[ProtectedPlanet], listing worlwide National Parks categories, filtered as units shown link:https://en.wikipedia.org/wiki/List_of_the_United_States_National_Park_System_official_units[here]

We used this link:https://www.protectedplanet.net/en/search-areas?filters%5Bis_type%5D%5B%5D=terrestrial&filters%5Bdesignation%5D%5B%5D=Nacional+Park&filters%5Bdesignation%5D%5B%5D=National+Forest+Park&filters%5Bdesignation%5D%5B%5D=National+Historic+Park&filters%5Bdesignation%5D%5B%5D=National+Battlefield&filters%5Bdesignation%5D%5B%5D=National+Historic+Site&filters%5Bdesignation%5D%5B%5D=National+Historical+Park&filters%5Bdesignation%5D%5B%5D=National+Lakeshore&filters%5Bdesignation%5D%5B%5D=National+Military+Park&filters%5Bdesignation%5D%5B%5D=National+Monument&filters%5Bdesignation%5D%5B%5D=National+Park&filters%5Bdesignation%5D%5B%5D=National+Park+%28Category+Ii%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28Commonwealth%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28Fbih+Law%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28PN%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28Rs+Law%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28Scientific%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28Svalbard%29&filters%5Bdesignation%5D%5B%5D=National+Park+%28project%29&filters%5Bdesignation%5D%5B%5D=National+Park+-+Buffer+Zone&filters%5Bdesignation%5D%5B%5D=National+Park+-+Buffer+Zone%2FArea+Of+Adhesion&filters%5Bdesignation%5D%5B%5D=National+Park+-+Core+Area&filters%5Bdesignation%5D%5B%5D=National+Park+-+Integrale+Reserve&filters%5Bdesignation%5D%5B%5D=National+Park+-+Peripheral+Zone&filters%5Bdesignation%5D%5B%5D=National+Park+Aboriginal&filters%5Bdesignation%5D%5B%5D=National+Park+and+ASEAN+Heritage+Park&filters%5Bdesignation%5D%5B%5D=National+Park+and+Ecological+Reserve&filters%5Bdesignation%5D%5B%5D=National+Park+and+Indigenous+Territory&filters%5Bdesignation%5D%5B%5D=National+Reserve&filters%5Bdesignation%5D%5B%5D=National+River&filters%5Bdesignation%5D%5B%5D=National+Seashore[query] listing 2830 National Parks at the moment.
