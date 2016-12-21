using UnityEngine;
using System.Collections;

public class WinGameOverMenu : MonoBehaviour {

	public void LoadGame () {
		//nullstiller nødvendige variabler og starter spillet
		Application.LoadLevel ("game");
		BallController.speedIncreaser = 1;
		BallController.countCollisionsWithCeiling = 0;
		BallController.countCollisions = 0;
		LivesManager.lives = 3;
		ScoreManager.score = 0;
		Time.timeScale = 1;
		BallController.ballFreeze = 3;
		BallController.ballIsFrozen = false;
		SapplingController.hasSappling = false;
		SapplingController.hasSapplingPlus = false;
		BallController.hasFallenWithSappling = false;
	}
	
	public void MainMenu () {
		//nullstiller nødvendige variabler og åpner hovedmenu
		Application.LoadLevel ("menu");
		BallController.speedIncreaser = 1;
		BallController.countCollisionsWithCeiling = 0;
		BallController.countCollisions = 0;
		LivesManager.lives = 3;
		ScoreManager.score = 0;
		Time.timeScale = 1;
		BallController.ballFreeze = 3;
		BallController.ballIsFrozen = false;
		SapplingController.hasSappling = false;
		SapplingController.hasSapplingPlus = false;
		GameObject.FindGameObjectWithTag("Platform").transform.localScale = 
			new Vector3 (PlatformController.platformSize, 
			             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.y, 
			             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.z);
		PlatformController.maxBorder = 20.0f;
		BallController.hasFallenWithSappling = false;
	}
}
