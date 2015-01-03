using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using com.game.pawn;

namespace com.game.manager
{
	public class PawnManager
	{
		// contains all
		private List<Pawn> _pawns = new List<Pawn> ();

		public List<Pawn> pawns
		{
			get
			{
				return _pawns;
			}

			set
			{
				_pawns = value;
			}

		}

		// constructor
		protected PawnManager ()
		{
			foreach (var pawn in GameObject.FindObjectsOfType<Pawn> ())
			{
				_pawns.Add (pawn);
			}
		}

		// Singleton pattern
		private static PawnManager _instance = null;
		public static PawnManager Instance ()
		{
			if (_instance == null)
			{
				_instance = new PawnManager ();
			}

			return _instance;
		}

		public List<Pawn> GetAllPawn ()
		{

			return Instance ()._pawns;

		}
	}
}