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
    "p ぱぴぷぺぽ", // 16
    "\nCombinations:", // the bool for if they have found anything about combinations
    "   や   ゆ   よ",  // 18
    "き きゃ きゅ きょ", // 19
    "し しゃ しゅ しょ", // 20
    "ち ちゃ ちゅ ちょ", // 21
    "に にゃ にゅ にょ", // 22
    "ひ ひゃ ひゅ ひょ", // 23
    "み みゃ みゅ みょ", // 24
    "り りゃ りゅ りょ", // 25
    "ぎ ぎゃ ぎゅ ぎょ", // 26
    "じ じゃ じゅ じょ", // 27
    "び びゃ びゅ びょ", // 28
    "ぴ ぴゃ ぴゅ ぴょ" // 29
    ];
bool[] found = [
    true, // 0
    true, // 1
    false, // 2
    false, // 3
    false, // 4
    false, // 5
    false, // 6
    false, // 7
    false, // 8
    false, // 9
    false, // 10
    false, // dakuten
    false, // 12
    false, // 13
    false, // 14
    false, // 15
    false, // 16
    false, // combinations
    false, // 18
    false, // 19
    false, // 20
    false, // 21
    false, // 22
    false, // 23
    false, // 24
    false, // 25
    false, // 26
    false, // 27
    false, // 28
    false // 29
    ];
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
            Console.WriteLine(
                "You make your way into the next room, the room looks almost identical to the previous room.\n" +
                "\n" +
                "You spot the next door, above it hangs yet another set of symbols that reads \"ありがと\"\n" +
                "\n" +
                "Press G to guess\n" +
                "Press T to show the table\n" +
                "Press S to search the room"
                );
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
        Console.WriteLine(found[i] ? hiragana[i] : "");
    }
    if (found[11]) //This is so that it won't show the dakuten before the player has found out about it
    {
        for (int i = 11; i < 17; i++)
        {
            Console.WriteLine(found[i] ? hiragana[i] : "");
        }
    }
    if (found[17]) //This is so that it won't show the combinations before the player has found out about it
    {
        for (int i = 17; i < hiragana.Length; i++)
        {
            Console.WriteLine(found[i] ? hiragana[i] : "");
        }
    }
    Console.ReadLine();
    Main();
}

void Guess()
{
    Console.Clear();
    switch (current_room)
    {
        case 1:
            Console.Write(
                "すいか\n" +
                "Please enter your guess: "
                );
            break;
        case 2:
            Console.Write(
                "ありがと\n" +
                "Please enter your guess: "
                );
            break;
        case 3:
            Console.Write(
                "HIRAGANA\n" +
                "Please enter your guess: "
                );
            break;
    }
    string guess = Console.ReadLine();
    Console.Clear();
    switch (current_room)
    {
        case 1:
            if (guess.ToLower() == "suika")
            {
                Console.WriteLine(
                    "The door opens and you step into the next room.\n" +
                    "Press enter to continue"
                    );
                Console.ReadLine();
                current_room = 2;
                (found[2], found[3], found[11], found[12], found[13], found[19], found[20]) = (true, true, true, true, true, true, true);
            }
            else
            {
                Console.WriteLine(
                    "The lock does not open, guess was incorrect.\n" +
                    "Press enter to go back"
                    );
                Console.ReadLine();
            }
            break;
        case 2:
            if (guess.ToLower() == "arigato")
            {
                Console.WriteLine(
                    "The door opens and you step into the next room.\n" +
                    "Press enter to continue"
                    );
                Console.ReadLine();
                current_room = 3;
                (found[17], found[18]) = (true, true);
                // (found[2], found[3], found[12], found[13]) = (true, true, true, true);
            }
            else
            {
                Console.WriteLine(
                    "The lock does not open, guess was incorrect.\n" +
                    "Press enter to go back"
                    );
                Console.ReadLine();
            }
            break;
        case 3:
            if (guess.ToLower() == "xxxxx")
            {
                Console.WriteLine(
                    "The door opens and you step into the next room.\n" +
                    "Press enter to continue"
                    );
                Console.ReadLine();
                current_room = 4;
                // (found[2], found[3], found[12], found[13]) = (true, true, true, true);
            }
            else
            {
                Console.WriteLine(
                    "The lock does not open, guess was incorrect.\n" +
                    "Press enter to go back"
                    );
                Console.ReadLine();
            }
            break;
    }
    Main();
}

void Search()
{
    Console.Clear();
    switch (current_room)
    {
        case 1:
            Console.WriteLine(
                "You look around the room, you see a drawer, an unlocked safe and an envelope.\n" +
                "\n" +
                "Which do you search first?\n" +
                "\n" +
                "Press D to open the drawer\n" +
                "Press S to open the safe\n" +
                "Press E to read the envelope"
                );
            break;
        case 2:
            Console.WriteLine(
                "You look around the room, you see a dresser, a locked safe and another envelope.\n" +
                "\n" +
                "Which do you search?\n" +
                "\n" +
                "Press D to search through the dresser\n" +
                "Press S to investigate the safe\n" +
                "Press E to read the envelope"
                );
            break;
        case 3:

            break;
    }
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
                    found[19] = true;
                    break;
                case 2:
                    // text
                    Console.WriteLine(
                        "You look through the dresser, it's mostly empty with a few dusty books lying around.\n" +
                        "You find a small piece of paper with some more symbols on it.\n" +
                        "\n" +
                        "Press enter to continue"
                        );
                    found[4] = true;
                    found[14] = true;
                    found[21] = true;
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
                    found[20] = true;
                    break;
                case 2:
                    // text
                    // add puzzle to unlock the safe
                    found[9] = true;
                    found[25] = true;
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
                        "You open the envelope, inside is a piece of paper with some text, it reads:\n" +
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
                    Console.WriteLine(
                        "You open the envelope, inside is a piece of paper with some text, it reads:\n" +
                        "\n" +
                        "You managed to escape the first room, congrats.\n" +
                        "But you still have a lot more to learn in order to escape.\n" +
                        "\n" +
                        "Hiragana has some special combinations.\n" +
                        "These combinations work by taking characters from the i coloumn and combining those with one of the three y row characters.\n" +
                        "The sound these combinations makes is usually straightforward, you take the vowel of the i column character along with the entire y row character."
                        );
                    (found[17], found[18]) = (true, true);
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