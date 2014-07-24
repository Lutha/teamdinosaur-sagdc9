using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	Transform tf;
	public float xPosition;
	public float xSpeed;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Bullet")) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			return;
		}
		return;
	}
	
	void Start () {
		tf = transform;
		return;
	}
	
	void Update () {
		if (tf.position.x > xPosition) {
			float xMove = xSpeed * Time.deltaTime;
			Vector3 vecMove = new Vector3 (xMove, 0, 0);
			tf.Translate (vecMove);
		}
		return;
	}
}
