
// Initial game setup

const double MULTIPLIER = 0.8;

// Changes the console title
Console.Title = "The Defense of Consolas";

// Track the amount of spells stopped by the user.
int spells_stopped = 0;


// Display the intro text to the user along with the current high score. 
int high_score = Data_handler.Load_high_score();
Console.WriteLine($"Welcome to the defense of Consolas! Your current highscore is {high_score}\n");

// Create the spell object needed for the game
Spell spell = new();

// The amount of time the user gets to raise their shields (1000ths of a second)
int time_to_shield = 60_000;

// ----------------------------------------------------------------------------------------------------------------------


// Ties together most of the logic required for playing the game.

bool playing = true;
while (playing)
{
    // Get new coordinates for spell hit and blocker location.
    spell.Generate_new_coordinates();
    var blockers = spell.Generate_blocker_coordinates();

    // Instructions.
    Console.WriteLine($"The enemy has tageted X: {spell.X_coordinate} Y: {spell.Y_coordinate}!!", Console.ForegroundColor = ConsoleColor.Red);
    Console.WriteLine("You have 4 shields to create a square around the impact location to stop Consolas from getting destroyed!\n", 
        Console.ForegroundColor = ConsoleColor.White);
    Console.WriteLine($"You have {time_to_shield/1000} seconds to raise the shield!");

    // Create shield objects
    List<Shield> shield_list = create_shield(time_to_shield);    

    // Check to see the shields are placed in the correct positions
    foreach (Shield shield in shield_list)
    {
        blockers = shield.Check_position(blockers);
    }

    // Check if the blast was prevented
    bool is_empty = !blockers.Any();
    if (is_empty)
    {
        // Increment the variable recording the blasts stopped
        spells_stopped++;
        Console.WriteLine($"\nYou have stopped the blast! Your current score is: {spells_stopped}\n", Console.ForegroundColor = ConsoleColor.Green);

        // Delete the shield objects from the list.
        for (int i = 0; i < shield_list.Count; i++)
        {
            shield_list.Remove(shield_list[i]);
        }

        // Make the game harder by reducing the input time
        time_to_shield = Convert.ToInt32(time_to_shield * MULTIPLIER);
    }
    else
    {
        // Trigger game over logic.
        Console.WriteLine("\nThe spell touched down! Consolas is no more.", Console.ForegroundColor = ConsoleColor.Red);
        Console.WriteLine($"You stopped {spells_stopped} blasts.", Console.ForegroundColor = ConsoleColor.White);
        Console.WriteLine("GAME OVER!");

        // See if the highscore needs updating and write it to file.
        if (spells_stopped > high_score)
        {
            Console.WriteLine($"\nNEW HIGH SCORE: {spells_stopped}. WAS: {high_score}. WELL DONE", Console.ForegroundColor = ConsoleColor.Green);
            Data_handler.Write_highscore(spells_stopped);
        }

        // Break the loop
        playing = false;
    }
}


// ----------------------------------------------------------------------------------------------------------------------


List<Shield> create_shield(int time)
    // Creates shield objects and ensures correct values are passed.
{
    // List to be returned
    List<Shield> shield = [];


    // Use an lambda expression to give the task x seconds to complete.
    var user_input_task = Task.Run(() =>
    {
        // Count the number of shields created
        int total_shields = 0;
        while (total_shields < 4)
        {

            // Take user input - this should check that the input is valid as well. 
            Console.WriteLine($"Create shield {total_shields + 1}:");
            Console.Write("X value: ");
            int x_value = value_conversion();
            Console.Write("Y value: ");
            int y_value = value_conversion();
            Console.WriteLine();

            // Create an add the shield object using valid inputs
            Shield new_shield = new(x_value, y_value);
            shield.Add(new_shield);

            // Increment the counter 
            total_shields++;

        }
    });

    // Stops the task after X amount of time.
    user_input_task.Wait(time);
    
    // Return the values of the list
    return shield; 
}


// ----------------------------------------------------------------------------------------------------------------------


int value_conversion()
    // Takes user input and converts it to an int. If it cannot do that then it continues to prompt user for a valid input.
{
    // We are using an imaginary 10 x 10 grid for the game - this is the boundaries of the allowed user input.
    const int MIN_VALUE = 0;
    const int MAX_VALUE = 10;
    
    // The the position the user inptus that we will return
    int value = 0;
    
    bool taking_input = true;  
    while (taking_input)
    {
        try
        {
            // Take the input from the console and attempt to convert it to a int.
            value = Convert.ToInt32(Console.ReadLine());

            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                // Prompt the user for a valid input. 
                Console.WriteLine("Invalid input! Enter a number between 0 to 10:");
            }
            else
            {
                // Break the loop in the case of valid input.
                taking_input = false;
            }
        }
        catch (Exception)
        {
            // Prompt the user for a valid input in the case that we cannot typecast their input from a string to int.
            Console.WriteLine($"Invalid input! Enter a number between 0 to 10.");
        }
    }
    return value;
}


// ----------------------------------------------------------------------------------------------------------------------
