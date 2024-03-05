Defense of Consolas
------------------

This is project Idea taken from a random C# book. It has turned into a much bigger endeavour than what was in the book. The game is played on an imaginary 10 x 10 grid, the computer fires a "projectile" at a certain square. 
The user must raise 4 "shields" in a square pattern around the projectile to block it (one at each right angle).

Over the orignal spec added:
- Time for user to complete placing of their shields
- Difficulty increase through reduction of time upon each success.
- Input validation - the user will continue to be prompted if they enter a string that can't be cast into an int or an int outside of the grid limits.
- Scores.
- Presistent high scores across playthroughs (saved in a simple .txt file and is parsed every time the game opens).
- Used classes/objects to try to keep the code clean as possible. Used a static object to handle saving scores.
- Added a graph that shows where the spell will hit on the grid for some visual feedback.

 Unlike my previous projects, the save/load functions should work on all platforms. My high score is a mere 9.
