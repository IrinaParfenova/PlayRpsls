# PlayRpsls
Play rock paper scissors lizard spock funny game

Implementation the next endpoints for a funny game.
Rules: https://www.wikihow.com/Play-Rock-Paper-Scissors-Lizard-Spock

Choices  
GET /choices  
Returns all possible choices.  
{  
"id": integer,  
"name": string (rock, paper, scissors, lizard, spock)  
},  

Choice  
GET: /choice  
Returns a randomly generated choice.  
{  
  "id": integer,  
  "name" : string (rock, paper, scissors, lizard, spock)  
}  

Play  
POST: /play  
{  
  "player": choice_id  
}  

Play a round against a bot.  
{  
  "results": string (win, lose, tie),  
  "player": choice_id,  
  "bot": choice_id  
}  

Remarks  
To make a random choice used an external random generator.  
GET: https://rpssl.olegbelousov.online/random  
{  
  "random": [0-255]  
}  
