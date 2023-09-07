using System;

namespace TheGame
{

    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static bool gameOver = false;

        public static bool IsBoardFull()
        {
            bool full = true;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O') full = false;
            }
            return full;
        }

        static void Main(string[] args)
        {
            int player = 1; // 1 - X, 2 - O
            int choice = 5;
            bool validInput;

            do
            {
                Console.Clear();
                Console.WriteLine("Крестики-нолики\n");

                Console.WriteLine("Игрок 1: X и Игрок 2: O");
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Ходит игрок 2 ( O )");
                }
                else
                {
                    Console.WriteLine("Ходит игрок 1 ( X )");
                }
                Console.WriteLine("\n");

                DrawBoard();

                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Выберите пустую позицию на доске (1-9): ");
                    validInput = int.TryParse(Console.ReadLine(), out choice);

                    if (!validInput || choice < 1 || choice > 9)
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                        validInput = false;
                    }
                    else if (board[choice - 1] != ' ')
                    {
                        Console.WriteLine("Позиция уже занята. Попробуйте еще раз.");
                        validInput = false;
                    }
                }

                if (player % 2 == 0)
                {
                    board[choice - 1] = 'O';
                    player++;
                }
                else
                {
                    board[choice - 1] = 'X';
                    player++;
                }

                if (CheckWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Игрок " + (player % 2 + 1) + " победил!");
                    gameOver = true;
                }
                else if (IsBoardFull())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    gameOver = true;
                }

            } while (!gameOver);

            Console.ReadLine();
        }

        static void DrawBoard()
        {
            Console.WriteLine(" _________________  ");
            Console.WriteLine("|     |     |      |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}", board[0], board[1], board[2] + "   |");
            Console.WriteLine("|_____|_____|_____ |");
            Console.WriteLine("|     |     |      |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}", board[3], board[4], board[5] + "   |");
            Console.WriteLine("|_____|_____|_____ |");
            Console.WriteLine("|     |     |      |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}", board[6], board[7], board[8] + "   |");
            Console.WriteLine("|     |     |      |");
            Console.WriteLine(" -----------------  ");
        }

        static bool CheckWin()
        {
            if (board[0] == board[1] && board[1] == board[2] && board[0] != ' ')
            {
                return true;
            }
            else if (board[3] == board[4] && board[4] == board[5] && board[3] != ' ')
            {
                return true;
            }
            else if (board[6] == board[7] && board[7] == board[8] && board[6] != ' ')
            {
                return true;
            }
            else if (board[0] == board[3] && board[3] == board[6] && board[0] != ' ')
            {
                return true;
            }
            else if (board[1] == board[4] && board[4] == board[7] && board[1] != ' ')
            {
                return true;
            }
            else if (board[2] == board[5] && board[5] == board[8] && board[2] != ' ')
            {
                return true;
            }
            else if (board[0] == board[4] && board[4] == board[8] && board[0] != ' ')
            {
                return true;
            }
            else if (board[2] == board[4] && board[4] == board[6] && board[2] != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}