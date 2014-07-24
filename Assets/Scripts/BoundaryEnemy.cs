using UnityEngine;
using System.Collections;

public class BoundaryEnemy : MonoBehaviour {
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Enemy"))
			Destroy (other.gameObject);
			Debug.Log ("Enemy destroyed.");
	}
}
