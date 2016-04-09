using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject PlayerAvatar;
    public GameObject BotAvatar;
    public int nbBots;

    GameObject[] spawnPoints;

	void Start ()
    {
        // Finding spawnpoints
        spawnPoints = GameObject.FindGameObjectsWithTag("spawn");

	    // CREATING EVERYOOOOOOOOOONE
        for (int i = 0; i < nbBots; ++i)
        {
            GameObject newBot = GameObject.Instantiate(BotAvatar);
            newBot.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
