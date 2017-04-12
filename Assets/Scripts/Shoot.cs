using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	Rigidbody myRigidbody;
	GameObject cube;
	private Vector3 target;


	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();

		cube = GameObject.FindGameObjectWithTag ("cube");
		target = cube.transform.position;

		ThrowBallAtTargetLocation(target, 10f);
	}

	// Throws ball at location with regards to gravity (assuming no obstacles in path) and initialVelocity (how hard to throw the ball)
	public void ThrowBallAtTargetLocation(Vector3 targetLocation, float initialVelocity)
	{
		Vector3 direction = (targetLocation - transform.position).normalized;
		float distance = Vector3.Distance(targetLocation, transform.position);

		float firingElevationAngle = FiringElevationAngle(Physics.gravity.magnitude, distance, initialVelocity);
		Vector3 elevation = Quaternion.AngleAxis(60f, transform.right) * transform.up;
		float directionAngle = AngleBetweenAboutAxis(transform.forward, direction, transform.up);
		Vector3 velocity = Quaternion.AngleAxis(directionAngle, transform.up) * elevation * initialVelocity;

		// ballGameObject is object to be thrown
		myRigidbody.AddForce(velocity, ForceMode.VelocityChange);
	}

	// Helper method to find angle between two points (v1 & v2) with respect to axis n
	public static float AngleBetweenAboutAxis(Vector3 v1, Vector3 v2, Vector3 n)
	{
		return Mathf.Atan2(
			Vector3.Dot(n, Vector3.Cross(v1, v2)),
			Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}

	// Helper method to find angle of elevation (ballistic trajectory) required to reach distance with initialVelocity
	// Does not take wind resistance into consideration.
	private float FiringElevationAngle(float gravity, float distance, float initialVelocity)
	{
		float angle = 0.5f * Mathf.Asin((gravity * distance) / (initialVelocity * initialVelocity)) * Mathf.Rad2Deg;
		return angle;
	}

}
