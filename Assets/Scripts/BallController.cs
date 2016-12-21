using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public static float speed = 4250.0f;
	public GameObject ball;
	public GameObject brick;
	public AudioClip brickSound;
	public AudioClip wallSound;
	public static int countCollisions = 0;
	private int countCollisionsFrozen;
	public int countCollisionsWithTopBricks = 0;
	public static int countCollisionsWithCeiling = 0;
	public static int speedIncreaser = 1;
	private Vector3 frozenSpeed;
	private Vector3 unfrozenSpeed;
	public static int ballFreeze = 3;
	public static bool ballIsFrozen = false;
	private int basicScore = 100;
	public GameObject sappling;
	public static bool hasFallenWithSappling = false;

	
	// Update is called once per frame
	void Update () {

		if (PlatformController.ballRigidBody.velocity.x > 130.0f || PlatformController.ballRigidBody.velocity.y > 130.0f) {
			PlatformController.ballRigidBody.velocity = 
			Vector3.ClampMagnitude (PlatformController.ballRigidBody.velocity, 130.0f);
		}

		if (transform.position.y < -100) {
			//fjerner 1 forsøk, returnerer ballen til platformen og nullstiller nødvendige variabler
			LivesManager.lives--;
			speedIncreaser = 1;
			countCollisionsWithTopBricks = 0;
			countCollisions = 0;
			countCollisionsWithCeiling = 0;
			SapplingController.hasSappling = false;
			SapplingController.hasSapplingPlus = false;
			ballIsFrozen = false;
			RestoreVelocity ();
			GameObject.FindGameObjectWithTag("Platform").transform.localScale = 
				new Vector3 (PlatformController.platformSize, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.y, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.z);
			PlatformController.maxBorder = 20.0f;
			hasFallenWithSappling = true;

			Vector3 tmp = transform.position;
			tmp.y = GameObject.FindGameObjectWithTag("Platform").transform.position.y + 5.5f;
			tmp.x = GameObject.FindGameObjectWithTag("Platform").transform.position.x;
			transform.position = tmp;
			ball.rigidbody.Sleep();

			PlatformController.attachedBall = this.gameObject;

			if (countCollisionsWithCeiling >= 1) {
			GameObject.FindGameObjectWithTag("Platform").transform.localScale = 
				new Vector3 (GameObject.FindGameObjectWithTag ("Platform").transform.localScale.x * 2, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.y, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.z);
			PlatformController.maxBorder *= 1.8f;
			countCollisionsWithCeiling = 0;
			}
		}

		// sjekker om spilleren har vunnet / tapt
		if (LivesManager.lives == 0) {
			Application.LoadLevel("gameOver");
			hasFallenWithSappling = false;
		}

		if (ScoreManager.score == 39600) {
			Application.LoadLevel("win");
		}

		//setter i gang PowerUps
		if ((Input.GetKeyDown (KeyCode.UpArrow) ||  Input.GetKeyDown (KeyCode.W))
		    && (ballFreeze > 0)  && (PlatformController.attachedBall == null) && (!ballIsFrozen)
		    && !PauseController.paused) {
			FreezeBall ();
			ballFreeze--;
			ballIsFrozen = true;
		}

		if (SapplingController.hasSappling) {
			SapplingController.hasSappling = false;
			Debug.Log (SapplingController.hasSappling);
			Invoke ("DisablePlatform", 4.0f);
		}
	}

	void BallSpeedIncreaser (){
			PlatformController.ballRigidBody.AddForce(PlatformController.ballRigidBody.velocity.normalized * 
		                                          5 * speedIncreaser, ForceMode.Impulse);
		}

	void FreezeBall () {
		countCollisionsFrozen = countCollisions;
		unfrozenSpeed = PlatformController.ballRigidBody.velocity;
		frozenSpeed = PlatformController.ballRigidBody.velocity;
		frozenSpeed.x *= 0.1f;
		frozenSpeed.y *= 0.1f;
		PlatformController.ballRigidBody.velocity = frozenSpeed;
		PlatformController.ballRigidBody.renderer.material.color = Color.blue;
		Invoke ("RestoreVelocity", 2);
	}

	void RestoreVelocity (){
		if (ballIsFrozen) {
			Debug.Log (countCollisions + " " + countCollisionsFrozen);
			if (countCollisions > countCollisionsFrozen) {
				PlatformController.ballRigidBody.velocity = -unfrozenSpeed;
			} else {
				PlatformController.ballRigidBody.velocity = unfrozenSpeed;
			}
			PlatformController.ballRigidBody.renderer.material.color = Color.white;
			ballIsFrozen = false;
		}
	}

	void DisablePlatform(){
		if (!hasFallenWithSappling) {
			GameObject.FindGameObjectWithTag ("Platform").transform.localScale = 
				new Vector3 (GameObject.FindGameObjectWithTag ("Platform").transform.localScale.x / 2, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.y, 
				             GameObject.FindGameObjectWithTag ("Platform").transform.localScale.z);
			PlatformController.maxBorder /= 1.8f;
			SapplingController.hasSapplingPlus = false;
		}
	}

	void SpawnPowerUp(Vector3 position){ 
		//Velger en tilfeldig PU ut av parameter posisjon.(Fra ødelagt brick)
		Instantiate(sappling, position, Quaternion.identity); 
	}

	void OnCollisionEnter (Collision collision) {
				// endrer scores, hastighet og spiller lyd

		        if (collision.gameObject.tag.Contains("Brick")){
				audio.PlayOneShot (brickSound);
				Destroy (collision.gameObject);
				Vector3 currentPos = collision.transform.position;

				if(Random.Range(0, 10) > 8){
					SpawnPowerUp(currentPos);
				}
				if (collision.gameObject.tag.Contains("2")){
					ScoreManager.score+=basicScore*2;
				} else if (collision.gameObject.tag.Contains("3")){
					ScoreManager.score+=basicScore*3;
				} else if (collision.gameObject.tag.Contains("4")){
					ScoreManager.score+=basicScore*4;
				} else if (collision.gameObject.tag.Contains("5")){
					ScoreManager.score+=basicScore*5;
				} else if (collision.gameObject.tag.Contains("6")){
					ScoreManager.score+=basicScore*6;
				} else if (collision.gameObject.tag.Contains("7")){
					ScoreManager.score+=basicScore*7;
				} else if (collision.gameObject.tag.Contains("8")){
					ScoreManager.score+=basicScore*8;
				} else {
					ScoreManager.score+=basicScore;
				}
			}
		

		if (collision.gameObject.tag == "Wall") {
			audio.PlayOneShot (wallSound);
		}

		if (collision.gameObject.tag == "Ceiling") {
			audio.PlayOneShot (wallSound);
			countCollisionsWithCeiling++;
		}

		if (collision.gameObject.tag == "Brick" || collision.gameObject.tag == "Brick2" ||
			collision.gameObject.tag == "Brick3" || collision.gameObject.tag == "Brick4" ||
			collision.gameObject.tag == "Brick5" || collision.gameObject.tag == "Brick6" ||
			collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ceiling" ||
			collision.gameObject.tag == "Platform") {
			countCollisions++;
		}

		if ((collision.gameObject.tag == "Platform") && (ballIsFrozen) && (ballFreeze > 0)) {
			RestoreVelocity ();
			ballIsFrozen = false;
		}

		if (collision.gameObject.tag == "Brick7" || collision.gameObject.tag == "Brick8") {
			countCollisionsWithTopBricks++;
			countCollisions++;
		}

		if (countCollisions == 4 || countCollisions == 12) {
			speedIncreaser++;
			BallSpeedIncreaser (); 			
		}
		if (countCollisionsWithTopBricks == 1 && (countCollisions != 4 || countCollisions != 12)) {
			speedIncreaser++;
			BallSpeedIncreaser (); 
			countCollisionsWithTopBricks++;
			countCollisions++;
		}
	}
}
