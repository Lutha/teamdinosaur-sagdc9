using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject enemy, kids;
	private Object[] stateObjs;
	private float[] enemyYPos;
	private static int gameState, enemiesLeft;
	private int iState;
	private bool cutsceneStarted, cutsceneFinished;
	
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
				stateObjs = null;
				enemyYPos = null;
				enemiesLeft = 0;
				iState = 0;
				cutsceneStarted = false;
				cutsceneFinished = false;
				break;
			
			case 2:
				// welp
				break;
		}
		gameState++;
		Debug.Log ("Entering gameState " + gameState);
		return;
	}
	
	private IEnumerator Cutscene () {
		yield return new WaitForSeconds (2.0f);
		Instantiate (kids, new Vector3 (0,0,-5), Quaternion.identity);
		cutsceneFinished = true;
	}
	
	public static void EnemyDestroyed () {
		enemiesLeft--;
		Debug.Log ("Enemies left: " + enemiesLeft);
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
				if (stateObjs[iState] == null) {
					GameObject gObj = (GameObject)Instantiate (
							enemy,
							new Vector3 (10.5f, enemyYPos[iState], 0f),
							Quaternion.identity);
					gObj.SendMessage ("SetBehavior", 1);
					stateObjs[iState] = gObj;
					gObj = null;
				}
				
				// continue? see if player has destroyed three
				if (enemiesLeft > 3) {
					iState = (iState + 1) % 3;
					return;
				} else {
					
					break;
				}
				
			case 1:
				// continue? wait until player destroys all of first wave.
				if (enemiesLeft > 1) {
					return;
				} else {
					break;
				}
				
			case 2:
				// show cutscene
				if (! cutsceneStarted) {
					StartCoroutine (Cutscene ());
					cutsceneStarted = true;
					return;
				}
				if (! cutsceneFinished) {
					return;
				} else {
					break;
				}
				
			case 3:
				// faaaaart
				return;
		}
		
		// this should only execute when we want the next "gameState"!
		NextGameState();
		return;
	}
}
