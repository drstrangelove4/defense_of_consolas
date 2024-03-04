class Shield(int x_value, int y_value)
    // Shield objects which are placed by the user to prevent the impact
{
    public int X_coordinate { get; set; } = x_value; 
    public int Y_coordinate { get; set; } = y_value;


    // ----------------------------------------------------------------------------------------------------------------------


    public List<(int, int)> Check_position(List<(int, int)>spell_blockers)
        // Checks to see if the current shield position is in a valid blocker as defined by the spell object.
        // Removes the position from the list if it is filled. 
    {
        // make a tuple from the class variables x and y coordinates
        (int, int) blocker_tuple = (X_coordinate, Y_coordinate);
        
        // loops over and checks if a valid position is found.
        foreach((int, int) position in  spell_blockers)
        {
            if (blocker_tuple == position)
            {
                // Delete the position from the list.
               spell_blockers.Remove(position);
               return spell_blockers;
            }            
        }
        return spell_blockers;
    }
}