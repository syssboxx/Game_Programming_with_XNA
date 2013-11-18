Game_Programming_with_XNA
=========================

Game Programming with C# and XNA

Game that randomly generates a number from 1 to 9. The player guesses numbers by clicking on the number
tile corresponding to their guess. Tiles are highlighted when the mouse is over them. If the player clicks the left
mouse button on a tile that's an incorrect guess, the tile slowly shrinks until it's no longer visible. When the player
clicks the left mouse button on the tile that’s the correct guess, the tile blinks for a few seconds. The game then
randomly generates a new number and resets the board. The player keeps playing until they press <Esc>.
The game plays appropriate sounds on incorrect guesses, correct guesses, and the start of a new game.

Increment 1 - This increment displays the opening screen.

Increment 2 - When the player presses Enter, the opening screen disappears and the board (without any number tiles) is displayed.

Increment 3 - This increment displays all the number tiles on the board.

Increment 4 - This increment displays all the number tiles, which highlight when the mouse is over them. When incorrect tiles are
clicked, they shrink until they disappear.

Increment 5 - This increment finishes the game. When the correct tile is clicked, it blinks for a while, then a new game is started.
The game also includes sound effects.
