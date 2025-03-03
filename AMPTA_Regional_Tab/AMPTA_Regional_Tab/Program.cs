// get the date from the computer, create pi and delta as strings
// if year of the date is odd
// then if it is after december but before september pi's name is plantiff
// else pi's name is prosecution
// else
// then if it is after december but before september pi's name is prosecution
// else pi's name is plantiff
// else {{ie the date is even}} the above but swap plantiff and prosecution

// create a team object that stores the following properties: a string name {{get;}}, an int number {{get;}}, string school, string lastSide, string list of previous judges, a double pointDiff {{get; set;}} = 0, a double balots {{get; set;}} = 0, and a double cs {{get; set;}}=0
// a default constructor of team objects that takes a string name, int number, and string school

// create a judge object that stores the following as properties: a string name, a string schoolFrom, an int rounds Judged
// a default constructor for judge that takes a string name and a string schoolFrom

// Get how many teams are in attendance store in a var
// calulate the number of bids from teams in attendance: 
// have a var roomsNeeded that is teams in attendace/2
// make a list of team objects and a list of judge objects and a string list of rooms
// For however many teams are in attendance: ask for team name, number, and school. Then create a new team with that data and add it to the list of teams.
// Ask how many judges there are, then for howeevr many judges there are ask for name and school. Then create a new judge object with that data andadd it to judge list.
// For roomsNeeded, ask for the name of the room add to room list

// the first round is random
// however two teams from the same school should not be on the same side(delta / pi) if possible
// two teams from the same school should never play each other ever
// list like the following: Room: , P: team.name, D: team.name

// hold until the first round finishes with a prompt
// for teams in attendance, ask for the result of a balot 
// when asking for the results of a balot ask for two team codes (check to make sure they match a round one pairing, if they dont pop a message saying that and have them re-enter), ask of a char p or d or T representing is plantiff/prossecution or defence or a tie won the balot and an int point differential
// set the winning teams balots to its balots + 1 (in a tie add 0.5 to both), same for its point diff execpt add the point diff instead of 1,  
// following this make two new lists one ranking all the p teams and one ranking all the d teams:
/*
 * EXAMPLE: Ranking, Team Number, # of Ballots Won, Point Differential
P1, 1030, 2, +40 D1, 1298, 2, +38
P2, 1401, 2, +30 D2, 1100, 2, +38
P3, 1582, 2, +5 D3, 1058, 1.5, +2
P4, 1282, 2, -5 D4, 1287, 1, +25
…and so on.
 */
// if two teams have exactly the same ballots won and point diff break the tie with a coin flip (ie roll 1 or 2 and give the 1 the higher seed)

// if round one is plantiff / prosecution then round two must be defence
// if round three is plantiff / procecution then round four must be defence
// so pair P1 with D1 ect

// hold until the second round finishes with a prompt
// after round 2 do the same as after round 1 but this time also increment team cs (team cs is intended to be the total number of balots won by the teams your facing totaled)

/*
 * Round 3 is not side constrained. As a result, the entire field is ranked R1 through
   Rn regardless of the side the team played in Round 2. tie break with larger cs, then larger point, then coinflip.
*/

// pair r1 with r2 ect then print them out just like round two
// remember still no teams of the same school should ever hit eachother
// print out the rooms and pairing as before
// prompt to hold until round three finishes
// get the results from round 3 and properly change all the teams information as it goes

// round 4 works a little differently, create two lists of teams called PrimaryBracket and SecondaryBracket
/*
 * Step 1: Rank the Teams
Rank all teams as P1 to P___ (Plaintiff) and D1 to D___ (Defense) based on their performance.

Use Combined Strength (CS) to rank teams after considering ballots won and point differential.

Step 2: Divide Teams into Brackets
Divide teams into two groups: Primary Bracket (teams still competing for bids) and Secondary Bracket (teams unlikely to advance or already guaranteed to advance).

2a. Determine the "First Out" Record
Find out how many bids are available at your tournament (e.g., 5, 6, or 7 bids).

The "First Out" record is the record of the team just below the cutoff for bids. For example:

If there are 5 bids, the "First Out" record is the 6th-best record.

If there are 6 bids, the "First Out" record is the 7th-best record.

2b. Assign Teams to Brackets
Move to the Secondary Bracket:

Teams with 2.5 or more wins above the "First Out" record.

Teams with 2.0 or more wins below the "First Out" record.

Adjust for Even Brackets:

If the brackets are uneven, move the lowest-ranked team from the Primary Bracket to the Secondary Bracket.

Exception (Caveat): Do not move a team if they are tied or within 1 win of the "Last In" record (the record of the team in the last bid spot).

If the caveat applies, move the highest-ranked team from the Secondary Bracket back to the Primary Bracket instead.

 */

// pair and print room assignments for round 4

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Get the current date
        DateTime currentDate = DateTime.Now;
        int year = currentDate.Year;
        int month = currentDate.Month;

        // Determine the side names based on the year and month
        string piName, deltaName;
        if (year % 2 == 1) // Odd year
        {
            if (month > 12 || month < 9) // After December or before September
            {
                piName = "Plantiff";
                deltaName = "Defence";
            }
            else
            {
                piName = "Prosecution";
                deltaName = "Defence";
            }
        }
        else // Even year
        {
            if (month > 12 || month < 9) // After December or before September
            {
                piName = "Prosecution";
                deltaName = "Defence";
            }
            else
            {
                piName = "Plantiff";
                deltaName = "Defence";
            }
        }

        // Create lists to store teams, judges, and rooms
        List<Team> teams = new List<Team>();
        List<Judge> judges = new List<Judge>();
        List<string> rooms = new List<string>();

        // Get the number of teams in attendance
        Console.Write("Enter the number of teams: ");
        int numTeams = int.Parse(Console.ReadLine());

        // Calculate the number of rooms needed
        int roomsNeeded = numTeams / 2;

        // Input team details
        for (int i = 0; i < numTeams; i++)
        {
            Console.Write($"Enter team {i + 1} name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter team {i + 1} number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write($"Enter team {i + 1} school: ");
            string school = Console.ReadLine();

            teams.Add(new Team(name, number, school));
        }

        /*
        // Input judge details
        Console.Write("Enter the number of judges: ");
        int numJudges = int.Parse(Console.ReadLine());
        for (int i = 0; i < numJudges; i++)
        {
            Console.Write($"Enter judge {i + 1} name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter judge {i + 1} school: ");
            string school = Console.ReadLine();

            judges.Add(new Judge(name, school));
        }
        */

        // Input room names
        for (int i = 0; i < roomsNeeded; i++)
        {
            Console.Write($"Enter room {i + 1} name: ");
            rooms.Add(Console.ReadLine());
        }

        // Randomly pair teams for the first round
        Random random = new Random();
        List<Team> shuffledTeams = teams.OrderBy(t => random.Next()).ToList();

        // Ensure no two teams from the same school are paired
        List<(Team, Team)> pairings = new List<(Team, Team)>();
        for (int i = 0; i < shuffledTeams.Count; i += 2)
        {
            Team team1 = shuffledTeams[i];
            Team team2 = shuffledTeams[i + 1];

            // If teams are from the same school, swap team2 with the next team
            if (team1.School == team2.School)
            {
                for (int j = i + 2; j < shuffledTeams.Count; j++)
                {
                    if (shuffledTeams[j].School != team1.School)
                    {
                        Team temp = team2;
                        team2 = shuffledTeams[j];
                        shuffledTeams[j] = temp;
                        break;
                    }
                }
            }

            pairings.Add((team1, team2));
        }

        // Print round 1 pairings
        Console.WriteLine("\nRound 1 Pairings:");
        for (int i = 0; i < pairings.Count; i++)
        {
            Console.WriteLine($"Room: {rooms[i]}, {piName}: {pairings[i].Item1.Name}, {deltaName}: {pairings[i].Item2.Name}");
            pairings[i].Item1.LastSide = "P";
            pairings[i].Item2.LastSide = "D";
        }

        // Wait for round 1 to finish
        Console.WriteLine("\nPress Enter to proceed to round 1 results...");
        Console.ReadLine();

        // Input round 1 results
        foreach (var pairing in pairings)
        {
            Console.WriteLine($"Enter results for {pairing.Item1.Name} {pairing.Item1.Number} vs {pairing.Item2.Name} {pairing.Item2.Number}:");

            Console.Write("Enter result (P for Plaintiff/Prosecution, D for Defense, T for Tie): ");
            char result = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            int pointDiff = 0;
            if (result != 'T')
            {
                Console.Write("Enter point differential: ");
                pointDiff = int.Parse(Console.ReadLine());
            }

            // Update team stats
            if (result == 'P')
            {
                pairing.Item1.Balots += 1;
                pairing.Item1.PointDiff += pointDiff;
                pairing.Item2.PointDiff -= pointDiff;
            }
            else if (result == 'D')
            {
                pairing.Item2.Balots += 1;
                pairing.Item2.PointDiff += pointDiff;
                pairing.Item1.PointDiff -= pointDiff;
            }
            else if (result == 'T')
            {
                pairing.Item1.Balots += 0.5;
                pairing.Item2.Balots += 0.5;
            }
        }

        // Rank teams after round 1
        var rankedPTeams = teams
            .Where(t => t.LastSide == "D") // Only teams that were Defense in Round 1
            .OrderByDescending(t => t.Balots)
            .ThenByDescending(t => t.PointDiff)
            .ToList();

        var rankedDTeams = teams
            .Where(t => t.LastSide == "P") // Only teams that were Plaintiff/Prosecution in Round 1
            .OrderByDescending(t => t.Balots)
            .ThenByDescending(t => t.PointDiff)
            .ToList();

        Console.WriteLine("\nRankings after Round 1:");
        Console.WriteLine("Plaintiff/Prosecution Teams:");
        for (int i = 0; i < rankedPTeams.Count; i++)
        {
            Console.WriteLine($"P{i + 1}, {rankedPTeams[i].Number}, {rankedPTeams[i].Balots}, {rankedPTeams[i].PointDiff}");
        }
        Console.WriteLine("\nDefense Teams:");
        for (int i = 0; i < rankedDTeams.Count; i++)
        {
            Console.WriteLine($"D{i + 1}, {rankedDTeams[i].Number}, {rankedDTeams[i].Balots}, {rankedDTeams[i].PointDiff}");
        }

        // Pair teams for round 2
        List<(Team, Team)> round2Pairings = new List<(Team, Team)>();
        for (int i = 0; i < rankedPTeams.Count; i++)
        {
            round2Pairings.Add((rankedPTeams[i], rankedDTeams[i]));
        }

        // Print round 2 pairings
        Console.WriteLine("\nRound 2 Pairings:");
        for (int i = 0; i < round2Pairings.Count; i++)
        {
            Console.WriteLine($"Room: {rooms[i]}, {piName}: {round2Pairings[i].Item1.Name}, {deltaName}: {round2Pairings[i].Item2.Name}");
        }

        // Wait for round 2 to finish
        Console.WriteLine("\nPress Enter to proceed to round 2 results...");
        Console.ReadLine();

        // Input round 2 results
        foreach (var pairing in round2Pairings)
        {
            Console.WriteLine($"Enter results for {pairing.Item1.Name} vs {pairing.Item2.Name}:");

            Console.Write("Enter result (P for Plaintiff/Prosecution, D for Defense, T for Tie): ");
            char result = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            int pointDiff = 0;
            if (result != 'T')
            {
                Console.Write("Enter point differential: ");
                pointDiff = int.Parse(Console.ReadLine());
            }

            // Update team stats
            if (result == 'P')
            {
                pairing.Item1.Balots += 1;
                pairing.Item1.PointDiff += pointDiff;
                pairing.Item2.PointDiff -= pointDiff;
                pairing.Item1.CS += pairing.Item2.Balots;
            }
            else if (result == 'D')
            {
                pairing.Item2.Balots += 1;
                pairing.Item2.PointDiff += pointDiff;
                pairing.Item1.PointDiff -= pointDiff;
                pairing.Item2.CS += pairing.Item1.Balots;
            }
            else if (result == 'T')
            {
                pairing.Item1.Balots += 0.5;
                pairing.Item2.Balots += 0.5;
                pairing.Item1.CS += pairing.Item2.Balots;
                pairing.Item2.CS += pairing.Item1.Balots;
            }
        }

        // Rank teams after round 2
        var rankedTeamsRound2 = teams.OrderByDescending(t => t.Balots).ThenByDescending(t => t.PointDiff).ThenByDescending(t => t.CS).ToList();

        Console.WriteLine("\nRankings after Round 2:");
        for (int i = 0; i < rankedTeamsRound2.Count; i++)
        {
            Console.WriteLine($"R{i + 1}, {rankedTeamsRound2[i].Number}, {rankedTeamsRound2[i].Balots}, {rankedTeamsRound2[i].PointDiff}, {rankedTeamsRound2[i].CS}");
        }

        // Pair teams for round 3
        List<(Team, Team)> round3Pairings = new List<(Team, Team)>();
        for (int i = 0; i < rankedTeamsRound2.Count; i += 2)
        {
            round3Pairings.Add((rankedTeamsRound2[i], rankedTeamsRound2[i + 1]));
        }

        // Print round 3 pairings
        Console.WriteLine("\nRound 3 Pairings:");
        for (int i = 0; i < round3Pairings.Count; i++)
        {
            Console.WriteLine($"Room: {rooms[i]}, Team 1: {round3Pairings[i].Item1.Name}, Team 2: {round3Pairings[i].Item2.Name}");
        }

        // Wait for round 3 to finish
        Console.WriteLine("\nPress Enter to proceed to round 3 results...");
        Console.ReadLine();

        // Input round 3 results
        foreach (var pairing in round3Pairings)
        {
            Console.WriteLine($"Enter results for {pairing.Item1.Name} vs {pairing.Item2.Name}:");

            Console.Write("Enter result (P for Plaintiff/Prosecution, D for Defense, T for Tie): ");
            char result = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            int pointDiff = 0;
            if (result != 'T')
            {
                Console.Write("Enter point differential: ");
                pointDiff = int.Parse(Console.ReadLine());
            }

            // Update team stats
            if (result == 'P')
            {
                pairing.Item1.Balots += 1;
                pairing.Item1.PointDiff += pointDiff;
                pairing.Item2.PointDiff -= pointDiff;
                pairing.Item1.CS += pairing.Item2.Balots;
            }
            else if (result == 'D')
            {
                pairing.Item2.Balots += 1;
                pairing.Item2.PointDiff += pointDiff;
                pairing.Item1.PointDiff -= pointDiff;
                pairing.Item2.CS += pairing.Item1.Balots;
            }
            else if (result == 'T')
            {
                pairing.Item1.Balots += 0.5;
                pairing.Item2.Balots += 0.5;
                pairing.Item1.CS += pairing.Item2.Balots;
                pairing.Item2.CS += pairing.Item1.Balots;
            }
        }

        // Rank teams after round 3
        var rankedTeamsRound3 = teams.OrderByDescending(t => t.Balots).ThenByDescending(t => t.CS).ThenByDescending(t => t.PointDiff).ToList();

        Console.WriteLine("\nRankings after Round 3:");
        for (int i = 0; i < rankedTeamsRound3.Count; i++)
        {
            Console.WriteLine($"R{i + 1}, {rankedTeamsRound3[i].Number}, {rankedTeamsRound3[i].Balots}, {rankedTeamsRound3[i].PointDiff}, {rankedTeamsRound3[i].CS}");
        }

        // Determine Primary and Secondary Brackets for Round 4
        int numBids = 6; // Example: 6 bids available
        int firstOutIndex = numBids; // Teams below this index are in the Secondary Bracket

        List<Team> primaryBracket = rankedTeamsRound3.Take(firstOutIndex).ToList();
        List<Team> secondaryBracket = rankedTeamsRound3.Skip(firstOutIndex).ToList();

        // Adjust brackets if necessary
        if (primaryBracket.Count % 2 != 0)
        {
            // Move the lowest-ranked team from Primary to Secondary
            Team lowestPrimary = primaryBracket.Last();
            primaryBracket.Remove(lowestPrimary);
            secondaryBracket.Insert(0, lowestPrimary);
        }

        // Pair teams for round 4
        List<(Team, Team)> round4Pairings = new List<(Team, Team)>();
        for (int i = 0; i < primaryBracket.Count; i += 2)
        {
            round4Pairings.Add((primaryBracket[i], primaryBracket[i + 1]));
        }
        for (int i = 0; i < secondaryBracket.Count; i += 2)
        {
            round4Pairings.Add((secondaryBracket[i], secondaryBracket[i + 1]));
        }

        // Print round 4 pairings
        Console.WriteLine("\nRound 4 Pairings:");
        for (int i = 0; i < round4Pairings.Count; i++)
        {
            Console.WriteLine($"Room: {rooms[i]}, Team 1: {round4Pairings[i].Item1.Name}, Team 2: {round4Pairings[i].Item2.Name}");
        }

        // Wait for round 4 to finish
        Console.WriteLine("\nPress Enter to proceed to round 4 results...");
        Console.ReadLine();

        // Input round 4 results
        foreach (var pairing in round4Pairings)
        {
            Console.WriteLine($"Enter results for {pairing.Item1.Name} vs {pairing.Item2.Name}:");

            Console.Write("Enter result (P for Plaintiff/Prosecution, D for Defense, T for Tie): ");
            char result = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            int pointDiff = 0;
            if (result != 'T')
            {
                Console.Write("Enter point differential: ");
                pointDiff = int.Parse(Console.ReadLine());
            }

            // Update team stats
            if (result == 'P')
            {
                pairing.Item1.Balots += 1;
                pairing.Item1.PointDiff += pointDiff;
                pairing.Item2.PointDiff -= pointDiff;
                pairing.Item1.CS += pairing.Item2.Balots;
            }
            else if (result == 'D')
            {
                pairing.Item2.Balots += 1;
                pairing.Item2.PointDiff += pointDiff;
                pairing.Item1.PointDiff -= pointDiff;
                pairing.Item2.CS += pairing.Item1.Balots;
            }
            else if (result == 'T')
            {
                pairing.Item1.Balots += 0.5;
                pairing.Item2.Balots += 0.5;
                pairing.Item1.CS += pairing.Item2.Balots;
                pairing.Item2.CS += pairing.Item1.Balots;
            }
        }

        // Final rankings
        var finalRankings = teams.OrderByDescending(t => t.Balots).ThenByDescending(t => t.CS).ThenByDescending(t => t.PointDiff).ToList();

        Console.WriteLine("\nFinal Rankings:");
        for (int i = 0; i < finalRankings.Count; i++)
        {
            Console.WriteLine($"R{i + 1}, {finalRankings[i].Number}, {finalRankings[i].Balots}, {finalRankings[i].PointDiff}, {finalRankings[i].CS}");
        }
    }
}

class Team
{
    public string Name { get; }
    public int Number { get; }
    public string School { get; }
    public string LastSide { get; set; }
    public List<string> PreviousJudges { get; } = new List<string>();
    public double PointDiff { get; set; } = 0;
    public double Balots { get; set; } = 0;
    public double CS { get; set; } = 0;

    public Team(string name, int number, string school)
    {
        Name = name;
        Number = number;
        School = school;
    }
}

class Judge
{
    public string Name { get; }
    public string SchoolFrom { get; }
    public int RoundsJudged { get; set; } = 0;

    public Judge(string name, string schoolFrom)
    {
        Name = name;
        SchoolFrom = schoolFrom;
    }
}


