using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject enemy;
	Object[] enemies = new GameObject[3];
	float[] enemyYPos = new float[] { 3f, 0f, -3f };
	
	void Start () {
		
	}
	
	void Update () {
		for (int i = 0; i < enemies.Length; i++) {
			if (enemies[i] == null) {
				enemies[i] = Instantiate (
						enemy,
						new Vector3 (10.5f, enemyYPos[i], 0f),
						Quaternion.identity);
				return;
			}
		}
		return;
	}
}
