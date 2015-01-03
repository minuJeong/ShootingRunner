using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class PlayerPawn : MonoBehaviour
	{

		private float _speed = 0.1F;

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.D) ||
			    Input.GetKey (KeyCode.RightArrow)) {

				FloorRepeater.AddSpeed (- _speed * Time.deltaTime);

			}

			_speed *= 1.001F;

			GetComponentInChildren<Animator> ().SetFloat ("Speed", FloorRepeater.GetSpeed ());

		}
	}
}