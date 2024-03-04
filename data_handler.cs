
static class Data_handler
    // Used for saving and loading high scores and managing of score related files.
{
    // Create the path for the expected location of the highscore record.
    static string current_directory = AppDomain.CurrentDomain.BaseDirectory;
    static string filename = "highscore.txt";
    static string high_score_path = Path.Join(current_directory, filename);


    // ----------------------------------------------------------------------------------------------------------------------


    public static int load_high_score()
    // Load a high score from file. If the file isn't present call the function to create one.
    {
        int high_score = 0;
        // Try to load the file and get the highscore.
        try
        {
            // open the file at the path
            StreamReader reader = new(high_score_path);
            string line = reader.ReadLine();
            // conver the file value into a int and save it in the high score variable
            high_score = Convert.ToInt32(line);
            reader.Close();
        }
        // If there is no file found at the path or the file is messed up, create a new one.
        catch (Exception e)
        {
            write_highscore(high_score);
        }

        return high_score;
    }


    // ----------------------------------------------------------------------------------------------------------------------


    public static void write_highscore(int high_score)
    // Create a new high score file and write the highscore to it.
    {
        // Tell the stream writer to overwrite the file if it exists at path.
        StreamWriter writer = new(high_score_path, false);
        // write 0 to it
        writer.Write(high_score.ToString());
        writer.Close();
    }
}