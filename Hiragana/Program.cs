Console.OutputEncoding = System.Text.Encoding.UTF8;
string[] hiragana = [
    "  a i u e o", // 0
    "- あいうえお", // 1
    "k かきくけこ", // 2
    "s さしすせそ", // 3
    "t たちつてと", // 4
    "n なにぬねの", // 5
    "h はひふへほ", // 6
    "m まみむめも", // 7
    "y や  ゆ  よ", // 8
    "r らりるれろ", // 9
    "w わ      を", // 10
    "\nDakuten:", // the bool for if they have found anything about dakuten
    "g がぎぐげご", // 12
    "z ざじずぜぞ", // 13
    "d だぢづでど", // 14
    "b ばびぶべぼ", // 15
    "p ぱぴぷぺぽ" // 16
    ];
bool[] found = [true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false];
int current_room = 1;
Main();
void Main()
{
    Console.Clear();
    switch (current_room)
    {
        case 1:
            Console.WriteLine(
                "You find yourself in locked in a room, in front of you is a small piece of paper with a table showing a few symbols.\n" +
                "\n" +
                "The only door in the room is locked with a strange keypad, above it hangs three symbols that reads \"すいか\".\n" +
                "\n" +
                "Looking at the piece of paper and the keypad you understand that you have to enter the above symbols as Latin/Roman letters.\n" +
                "You could try to enter now but you don't see some of the symbols on the table, maybe there's missing parts somewhere in the room.\n" +
                "\n" +
                "Press G to guess\n" +
                "Press T to show the table\n" +
                "Press S to search the room"
                );
            break;
        case 2:
            Console.WriteLine("ROOM 2 TEXT");
            break;
        case 3:
            Console.WriteLine("ROOM 3 TEXT");
            break;
        default:
            Console.WriteLine(
                "ERROR, INVALID ROOM\n" +
                "\n" +
                "How did you even do this?"
                );
            break;
    }
    
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
    for (int i = 0; i < 11; i++)
    {
        Console.WriteLine(found[i] ? hiragana[i]:"");
    }
    if (found[11]) //This is so that it won't show the dakuten before the player has found out about it
    {
        for (int i = 11; i < hiragana.Length; i++)
        {
            Console.WriteLine(found[i] ? hiragana[i]:"");
        }
    }
    Console.ReadLine();
    Main();
}

void Guess()
{
    Console.Clear();
    Console.Write(
        "すいか\n" +
        "Please enter your guess: "
        );
    string guess = Console.ReadLine();
    Console.Clear();
    if (guess.ToLower() == "suika")
    {
        Console.WriteLine(
            "The door opens and you step into the next room.\n" +
            "Press enter to continue"
            );
        Console.ReadLine();
        current_room = 2;
        (found[2], found[3]) = (true, true);
        (found[12], found[13]) = (true, true);
    }
    else
    {
        Console.WriteLine(
            "The lock does not open, guess was incorrect.\n" +
            "Press enter to go back"
            );
        Console.ReadLine();
    }
    Main();
}

void Search()
{
    Console.Clear();
    Console.WriteLine(
        "You look around the room, you see a drawer, an unlocked safe and an envelope.\n" +
        "\n" +
        "Which do you search first?\n" +
        "\n" +
        "Press D to open the drawer\n" +
        "Press S to open the safe\n" +
        "Press E to read the envelope"
        );
    ConsoleKeyInfo search = Console.ReadKey();
    Console.Clear();
    switch (search.Key)
    {
        case ConsoleKey.D:
            // find
            switch (current_room)
            {
                case 1:
                    Console.WriteLine(
                        "You open the drawer, inside is a bunch of old books, pencils and other junk.\n" +
                        "Searching around some more you find a small piece of paper that seems to match up with your other paper, you take it.\n" +
                        "\n" +
                        "Press enter to continue"
                        );
                    found[3] = true;
                    found[13] = true;
                    break;
                case 2:
                    // text
                    // found
                    break;
                case 3:
                    //text
                    //found
                    break;
            }
            Console.ReadLine();
            break;
        case ConsoleKey.S:
            // find
            switch (current_room)
            {
                case 1:
                    Console.WriteLine(
                        "You open the safe, inside you find outdated currency and shredded documents.\n" +
                        "You also find a small piece of paper that matches up with your other paper and you take it.\n" +
                        "\n" +
                        "Press enter to continue"
                        );
                    found[2] = true;
                    found[12] = true;
                    break;
                case 2:
                    // text
                    // found
                    break;
                case 3:
                    //text
                    //found
                    break;
            }
            Console.ReadLine();
            break;
        case ConsoleKey.E:
            // read
            switch (current_room)
            {
                case 1:
                    Console.WriteLine(
                        "You open the envelope, inside is a a piece of paper with some text, it reads:\n" +
                        "\n" +
                        "Hello, if you're reading this then it means that you've finally woken up.\n" +
                        "You have always wanted to learn how to read but you never really bothered to start, so I knocked you out and locked you in here.\n" +
                        "If you want to escape you'll have to finally learn some, I've scattered a table of hiragana around these rooms for you to learn.\n" +
                        "\n" +
                        "Hiragana has more than just the base characters you have found so far.\n" +
                        "There's a thing called \"dakuten\" (and \"handakuten\") which is added onto the already existing hiragana to make slightly different sounds.\n" +
                        "They have added to your table now\n" +
                        "Press enter to continue"
                        );
                    found[11] = true;
                    break;
                case 2:
                    // text
                    break;
                case 3:
                    //text
                    break;
            }
            Console.ReadLine();
            break;
    }
    Main();
}