Game_Programming_with_XNA
=========================

Game Programming with C# and XNA

Game that randomly generates a number from 1 to 9. The player guesses numbers by clicking on the number
tile corresponding to their guess. Tiles are highlighted when the mouse is over them. If the player clicks the left
mouse button on a tile that's an incorrect guess, the tile slowly shrinks until it's no longer visible. When the player
clicks the left mouse button on the tile that’s the correct guess, the tile blinks for a few seconds. The game then
randomly generates a new number and resets the board. The player keeps playing until they press <Esc>.
The game plays appropriate sounds on incorrect guesses, correct guesses, and the start of a new game.

Increment 1

This increment displays the opening screen.

1. Run the project as provided to make sure it compiles and runs for you
2. Add code to the Game1 constructor to set the window width to 800 and height to 600 and to make the
mouse visible (Chapter 5, Week 2)
3. Add the openingscreen.png file to the GameProjectContent project. This is the graphical asset that will be
displayed when the game starts (Chapter 5, Week 2)
4. Declare a Texture2D field in the Game1 class to hold the opening screen image. As usual, we’ll load
content into this field then draw it as appropriate (Chapter 5, Week 2)
5. Declare a Rectangle field in the Game1 class to hold the draw rectangle for the opening screen image.
We’ll use this field to draw the opening screen image as the appropriate size (Chapter 5, Week 2)
6. In the Game1 LoadContent method, load the opening screen texture into the field from Step 4 (Chapter
5, Week 2)
7. In the Game1 LoadContent method, create a new Rectangle object and put it in the field from Step
5. The rectangle should be created so the opening screen takes up the entire window (Chapter 5, Week 2)
8. In the Game1 Draw method, draw the opening screen texture in the opening screen draw rectangle
(Chapter 5, Week 2)
