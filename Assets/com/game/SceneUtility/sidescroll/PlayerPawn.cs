using UnityEngine;
using System.Collections;

namespace com.sidescroll
{
	public class PlayerPawn : MonoBehaviour
	{

		// public:
	
		// private:
		// controls
		private float _controlPower = 0F;
		private float _groundControl = 15F;
		private float _jumpControl = 15F;

		// jumpstates
		private const int JUMP_DELAY = 25;
		private int _jumpDelay = 0;
		private bool _isJumped = false;
		private float _jumpPower = 45F;

		// references
		private Animator _mecanim = null;
		private Quaternion _target_rot = Quaternion.identity;
		private Vector2 _prevVelocity = Vector2.zero;

		// init
		void Awake ()
		{
			_mecanim = GetComponentInChildren<Animator> ();

			_target_rot = transform.rotation;

			_prevVelocity = rigidbody2D.velocity;
		}

		// Update is called once per frame
		void Update ()
		{
			CountDelays ();
			ReadInputs ();
			TellMecanim ();
		}

		private void CountDelays ()
		{
			--_jumpDelay;
		}


		// input control
		private void ReadInputs ()
		{
			if (_isJumped)
			{
				_controlPower = _jumpControl;
			} else
			{
				_controlPower = _groundControl;
			}

			if (Input.GetKey (KeyCode.LeftArrow))
			{
				rigidbody2D.velocity = new Vector2 (- _controlPower, rigidbody2D.velocity.y);
				_target_rot = Quaternion.Euler (0, -100, 0);
			}
			
			if (Input.GetKey (KeyCode.RightArrow))
			{
				rigidbody2D.velocity = new Vector2 (_controlPower, rigidbody2D.velocity.y);
				_target_rot = Quaternion.Euler (0, 120, 0);
			}

			transform.rotation = Quaternion.Lerp (transform.rotation, _target_rot, 0.1F);

			if (IsGround ())
			{

				_isJumped = false;
				if (Input.GetKey (KeyCode.Space))
				{
					_isJumped = true;
					_jumpDelay = JUMP_DELAY;
					rigidbody2D.AddForce (Vector3.up * _jumpPower, ForceMode2D.Impulse);
				}
			}
		}

		private bool IsGround ()
		{
			if (_jumpDelay > 0)
			{
				return false;
			}

			RaycastHit2D[] hits = Physics2D.RaycastAll (transform.position, - Vector2.up);
			foreach (var hit in hits)
			{
				if (hit.collider.GetComponent<Floor> () != null &&
					hit.distance < 0.15F)
				{
					return true;
				}
			}

			return false;
		}


		// mecanim control
		private void TellMecanim ()
		{
			_mecanim.SetFloat ("WalkSpeed", rigidbody2D.velocity.magnitude);
		}
	}
}