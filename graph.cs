class Graph
{
    const int START_ROWS = 10; // Will make X - 1 rows 
    const int END_ROWS = 2; // must always be 2 to make the bottom 2 rows correctly.
    const int ROW_SIZE = 11; // Will make X - 1 columns.

    List<List<string>> graph = [];    


    // ----------------------------------------------------------------------------------------------------------------------


    public void Populate(int x, int y)
    // A method that is responsible for creating all the graph "cells"
    {
        // Reset the contents of the graph - this will ensure we don't get repeat entries.
        graph.Clear();

        // Populate the graph - we stop at 0, not - 1 as we dont want to draw x = 0 as its own row. 
        for (int i = START_ROWS; i > 0; i--)
        {
            // Create the initial list for each row
            List<string> row = [];

            // Add the initial entry. Add the X instead of a number if we are aiming for X = 0 
            if (x == 0 && i == y)
            {
                row.Add("  X");
            }
            // Remove the spacing from the X if number has 2 digits.
            else if (i >= 10)
            {
                row.Add($"{i}|");
            }
            // Add spacing if we are dealing with single digit numbers.
            else if (i < 10)
            {
                row.Add($"{i} |");
            }

            // Add the "Cells" to the row
            for (int j = 0; j < START_ROWS; j++)
            {
                if (i == y && j == x && x > 0)
                {
                    row.Add("X ");
                }
                else
                {
                    row.Add($"  ");
                }
            }
            // Add the completed row to the class variable
            graph.Add(row);
        }

        // Add the final 2 rows to the graph 
        for (int j = 0; j < END_ROWS; j++)
        {
            // Create the list which will hold the "cells"
            List<string> row = ["  "];

            // Add a character depending on the row we are on.
            for (int i = 0; i < ROW_SIZE; i++)
            {
                if (j == 0)
                {
                    // Draw Y = 0
                    if (y == 0 && i == x)
                    {
                        row.Add("X-");
                    }
                    // Else just draw a line.
                    else
                    {
                        row.Add("--");
                    }
                }
                else
                {
                    row.Add($"{i} ");
                }
            }
            // Add the row to our class variable
            graph.Add(row);
        }
    }


    // ----------------------------------------------------------------------------------------------------------------------


    public void Print_graph()
    // A method that prints the graph to the user
    {
        foreach (List<string> row in graph)
        {
            Console.WriteLine();
            foreach (string cell in row)
            {
                // Highlight the X on the grid. 
                if (cell == "X " || cell == "X-" || cell == "  X")
                {
                    Console.Write(cell, Console.ForegroundColor = ConsoleColor.Red);
                }
                else
                {
                    // Print Each cell and ensure the color is white.
                    Console.Write(cell, Console.ForegroundColor = ConsoleColor.White);
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
