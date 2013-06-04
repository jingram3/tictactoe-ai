using System;

namespace TicTacToe
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Random r = new Random ();
			bool playAgain = true;
			while (playAgain) {
				Console.WriteLine ("Welcome to Tic Tac Toe! How many players?");
				int numPlayers = 0;
				while (numPlayers != 1 && numPlayers != 2) {
					numPlayers = int.Parse (Console.ReadLine ());
				}
				new Game (numPlayers, r.Next (0,2)).start ();
				char answer = '0';
				while (answer != 'y' && answer != 'n') {
					Console.WriteLine ("Play again? (y/n): ");
					answer = Console.ReadKey ().KeyChar;
					Console.WriteLine ();
				}
				if (answer == 'n') 
					playAgain = false;
			}
		}
	}
}
