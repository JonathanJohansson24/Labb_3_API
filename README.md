
Du kan göra tre anrop för Interests / Links samt Persons där alla är uppbyggda genom en simpel HttpGet, vilket visar all data i respektive klass i databasen.



När jag använder mig av endast id så är det personId som syftas på, lagt in personId där det även finns ett interestID.
Dessa två id är unika identifierare för respektive klass. 

Sedan kommer det fyra alternativ för Personklassen: 

En HttpGet(GetLinks/{id}) Där jag sorterar ut baserat på id't av personen vilka länkar som är kopplade till denna. 

En HttpGet(GetInterests/{id}) Där jag sorterar ut baserat på id't av personen vilka intressen som är kopplade till denna.

En HttpPost(AddNewInterest/{personId}/{interestId}) Där kollar jag om det redan finns en koppling mellan personen och ett intresse, om det redan görs så returneras att relationen redan finns, 
annars skapas det en koppling mellan personen och intresset ifråga. 

En HttpPost(AddLink/{personId}/{interestId}) Där kollar jag om det finns en koppling mellan personen och intresset, för att man ska kunna lägga till en ny länk så måste man 
redan vara kopplat till intresset. om det inte finns en koppling kommer det returnas ett meddelande att det saknas relation.
