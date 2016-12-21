using UnityEngine;
using System.Collections;

public class CeilingController : MonoBehaviour {

	void OnCollisionEnter () {
		// endrer størrelse på platformen
		if (BallController.countCollisionsWithCeiling == 1) {
			GameObject.FindGameObjectWithTag ("Platform").transform.localScale = 
				new Vector3 (GameObject.FindGameObjectWithTag ("Platform").transform.localScale.x / 2, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.y, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.z);
			PlatformController.maxBorder /= 1.8f;
		}
	}
}
