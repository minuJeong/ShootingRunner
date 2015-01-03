using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class EnemyPawn : MonoBehaviour
	{
		private float _runSpeed = - 0.04F;

		// Use this for initialization
		void Start ()
		{}
	
		// Update is called once per frame
		void Update ()
		{
			transform.position += transform.forward * _runSpeed;
			transform.position += Vector3.forward * FloorRepeater.GetSpeed ();

			if (transform.position.z < - 5F) {
				Destroy (gameObject);
			}
		}
	}
}