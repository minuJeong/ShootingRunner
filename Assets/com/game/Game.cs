// created 2014. 12. 28
// author: Minu Jeong


// Unity namespace
using UnityEngine;
using System.Collections;

// custom namespace
using com.game.manager;

namespace com.game
{
	public class Game : MonoBehaviour
	{
		// switch
		private bool _gameover = false;


		// input related
		private float _move_power = 20F;


		// initialize
		private void Start ()
		{
			Physics.gravity = Vector3.zero;

			PawnManager.Instance ();

			StartCoroutine ("OnEnterFrame");
		}


		// called every frame
		private IEnumerator OnEnterFrame ()
		{
			while (! _gameover)
			{
				readInput ();
				
				yield return 0;
			}
		}

		private void readInput ()
		{
			// read input
			Vector3 force = Vector3.zero;
			
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				
				force = Vector3.left;
				
			} else if (Input.GetKey (KeyCode.UpArrow))
			{
				
				force = Vector3.up;
				
			} else if (Input.GetKey (KeyCode.RightArrow))
			{
				
				force = Vector3.right;
				
			} else if (Input.GetKey (KeyCode.DownArrow))
			{
				
				force = Vector3.down;
				
			}
			
			force *= _move_power;
			force *= Time.deltaTime;
			
			foreach (var pawn in PawnManager.Instance ().pawns)
			{

				pawn.rigidbody.AddForce (force, ForceMode.Impulse);
				
			}
		}
	}
}