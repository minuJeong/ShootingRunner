using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class PlayerPawn : MonoBehaviour
	{

		private float _speed = 0.5F;

		private const float JUMP_POWER = 0.15F;
		private float _jumpSpeed = 0F;
		private float _jumpGravity = 0.01F;
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.W) ||
			    Input.GetKey (KeyCode.UpArrow)) {

				FloorRepeater.AddSpeed (transform.forward * (- _speed) * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.A) ||
				Input.GetKey (KeyCode.LeftArrow)) {

				transform.Rotate (0, -7, 0);
			}

			if (Input.GetKey (KeyCode.D) ||
			    Input.GetKey (KeyCode.RightArrow)) {
				
				transform.Rotate (0, 7, 0);
			}

			if (Input.GetKey (KeyCode.Space)) {
				if (isGround ()){
				_jumpSpeed += JUMP_POWER;
				}
			}

			GetComponentInChildren<Animator> ().SetFloat ("Speed", FloorRepeater.GetSpeed ());
			GetComponentInChildren<Animator> ().SetFloat ("Y Speed", _jumpSpeed);

			transform.position += new Vector3 (0, _jumpSpeed, 0);
			if (transform.position.y > 0) {
				_jumpSpeed -= _jumpGravity;
			} else {
				transform.position -= new Vector3 (0, transform.position.y, 0);
			}
		}

		private bool isGround () {
			if (transform.position.y == 0) {
				return true;
			} else {
				return false;
			}
		}
	}
}