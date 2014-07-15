using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	private float changeRate = 0.5f;
	private float changeNext = 0.0f;
	
	public float scrollMultiplier;
	private int scrollSpeed = 0;
	private readonly float scrollBaseSpeed = 0.001f;
	
	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		
		if ((moveX != 0) && (Time.time > changeNext)) {
			changeNext = Time.time + changeRate;
			if (moveX > 0 )
					scrollSpeed += 1;
			else
					scrollSpeed -= 1;
			
		}
		renderer.material.SetTextureOffset (
				"_MainTex",
				new Vector2 (renderer.material.mainTextureOffset.x +
						((scrollBaseSpeed * renderer.material.mainTextureScale.x *
						scrollSpeed * scrollMultiplier) % 1), 0)
		);
	}
}
