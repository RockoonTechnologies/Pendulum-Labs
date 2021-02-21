using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class basicbuttons : MonoBehaviour
{
	public Button yourButton;
	public Button yourButton1;
	public Rigidbody2D rb2D;
	public float thrust = 10.0f;

	void Start()
	{
		Button left = yourButton.GetComponent<Button>();
		Button right = yourButton1.GetComponent<Button>();
		left.onClick.AddListener(lefttask);
		right.onClick.AddListener(righttask);
	}

	void lefttask()
	{
		Debug.Log("left");
		rb2D.AddRelativeForce(Vector2.left * thrust);
	}
	void righttask()
	{
		Debug.Log("right");
		rb2D.AddRelativeForce(Vector2.right * thrust);
	}
}