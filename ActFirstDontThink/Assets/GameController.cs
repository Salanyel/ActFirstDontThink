using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject PlayerAvatar;
    public GameObject BotAvatar;
    public int nbBots;
    public int nbPlayers;

    struct Stats
    {
        public int score;
        public int deaths;
        public int kills;
    }

    GameObject[] spawnPoints;

    // bots
    GameObject[] avatars;
    Stats[] stats;

	void Start ()
    {
        // Finding spawnpoints
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        // CREATING EVERYOOOOOOOOOONE
        avatars = new GameObject[nbPlayers + nbBots];
        stats = new Stats[nbPlayers + nbBots];

        for (int i = 0; i < nbPlayers; ++i)
        {
            GameObject newPlayer = GameObject.Instantiate(PlayerAvatar);
            newPlayer.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            avatars[i] = newPlayer;
        }
        for (int i = nbPlayers; i < (nbPlayers + nbBots); ++i)
        {
            GameObject newBot = GameObject.Instantiate(BotAvatar);
            newBot.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            avatars[i] = newBot;
        }
	}

    public void OnBotDeath(int deadGuyIndex, int killerIndex)
    {
        GameObject newPlayer = GameObject.Instantiate(PlayerAvatar);
        newPlayer.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        avatars[deadGuyIndex] = newPlayer;
        newPlayer.GetComponent<PlayerId>().m_id = deadGuyIndex;

        stats[deadGuyIndex].deaths +=1;
        stats[killerIndex].kills += 1;
    }
}
