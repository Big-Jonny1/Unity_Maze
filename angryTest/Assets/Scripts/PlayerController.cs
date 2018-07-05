using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int hp = 100;
    bool dmgCHeck = false;
    Vector3 startingLevel1 = new Vector3(16, 8, -35);
    Vector3 startingLevel2 = new Vector3(-93, 60, 130);
    Vector3 startingLevel3 = new Vector3(-125, 1, 125);
    public Text Health;
    Scene currentScene;
    string sceneName;


    // Use this for initialization
    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        // Retrieve the name of this scene.

        if (sceneName == "maze")
        {
            transform.position = startingLevel1;
        }
        else if (sceneName == "maze 2")
        {
            transform.position = startingLevel2;
        }
        else if (sceneName == "maze 3")
        {
            transform.position = startingLevel3;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Health.text = "Health is " + hp;
		if (transform.position.y < -10)
        {
            if (sceneName == "maze")
            {
                transform.position = startingLevel1;
            }
            else if (sceneName == "maze 2")
            {
                transform.position = startingLevel2;
            }
            else if (sceneName == "maze 3")
            {
                transform.position = startingLevel3;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            if (sceneName == "maze")
            {
                SceneManager.LoadScene("maze 2");
            }
            else if (sceneName == "maze 2")
            {
                SceneManager.LoadScene("maze 3");
            }
            else if (sceneName == "maze 3")
            {
                SceneManager.LoadScene("maze");
            }
        }
        hp = hp - 10;
        if (hp <= 0)
        {
            if (sceneName == "maze")
            {
                transform.position = startingLevel1;
            }
            else if (sceneName == "maze 2")
            {
                transform.position = startingLevel2;
            }
            else if (sceneName == "maze 3")
            {
                transform.position = startingLevel3;
            }
            hp = 100;
        }      
    }

}
