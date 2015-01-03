using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class PlayerPawn : MonoBehaviour
	{

		private static PlayerPawn Instance = null;
		private float _velocity = 0.6F;
		private float _gravity = - 0.02F;
		private Vector3 _speed = Vector3.zero;
		private const float JUMP_POWER = 0.5F;
		private Animator mecanim = null;

		void Awake ()
		{
			Instance = this;
			mecanim = GetComponentInChildren<Animator> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			// inputs
			if (Input.GetKey (KeyCode.W) ||
				Input.GetKey (KeyCode.UpArrow)) {
				_speed += Vector3.forward * _velocity;
			}

			if (Input.GetKey (KeyCode.S) ||
				Input.GetKey (KeyCode.DownArrow)) {
				_speed += Vector3.back * _velocity;
			}

			if (Input.GetKey (KeyCode.A) ||
				Input.GetKey (KeyCode.LeftArrow)) {

				_speed += Vector3.left * _velocity;
			}

			if (Input.GetKey (KeyCode.D) ||
				Input.GetKey (KeyCode.RightArrow)) {
				
				_speed += Vector3.right * _velocity;
			}

			float _distance_g = DistanceToGround ();
			if (_distance_g < 0.2F) {

				transform.position -= new Vector3 (0, _distance_g, 0);

				if (Input.GetKey (KeyCode.Space)) {
					_speed.y = JUMP_POWER;
					transform.position += new Vector3 (0, _speed.y, 0);
				} else {
					_speed.y = 0F;
				}

			} else {
				_speed.y += _gravity;
				transform.position += new Vector3 (0, _speed.y, 0);
			}

			Vector3 _speedXZ = new Vector3 (_speed.x, 0, _speed.z);

			// translate
			float _distance_w = DistanceToWall ();
			if (_distance_w < 0.2F) {
				transform.position -= transform.forward * _distance_w/2;
				_speed.x = 0;
				_speed.z = 0;

			} else {
				transform.position += _speedXZ * Time.deltaTime;

			}

			if (_speedXZ.magnitude > 0.1F) {
				transform.forward = _speedXZ;
			}

			// friction
			_speed *= 0.85F;

			// mecanim control
			mecanim.SetFloat ("Speed", _speedXZ.sqrMagnitude);
			mecanim.SetFloat ("Y Speed", _speed.y);



			// kill-y
			if (transform.position.y < -10F) {
				transform.position += new Vector3 (0, 20, 0);
			
			}
		}

		private float DistanceToGround ()
		{
			float margin = 0.5F;

			Ray ray = new Ray (transform.position + new Vector3 (0, margin, 0), Vector3.down);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				return hit.distance - margin;
			}

			return 100F;
		}

		private float DistanceToWall () {
			float offset_y = 0.5F;
			Ray ray = new Ray (transform.position + new Vector3 (0, offset_y, 0), transform.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				return hit.distance;
			}
			
			return 100F;
		}

		public static float GetVelocity ()
		{
			return Instance._velocity;
		}
	}
}