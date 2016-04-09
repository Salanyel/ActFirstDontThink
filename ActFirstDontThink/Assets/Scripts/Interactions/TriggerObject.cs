using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TriggerObject : MonoBehaviour {

    List<ActionObject> targets;
    bool m_canBeActivated;
    int m_playerId;

    public float m_timeBeforeNewActivation;    

    void Start()
    {
        targets = new List<ActionObject>();
        m_canBeActivated = true;
    }

    public void setPlayerWhoUseIt(int p_id)
    {
        m_playerId = p_id;
    }

    public void Activate()
    {

        if (!m_canBeActivated)
        {
            Debug.Log("The object has to wait before being activated again");
            return;
        }

        Debug.Log(this.gameObject.name + " has been activated by player " + m_playerId, this.gameObject);

        m_canBeActivated = false;

        playUseAnimation();

        foreach (ActionObject t in targets)
        {
            t.activate();
        }

        StartCoroutine(waitBeforeNewActivation());

    }

    void playUseAnimation()
    {
        GetComponent<Animator>().SetBool(AnimationsVariables.m_interactibleObject_isUsed, true);
    }

    IEnumerator waitBeforeNewActivation()
    {
        yield return new WaitForSeconds(m_timeBeforeNewActivation);
        m_canBeActivated = true;
    }
}
