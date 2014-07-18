using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Transform myTransform;
	public float playerSpeed, xMoveLimit, yMoveLimit;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float fireNext = 0.0f;
	
	void Start () {
		myTransform = transform;
	}
	
	void Update () {
		float xMove = (playerSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime;
		float yMove = (playerSpeed * Input.GetAxis("Vertical")) * Time.deltaTime;
		Vector3 vecMove = new Vector3 (xMove, yMove, 0);
		vecMove = Vector3.ClampMagnitude(vecMove, playerSpeed * Time.deltaTime);
		myTransform.Translate(vecMove);
		myTransform.position = new Vector3 (
				Mathf.Clamp (myTransform.position.x, -xMoveLimit, xMoveLimit),
				Mathf.Clamp (myTransform.position.y, -yMoveLimit, yMoveLimit),
				0);
		
		if (Input.GetButton ("Fire1") && Time.time > fireNext) {
			fireNext = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
