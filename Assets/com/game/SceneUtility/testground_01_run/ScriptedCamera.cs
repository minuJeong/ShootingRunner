using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class ScriptedCamera : MonoBehaviour
	{
		private GameObject _target = null;

		private Vector3 _originPosition = Vector3.zero;

		private Quaternion _angle = Quaternion.identity;

		// Use this for initialization
		void Start ()
		{
			_target = GameObject.Find ("PlayerPawn");

			_originPosition = transform.position;

			_angle = transform.rotation;
		}
	
		// Update is called once per frame
		void LateUpdate ()
		{
	
			float _distance = FloorRepeater.GetSpeed ();
			const float _factor = 70F;

			transform.position = Vector3.Lerp (transform.position, _originPosition + transform.forward * _distance * _factor, 0.02F);

		}
	}
}