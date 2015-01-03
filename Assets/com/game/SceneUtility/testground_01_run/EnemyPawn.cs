using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class EnemyPawn : MonoBehaviour
	{
		private float _runSpeed = - 0.04F;
	
		// Update is called once per frame
		void Update ()
		{
			transform.position += transform.forward * _runSpeed;
		}
	}
}