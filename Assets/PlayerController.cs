using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 2;

	Animator animator;

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
	}
}
