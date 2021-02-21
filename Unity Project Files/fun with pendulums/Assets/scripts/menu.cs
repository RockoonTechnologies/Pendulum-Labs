using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Diagnostics;

using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{

	private Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public GameObject mainmenu;
	public Button pm;
	public GameObject premademenu;


	public Button pm1;
	public Button pm2;
	public Button pm3;
	public Button pm4;

	public Button cust;



	void Start()
    {

		Button premade = pm.GetComponent<Button>();
		premade.onClick.AddListener(premadeCam);
		premademenu.SetActive(false);

		Button pmone = pm1.GetComponent<Button>();
		pmone.onClick.AddListener(load1);

		Button pmtwo = pm2.GetComponent<Button>();
		pmtwo.onClick.AddListener(load2);

		Button pmthree = pm3.GetComponent<Button>();
		pmthree.onClick.AddListener(load3);

		Button pmfour = pm4.GetComponent<Button>();
		pmfour.onClick.AddListener(load4);

		Button custom = cust.GetComponent<Button>();
		custom.onClick.AddListener(loadcustom);

	}
	void FixedUpdate()

	{
		
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}

	void premadeCam()
    {
		mainmenu.SetActive(false);
		
		target = GameObject.Find("premadeplace").GetComponent<Transform>();
		premademenu.SetActive(true);
	}

	// 

	void load1()
	{
		SceneManager.LoadScene("basic");
	}

	void load2()
    {
		SceneManager.LoadScene("inline");
	}

	void load3()
    {
		SceneManager.LoadScene("add forces");
	}

	void load4()
	{
		SceneManager.LoadScene("triple");
	}

	void loadcustom()
	{
		SceneManager.LoadScene("custom");
	}
}