using System;

namespace TicTacToe_ConsoleApp
{
    class Program
    {
        const int TicTacToe_Rows = 3;
        const int TicTacToe_Cols = 3;
        static char[,] NewBoard() {
            char[,] board = new char[TicTacToe_Rows, TicTacToe_Cols];
            //insert numbers to game board
            int counter = 1;
            for (int i = 0; i < TicTacToe_Rows; i++) {
                for (int j = 0; j < TicTacToe_Cols; j++) {
                    board[i, j] = char.Parse(Convert.ToString(counter));
                    counter++;
                }
            }
            return board;
        }

        //Print board game
        static void PrintBoard(char[,] board) {
            //insert numbers to game board
            for (int i = 0; i < TicTacToe_Rows; i++) {
                Console.WriteLine("       |       |       ");
                for (int j = 0; j < TicTacToe_Cols; j++) {
                    if (j != TicTacToe_Cols - 1) {
                        Console.Write($"   {board[i, j]}   |");
                    }
                    else {
                        Console.Write($"   {board[i, j]}   ");
                    }
                }
                Console.WriteLine();
                if (i != TicTacToe_Rows - 1)
                    Console.WriteLine("_______|_______|_______");
                else
                    Console.WriteLine("       |       |       ");

            }
        }

        //win or lose
        //returns 0 if no one wins
        //returns 1/2 if one of the players wins
        static int Victory(char[,] board) {
            //rows check

            for (int i = 0; i < TicTacToe_Rows; i++) {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) {
                    if (board[i, 0] == 'X')
                        return 1;
                    else
                        return 2;
                }
            }

            //cols check
            for (int i = 0; i < TicTacToe_Cols; i++) {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i]) {
                    if (board[0, i] == 'X')
                        return 1;
                    else
                        return 2;
                }
            }

            //diagonals check

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) {
                if (board[0, 0] == 'X')
                    return 1;
                else
                    return 2;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) {
                if (board[0, 2] == 'X')
                    return 1;
                else
                    return 2;
            }

            return 0;
        }

        static bool PlayerChoice(char[,] board, int choice, int player) {
            for (int i = 0; i < TicTacToe_Rows; i++) {
                for (int j = 0; j < TicTacToe_Cols; j++) {
                    int fieldNum;
                    //if the field not chosen yet
                    if (int.TryParse(Convert.ToString(board[i, j]), out fieldNum) && fieldNum == choice) {
                        if (player == 1)
                            board[i, j] = 'X';
                        else
                            board[i, j] = 'O';

                        return true;
                    }

                }
            }
            Console.WriteLine("This Field was already chosen. Please Choose other field.");
            return false;
        }
        static void Main(string[] args) {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            char[,] board = NewBoard();

            PrintBoard(board);

            bool endGame = false;
            int player = 1;
            while (!endGame) {
                Console.WriteLine($"Player {player}: choose your field!   ");

                //ask and show player choice
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && (choice <= 9 && choice >= 1)) {
                    bool flag = PlayerChoice(board, choice, player);
                    while (!flag) {
                        int.TryParse(Console.ReadLine(), out choice);
                        flag = PlayerChoice(board, choice, player);
                    }

                    Console.Clear();
                    PrintBoard(board);

                    //change player
                    if (player == 1)
                        player = 2;
                    else
                        player = 1;
                }
                else
                    Console.WriteLine("Type only numbers please.");

                //check victory
                int playerWin = Victory(board);
                if (playerWin != 0) {
                    endGame = true;
                    Console.WriteLine($"Woohoo Player {playerWin} Won the game!!!");
                }

            }

            Console.Read();
        }
    }
}
