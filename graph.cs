class Graph
{

    List<List<string>> graph = [];    


    // ----------------------------------------------------------------------------------------------------------------------


    public void Populate(int x, int y)
        // A method that is responsible for creating all the graph "cells"
    {
        // Reset the contents of the graph - this will ensure we don't get repeat entries.
        graph.Clear();

        // Populate the graph
        for (int i = 10; i > -1; i--)           
        {
            // Create the initial list for each row
            List<string> row = [];
            
            // Add the initial entry 
            if (i == 10)
            {
                row.Add($"{i}|");
            }
            else
            {
                row.Add($"{i} |");
            }

            // Add the "Cells" to the row
            for (int j = 0; j < 11; j++)
            {
                if (i == y && j == x)
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
        for (int j = 0; j < 2; j++)
        {
            // Create the list which will hold the "cells"
            List<string> row = ["  "];

            // Add a character depending on the row we are on.
            for (int i = 0; i < 11; i++)
            {
                if (j == 0)
                {
                    row.Add("--");
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
                // Print Each cell and ensure the color is white (we change it in other parts of the program).
                Console.Write(cell, Console.ForegroundColor = ConsoleColor.White);
            }
        } 
        Console.WriteLine();
        Console.WriteLine();
    }
}