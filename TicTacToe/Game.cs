using System;

namespace TicTacToe
{
	public class Game
	{
		private int turn;
		private Board board;
		private char[] pieces;
		private int numMoves;
		private int numPlayers;
		private int cpuPlayer;

		public Game (int players, int cpu)
		{
			turn = 0;
			cpuPlayer = cpu;
			pieces = new char[2] { 'X', 'O' };
			board = new Board ();
			numMoves = 0;
			numPlayers = players;
		}

		private int determineWinner ()
		{
			if (board.hasWon (pieces[turn])) {
				return turn+1;
			}
			else if (numMoves == 9)
				return 3; //tie game
			return 0; //no winner yet
		}

		public void start() {
			int winner = 0;
			CPUPlayer cpu = null;
			if(numPlayers == 1)
				cpu = new CPUPlayer (cpuPlayer);
			while (winner == 0) {
				board.print ();
				Console.WriteLine (String.Format ("Player{0} ({1}'s) turn", turn+1, pieces[turn]));
				int move;
				if (numPlayers == 1 && turn == cpuPlayer) { //cpu's turn
					move = cpu.makeMove (board);
				} else {
					Console.Write ("Enter position 0-8: ");
					move = int.Parse (Console.ReadLine ()); //get move
				}
				while (move < 0 || move > 8 || !board.makeMove (move, pieces[turn])) { //invalid move
					Console.Write ("Invalid move.\nEnter position 0-8: ");
					move = int.Parse (Console.ReadLine ()); //get move again
				}
				numMoves++;
				winner = determineWinner ();
				turn ^= 1; //flip bit
			}
			Console.Write ("Game Over. ");
			if (winner == 3)
				Console.WriteLine ("Tie game!");
			else
				Console.WriteLine (String.Format ("Player{0} has won!", winner));
			board.print ();
		}
	}
}

