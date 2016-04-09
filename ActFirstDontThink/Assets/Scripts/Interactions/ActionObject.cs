using UnityEngine;
using System.Collections;

public class ActionObject : MonoBehaviour {

    public void activate()
    {
        playUseAnimation();
    }

    void playUseAnimation()
    {
        GetComponent<Animator>().SetBool(AnimationsVariables.m_interactibleObject_isUsed, true);
    }

}
