using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	public float speed;
	public static float platformSize = 36.0f;
	public static float maxBorder = 20.0f;
	public float xBorder;
	public static GameObject attachedBall = null;
	public GameObject ballPrefab;
	public static Rigidbody ballRigidBody;
	public float ballSpeed = 4250.0f;
	private float angle;
	public AudioClip platformSound;

	// setter ballen på platformen
	void Start () {
		attachedBall = Instantiate (ballPrefab, transform.position + new Vector3 (0.0f, 40.0f, 0.0f), 
		                            Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//sørger for platformens bevegelser, instansiering av ballen og endring av vinkel
		if (Input.GetAxis("Horizontal") != 0) {
			transform.position = new Vector3 (transform.position.x + Input.GetAxis ("Horizontal") * speed * Time.deltaTime, -85.0f, 0.0f);
			if (transform.position.x < -xBorder + maxBorder)
			{
				transform.position = new Vector3 (-xBorder + maxBorder, -85.0f, 0.0f);
			} else if (transform.position.x > xBorder - maxBorder){
				transform.position = new Vector3 (xBorder - maxBorder, -85.0f, 0.0f);
			}
		}

		if (attachedBall) {
			ballRigidBody = attachedBall.rigidbody;
			ballRigidBody.position = transform.position + new Vector3 (0.0f, 5.5f, 0.0f);

			if (Input.GetButtonDown("Jump")) {
				ballRigidBody.isKinematic = false;
				ballRigidBody.AddForce(0.0f, ballSpeed, 0.0f);
				attachedBall = null;
			} 
		}
	}

	void OnCollisionEnter (Collision platformCollision) {
		audio.PlayOneShot (platformSound);

		foreach (ContactPoint contact in platformCollision.contacts) {
			if (contact.thisCollider == collider) {
				angle = contact.point.x - transform.position.x;
				contact.otherCollider.rigidbody.AddForce (angle * 100, 0.0f, 0.0f);
			}
		}

	}
}
