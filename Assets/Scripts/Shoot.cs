using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject ball; //reference to the ball prefab, set in editor
	//private Vector3 throwSpeed = new Vector3(1, 2.2f, 0); //This value is a sure basket, we'll modify this using the forcemeter
	public Vector3 ballPos; //starting ball position
	private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
	private GameObject ballClone; //we don't use the original prefab

	Rigidbody myRigidbody;
	GameObject cube;
	GameObject player;

	private Vector3 target;
	private Vector3 angle;
	private Vector3 playerOrigin;
	private float ballSpeed = 6;

	// Use this for initialization
	void Start () {
		
		myRigidbody = GetComponent<Rigidbody> ();
		/* Increase Gravity */
		Physics.gravity = new Vector3(0, -8, 0);

		cube = GameObject.FindGameObjectWithTag ("cube");
		player = GameObject.FindGameObjectWithTag ("Player");
		target = cube.transform.position;
		playerOrigin = player.transform.position;
		angle = target-playerOrigin;
	}

	void FixedUpdate () {
	
		if (Input.GetButton("Fire1"))
		{
			thrown = true;
			//ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;

			//ballClone.rigidbody.AddForce(throwSpeed, ForceMode.Impulse);

			//GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
			myRigidbody.AddForce(angle * ballSpeed);

		}

	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "cube") {
			Debug.Log("HIT");
		}
	}

}
