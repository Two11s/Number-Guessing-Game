Random random = new Random(); // Create an instance of the Random class to generate random numbers
int numberToGuess = random.Next(1, 101); // Generate a random number between 1 and 100 (1 inclusive, 101 exclusive)
int attempts = 0; // Initialize the attempts counter

WriteColoredMessage("Welcome to the number guessing game!", ConsoleColor.Cyan);
WriteColoredMessage("I have selected a random number between 1 and 100. Can you guess it?", ConsoleColor.Cyan);

while (true) // Start an infinite loop to keep the game running until the user decides to end it
{
    Console.Write("Enter your guess: ");
    string? input = Console.ReadLine(); // Read the user's input

    if (input == null) // Check if the input is null (user pressed Enter without typing anything)
    {
        WriteColoredMessage("Input cannot be empty. Please enter a valid number.", ConsoleColor.Yellow);
        continue; // Skip the rest of the loop and prompt the user again
    }

    if (input.ToLower().Trim() == "end") // Check if the user wants to end the game
    {
        WriteColoredMessage("Game ended. Thanks for playing!", ConsoleColor.Yellow);
        break; // Exit the loop and end the game
    }

    if (int.TryParse(input, out int guess)) // Try to parse the input to an integer, out keyword is used to assign the parsed value to the guess variable
    {
        if (guess < 1 || guess > 100) // Check if the number to guess is out of the valid range
        {
            WriteColoredMessage("The number you entered is out of the valid range. Please enter a number between 1 and 100.", ConsoleColor.Yellow);
            continue; // Skip the rest of the loop and prompt the user again
        }

        attempts++; // Increment the attempts counter each time the user makes a guess

        if (guess < numberToGuess)
        {
            WriteColoredMessage("Too low! Try again.", ConsoleColor.Blue);
        }
        else if (guess > numberToGuess)
        {
            WriteColoredMessage("Too high! Try again.", ConsoleColor.Red);
        }
        else
        {
            WriteColoredMessage($"Congratulations! You guessed the number! You took {attempts} attempts.", ConsoleColor.Green);
            WriteColoredMessage("Type YES to play again.", ConsoleColor.Cyan);
            string? playAgain = Console.ReadLine(); // Read the user's input for playing again, "?" is used to indicate that the input can be null
            if (playAgain != null && playAgain.ToLower().Trim() == "yes") // Check if the user wants to play again
            {
                numberToGuess = random.Next(1, 101); // Generate a new random number
                attempts = 0; // Reset the attempts counter
                WriteColoredMessage("I have selected a new random number between 1 and 100. Can you guess it?", ConsoleColor.Cyan);
            }
            else
            {
                WriteColoredMessage("Thanks for playing! Goodbye!", ConsoleColor.Yellow);
                break; // Exit the loop and end the game
            }
        }
    }
    else
        {
            WriteColoredMessage("Invalid input. Please enter a valid number.", ConsoleColor.Yellow);
        }
    }

// Helper method to write colored messages to the console
void WriteColoredMessage(string message, ConsoleColor color) // Defines a helper method called WriteColoredMessage that takes a message and a color as parameters and writes the message to the console in the specified color
{
    Console.ForegroundColor = color; // Sets the console color to the specified color
    Console.WriteLine(message); // Writes the message to the console
    Console.ResetColor(); // Resets the console color to default after writing the message
}