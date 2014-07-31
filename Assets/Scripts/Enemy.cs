using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	Transform tf;
	public float xSpeed;
	private int behaviorType = 0;
	
	// physics
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Bullet")) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			GameController.EnemyDestroyed();
			return;
		}
		return;
	}
	
	// behaviors
	void SetBehavior (int behaviorType) {
		this.behaviorType = behaviorType;
	}
	
	/// <summary>
	/// Wander onto screen from right, on X axis. Sit in right half of screen.
	/// </summary>
	void Behavior1 () {
		if (tf.position.x > 3.5f) {
			float xMove = xSpeed * Time.deltaTime;
			Vector3 vecMove = new Vector3 (xMove, 0, 0);
			tf.Translate (vecMove);
		}
		return;
	}
	
	void Start () {
		tf = transform;
		return;
	}
	
	void Update () {
		switch (behaviorType) {
			case 1:
				Behavior1 ();
				break;
			
			default:
				break;
		}
		return;
	}
}
