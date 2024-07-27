->Partner
VAR playerName = "copo"
VAR playerPronouns = "zim"
EXTERNAL pronouns()
EXTERNAL name()
EXTERNAL radioAvailable()
==Partner
#Partner
{not PartnerGreeting: ->PartnerGreeting}
{not PartnerAfterName: ->PartnerAfterName}
{not PartnerAfterPronouns: ->PartnerAfterPronouns}
Nothing more
->END
==PartnerGreeting
Hey there, you must be my new partner,
Nice to finally make your acquaintance.
My name is Hunter Ferguson.
*Nice to meet you Hunter, my name is …
*I am …
-
~name()
->END
==PartnerAfterName
#Partner

Well, truth be told {playerName}, I have been on this job for 20 years, and I had gone through my fair share of partners, but this time it’s different,
this country needs the good men and women of the police force more than ever, and the  manner we lost my last partner goes to prove it…
*What happened to your last partner?
*...
- We were responding to a 10-51 on the shopping mall north of Main Street.. 
It was another late night call, when the whole city of sheep sleeps unknowing of the
predators of the night, and unthankful of the shepherds who protect them.
My partner was KIA in line of duty. I don’t like to dwell in the past but his sacrifice is why I keep wearing the badge proudly for this nation, despite the crazies trying to take it over.
Nowadays the police force is fighting evil on two fronts.
As you know there is a huge crime wave happening, and we must be ready to defend
this country at all costs. Yet some evil crime-lovers are complaining about these costs! They are trying to defund us! 
These goddamn fools don’t realize the next time they see a suspicious group of people in their pool club, and they are speaking Mexican among each other, who are you going to call to scare off those illegals if the police is all but defunded? 
They are always complaining about how much of the city budget goes to the police but they don’t realize they are attempting to put a price on their own freedom. What percentage of the city budget could possibly be more important than your family’s safety?

*I’d say 26.8%.
That’s the police budget percentage from the city with the pensions included. It is barely enough money to buy two helicopters in a year!
*About 16%?
That does not even account for the pensions!
*Maybe 5%?
That’s the number liberals want in the future! Not even enough money to buy two new helicopters in a year!
-They are trying to get that number down and they are willing to use every small mistake an on duty officer makes to justify their budget cuts.
I expect from you, as my partner, to not give them any of the excuses they are looking for. 
But also don’t go easy on the evil-doers of the world at the same time, so the mag dump policy is still in full effect.
I am certain you are more than capable in finding the delicate balance between the two, the police academy only graduates the brightest and bravest after all and nothing the crazies say will ever change that.
Speaking of crazies, you are not one of those that cave in to their demands, right partner?
~pronouns()
->END
==PartnerAfterPronouns
#Partner

Hold on partner, the station is on the radio for a possible situation developing.
Use the standard issue radio call televizor on the dashboard to answer the call.
 ~radioAvailable()


-
->DONE

==topOfTheHour
#Partner

Partner, the dispatch just radioed in they are saying there is a top of the hour in progress, and there will be an ad break at the top of the hour, every hour.
To avoid those ads you can subscribe for five dollars or for free with a prime.
Or you can get lucky and get gifted a sub.
Here is the ad break right now. ->END