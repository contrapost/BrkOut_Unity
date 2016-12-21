using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FreezerManager : MonoBehaviour {

	Text text;
	
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Freezer: " + BallController.ballFreeze;
	}
}
