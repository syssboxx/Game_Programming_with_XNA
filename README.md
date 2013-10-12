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

Increment 2

When the player presses Enter, the opening screen disappears and the board (without any number tiles) is displayed.

9. You don't need to do anything for this step; it just provides information you need for the next step. I've
declared a GameState field called gameState in the Game1 class and I've set it to
GameState.Menu. This field is used to keep track of the current game state
10. In the Game1 Draw method, add an if statement that checks if the current game state is
GameState.Menu before drawing the opening screen texture in the opening screen draw rectangle
(Chapter 7, Week 3)
This step uses something called an enumeration, which we haven't discussed yet. You can read
about enumerations in Section 8.1 of the book if you'd like, but for this step you just need to know that
gameState == GameState.Menu
is a Boolean expression that will evaluate to true if the value of the gameState variable is currently
GameState.Menu.
11. Declare a NumberBoard field in the Game1 class. This field will be used to hold the number board for
the current game (Chapter 4, Week 2)
12. In the Game1 LoadContent method, create a new NumberBoard object and put it in the field from
Step 11. Use the window width and height to calculate the board side length and the board center before
calling the constructor. The board should be centered in the window and should be smaller than the window
width and height. At this point, I just set the correct number to 8 and the sound bank to null
(Chapter 4, Week 2)
13. Add the board.png file to the GameProjectContent project. This is the graphical asset we’ll use for the
board background (Chapter 5, Week 2)
14. You don't need to do anything for this step; it just provides information you need for the next step. In the
NumberBoard class, I've declared Texture2D field called boardTexture to hold the board texture
and I've declared a Rectangle field called drawRectangle to hold the draw rectangle for the board
texture
15. Write the NumberBoard LoadContent method (Chapter 5, Week 2)
16. Write the NumberBoard constructor, which loads the content (by calling the LoadContent method you
wrote in the previous step), creates a new draw rectangle object, and calculates the size of the number tiles
on the board. Be sure to include borders around the tiles using the BORDER_SIZE constant; the picture
below might help you generate the appropriate calculation. Don’t create the number tiles yet (Chapter 5,
Week 2)
17. Write the NumberBoard Draw method to draw the board texture in the board draw rectangle. Don’t draw
the number tiles yet. (Chapter 5, Week 2)
18. In the Game1 Update method, add an if statement that changes the game state to GameState.Play if
the current game state is GameState.Menu and the Enter key is pressed. The following code returns
true if the Enter key is pressed and false otherwise:
Keyboard.GetState().IsKeyDown(Keys.Enter)
and the following code changes the game state to GameState.Play
gameState = GameState.Play;
(Chapter 7, Week 3)
19. In the Game1 Draw method, add an else clause to the if statement from Step 10 to have the board draw
itself if the current game state is GameState.Play
(Chapter 7, Week 3)
