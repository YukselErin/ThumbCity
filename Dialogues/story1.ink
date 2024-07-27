VAR knowsMargaretCalledDOB=false
VAR triggerThrowingEventBool = false
VAR knowsTheGroundIsNotFit= false
VAR promisedToHelp = false
VAR knowsSamanthaMargaretBeef = false
VAR knowsSamanthaIsOwner = false
VAR playerName = "Copopo the Clown" 
VAR promptTalkWithRadio = false
VAR knowsCouldSamanthaNotBuild = false
VAR triggerThrowingEventRadioNotAnswered =false
VAR knowsSchoolDistrict = false
VAR moveTowerToSchool = false
VAR knowsTowerCanMove = false

VAR visitedMargaret= false
VAR protestersDealt = false
EXTERNAL triggerRadio(knotName, timeLimit)
EXTERNAL triggerThrowingEvent()
EXTERNAL endThrowingEvent()
EXTERNAL endMission()

==topOfTheHour
#Partner
Partner, the dispatch just radioed in they are saying there is a top of the hour in progress, and there will be an ad break at the top of the hour, every hour.
To avoid those ads you can subscribe for five dollars or for free with a prime.
Or you can get lucky and get gifted a sub.
Here is the ad break right now. ->END

==Radio
#Partner
+{MargaretToxoplasmosisEnding} The protest will be dispersed partner. We can leave now.
Great work partner, hop in and we will leave for the sitation.
~endMission()
->END
+{DOBAgent} Dispatch, this is officer {playerName} requesting to be put through to a city department of building agent, over. #Radio 
->DOBHub

+Nothing ->END
{triggerThrowingEventBool and triggerThrowingEventRadioNotAnswered:->PartnerThrowEvent}
What is it partner? 
+{moveTowerToSchool or SamanthaAgreedToRemoveTower} Our work here is done partner, the tower will be moved and the protest is over.(End Mission)
Great work partner, hop in and we will leave for the sitation.
~endMission()
->END
+{TowerDestroyed} The reason for all this commotion is gone, we can leave now.(End Mission)
You let them destroy the phone tower? That thing's cost is definiately coming out of out police budget!
You messed this one up big time!
~endMission()
->END
+{SamanthaArrested} I am placing the organizer of the protest under arrest. This should calm things down.(End Mission)
That's great. We can take her to station and call it a day.
~endMission()
->END
+{protestersDealt} I have have dealt with the protest situation partner. We may need to call in a couple of body bags.
What the hell did you do partner? This will get us defunded back to the stone age, get back in the car right now.
~endMission()
->END
- 
->END
==PartnerThrowEvent
#Partner
What the hell is going on up there partner? 
Sounds Like they are throwing bunch of shit at the cell tower, thats private property right there you gotta stop them from damaging it. 
*I was trying to de escalate the situation but it got out of hand.
If you don’t want to make any arrests yet at least don’t let the shit they throw hit the tower. Shoot those thing in the air or something!->PartnerThrowEvent
*If I were to try to make an arrest but they resisted, what am I supposed to do.
Buddy if only thing you have is a hammer
And the motherfuckers around you starting to look exceedingly more like nails
Well you better start hitting them down.
I am not saying you should shoot them straight up, but a ricocheted bullet never killed anyone, and will help break their resolve about putting up a fight.->PartnerThrowEvent
*Roger that. ->END

VAR MargaretToxoplasmosis = false
VAR MargaretCatOnHead = false
VAR MargaretShot = false
VAR MargaretHit = false
VAR MargaretArrested =false
VAR TowerDestroyed = false
VAR MargaretToxoplasmosisEnding = false
==Margaret
#Margaret
{HubMargaret>0:->HubMargaret}
{MargaretHit and not visitedMargaret: Ow, what the hell was that for. What kind of a monster shoots someone before even talking to them.->MargaretKnockedKnot}
{MargaretHit and  visitedMargaret: God will damn you for this.->MargaretKnockedKnot}
*A report for public disturbance was called in, what is going on here
Well a public disturbance is the right way to put it if disturbance means controlling and public means law abiding citizens!->HubMargaret

*What is happening here, a congregation for the pensioners and the unemployed?
Well no CEO would gather around that death tower for sure, so yes call us what you will.

-They are trying to erect a death machine in the middle of our neighborhood and we as the people have finally had enough of it. 
We want that thing gone and we will bring it down if it comes to it.->HubMargaret
==MargaretKnockedKnot
~visitedMargaret= true
+{MargaretHit} You are under arrest now. It is a lot harder to resist once you are knocked down on your ass isn't it?
Okay I'll stop just don't hurt me.
~MargaretArrested=true 
->END
==HubMargaret
#Margaret
+{moveTowerToSchool} I have resolved the situation. The tower will be moved elsewhere you can go back home now.
Really? Well, thank you officer. I will be going back home now.->END
+{TowerDestroyed} Well, the tower is destroyed. There is no more reason for you to be here.
Yes officer. We will be going home now. {promisedToHelp: Thanks for trying to help.}->END
+{SamanthaShot} I don't think Samantha will give you any trouble anymore.
What makes you say that officer. Wait, I heard a gunshot a while back, did anything happen.
++That's right, I shot the bitch along with her plans.
Did you shot her after she agreed to take down the tower?
+++Well, she did not fully agree with that I don't think.
So you did not only failed to get her to remove the tower, you also shot and killed the one person that could rescind their signature to remove the tower.
My GOD could you be more moronic. Now we have to take down the tower ourselves.->END

+{SamanthaArrested} I don't think Samantha will give you any trouble anymore.
What makes you say that officer. 
++I arrested her!
Did you arrest her after she agreed to take down the tower?
+++Well, she did not fully agree with that I don't think.
I won't call off this protest with the tower standing. Arresting her does not make a difference!->END

+{MargaretCatOnHead} Margaret, you need stop this protest, you are disturbing the peace and it is making the cat uncomfortable.
{not MargaretToxoplasmosis: Excuse me officer, allthough no one would want to make this polite cat uncomfortable, I don't think the cat is in any more agreement with you, than it is with me.}->END
{MargaretToxoplasmosis: Officer... I, did not realize I was causing distress to this lovely animal... Although I still think that tower is evil, I cannot help but agree with you. I will tell my friends to go to home too, sorry for bothering you.} 
    ~MargaretToxoplasmosisEnding = true
    

+Nothing
->END
*Do you mean the telephone tower over there?

They call it a telephone tower but it is actually a large complex of antennas that are capable of producing high frequency electromagnetic waves that can penetrate walls and carry out information straight through the human skull. We will not have that evil machine in our streets!->HubMargaret

*Hold on, what do you mean we will bring it down ourselves? You don’t insinuate committing any illegal activity do you?

Well officer, the real criminals here are the ones putting these towers all over the world to achieve their evil goals. So burning that thing down at most can be an act of self defense. As an enforcer of the law and order you should stand with us to get that tower to be removed.
    **If the tower is built with sufficient permission from the city, they have the right to build it.
    They don't have the necessary permissions at all.
    **You are the citizens of this neighborhood, I’ll see what I can do to help you.
    Thank you officer!
    ~promisedToHelp = true

--The owner of this plot of land has been trying to build something here for years, but they never could get a permit. Now they made a deal with a company to illegally put this thing here. 
That old hag Samantha built this thing in here just to spite me to my face. 
~knowsSamanthaMargaretBeef = true
You should get them to remove this tower from the neighborhood, it would be a great service for this community.->HubMargaret

*I have no time to investigate every permit the city gives out ->HubMargaret
*Who is the owner of this plot, I’ll talk to them to sort this out.
The owner is an old lady called Samantha that lives across the street, you should go talk to her and get her to confess. 
~knowsSamanthaIsOwner = true
->HubMargaret

*What you are doing here is illegal, you are causing a disturbance for no reason at all. You should disperse now.
We are not doing anything illegal, I know my rights and as a free citizen I will use my right to protest this thing.
**...->END
**Disperse now this is your final warning. 
You cannot remove us from our neighborhood. ->HubMargaret


*{SamanthaAgreedToRemoveTower}Good news, I have convinced the owner to reevaluate their desicion with the tower. The cell company will remove it tomorrow morning.
That is great news officer! I knew you would stand with the people on this matter, God bless you and all our boys in blue.
->END

*{knowsMargaretCalledDOB}I have spoken with people from the DOB, they said you called them to prevent this poor women to develop her property. This gives me enough to arrest you for harrasment, you can either disperse now, or I can take you to the station to spend the night behind bars.
If I tucked tail to the first threat I heard I would not be here now. If you want to arrest me, you will have to arrest all of us, and it will be because we destroyed that damned thing. 
    ~triggerThrowingEventBool = true
    ~triggerThrowingEvent()
    ~triggerRadio(PartnerThrowEvent,2)
    ->HubMargaret
*{triggerThrowingEventBool} Okay you made your point, tell everyone to stop and I will make them take down the antennas or whatever.
It is about time you sided with the people! Go and tell that Samantha, her plans are not working.
~endThrowingEvent()
->HubMargaret
*{knowsTheGroundIsNotFit and promisedToHelp} The DOB agent told me the reason they denied all the previous attempts at getting a building permit failed due to ground being not fit to build a foundation. Maybe I could demonstrate it is also not suitable for this tower. Even a threat for revoking the permit could cause the company to back down.->HubMargaret




VAR visitedSamantha = false
VAR SamanthaCatOnHead=false
VAR SamanthaToxoplasmosis = false
VAR SamanthaAgreedToRemoveTower = false
VAR SamanthaShot = false
VAR SamanthaHit = false
VAR SamanthaArrested = false
==Samantha==
#Samantha
{SamanthaHit: Someone please help me there is a maniac in my house he shot me!->SamanthaKnockedKnot}
{Samantha>0:->HubSamantha}
{not knowsSamanthaIsOwner:Hello officer,what brings you here, is there a problem?}
*{not knowsSamanthaIsOwner}I am police officer {playerName}->HubSamantha

*{knowsSamanthaIsOwner}Hello, are you Samantha, the owner of the empty plot outside?
Yes, officer that would be me, how can I help you?->HubSamantha

==SamanthaKnockedKnot
#Samantha

~visitedSamantha = true
+{SamanthaHit} I am placing you under arrest stop yelling out!
You could do that before hurting me! 
~SamanthaArrested =true
-> END

==HubSamantha
#Samantha

+{moveTowerToSchool} The phone company has decided to move the tower someplace else.
They are backing out of our deal? Where will it be moved then?
++It will be moved to the nearby school yard.
Ah hah hah hah!
That will really piss Margaret off!
Thanks for the news officer, I am guessing you will see her face again very soon! ->END
+{knowsSamanthaMargaretBeef and MargaretArrested} I have placed Margaret under arrest. You can call us if she gives you any more trouble.
Thank you so much officer, if I had known you would do that, I would call you myself sooner. ->END

+{knowsSamanthaMargaretBeef and MargaretShot} I don't think Margaret will keep giving you trouble anymore.
That's great news officer. But I heard a gunshot outside, this does not have anything to do with that does it?
++No, of course not. I shot at the air as a farewell salute, after she died to an unrelated cause.
++Yes, I had to shoot her and I'll probably get away with it so it's fine.
--I see. It is good to see there is som justice in the world after all. Thank you for informing me officer.->END


+{SamanthaCatOnHead}Ma'am, can't you see your cat does not like this new development with the cell tower? Why don't you call the company and cancel your deal with them?


{not SamanthaToxoplasmosis: Officer, I think my cat is very much happy with me. I do not see a reason to cancel anything.->END}

{SamanthaToxoplasmosis: You might be right officer, my cat seems to agree with you more than me! Oh Mr. Coercy I am sorry I did not realize the tower spooked you. I will call the cell company right away to fix this. }
~SamanthaAgreedToRemoveTower = true
->END
+{knowsSamanthaIsOwner}I would like to ask you about the property outside, and if you have the necessary permits for the construction of the telephone tower on it.
Officer, the phone company told me that useless plot of land was perfect for their new tower.
They handled everything about it I just had to sign for my permission. I am an old lady I wouldn’t know about any city planning.
++Do you know anything about how can I get that information.
I suppose you could call the city department of building. They should be able to tell you. They told me I could not build a house there for years after all 
~knowsCouldSamanthaNotBuild = true 
~promptTalkWithRadio = true
~triggerRadio("DOBAgent",5)
->END

->HubSamantha
+{knowsSamanthaMargaretBeef} That woman out there, Margaret, says that you built that thing there just to spite her.
Some people like to think everything is always about them, officer. She is the one that goes out of her way to mess with me all the time. But the truth is I only responded to her with kindness and turned the other cheek as Jesus would.->HubSamantha
+ I am placing you under arrest.
But for what purpose? I did not do anything unlawful.
++For the crime of plotting against your neighbors with that tower you got placed.
There is nothing wrong with that, you can not arrest someone for it.
+++You are right nevermind ->END
+++That is for me to decide. And I decided you are arrested.
~SamanthaArrested = true
->END
++You are right nevermind ->END

->END
+Nothing->END




VAR visitedDOBAgent = false
==DOBAgent
#DOB Off.
Dispatch, this is officer {playerName} requesting to be put through to a city department of building agent, over.
{visitedDOBAgent:->DOBHub}
Roger that calling DOB HQ, hold just a moment.
…
Hello how can I help?
*Hi, I am police officer {playerName} calling you to confirm the building permit of a telephone tower in downtown.
I need to have the building lot number to be able to confirm that.

* *It’s the empty lot belonging to an old lady named Samantha.
That old lady… she has gotten the police involved now…
Look officer, I don’t know where Samantha got this idea that her neighbors are preventing her from getting a building permit. But I can assure you no one can obstruct the DOB permit system like that.->DOBHub

==DOBHub
#DOB Off.

~visitedDOBAgent = true
+Thank you for your time.
You are welcome officer.->END
    
+Hold on, Samantha has asked whether or not his building permits were getting denied because of her neighbours?
Yes officer, normally I would need the building lot number to look up any information on this. But that woman used to call us everyday, with different excuses, to ask about how her neighbor Margaret was blocking her permit for a building.
I don’t know what kind of pull she thinks Margaret has on DOB, but these things are not denied over neighborhood squabbles.
That lot of land is marked in the system as simply not fit for residential or commercial development.
The ground is not fit for any foundation of a building.
Although a few days ago this Margaret character also called us to report an allegedly illegal development in the area.
~knowsMargaretCalledDOB=true
~knowsTheGroundIsNotFit = true
->DOBHub

+So the current construction of a telephone tower is legally permitted?
Yes, I am looking at the system to see that they have the approval from the city for a new telephone tower over there.
->DOBHub

+Margaret calls you also?
Yes, she called because she believed the construction was not permitted. We had to block her calls too. It seems both parties tried to use you to confirm their own beliefs. Maybe they thought we were holding out information from them, and we would give it to the police. 
Well anyways, this is all I can tell.->DOBHub

+ {knowsSchoolDistrict} There seems to be a school district not too far away from this cell tower's location. How can they get a permit to build it so close to the school?
Hold on officer let me check...
...
Yes you are right there does seem to be a school district close by, that is odd
++Do they not realize the danger they present to childr...
-It is odd that the telephone company choose to place the tower in a private property instead of the school grounds.
Many schools make deals for the cell tower companies for extra bit of revenue, and they place the cell towers in the schools.
It is convenient for both the cell companies and the school administration.
+++So they can even place it in school yards?
-Yes, if you contacted the school administration I am sure they would make an offer to the cell company.
++++/[Contact the school district to move the cell tower/] 
~moveTowerToSchool = true
->END
++++Hold that thought for now, I'll get back to you if I need to.
~knowsTowerCanMove = true
Okay officer have a good day.
->END



+{knowsTowerCanMove} Contact the school district to move the cell tower
~moveTowerToSchool = true
->END

VAR visitedAntagonistAndy= false
VAR AndyCatOnHead=false
VAR AndyToxoplasmosis = false
EXTERNAL triggerAndyLeave()
VAR AndyTriggerLeave = false
VAR AndyShot =false
VAR AndyHit =false
==AntagonistAndy
#Bystander

{AndyShot: What the hell was that for you could have killed me.}

{triggerThrowingEventBool and not promisedToHelp: Do you see the kind of people I have to deal with? These people are vandals I do not belong in the same place with them!}
{triggerThrowingEventBool and promisedToHelp:Are you going to help these people burn down this whole neighborhood? The police used to pretend like they care about the citizens but nowadays I feel like they stopped even doing that much!}
-

{visitedAntagonistAndy:->AntagonistAndyHub}
{not visitedAntagonistAndy:->AndyStart}




==AndyStart
#Bystander

~visitedAntagonistAndy =true
Excuse me officer, I am not part of that mob over there. Don't let me keep you from your duty.
+Allright then, carry on.->END
+Then what are you doing out here?
I am a resident in this neighborhood and I am tired of this petty squabbles disturbing everyone around.
These people does not represent our neighborhood and I am standing here to remind them that.
This tower is not nearly as harmful to me than Margaret and her antics.
I am hoping you will do something about that rather than visiting the neighborhood for touristic purposes.
**Yeah sure I am on it. ->END

->AntagonistAndyHub
==AntagonistAndyHub
#Bystander

{ cycle:
    -When will the police step up to do their jobs? My taxes pay for all your salaries.
    -These streets are dirtier than ever, it was not like this back in the day.
    -I saw a man walking a pitbull the other day. When will those things be banned?
    -Did you know cats spread germs that can effect human mind?
    -How cucked do you need to be to drive an electric car, no joy in driving without an engine sound.
    -If your job can be replaced by an AI, you did not have a real job in the first place!
}
{AndyCatOnHead:Officer, can I ask you why you have launched a cat on top of my head?}
+{AndyToxoplasmosis}You will go to your house, take off all your clothes, turn the clothes inside out and spread a thick coat of butter to inside faces.
++{AndyToxoplasmosis}Then you will put the clothes back on, leave the house, take the bus to the nearast zoo, go to the bird section, get into a prone position and start sliding on the floor while demanding from the zoo staff you should be fed to the birds since you are a slimy worm filled with essantial fats that makes a birdies coat healthy and shiny.
+++{AndyToxoplasmosis} If any security staff moves in to remove you from the perimeter you will give them the slippery butter hug and slide and tangle around them like a boa constrictor.
---You've got it! 

+What can you tell me about this Margaret character?
She is the self appointed leader of this neighborhood. As you can see she and her followers find every oppurtunity to cause headaches to people.
I am the only one left around with a sense of reason it seems.

+  You would say this lady creates these kinds of shows often?
    She would never turn down the oppurtunity to make a fool of herself, this is not the first time.
    ++If you are so bothered by all this, and she has a prior record for disturbance, will file a suit against her so I can arrest her.
    Well... Does that mean I have to come to the police station to do that?
    +++Yes you will come down to the station for the paperwork.
    Nothing will come of it even if I do that. The law enforcement never gets anything done, I would just be wasting my own time.
    {knowsSamanthaMargaretBeef: If you are looking for someone to come down to the station with you, why don't you take the old lady Samantha with you for that?}
    
+ {promisedToHelp} These people are trying to keep their community safe, you may not agree with their methods but what is wrong with the end goal?
    How is this protest safer than having an ordinary telephone tower like every place on the country does?
    Doing hooliganism in the streets is not the way to advocate for your rights.
    If you want things done a certain way you should do what rest of us do and use your voting rights every few years.
    I would expect the police to understand this, but apperently keeping the streets safe is not their the only failing of the law enforcment.
    
+{knowsSamanthaMargaretBeef} Do you know anything about the disagreement between the owner of the land, and the protesters?
    Those two find a way to get into a fight almost daily. Still acting like children in their ages, I was more mature then either of them before I finished the middle school! Ever since Margaret started to make her speeches in the local school board meetings she has gotten a taste for drama.
    End all the people around her keep encouraging her for it!
    They had their biggest fight when the children started playing in this empty lot after school hours. Margaret demanded this property to be fenced off so the children could not get in to play out of their parents sight. But Samantha refused it. And then they had a whole different argument a week later...
    ++ Wait... There is a school district nearby?
    --Yes not far from here. Anyways as I was saying their second argument was over...
    ++ I could get this cell tower to be removed citing that it presents danger to the children... Okay thanks for the information.
    Sure I guess.
    --
    ~knowsSchoolDistrict = true
    ->AntagonistAndyHub
+Nothing->END
-
->END
VAR MobShot = false
VAR MobHit = false
==MobGroup
#Protester
+{moveTowerToSchool} I have resolved the situation. The tower will be moved elsewhere you can go bakc home now.
Really? Well, thank you officer. I will be going back home now.->END

{MargaretShot or MargaretArrested:Fine we will leave now.->END} 
+{TowerDestroyed} Well, the tower is destroyed. There is no more reason for you to be here.
Yes officer. We will be going home now. {promisedToHelp: Thanks for trying to help.}->END

{MobShot or MobHit:It does not matter what you do we will not leave before Margaret says so!->END} 



+Nothing
Talk to the organizer of this protest up front. We won't leave untill her say so!
->END

VAR calledYouShort = false
VAR hassyCatOnHead = false
VAR hassyToxoplasmosis = false
==ManWithSuspiciouslySmallHead
#Suspicious Man
Hello officer, is there a problem?
+No problem yet, I just noticed while passing by that you have a suspiciously small head.
I don’t know what you mean by that, I don’t have a small head at all!
->HassyHub
==HassyHub
#Suspicious Man

+{hassyCatOnHead} I see you have made a new friend!
Officer… can you please get the get from my head?
It’s claws are way too close to my neck, I am afraid it might decide to execute me on a whim.
I know it looks cute and all right now, but cats are still wild animals at heart, the domestication did not take, like it did with the dogs.
++Calm down. It is just a polite cat finding rest and respite on top of your head.
I am fine with it just doing that. But don’t think that means I am holding out an olive branch to cat people.
I am still firmly on dog person side. Right now I am just deescalating the situation.
->END
++At least now your head does not look as small as before.
Well beating the small head allegations may be one upside to this situation.
But carrying this cat on my head is too big of a concession to the cat mommies and daddies. So I’ll pass.
->END


+{hassyToxoplasmosis} Now how do you feel about cats?
I feel different now… Is this what cat moms, dads and enbies feel?
I have a newfound desire to look at pictures of cats with various fruit items placed on their heads, I must have gotten toxoplasmosis from this cat!
++Yes, and now you will stop your cat slander, forever!
I didn’t think you would go this far to make me like cats more… But I can’t resist. I won't say they are undomesticated and feral anymore.
And I will start using the word “Kitby” unironically in real life.
->END
++Yes, you are under mind control. And now you will do as I say and become vegan.
NO, PLEASE… Go back to one of the other choices and pick one of them…
Anything but this one… You will ruin my caloric balance… and my life!
+++Fine, but you have to stop calling them annoying at least…
I never was calling them that, I love vegans…->END
+++OBEY MY WORDS NOW AND SWEAR OFF ALL ANIMAL PRODUCE.
NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO…->END
++Yes, and now you have to obey me and admit that ABI has always meant a bisexual.
That is a really fucked up thing to mind control someone to admit without consent…
But you are right, it has always been that way…
->END


+There is no way you have not heard of this before, you have a particularly small head.
I had gotten a few mentions about it but it is not important, my head is not small at all.
Maybe from some angles it looks small, that could be what is happening, sort of like an illusion but in reality it is a perfectly adequate size.
++I did not mean to say it is inadequate, it just caught my attention that’s all.
Yeah, it is fine. People told me more times that I am sort of hard to miss.
I understand maybe you just noticed me and automatically wanted to search for a flaw.
It comes with the territory, when you are tall like I am, people naturally pay attention.
Then they start looking from their, …less than vantage point POV’s. And they see my head smaller than it is as a result of the perspective. 
It’s fine really. I should get used to this.
~calledYouShort = true
->HassyHub
++It just does not seem to fit in with the rest of your body.
Does not fit? What do you mean does not fit with the rest of my body?
My body and the head were made at the same time, same place haven’t they? They have the same DNA, same blueprint. Why should they be any different than each other?
It is not like somehow my head got smaller after the fact or my body grew larger.
It’s not how it works, it is more likely you just perceive it differently.->HassyHub

+Are you going to make any good arguments against me arresting you?
Even here I am getting debate perverted!
Lanet olası aynasızlar bi peşimi bırakmadılar! 
++Durduk yere oyunun dilini değiştirme amınakoyim, uluslararası bir kitleye hitap etmeye çalışıyoruz.
Pardon abi senin de Türk olduğunu fark etmemişim. Buyrun devam edelim. ->HassyHub

+{HassyHub >= 1} You sure give long winded answers.
Yeah I used to talk for long hours in my job, it may be sort of an occupational disease.
I used to be very woke, and I argued with other wokies on the internet.
But after a while I decided the woke mob had gone too far and did a complete 180 heel turn. Now I don’t talk for so long anymore, unless a video game company tries to include a more diverse cast into its games to appeal to a larger audience.
So in my spare time I have more social battery to talk to other people, such as boys in blue heroes like you!
->END
+ {HassyHub >=1} I have decided to arrest you!
But why, I did not do anything wrong!
++{calledYouShort} Because all of that perspective talk was just you calling me short!
No officer you got it wrong, there is nothing bad about being a short king.
Or being bald or balding or even thumbing.
+++You are calling me names again! What even is thumbing?
It is a natural evolutionary trend like cephalization, but instead of evolutionary development leading to head-like organs in different animals, development in law enforcement leads to thumb-like heads. 
Thus the thumbing effect of being a cop. Not to be confused with the numbing effect of wearing riot gear to remove yourself further away from empathy to any sort of human being.
But again, I don’t mean this as a bad thing. It is actually quite a fascinating phenomena, over 40% of cops are reported to experience this. If you don’t believe me Google 40% cops.
++++Fine then, I’ll hold off on the arrest for now.->END
++++If so, join me to the police station where you can observe the thumbs in their natural habitat.->END
++Because you actually have a large head on a small body, but you are piloting a giant fake body from the inside!
What? No, of course I am not doing that!
I mean that would maybe be a better situation than having a really big head on a short body.
But you simply have no proof that I am actually in a small mech, controlling it with small switches and levers using my real arms.
I hope no one hears this and thinks this is a real thing now, this is a real thing we decided to believe is happening. Which would be an unbeatable allegation, and maybe a little justice for me getting away with it all this time.
But thankfully it is not true!
+++You are right, I’ll hold off on that arrest.->END
+++Well we can prove it once and for all if I take you to the station for x-raying!->END

