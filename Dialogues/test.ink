VAR MobShot = false
VAR MobHit = false

+{MobShot} I have resolved the situation. The tower will be moved elsewhere you can go bakc home now.
Really? Well, thank you officer. I will be going back home now.->END

{MobShot:Fine we will leave now.->END} 
+{MobShot} Well, the tower is destroyed. There is no more reason for you to be here.
Yes officer. We will be going home now. {MobShot: Thanks for trying to help.}->END

{MobShot or MobHit:It does not matter what you do we will not leave before Margaret says so!->END}