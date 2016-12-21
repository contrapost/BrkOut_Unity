using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public static bool paused = false;
	public GameObject pause;
	public GameObject music;
	private GameObject pauseInGame;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)
		    || Input.GetKeyDown(KeyCode.P)) {
			if (!paused) {
				Time.timeScale = 0;
				paused = true;
				pauseInGame = Instantiate (pause, transform.position + new Vector3 (0.0f, 0.0f, 0.0f), 
				                           Quaternion.identity) as GameObject;
				music.audio.Pause();
			} else {
				Time.timeScale = 1;
				paused = false;
				pauseInGame.SetActive(false);
				music.audio.Play();
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			//nullstiller nødvendige variabler og åpner hovedmenu
			Application.LoadLevel("menu");
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
}
