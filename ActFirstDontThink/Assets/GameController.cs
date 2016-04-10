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

    public GameObject m_player1;

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

            if (i == 1)
            {
                m_player1 = GameObject.FindGameObjectWithTag(Tags.m_cameraP1);
            }
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

        switch (deadGuyIndex)
        {
            case 1:
                cameraGetOut(m_player1);
                break;

            case 2:
                cameraGetOut(m_player1);
                break;

            default:
                break;
        }

        Destroy(deadAvatar);

        GameObject newPlayer = GameObject.Instantiate(PlayerAvatar);
        newPlayer.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        avatars[deadGuyIndex] = newPlayer;
        newPlayer.GetComponent<PlayerId>().m_id = deadGuyIndex;

        switch (deadGuyIndex)
        {
            case 1:
                cameraGetIn(m_player1, newPlayer);
                break;

            case 2:
                cameraGetIn(m_player1, newPlayer);
                break;

            default:
                break;
        }
    }

    void cameraGetOut(GameObject p_camera)
    {
        p_camera.transform.SetParent(transform);
    }

    void cameraGetIn(GameObject p_camera, GameObject p_player)
    {
        p_camera.transform.SetParent(p_player.transform);
        p_camera.GetComponent<CameraController>().m_player = p_player;
    }
}
