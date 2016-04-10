using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject PlayerAvatar;
    public GameObject BotAvatar;
    public int nbBots;
    public int nbPlayers;
    public float m_timeBeforeRespawn;
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

        GameObject newBot = GameObject.Instantiate(BotAvatar);
        newBot.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        avatars[0] = newBot;

        for (int i = 1; i < nbPlayers; ++i)
        {
            GameObject newPlayer = GameObject.Instantiate(PlayerAvatar);
            newPlayer.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            avatars[i] = newPlayer;
        }
        for (int i = nbPlayers + 1; i < (nbPlayers + nbBots); ++i)
        {
            newBot = GameObject.Instantiate(BotAvatar);
            newBot.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            avatars[i] = newBot;
        }
	}

    public void OnBotDeath(int deadGuyIndex, int killerIndex)
    {
        GameObject deadAvatar = avatars[deadGuyIndex];
        deadAvatar.SetActive(false);

        stats[deadGuyIndex].deaths += 1;
        stats[killerIndex].kills += 1;

        StartCoroutine(waitBeforeRespawn(deadGuyIndex));
    }

    IEnumerator waitBeforeRespawn(int deadGuyIndex)
    {
        yield return new WaitForSeconds(m_timeBeforeRespawn);

        GameObject deadAvatar = avatars[deadGuyIndex];
        deadAvatar.SetActive(false);

        Destroy(deadAvatar);

        GameObject newPlayer = GameObject.Instantiate(PlayerAvatar);
        newPlayer.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        avatars[deadGuyIndex] = newPlayer;
        newPlayer.GetComponent<PlayerId>().m_id = deadGuyIndex;        
    }
}
