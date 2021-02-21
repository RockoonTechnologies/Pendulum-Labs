using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Diagnostics;

public class customize : MonoBehaviour
{
    public GameObject red;
	public GameObject orange;
	public GameObject yellow;
	public GameObject green;
	public GameObject blue;
	public GameObject purple;

	public Button colorbutton;
	private int colornumber = 1;

	public Slider uparmWeight;
	public Text uweightVal;
	private Rigidbody2D uparmrb;

	public Slider lowarmWeight;
	public Text lweightVal;
	private Rigidbody2D lowarmrb;

	public Toggle axisToggle;
	private bool axisEnabled = false;

	public Slider rotation;
	public Text rotVal;

	public Button start;
	public Text starttext;
	private bool running = false;

	public Button halfspeed;
	public Button normalspeed;
	public Button onepointfive;
	public Button doublespeed;

	public Slider gslider;

	
	public Button trb;
	private TrailRenderer tr;
	void Start()
	{
		

		Button colorbtn = colorbutton.GetComponent<Button>();
		colorbtn.onClick.AddListener(changeColor);

		Button startbutton = start.GetComponent<Button>();
		startbutton.onClick.AddListener(simStart);
		//time stuff
		Button halfbutton = halfspeed.GetComponent<Button>();
		halfbutton.onClick.AddListener(halfSpeed);

		Button normalbutton = normalspeed.GetComponent<Button>();
		normalbutton.onClick.AddListener(normalSpeed);

		Button normalfivebutton = onepointfive.GetComponent<Button>();
		normalfivebutton.onClick.AddListener(normalfiveSpeed);

		Button doublebutton = doublespeed.GetComponent<Button>();
		doublebutton.onClick.AddListener(doubleSpeed);

		halfbutton.interactable = false;
		normalbutton.interactable = false;
		normalfivebutton.interactable = false;
		doublebutton.interactable = false;

		Button trailbtn = trb.GetComponent<Button>();
		trailbtn.onClick.AddListener(clearTrail);
		//-----------

		Physics.gravity = new Vector3(0, 9.81f, 0);

		Instantiate(red, new Vector2(0, 0), Quaternion.identity);

		axisToggle = axisToggle.GetComponent<Toggle>();

		axisToggle.onValueChanged.AddListener(delegate {
			toggleAxis(axisToggle);
		});

		StartCoroutine(wait());




	}
	IEnumerator wait()
	{

		Time.timeScale = 1f;
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		Time.timeScale = 0f;

	}

	void Update()
    {
		GameObject trailbuff = GameObject.Find("Trail (1)");
		tr = trailbuff.GetComponent<TrailRenderer>();

		GameObject uparm = GameObject.Find("main arm");
		uparmrb = uparm.GetComponent<Rigidbody2D>();
		uweightVal.text = uparmWeight.value.ToString();
		uparmrb.mass = uparmWeight.value;

		GameObject lowarm = GameObject.Find("second arm");
		lowarmrb = lowarm.GetComponent<Rigidbody2D>();
		lweightVal.text = lowarmWeight.value.ToString();
		lowarmrb.mass = lowarmWeight.value;
		rot();
		grav();

	}
	void changeColor()
	{
		
		colornumber += 1;
		if(colornumber == 7)
        {
			colornumber = 1;
        }
		if(colornumber == 1)
        {
			GameObject toDestroy = GameObject.Find("purple(Clone)");
			Destroy(toDestroy);
			Instantiate(red, new Vector2(0, 0), Quaternion.identity);
		}
		if (colornumber == 2)
		{
			GameObject toDestroy = GameObject.Find("red(Clone)");
			Destroy(toDestroy);
			Instantiate(orange, new Vector2(0, 0), Quaternion.identity);
		}
		if (colornumber == 3)
		{
			GameObject toDestroy = GameObject.Find("orange(Clone)");
			Destroy(toDestroy);
			Instantiate(yellow, new Vector2(0, 0), Quaternion.identity);
		}
		if (colornumber == 4)
		{
			GameObject toDestroy = GameObject.Find("yellow(Clone)");
			Destroy(toDestroy);
			Instantiate(green, new Vector2(0, 0), Quaternion.identity);
		}
		if (colornumber == 5)
		{
			GameObject toDestroy = GameObject.Find("green(Clone)");
			Destroy(toDestroy);
			Instantiate(blue, new Vector2(0, 0), Quaternion.identity);
		}
		if (colornumber == 6)
		{
			GameObject toDestroy = GameObject.Find("blue(Clone)");
			Destroy(toDestroy);
			Instantiate(purple, new Vector2(0, 0), Quaternion.identity);
		}
	}
	void toggleAxis(Toggle change)
    {
		if (axisEnabled == true)
		{
			axisEnabled = false;
			GameObject axis = GameObject.Find("axis");
			SpriteRenderer saxis = axis.GetComponent<SpriteRenderer>();
			saxis.enabled = false;
			return;
		}
		if (axisEnabled == false)
        {
			axisEnabled = true;
			GameObject axis = GameObject.Find("axis");
			SpriteRenderer saxis = axis.GetComponent<SpriteRenderer>();
			saxis.enabled = true;
			return;
		}
		
		

	}
	void rot()
    {
		
		GameObject rotbuffer = GameObject.Find("main arm");
		GameObject rotobj = GameObject.Find(rotbuffer.transform.parent.name);
		rotVal.text = rotation.value.ToString();
		rotobj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation.value);

	}
	void simStart()
    {
		Button halfbutton = halfspeed.GetComponent<Button>();
		halfbutton.onClick.AddListener(halfSpeed);

		Button normalbutton = normalspeed.GetComponent<Button>();
		normalbutton.onClick.AddListener(normalSpeed);

		Button normalfivebutton = onepointfive.GetComponent<Button>();
		normalfivebutton.onClick.AddListener(normalfiveSpeed);

		Button doublebutton = doublespeed.GetComponent<Button>();
		doublebutton.onClick.AddListener(doubleSpeed);

		if (running == false)
        {
			running = true;
			Time.timeScale = 1f;
			starttext.text = "Stop";
			halfbutton.interactable = true;
			normalbutton.interactable = true;
			normalfivebutton.interactable = true;
			doublebutton.interactable = true;
			return;

		}
		if (running == true)
		{
			running = false;
			Time.timeScale = 0f;
			starttext.text = "Start";
			halfbutton.interactable = false;
			normalbutton.interactable = false;
			normalfivebutton.interactable = false;
			doublebutton.interactable = false;
			rot();

			return;

		}

	}
	//time stuff
	void halfSpeed()
    {
		Time.timeScale = 0.5f;
	}
	void normalSpeed()
	{
		Time.timeScale = 1f;
	}
	void normalfiveSpeed()
	{
		Time.timeScale = 1.5f;
	}
	void doubleSpeed()
	{
		Time.timeScale = 2f;
	}
	void clearTrail()
    {
		tr.Clear();
	}
	void grav()
    {
		if(gslider.value == 1)
        {
			Physics.gravity = new Vector3(0, 5.8f, 0);
		}

		if (gslider.value == 2)
		{
			Physics.gravity = new Vector3(0, 9.81f, 0);

		}
		if (gslider.value == 3)
		{
			Physics.gravity = new Vector3(0, 14.8f, 0);
		}
	}
}