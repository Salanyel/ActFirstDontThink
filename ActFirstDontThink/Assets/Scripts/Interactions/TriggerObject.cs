using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TriggerObject : MonoBehaviour {

    public List<ActionObject> targets;
    public bool m_canBeActivated;
    int m_playerId;
    GameController m_gameController;

    public float m_timeBeforeNewActivation;    

    void Start()
    {
        m_canBeActivated = true;

        foreach(ActionObject actionObject in targets)
        {
            actionObject.setTriggerObject(this);
        }

        m_gameController = GameController.FindObjectOfType<GameController>();

    }

    public void setPlayerWhoUseIt(int p_id)
    {
        m_playerId = p_id;
    }

    public void Activate()
    {

        if (!m_canBeActivated)
        {
            return;
        }

        Debug.Log(this.gameObject.name + " has been activated by player " + m_playerId, this.gameObject);

        m_canBeActivated = false;

        playUseAnimation();

        StartCoroutine(waitBeforeActivation());
                    
    }

    void playUseAnimation()
    {
        GetComponent<Animator>().SetBool(AnimationsVariables.m_interactibleObject_isUsed, true);
    }

    public void playerKilled(int p_index)
    {
        Debug.Log("Player " + p_index + " has been killed by the player " + m_playerId);
        m_gameController.OnBotDeath(p_index, m_playerId);
    }

    IEnumerator waitBeforeNewActivation()
    {
        yield return new WaitForSeconds(m_timeBeforeNewActivation);
        m_canBeActivated = true;
    }

    IEnumerator waitBeforeActivation()
    {
        yield return new WaitForSeconds(2f);

        foreach (ActionObject t in targets)
        {
            t.activate();
        }

        StartCoroutine(waitBeforeNewActivation());

    }
}
