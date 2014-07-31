using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	// cheater constants
	const int	KIDPIC 	= 0,
					GIRLTALK	= 1,
					BOYTALK 	= 2;
	
	// real variables
	public GameObject enemy, kids;
	Object[] stateObjs;
	float[] enemyYPos;
	private static int gameState, enemiesLeft;
	int iEnemies;
	
	private void NextGameState () {
		switch (gameState) {
			case -1:			// set spawner info for state 0
				stateObjs = new GameObject[3];
				enemyYPos = new float[] { 3f, 0f, -3f };
				enemiesLeft = 6;
				break;
			
			case 0:
				break;
			
			case 1:			// set up cutscene
				// cleanup
				stateObjs = new GameObject[3];
				enemyYPos = null;
				enemiesLeft = 0;
				
				// new
				break;
		}
		gameState++;
		// Debug.Log ("Entering gameState " + gameState);
		return;
	}
	
	public static void EnemyDestroyed () {
		enemiesLeft--;
		// Debug.Log ("Enemies left: " + enemiesLeft);
		return;
	}
	
	void Start () {
		gameState = -1;
		NextGameState ();
		return;
	}
	
	void Update () {
		switch (gameState) {
			case 0:
				// spawn replacement enemies until player destroys three.
				if (stateObjs[iEnemies] == null) {
					GameObject gObj = (GameObject)Instantiate (
							enemy,
							new Vector3 (10.5f, enemyYPos[iEnemies], 0f),
							Quaternion.identity);
					gObj.SendMessage ("SetBehavior", 1);
					stateObjs[iEnemies] = gObj;
					gObj = null;
				}
				
				// continue? see if player has destroyed three
				if (enemiesLeft > 3) {
					iEnemies = (iEnemies + 1) % 3;
					return;
				} else {
					break;
				}
				
			case 1:
				// continue? wait until player destroys all of first wave.
				if (enemiesLeft > 0) {
					return;
				} else {
					break;
				}
				
			case 2:
				// show cutscene
				return;
				
			case 3:
				// second wave (AWESOME wave)
				return;
				
			case 4:
				// boss
				return;
		}
		
		// this should only execute when we want the next "gameState"!
		NextGameState();
		return;
	}
}
