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

        // Query the data and find matches 
        IEnumerable<(int, int)> blocker_match =
            from position in spell_blockers
            where position == blocker_tuple
            select position;

        // Convert the matches to a list
        var matches = blocker_match.ToList();

        // Remove the matches from the blockers
        for(int i = 0; i < matches.Count; i++)
        {
            spell_blockers.Remove(matches[i]);
        }
        // Return the list of blockers remaining. 
        return spell_blockers;
    }
}
