using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    int hp = 100;
    Vector3 startingLevel1 = new Vector3(16, 8, -35);
    Vector3 startingLevel2 = new Vector3(-93, 60, 130);
    Vector3 startingLevel3 = new Vector3(-125, 1, 125);
    public Text Health;
    Scene currentScene;
    string sceneName;
    float timer;


    // Use this for initialization
    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        // Retrieve the name of this scene.

        Restart(); //I made a Function at the bottom that will automatically check and restart your position
    }
	
	// Update is called once per frame
	void Update ()
    {
        Health.text = "Health is " + hp;

        timer = timer + Time.deltaTime; //this adds the miliseconds that have passed every frame together, giving you a realtime timer
        if (Math.Round(timer, 1) >= 1)
        {                            //This is rounding off the time to only a single digit, and then checks to see when "1" second has passed
            hp--; //Lowers hp by 1 every second
            timer = 0; //this is reset so that the If statement can continuously check to see if "1" second has gone by
        }

		if (transform.position.y < -10)
        {
            Restart();
        }

        if (hp <= 0)
        {
            Restart();
            SceneManager.LoadScene("maze");
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
        else if (other.gameObject.tag == "red") //I added a check so that only the red stuff will hurt you
        {
            hp = hp - 10;
        }
    }

    void Restart() // I added this so that it could clean up the code a little bit
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
