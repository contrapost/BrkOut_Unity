using UnityEngine;
using System.Collections;

public class SapplingController : MonoBehaviour {

	public static GameObject PowerUps;
	public static bool hasSappling = false;
	public static bool hasSapplingPlus = false;
	public static float size;



	void Update(){

		if (transform.position.y < -100) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider collide){
		if (collide.gameObject.tag.Contains ("Platform")) {
			if (!hasSappling){
				if (!hasSapplingPlus){
					EnlargePlatform ();
				}
			}
			Destroy(this.gameObject);
		}
	}

	void EnlargePlatform () {
		GameObject.FindGameObjectWithTag ("Platform").transform.localScale = 
			new Vector3 (GameObject.FindGameObjectWithTag ("Platform").transform.localScale.x * 2, 
			             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.y, 
			             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.z);
		PlatformController.maxBorder *= 1.8f;
		hasSappling = true;
		hasSapplingPlus = true;
	}
}
