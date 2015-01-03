using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class ScriptedCamera : MonoBehaviour
	{
		private GameObject _target = null;

		private float _originY = 0F;

		private float _distance = 0F;

		private float _angle = 0F;

		// Use this for initialization
		void Start ()
		{
			_target = GameObject.Find ("PlayerPawn");

			_originY = transform.position.y;

			Vector3 delta = transform.position - _target.transform.position;

			_distance = delta.magnitude;

			_angle = Mathf.Atan2 (delta.z, delta.x);
		}
	
		// Update is called once per frame
		void LateUpdate ()
		{

			Vector3 _offset = new Vector3 (Mathf.Cos (_angle) * _distance, _originY, Mathf.Sin (_angle) * _distance);

			transform.position = _target.transform.position + _offset;

			// init hide
			foreach (var g in GameObject.FindGameObjectsWithTag ("Hidable")) {
				g.GetComponentInChildren<MeshRenderer> ().enabled = true;
			}

			// hide
			Ray ray = new Ray (transform.position + new Vector3 (0, 0.5F, 0), _target.transform.position - transform.position);
			RaycastHit[] hits = null;
			hits = Physics.RaycastAll (ray);
			foreach (var hit in hits) {
				if (hit.collider.CompareTag ("Hidable") &&
				    hit.distance < _distance + 2F) {
					hit.collider.GetComponentInChildren<MeshRenderer> ().enabled = false;
				}
			}

		}
	}
}