using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class Game : MonoBehaviour
	{

		private GameObject _playerPawn = null;

		// Use this for initialization
		void Start ()
		{
			_playerPawn = GameObject.Find ("PlayerPawn");
		}
	
		// Update is called once per frame
		void Update ()
		{

		}
	}
}