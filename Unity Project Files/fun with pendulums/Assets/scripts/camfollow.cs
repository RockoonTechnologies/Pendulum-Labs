using UnityEngine;

public class camfollow : MonoBehaviour
{

	private Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void FixedUpdate()

	{
		GameObject rotbuffer = GameObject.Find("main arm");
		target = GameObject.Find(rotbuffer.transform.parent.name).GetComponent<Transform>();
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}

}