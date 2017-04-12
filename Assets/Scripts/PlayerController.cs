using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 2;

	Animator animator;

	public GameObject ball;
	public Transform ballPoint;

	public int ballCount;
	private bool thrown;
	private GameObject ballClone; //we don't use the original prefab


	void Start () {
		animator = GetComponent<Animator> ();
	}


	void Update () {

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero) {
			transform.eulerAngles = Vector3.up * Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg;	
		}

		float speed = walkSpeed * inputDir.magnitude;

		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);

		float animationSpeedPercent = 1 * inputDir.magnitude;
		animator.SetFloat ("speedPercent", animationSpeedPercent);

		//if(Input.GetButtonDown ("Fire1") && !thrown && ballCount != 0) {
			//FireBall();
		//}
		thrown = false;
		if(Input.GetButtonDown ("Fire1") && !thrown) {
			FireBall();
		}

	}

	public void FireBall() {
		Instantiate(ball, ballPoint.position, ballPoint.rotation);

		thrown = true;
		//ballCount--;

		//if (ballCount == 0) {
		//	Debug.Log("NO MORE BALLS");
		//}			
	}
}
