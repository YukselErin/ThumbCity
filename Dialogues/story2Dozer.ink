/*
Story2: Dozer Rampage
Characters:
Dozer Rampager Cousinfuck Jonhatan
FenthenolCut Deal Guy
Old Vet HVAC Small Business Tyrant
*/
VAR playerName = "JDAM Fisher"
VAR spokenToJonathan = false
VAR JonathanMad = false
==topOfTheHour
#Partner

Partner, the dispatch just radioed in they are saying there is a top of the hour in progress, and there will be an ad break at the top of the hour, every hour.
To avoid those ads you can subscribe for five dollars or for free with a prime.
Or you can get lucky and get gifted a sub.
Here is the ad break right now. ->END
==Partner
+I am going in to deal with this situation, are you coming or what?
Partner as much as I like to do that I have to adhere to protocol on this one and stay back until he runs out of ammo or something.
But I will try to scan the area and gather some intel that could come in use.
This whole thing is already trending on Tiktok, maybe someone will post it when the dozer runs out of gas or something?
Anyways good luck to you though!
++Thanks a whole bunch…
-
->END

EXTERNAL endMission()
==Radio
#Partner

+{peacefulEnding} I think I've managed to end his rampage partner. (End Mission)
Roger that, rest of us will be there shortly. 
~endMission()
->END
+{JonathanKillsHimselfBool} The situation has resolved itself partner, you can come in now (End mission)
Roger that, rest of us will be there shortly.
~endMission()
->END
+{JonathanOpening > 0 and JonathanMad}Dispatch{~, put me through to the coward with the portable panic room.|, put me through to the War Thunder player outside, that left his room finally.|, put me through to the terrorist outside if a hellfire missile did not got him yet.}->JonathanHub

+{JonathanOpening > 0 and not JonathanMad} Dispatch, put me through to the perpetrator outside. ->JonathanHub
+Nothing ->END
==Jonathan //Dozer Rampager Cousinfuck Jonhatan
#Dozer Rampager

{spokenToJonathan:->JonathanHub}
~spokenToJonathan =true
*Can you hear me? This is police officer {playerName}.
I can hear you alright. If you can hear me, do what you were taught to do in your academy and stay out of my way like the rest of your crooked friends.
*Earth to cousinfuck in the tin can, Earth to cousinfuck do you read me?
If you want me to hear you, why don't you come on out in the open so I can flatten your arrogant head into the asphalt?

-
*I am coming over to your side. Do not shoot, you can still get out of this.
Boy, if you get into my sightline it will be the dumbest mistake of your life, not saying that figuratively.
*I will crack open the lid of your Alzheimer prevention hobby and fill it with my load until you are swimming inside the biggest man made coconut to exist.
YOU INBRED FUCK I LIKE TO SEE YOU TRY I AM GOING TO SHOOT OUT YOUR KNEECAPS AND START RUNNING OVER YOU LEGS FIRST SO YOU CAN FEEL EVERY SECOND OF IT UNTIL I GET TO YOU HEAD.
I WILL RECORD THE SOUND OF YOUR SKULL POPPING UNDER MY THREADS AND PUT IT ON FACEBOOK FOR YOUR WIFE AND KIDS TO LISTEN TO.
-
- ->END


VAR visitedJonathanOpening = false
==JonathanOpening
#Dozer Rampager
~visitedJonathanOpening = true
Behold, I have created the smith that bloweth the coals in the fire, and that bringeth forth an instrument for his work; and I have created the waster to destroy.
 No weapon that is formed against thee shall prosper; and every tongue that shall rise against thee in judgment thou shalt condemn. This is the heritage of the servants of the Lord, and their righteousness is of me, saith the Lord.->END
 
 
==RadioEncounteredNarcan
Partner, you seem to have encountered a Narcan in that medicine cabinet.
+Wait, how do you know that?
-It says so right there on the vial. That thing saved many police officer's lives.
+No, I meant how do you know what I have come across?
-Did you forget about your body cam partner?
Now, the existence of that can in a regular medicine cabinet might mean you are near a fentanyl den.
Fentanyl started popping out all around the country, they put it into low grade cocaine to give it extra kick. 
But in reality a single speck of fent will make you join choir eternal.
Normally someone else would have to administer the Narcan to you in an emergency. But seeing as though strayed apart from your partner,
you will have to administer it yourself, nasally.
If you feel like you came in contact with fentanyl, lose no time to huff a cloud of the medicine, you can shoot the can to get it faster if you need to.
+So you have been watching my video feed to see how this plays out huh?
-It's not like that at all, partner, I've been pretty busy myself.
I am trying to put it to Facebook live by filming your body cam feed.
+Roger that, good to know one of us is making progress. Over.->END
==RadioEncounteredTrail
*Partner, do you see what I am seeing?
As I suspected, this is a drug den. They must have spread fentanyl all around as a trap.
Whatever you do, do not touch them unless you are inhaling the Narcan.
And if you encounter any clean stuff in a plastic bag make sure to confiscate it without the bodycam seeing it. I can dispose of them later, over.
->END

==RadioEncounteredDoorknob
#Partner

Wait partner. Don't you see that doorknob?
They have laced it with fentanyl, you can not touch that doorknob and open it without narcan.
Hope you have extra on you or you will need to go back to get some more. 
Be careful partner, over.->END

==JonathanHub
#Dozer Rampager

{JonathanMad} You again? You slippery devil you barely escaped from my hand. Come on out again and I'll finish you.
{not JonathanMad}I warned you not to cross my path officer. I will not show mercy again.
+{JonathanMad} You could not outpace a snail with that brick truck of yours, I will come out again to light a fire under you until you are cooked like pottery kebab.
+ Know that if you shoot down a police officer our revenge will be enacted upon you.
-Your threats do not scare me. I was put on this path by God and by his will I am protected.->JonathanHub.chocies
=chocies
*Only thing that protects you is that you have not ran out of gas yet.->JonathanHub.chocies
Do not deny God's grace, if the Lord did not protect you would be riddled with holes by now.
+You are surrounded by all sides, there is no running away, come out unarmed now.
You will pursue your enemies, and they will fall by the sword before you.
Five of you will chase a hundred, and a hundred of you will chase ten thousand, and your enemies will fall by the sword before you
I will look favorably upon you, making you fertile and multiplying your people. And I will fulfill my covenant with you.->JonathanHub.chocies
++You keep reciting bible verses, but where in the good book does it say to seal yourself in a deathmachine and shoot people from there?
You people have given me n other option, you will not walk all over the righteous anymore, God is just in his wrath.
++I am a bible man myself, you are hurting innocent in your crusade. 
I have been reasonable until this day but they left me no choice but to be unreasonable.
Good people will stay silent only so long. One day we snap. And keep snapping multiple weeks in their workshop building a tank, there isn't anything else they can do.
++Keep your biblicisms to yourself, we won't have every schizophrenic person get on a quest for death and destruction.
If you wanted less schizo breakdowns you would not have worked so hard to keep city's money flowing to you instead of shrinks.
If you are the only answer this city has to me, keep tooting your gun and pray the bullet that ricocheted from my armor does not hit anyone rich or important.
-
->END
==JonathanOnTopOfDozer
#Dozer Rampager

How in the hell did you manage to get up there? Don't try anything stupid now or I'll come out and shoot you myself.->JonathanOnTopOfDozerChoices
==JonathanOnTopOfDozerChoices
#Dozer Rampager

*It's over Jonathan, I have the high ground.
You underestimate how I will drive this thing into a burning car pile and get you, even if it burns me in the process.->JonathanOnTopOfDozerChoices
*You built this whole thing but you could not anticipate someone getting on top of it? No real tank engineer would make this oversight!
I thought of that, of course I thought of that... Don't speak as if you know anything of my craft!
The grease I put on top of the armor should have made you slide and fall off.
But either all the grease came off when I plowed through buildings, or you are just enough of a piggy yourself to be accustomed to grease.
I bet it is the second one, so good job being as slippery you are in your daily life.->JonathanOnTopOfDozerChoices
*It's only a matter of time until I figure out a way into this thing through the top, why don't you just save us the time and come on out?
You can hardly afford to fall off of that thing now can you? I will flatten you moment you hit the ground. You are probably too afraid to even shoot your gun now!
Why don't you just enjoy the show from up there instead of trying anything?
You will still come off as a hero to anyone looking from outside! This is the easiest way to be a hero cop in this situation, well done!->JonathanOnTopOfDozerChoices
*END ->END
EXTERNAL JonathanKillsHimself()
VAR JonathanKillsHimselfBool = false
==JonathanTrapped
#Dozer Rampager

*You are trapped now, there is no way for you to get out of that hole. Come on out slowly.
*{JonathanMad} You have thirty seconds until I find where I put my can opener. Come on out if you don't want me to pour seasoning into your box and seal it for fermentation.
-...
-...
~JonathanKillsHimself()
~JonathanKillsHimselfBool = true
->END
EXTERNAL peaceful()
VAR peacefulEnding = false
EXTERNAL outOfTrip()
==JonathanFentanylIntake
#Dozer Rampager

Wait... What the hell did you do...
I don't feel like myself. Did you put something through the air conditioner...
*Yes, I did. And if you keep hotboxing it inside you won't have much time to live.
You devil... How could you do such a thing... I cannot tell my elbow from my ass...
This should not be possible, the air conditioner should have been sealed... Only a tiny amount of could have gotten through.
You will not get to me with tricks like this... I was put on this path by God.
*No, what are you talking about. It must be your own actions weighing on your conscience.
My conscience is light as a feather, I only did what I was meant to do...
-God lead me to this path I will see it through.

*Yes my son, and thee hadt done well. Thy mission is complete now.
My Lord... Am I dead, is my life's work done?
**No my son, I decided to communicate directly to tell thy mission is complete. You can come out now.
But your signs, you sent so only signs before...
There is no out for me now, I left everyting behind when I decided to do this.
What am I going to do outside.
***Now you will live the life you always deserved. I will bless thee with more riches than you left behind.
My Lord... I always knew I deserved too be much more successful... But the wicked kept me down...
I am ready, make me a way outside dear God!
                ****You shall sit and wait now until I open a way through.
                ~peaceful()
                ~peacefulEnding = true
                ->END
                ****Now leave this world as thee have planned to do, and thy Lord will bring thee to a life worth living. Kill thyself.
                ~JonathanKillsHimself()
                ~JonathanKillsHimselfBool = true
                ...
                ...
                ...
                ->END
            ***Now you will keep serving thy Lord by raising a family with many children.
            I never had any signs to raise no family, so I could do my mission without leaving a widow behind...
            How am I going to raise a family now, they will arrest me outside.
                ****Thy Lord shall drop all thy major charges in court thus thee shall get out to parole relatively easy.
                No, no somethings wrong. This is can not be a vision from God, but Satan.
                You will not turn me from my path, Satan. I will make your servants pay.
                ~outOfTrip()
                ->END
            
                ****Thine people will recognize thee had good intentions. Do thee not trust my words?
                No, no somethings wrong. This is can not be a vision from God, but Satan.
                You will not turn me from my path, Satan. I will make your servants pay.
                ~outOfTrip()
                ->END
**Yes my son, you are in my Kingdom now. 
But I still hear the engine sound, I don't feel dead.
***I raptured you alongside with your dozer, come on out if you wish to see me.
***That is the sound of the choirs, come on out if you wish to see me.
I lived next to engines all my life, I know the difference.
--No, no somethings wrong. This is can not be a vision from God, but Satan.
--You will not turn me from my path, Satan. I will make your servants pay.
~outOfTrip()
->END
VAR triedDealerArrest = false
EXTERNAL spawnFlares()
VAR DealerHit = false
VAR DealerShot = false
==Dealer
#Dealer
Aw geez what the hell...
How the hell does the police bust down my door in the middle of this shitshow!
I told Richie to make sure no cop can walk through that corridor, gave him enough fent to make a blue whale go belly up too...
+I am placing you under arrest for possession and trafficking of the number one cop killer, besides car crashes and covid. Put your hands in the air!
I hear and respect that officer. 
~triedDealerArrest = true
But have you consider the situation we are in and how none of your cop friends will show up to help you while that lunatic is out there?
So in light of that I think we will be putting the arrest thing on hold untill the situation is fixed.
+You had enough fentanyl laced outside to kill a pod of blue whales, which is what a group of whales are called, but relax I am not here for you today.
Well then why did you go through all that to come to me?
-
+You have your whole criminal business down here and yet are you not afraid of that lunatic coming here?
-A basement like this completely safe from the tank outside beacuse of the single fact that although that tank of his can flatten any man made object, it could not climb out of a ditch like a basement to save it's life.
So that looney should think twice before crashing my party.
+That's what a sane person would avoid, does the man outside seem like that to you?
Hell, you might be right there is no way that jacko thought this through.
{JonathanMad:He was calmer for a few minutes up there but started going bananas again when, I assume you arrived.}
+Yes, but the amount of bullets he's been sending out means that no one would suspect me for the bullet I'll put in you if you don't agree to cooperate.
Hey settle down why don't yous there is no need to get your panties in a bunch.
-He de did not stop for all the coppers up there how in the hell you think he's gonna stop for yous.
{triedDealerArrest: I mean I appreciate your guts to try arrest me in my own lair but you gotta be realistic here.}
I've seen the coo-coo vet that lives across the street launch a rocket at the thing but no avail.
But what I'll tell you officer, I am a man who knows business so I'll make you a deal.
I'll lend you my henchmen if you agree that after we take down that thing, it quitely dissapears of the record.
Meaning that I get to keep it of course.->Deal
-
->END
==Deal
#Dealer

So what do you say to my deal?
+Absolutely not, I'll handle this on my own.
+Allright you got yourself a deal. 
~spawnFlares()
+How about you listen to my deal, you agree to help and I'll keep the heat from the station to get to your business.
-I am afraid I can't do that, but the original offer stands.
->END
VAR VetHit = false
VAR VetShot = false
VAR talkedVetToDisarm =false
EXTERNAL talkedVetDisarm()
==OldVet
#Old Vet
Don't come any closer you damned wops. This is the last place you will shakedown, I'll spill your tomato pizza sauce right out of your skull. 
+Sir this is the police. Put your gun down now.
The police? You will never get my guns you fed scum. If you want it so much, come and take it!
++You got it all wrong, I am here for the mass shooter out there. Just please stop shooting and I'll explain
Shooter? You mean your fed friends staging a play to take away my God given right to bear arms that did not exist before the founding fathers?
I will never give up my second amendment rights because of your bitch made tactics.
Now get the hell out of my property before I tear you a new one. ->END
++There is no need for this, I am here to help you out.
You are with the government and you are here to help me !?!?
That is the single scariest thing I have ever heard in my entire life!
I was warned about this, you will never take me alive you sumbitch!->END
++You misunderstand me, I need your help with the situation outside.
Need help is putting it lightly. Everything you do, you do because of my tax dollars.
Now stop begging for even more and get the hell out of my property.->END
++I am here to confiscate all your guns, just come on out peacefully or there will be trouble.
Who do you think you are threatening, I spent my whole life fighting wars your bitch made threats mean nothing to me.
If you want my guns come inside and get it.->END
+No this is your neighbor from the next apartment. The psychopath outside destroyed my house. I need your help.
What psychopath outside? What is this, some kind of trick?
++What do you mean, the man in the bulldozer outside breaking all hell? Did you not even notice that?
Everyday there is a maniac in the news and gunshots are not rare occurrence in this part of town. 
If my kids sent you here to make me look like a confused old man, it is not working.
Now get the hell out and tell my ungrateful children I will not be admitted to a looney bin.->END
++A man has attacked my house and scared my children. I just need some help from a hero who has served in the military. Please let us in.
I am not here to do charity for every schmuck that blames their failures for others.
If you feel unsafe go buy some guns like a normal American. ->END
++A man out there has attacked my private property with a bulldozer. If you don't help they will ruin my way of life.
Those godless commies just can not learn to respect the American lifestyle. Come on in brother, I know how it is like to be constantly under attack. 
~talkedVetToDisarm=true 
~talkedVetDisarm()
->END
++We are under attack and we need you to save this nation once again!
Well if shit got real this time.
Then every man for himself is the rule of the jungle!
Go help yourself and stay out of my building.
+You are the vet that lives in this building right? I am here to finally sign you in for veterans benefits.
So you have finally decided to support the brave men of this country. But you remember the real reason I asked for veterans support right? I wrote it to you in my many mails to your organization.
++Yes, of course. Veterans do a great service to this country and should not be left behind to suffer financial troubles.
What in the hell kind of reason is that, don't you see I have this whole apartment building to myself. I did not ask for a handout go and read the mails I sent you and then come back!->END
++Yes, we need to teach the kids of the new generation of the sacrifice the veterans made.
All your government thought to the kids is being homosexual. I don't talk to mine anyway so get the hell out of my face with that bullsiht.->END
++Yes, your veteran benefits compensation will be used to lobby to make sure no other veterans get any money from the government.
I even though my hearing aid is not on I can hear the mockery in your tone. You may not like it but it is consistent ideology! ->END
++Yes, the money will be used to expose the shapeshifting reptile ruling class.
I don't need money for that, I have my boomstick. Now get the hell out and read my mails to your agency.->END
+Hey that is anti-Italian racism. Shame on you bigoted old man.
I fought for my freedom to say whatever the hell I want.
++Yeah but that does not give you the right to be racist, that is still bad.
Then I'll fight to be racist too.->END
++So did they! Do you mean to disrespect the Italian's who gave their lives for this country?
I, did not meant to disparage any fighting man of the USA... That's not what I meant! Get the hell out!->END
++Well if they hear you talking like that they are gonna whoop your ass.
You threatening me with the mobsters? I am no small fish for them, come and get it if you want. ->END
++No, I was pulling your leg a little. I am anti Italian as well, come on no need for hostility?
Well that is good on you.
I don't like suck ups though so stay the hell back.

- ->END

==OldVetFaceToFace
#Old Vet

+The commotion outside has shaken you huh old man?
What in the hell are you talking about again? This is a fairly average in around these parts.
++Did you not even hear the noise of the buildings getting demolished outside?
Well, my healing aid is not working so good anymore, so what noise you talking about I might have missed.
It might also be my training to filter out the sounds of shells dropping in the war kicking in.
In the heat of the battle you can not afford to pay attention to the sound of every explosion. 
What you learn in the war you don’t forget so quickly after, but it still sometimes comes in handy to filter out things like construction noises, smell of moldy man feet and pleas of innocent people.
+++Is that also why you had a shotgun trained on your front door entrance? Training kicking in?
That one might just be the PTSD.
+Don’t you want to be the good guy with a gun, why have you not gone outside to stop the rampaging dozer outside?
Look what ever the shooter outside is on about, there is a good chance I agree with him. 
And if I don’t it is a false flag anyways. There is no need for me to put my hide on the line here, I have already shown my courage by hoarding as many guns as possible.
++So at least you have a weapon to pierce the armor outside?
I have a few rockets lying around, legally mind you, but I don’t think they would ever be able to go through an armor.
They might be good for demolishing a wall or blowing up some watermelons if you have a slow mo camera to capture it though.
+Nothing.
- ->END