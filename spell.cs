using System.Security.Cryptography;

class Spell()
    // The spell object. The computer will use this to target a location
{
    // Constants - required for correct placement and blocker generation. 
    const int min_grid = 1;
    const int max_grid = 10;
    const int offset = 1;

    public int X_coordinate { get; set; } = 0;
    public int Y_coordinate { get; set; } = 0;


    // ----------------------------------------------------------------------------------------------------------------------



    public List<(int, int)> Generate_blocker_coordinates()
        // Generate a list of correct coordinated for the shields to be placed.
    {
        List<(int, int)> blockers =
        [
            (X_coordinate - offset, Y_coordinate + offset),
            (X_coordinate - offset, Y_coordinate - offset),
            (X_coordinate + offset, Y_coordinate + offset),
            (X_coordinate + offset, Y_coordinate - offset),
        ];

        return blockers;
    }


    // ----------------------------------------------------------------------------------------------------------------------



    public void Generate_new_coordinates()
        // Used at the start of every round. Allows the spell to be targeted at a location on the grid. 
    {
        X_coordinate = RandomNumberGenerator.GetInt32(min_grid, max_grid);
        Y_coordinate = RandomNumberGenerator.GetInt32(min_grid, max_grid);
    }

}