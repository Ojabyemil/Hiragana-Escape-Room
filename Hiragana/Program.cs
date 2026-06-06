Console.OutputEncoding = System.Text.Encoding.UTF8;
string[] hiragana = [
    "  a i u e o", 
    "- あいうえお", 
    "k かきくけこ", 
    "s さしすせそ", 
    "t たちつてと", 
    "n なにぬねの", 
    "h はひふへほ", 
    "m まみむめも", 
    "y や  ゆ  よ", 
    "r らりるれろ", 
    "w わ      を"
    ];
bool[] found = [true, true, false, false, false, false, false, false, false, false, false];
Main();
void Main()
{
    Console.Clear();
    Console.WriteLine("You find yourself in locked in a room, in front of you is a small piece of paper with a table showing a few symbols.\n\nThe only door in the room is locked with a strange keypad, above it hangs three symbols that reads \"すいか\"\n\nLooking at the piece of paper and the keypad you understand that you have to enter the above symbols as Latin/Roman letters. You could try to enter now but you don't see some of the symbols on the table, maybe there's missing parts somewhere in the room.\n\nPress G to guess\nPress T to show the table\nPress S to search the room");
    ConsoleKeyInfo input = Console.ReadKey();
    switch (input.Key)
    {
        case ConsoleKey.G:
            Guess();
            break;
        case ConsoleKey.T:
            Table();
            break;
        case ConsoleKey.S:
            Search();
            break;
    }
    Main();
}

void Table()
{
    Console.Clear();
    for (int i = 0; i < hiragana.Length; i++)
    {
        Console.WriteLine(found[i] ? hiragana[i]:"");
    }
    Console.ReadLine();
    Main();
}

void Guess()
{
    Console.Clear();
    Console.Write("すいか\nPlease enter your guess: ");
    string guess = Console.ReadLine();
    Console.Clear();
    if (guess.ToLower() == "suika")
    {
        Console.WriteLine("The door opens and you step into the next room\nPress enter to continue");
        Console.ReadLine();
        // room2();
    }
    else
    {
        Console.WriteLine("The lock does not open, guess was incorrect\nPress enter to go back");
        Console.ReadLine();
        Main();
    }
}

void Search()
{
    Console.Clear();
    Console.WriteLine("You look around the room, you see a drawer, an unlocked safe and an envelope\n\nWhich do you search first?\n\nPress D to open the drawer\nPress S to open the safe\nPress E to read the envelope");
    ConsoleKeyInfo search = Console.ReadKey();
    switch (search.Key)
    {
        case ConsoleKey.D:
            // find
            break;
        case ConsoleKey.S:
            // find
            break;
        case ConsoleKey.E:
            // read
            break;
    }
    Main();
}