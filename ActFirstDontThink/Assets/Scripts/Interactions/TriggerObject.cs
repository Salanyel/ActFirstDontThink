using UnityEngine;
using System.Collections.Generic;

public class TriggerObject : MonoBehaviour {

    public List<ActionObject> targets;

    public void Activate()
    {

        Debug.Log(this.gameObject.name + " has been activated", this.gameObject);

        playUseAnimation();

        foreach (ActionObject t in targets)
        {
            t.activate();
        }
    }

    void playUseAnimation()
    {
        GetComponent<Animator>().SetBool(AnimationsVariables.m_interactibleObject_isUsed, true);
    }
}
