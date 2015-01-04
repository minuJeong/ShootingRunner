using UnityEngine;
using System.Collections;

namespace com.sidescroll
{
	public class SideScrollScriptedCamera : MonoBehaviour
	{

		private GameObject _target = null;

		private Vector3 _delta = Vector2.zero;

		// Use this for initialization
		void Start ()
		{
			_target = GameObject.Find ("PlayerPawn");

			_delta = _target.transform.position - transform.position;
			_delta.z = - transform.position.z;
		}
	
		// Update is called once per frame
		void Update ()
		{
			transform.position = _target.transform.position - _delta;
		}
	}
}