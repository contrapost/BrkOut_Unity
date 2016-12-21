using UnityEngine;
using System.Collections;

public class HowToMenu : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("menu");
		}
	}

	public void LoadGame () {
		Application.LoadLevel ("menu");
	}
}
