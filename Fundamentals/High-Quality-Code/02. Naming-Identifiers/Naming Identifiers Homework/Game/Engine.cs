using System;
using System.Collections.Generic;

namespace _3.Game
{
    public class Engine
    {
        private const int MaxMovies = 35;

        private string command;
        private char[,] playground = SetPlayground();
        private char[,] bombs = SetBombs();
        private readonly List<Ranking> topFiveRanking = new List<Ranking>(6);
        private int counter = 0;
        private int row = 0;
        private int column = 0;
        private bool start = true;

        public void Run()
        {
            do
            {
                if (start)
                {
                    Console.WriteLine(
                        "Let's play \"Minesweeper\"!!! \n" +
                        "Try to find the non minesweeper fields. \n" +
                        "You can choose several commands while playing: \n" +
                        "'top' - gives you current ranking; \n" +
                        "'restart' - leads you to a new game; \n" +
                        "'exit' - exit the game. \n" +
                        "Have fun :)"
                        );
                    CreatePlayground(playground);
                    start = false;
                }

                Console.Write("Next turn: ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row)
                        && int.TryParse(command[2].ToString(), out column)
                        && row <= playground.GetLength(0)
                        && column <= playground.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GetRanking(topFiveRanking);
                        break;
                    case "restart":
                        playground = SetPlayground();
                        bombs = SetBombs();
                        CreatePlayground(playground);
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        MakeAMove();
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Byeeeeeeeee.");
            Console.Read();
        }

        private void MakeAMove()
        {
            if (bombs[row, column] != '*')
            {
                if (bombs[row, column] == '-')
                {
                    NextTurn(playground, bombs, row, column);
                    counter++;
                }

                if (MaxMovies == counter)
                {
                    Console.WriteLine("\nBRAVOOOS! You opened 35 cells without a drop of blood!!!");
                    CreatePlayground(bombs);

                    Console.Write("Your name: ");
                    var name = Console.ReadLine();

                    var points = new Ranking(name, counter);

                    topFiveRanking.Add(points);
                    GetRanking(topFiveRanking);
                    playground = SetPlayground();
                    bombs = SetBombs();
                    counter = 0;
                    start = true;
                }
                else
                {
                    CreatePlayground(playground);
                }
            }
            else
            {
                CreatePlayground(bombs);
                Console.Write("\nHrrrrrr! You end up with {0} points. " + "What is your nickname: ", counter);

                var nickname = Console.ReadLine();
                var ranking = new Ranking(nickname, counter);

                if (topFiveRanking.Count < 5)
                {
                    topFiveRanking.Add(ranking);
                }
                else
                {
                    for (int i = 0; i < topFiveRanking.Count; i++)
                    {
                        if (topFiveRanking[i].Points < ranking.Points)
                        {
                            topFiveRanking.Insert(i, ranking);
                            topFiveRanking.RemoveAt(topFiveRanking.Count - 1);
                            break;
                        }
                    }
                }

                topFiveRanking.Sort((r1, r2) => string.Compare(r2.Name, r1.Name, StringComparison.Ordinal));
                topFiveRanking.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));
                GetRanking(topFiveRanking);

                playground = SetPlayground();
                bombs = SetBombs();
                counter = 0;
                start = true;
            }
        }

        private static void GetRanking(IReadOnlyList<Ranking> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No participants!\n");
            }
        }

        private static void NextTurn(char[,] playground, char[,] bombs, int row, int column)
        {
            var numberOfBombs = RiskOfBombs(bombs, row, column);
            bombs[row, column] = numberOfBombs;
            playground[row, column] = numberOfBombs;
        }

        private static void CreatePlayground(char[,] playground)
        {
            int playgroundRow = playground.GetLength(0);
            int playgroundColumn = playground.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < playgroundRow; row++)
            {
                Console.Write("{0} | ", row);
                for (int column = 0; column < playgroundColumn; column++)
                {
                    Console.Write($"{playground[row, column]} ");
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] SetPlayground()
        {
            const int playgroundRows = 5;
            const int playgroundColumns = 10;
            var playground = new char[playgroundRows, playgroundColumns];
            for (int i = 0; i < playgroundRows; i++)
            {
                for (int j = 0; j < playgroundColumns; j++)
                {
                    playground[i, j] = '?';
                }
            }

            return playground;
        }

        private static char[,] SetBombs()
        {
            const int playgroundRows = 5;
            const int playgroundColumns = 10;
            var populatePlayground = new char[playgroundRows, playgroundColumns];

            for (int i = 0; i < playgroundRows; i++)
            {
                for (int j = 0; j < playgroundColumns; j++)
                {
                    populatePlayground[i, j] = '-';
                }
            }

            var collectBombsPositons = new List<int>();
            while (collectBombsPositons.Count < 15)
            {
                var random = new Random();
                var getBombPositon = random.Next(50);
                if (!collectBombsPositons.Contains(getBombPositon))
                {
                    collectBombsPositons.Add(getBombPositon);
                }
            }

            foreach (var bombPositon in collectBombsPositons)
            {
                var row = bombPositon / playgroundColumns;
                var column = bombPositon % playgroundColumns;
                if (column == 0 && bombPositon != 0)
                {
                    row--;
                    column = playgroundColumns;
                }
                else
                {
                    column++;
                }

                populatePlayground[row, column - 1] = '*';
            }

            return populatePlayground;
        }

        private static char RiskOfBombs(char[,] playgroundSize, int currentRow, int currentColumn)
        {
            var riskOfBombs = 0;
            var rows = playgroundSize.GetLength(0);
            var columns = playgroundSize.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (playgroundSize[currentRow - 1, currentColumn] == '*')
                {
                    riskOfBombs++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (playgroundSize[currentRow + 1, currentColumn] == '*')
                {
                    riskOfBombs++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (playgroundSize[currentRow, currentColumn - 1] == '*')
                {
                    riskOfBombs++;
                }
            }

            if (currentColumn + 1 < columns)
            {
                if (playgroundSize[currentRow, currentColumn + 1] == '*')
                {
                    riskOfBombs++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (playgroundSize[currentRow - 1, currentColumn - 1] == '*')
                {
                    riskOfBombs++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < columns))
            {
                if (playgroundSize[currentRow - 1, currentColumn + 1] == '*')
                {
                    riskOfBombs++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn - 1 >= 0))
            {
                if (playgroundSize[currentRow + 1, currentColumn - 1] == '*')
                {
                    riskOfBombs++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn + 1 < columns))
            {
                if (playgroundSize[currentRow + 1, currentColumn + 1] == '*')
                {
                    riskOfBombs++;
                }
            }

            return char.Parse(riskOfBombs.ToString());
        }
    }
}
