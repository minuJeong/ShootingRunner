using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class FloorRepeater : MonoBehaviour
	{
		private GameObject _floorUnit = null;
		private const int _floorCount = 8;
		private GameObject[] _floors = new GameObject[_floorCount];
		private Vector3 _speed = Vector3.zero;
		private const float _kill_z = -10F;
		private static FloorRepeater _instance = null;

		void Awake ()
		{
			_instance = this;
		}

		// Use this for initialization
		void Start ()
		{
			_floorUnit = transform.FindChild ("Floor").gameObject;

			// copy and preserve in array
			_floors [0] = _floorUnit;

			for (int i = 1; i < _floorCount; i++) {
				_floors [i] = (GameObject)Instantiate (_floorUnit);
				_floors [i].transform.position += new Vector3 (0, 0, _floorUnit.transform.localScale.z * i);
			}

			// set parent
			foreach (var floor in _floors) {
				floor.transform.parent = transform;
				floor.transform.localScale = new Vector3 (Random.Range (1.25F, 2.5F), Random.Range (0.25F, 1.5F), _floorUnit.transform.localScale.z);

				var temp = floor.transform.position;
				temp.y = - floor.transform.localScale.y / 2;

				floor.transform.position = temp;
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
			// translate
			foreach (var floor in _floors) {
				floor.transform.position += _speed;

				if (floor.transform.position.z < _kill_z) {
					floor.transform.position += new Vector3 (0, 0, _floorUnit.transform.localScale.z * _floorCount);

					floor.transform.localScale = new Vector3 (Random.Range (1.25F, 2.5F), Random.Range (0.25F, 1.5F), _floorUnit.transform.localScale.z);
					
					var temp = floor.transform.position;
					temp.y = - floor.transform.localScale.y / 2;
					
					floor.transform.position = temp;
				}
			}

			// apply friction
			_speed *= 0.85F;

			//
			transform.forward = - _speed.normalized;
		}

		public static void AddSpeed (Vector3 value)
		{
			_instance._speed += value;
		}

		public static float GetSpeed ()
		{
			return _instance._speed.magnitude;
		}
	}
}