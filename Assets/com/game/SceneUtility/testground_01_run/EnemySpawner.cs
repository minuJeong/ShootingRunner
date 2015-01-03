using UnityEngine;
using System.Collections;

namespace testground_01_run
{
	public class EnemySpawner : MonoBehaviour
	{

		private const int NUMBER_OF_PAWNS = 4;
		private int _pawn_count = 0;
		private const float SPAWN_DELAY_BASE = .5F;
		private const float SPAWN_DELAY_VARY = 2.5F;
		private GameObject _target = null;

		// Use this for initialization
		void Start ()
		{
			_target = Resources.Load<GameObject> ("Prefabs/testground_01_run/EnemyPawn");

			StartCoroutine ("Spawn");
		}
	
		IEnumerator Spawn ()
		{
			while (_pawn_count <= NUMBER_OF_PAWNS) {

				GameObject instantiated = (GameObject)Instantiate (_target);
				instantiated.transform.parent = transform;
				instantiated.transform.position += new Vector3 (0, 0, 15F);


				yield return new WaitForSeconds (SPAWN_DELAY_BASE + Random.value * SPAWN_DELAY_VARY);

				_pawn_count = transform.childCount;
			}
		}
	}
}