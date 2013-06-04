using System;
using System.Collections;

namespace TicTacToe
{
	/// 0 1 2
	/// 3 4 5 
	/// 6 7 8
	public class Board
	{
		private char[] board = new char[9] {' ',' ',' ',' ',' ',' ',' ',' ',' '};
		public Board ()
		{
		}

		public int determineWinner() {
			if (hasWon ('X')) 
				return 0;
			if (hasWon ('O'))
				return 1;
			int numMoves = 0;
			foreach (char c in board) {
				if (c != ' ')
					numMoves++;
			}
			if (numMoves == 9)
				return 2;
			return -1;
		}

		public bool makeMove (int move, char piece)
		{
			if (board [move] == ' ') {
				board [move] = piece;
				return true;
			} 
			return false;
		}

		public bool hasWon (char p)
		{
			if (board [4] == p) { //middle
				if ((board [0] == p && board [8] == p) || (board [6] == p && board [2] == p) ||
					(board [3] == p && board [5] == p) || (board [1] == p && board [7] == p)) {
					return true;
				}
			}
			if (board [0] == p) { //upper left
				if ((board [1] == p && board [2] == p) || (board [3] == p && board [6] == p))
					return true;
			}
			if (board [8] == p) { //lower right
				if ((board [6] == p && board [7] == p) || (board [2] == p && board [5] == p))
					return true;
			}
			return false;
		}

		public ArrayList legalMoves ()
		{
			ArrayList moves = new ArrayList();
			for (int i=0;i<board.Length;i++) {
				if(board[i]==' ')
					moves.Add (i);
			}
			return moves;
		}

		public Board newBoard (int move, char p)
		{
			Board copy = new Board ();
			for (int i=0;i<board.Length;i++) {
				copy.makeMove (i, board [i]);
			}
			copy.makeMove (move, p);
			return copy;
		}

		public void print() {
			for (int i=1;i<=board.Length;i++) {
				Console.Write (board[i-1]);
				if (i % 3 == 0)
					Console.Write ("\n");
				else
					Console.Write (" | ");
			}
		}
	}
}

