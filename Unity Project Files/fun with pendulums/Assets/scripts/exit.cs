using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{

    public Button pm1;

    // Start is called before the first frame update
    void Start()
    {

        Button exit = pm1.GetComponent<Button>();
        exit.onClick.AddListener(exitlevel);
    }

    void exitlevel()
    {
        SceneManager.LoadScene("menu");
    }

   
}
