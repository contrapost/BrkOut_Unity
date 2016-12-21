using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {

	public GameObject brick;
	public GameObject brick2;
	public GameObject brick3;
	public GameObject brick4;
	public GameObject brick5;
	public GameObject brick6;
	public GameObject brick7;
	public GameObject brick8;

	// Use this for initialization
	void Start () {
		brickCreator ();
	}

	void brickCreator()
	{
		for (int i = -5; i < 6; i++) {
			Instantiate (brick, new Vector3 (i * 21, 10, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick2, new Vector3 (i * 21, 20, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick3, new Vector3 (i * 21, 30, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick4, new Vector3 (i * 21, 40, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick5, new Vector3 (i * 21, 50, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick6, new Vector3 (i * 21, 60, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick7, new Vector3 (i * 21, 70, 0), Quaternion.identity);
		}

		for (int i = -5; i < 6; i++) {
			Instantiate (brick8, new Vector3 (i * 21, 80, 0), Quaternion.identity);
		}
	}
}
