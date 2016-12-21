using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void LoadGame () {
		Application.LoadLevel ("game");
	}

	public void LoadHowTo () {
		Application.LoadLevel ("howTo");
	}

	public void Exit () {
		Application.Quit ();
	}
}
