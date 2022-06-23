// See https://aka.ms/new-console-template for more information
using Bowling2;

Console.WriteLine("Game starts");
Console.WriteLine("Please enter the number of Players");
List<Player> playerList = new List<Player>();
int noOfPlayer = Convert.ToInt16(Console.ReadLine());
while (noOfPlayer > 0)
{
    noOfPlayer = StorePlayer(playerList, noOfPlayer);
}

for (int round = 1; round< 11; round++)
{
    Console.WriteLine($"Round {round}:");
    foreach (Player player in playerList)
    {
        if (round < 10)
        {
            Roll(player);
        }
        else
        {
            BonusRoll(player);
            var calculatedScoreList = CalculateScore(player.scores);
            populateResult(player,calculatedScoreList);
        }
    }
}

List<int> CalculateScore(List<Tuple<string,int,int>> scores)
{
    var reverseList = Enumerable.Reverse(scores);
    int nextTwoframes = 0;
    int nextframe = 0;
    int record = 0;
    List<int> result = new List<int>();
    foreach (var score in reverseList)
    {
            if (score.Item1.Contains("nextTwoframes"))
            {
                int newRecord=Convert.ToInt32(score.Item1.Replace("+nextTwoframes", ""));
                record = newRecord + nextTwoframes;
            }
            else if (score.Item1.Contains("nextframe"))
            {
            int newRecord= Convert.ToInt32(score.Item1.Replace("+nextframe", ""));
            record =Convert.ToInt16(newRecord) + nextframe;
            }
            else
            {
                record =Convert.ToInt32(score.Item1);
            }
        
        nextframe = score.Item2;
        nextTwoframes = score.Item3;
        result.Add(record);
    }
    return result;
}
void BonusRoll(Player player)
{
        Console.WriteLine($"{player.name}:");
        Console.WriteLine("Please enter your score for Turn 1");
        int score1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter your score for Turn 2");
        int score2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter your score for Turn 3");
        int score3 = Convert.ToInt32(Console.ReadLine());
        int nextTwoframes = score1 + score2;
        int nextframe = score1;
        string totalScore = (score1 + score2 + score3).ToString();
        if (score1 == 10)
        {
            totalScore = (10 + score2 +score3).ToString();
        }
        if (score2 == 10)
        {
            totalScore = (10 + score3).ToString();
        }
        if (score3 == 10)
        {
            totalScore = "10";
        }
        if (score1 < 10 && score1 + score2 == 10)
        {
            totalScore = (10 + score3).ToString();
        }
        if(score1 == 10 && score2 + score3 == 10)
        {
        totalScore ="10" ;
        }
        Tuple<string, int, int> scoreList = new Tuple<string, int, int>(totalScore, nextframe, nextTwoframes);
        player.scores.Add(scoreList);
}

static void Roll(Player player)
{
        Console.WriteLine($"{player.name}:");
        Console.WriteLine("Please enter your score for Turn 1");
        int score1 = Convert.ToInt32(Console.ReadLine());
        int score2 = 0;
        if (score1 < 10)
        {
            Console.WriteLine("Please enter your score for Turn 2");
            score2 = Convert.ToInt32(Console.ReadLine());
        }
        int nextTwoframes = score1+score2;
        int nextframe = score1;
        string totalScore = (score1 + score2 ).ToString();
        if (score1 == 10)
        {
            totalScore = 10 +"+"+ "nextTwoframes";
        }
        if (score1 < 10 && score1 + score2 == 10)
        {
            totalScore = 10 + "+" + "nextframe";
        }
    Tuple<string, int, int> scoreList = new Tuple<string, int, int>(totalScore, nextframe, nextTwoframes);
    player.scores.Add(scoreList);  
}

static int StorePlayer(List<Player> playerList, int noOfPlayer)
{
    Console.WriteLine($"Player {noOfPlayer}, please enter your name");
    var player = new Player();
    player.name = Console.ReadLine();
    playerList.Add(player);
    noOfPlayer--;
    return noOfPlayer;
}

static void populateResult(Player player, List<int> calculatedScoreList)
{
    int i = 0;
    Console.WriteLine($"{player} result:");
    foreach (var score in calculatedScoreList)
    {
        i++;

        Console.WriteLine($"Round {i} :{score}");
    }
}