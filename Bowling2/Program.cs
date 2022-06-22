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
            //CalculateScore(player.scores);
        }
    }
}

//int CalculateScore(List<string> scores)
//{
//    var reverseList = Enumerable.Reverse(scores);
//    bool startList = true;
//    foreach (var score in reverseList)
//    {
//        if (startList)
//        {

//        }
//        else
//        {
//            if (score.Contains("nextTwoframes"))
//            {

//            }
//            if (score.Contains("nextframe"))
//            {

//            }
//        }
//    }
//}
void BonusRoll(Player player)
{
        Console.WriteLine($"{player.name}:");
        Console.WriteLine("Please enter your score for Turn 1");
        int score1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter your score for Turn 2");
        int score2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter your score for Turn 3");
        int score3 = Convert.ToInt32(Console.ReadLine());
        string nextTwoframes = "nextTwoframes";
        string nextframe = "nextframe";
        string totalScore = (score1 + score2 + score3).ToString();
        if (score1 == 10)
        {
            totalScore = 10 + nextTwoframes;
        }
        if (score2 == 10)
        {
            totalScore = 10 + nextTwoframes;
        }
        if (score3 == 10)
        {
            totalScore = 10 + nextTwoframes;
        }
        if (score1 < 10 && score1 + score2 == 10)
        {
            totalScore = 10 + nextframe;
        }
        if(score1 == 10 && score2 + score3 == 10)
        {
        totalScore = 10 + nextframe;
        }
        player.scores.Add(totalScore);
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
        string nextTwoframes = "nextTwoframes";
        string nextframe = "nextframe";
        string totalScore = (score1 + score2 ).ToString();
        if (score1 == 10)
        {
            totalScore = 10 + nextTwoframes;
        }
        if (score1 < 10 && score1 + score2 == 10)
        {
            totalScore = 10 + nextframe;
        }
        player.scores.Add(totalScore);  
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