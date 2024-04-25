using Review;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Movie Theater Application\n");

        MovieTheater movieTheater = new();

        // user choice
        int choice;
        do
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\nEnter the choice");
            Console.WriteLine("\n1.Add Movie\n2.Remove Movie\n3.Search Movie by Title\n4.Sort the Movie by Rating\n5.Average Ratings of All Movies\n0.Exit Application\n");
            choice = int.Parse(UserInput());

            switch (choice)
            {
                case 1:
                    // Movie Added 
                    Console.WriteLine("\nAdding the Movie : ");
                    Console.Write("\nEnter the Title of the Movie : ");
                    string addTitle = UserInput();
                    Console.Write("Enter the rating of the Movie : ");
                    double addRating = Double.Parse(UserInput());
                    movieTheater.AddMovie(new Movie(addTitle, addRating));
                    break;
                case 2:
                    // Movie Removed
                    Console.WriteLine("\nRemoving the Movie : ");
                    Console.Write("\nEnter the Title of the Movie : ");
                    string removeTitle = UserInput();
                    Movie? Movie = movieTheater.RemoveMovie(removeTitle);
                    Console.WriteLine($"Removed Movie : {Movie}");
                    break;
                case 3:
                    //Movie Searched
                    Console.WriteLine("\nSearching the Movie : ");
                    Console.Write("\nEnter the Title of the Movie : ");
                    string searchTitle = UserInput();
                    Movie? foundMovie = movieTheater.GetMovieByTitle(searchTitle);
                    if(foundMovie != null)
                        Console.WriteLine("Searched Movie : " + foundMovie);
                    else
                        Console.WriteLine($"{searchTitle} movie is not released in Theater yet");
                    break;
                case 4:
                    // Sorting Descending
                    Console.WriteLine("\nSorting the Movies : ");
                    IEnumerable<Movie> movies = movieTheater.SortByRatingDesc();
                    foreach (Movie movie in movies)
                        Console.WriteLine(movie + " ");
                    break;
                case 5:
                    // Average of Ratings of All movies
                    Console.WriteLine("\nAverage the Ratings Of All the Movies : ");
                    decimal average = movieTheater.GetAverageRatingOFAllMovies();
                    Console.WriteLine(average);
                    break;
                case 0:
                    // Exiting Application
                    Console.WriteLine("\nThank you for Visiting the Application");
                    break;
                default:
                    break;
            }
        }
        while (choice != 0);
    }

    static String UserInput()
    {
        // Accepting user input it can be null as well 
        String? input = Console.ReadLine();

        // Validating for Null or empty input string 
        if (string.IsNullOrEmpty(input))
        {
            throw new NullInputException("Null Value not allowed");
        }
        else
        {
            return input;
        }
    }
}