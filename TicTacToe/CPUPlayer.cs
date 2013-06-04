using System;

namespace TicTacToe
{
	public class CPUPlayer
	{
		private char[] pieces = new char[2] {'X', 'O'};
		private int bestMove;
		private int cPlayer;

		public CPUPlayer(int player) {
			cPlayer = player;
		}

		public int makeMove (Board board)
		{
			bestMove = 0;
			//int score = minimaxab (board, 9, -100, 100, true);
			int score = minimax (board, cPlayer, 9);
			Console.WriteLine ("Score: " + score);
			return bestMove;
		}

		private int minimax(Board brd, int turn, int depth) {
			int winner = brd.determineWinner ();
			if (winner != -1) { //terminal node
				if (winner == turn) {
					return 1;
				} else if (winner == (turn ^ 1)) {
					return -1;
				}
				return 0;
			}
			int alpha = -10000;
			foreach (int move in brd.legalMoves()) {
				int score = Math.Max (alpha, -minimax (brd.newBoard (move, pieces [turn]), turn ^ 1, depth - 1));
				if (score > alpha && depth==9)
					bestMove = move;
				alpha = score;
			}
			return alpha;
		}
	}
}

