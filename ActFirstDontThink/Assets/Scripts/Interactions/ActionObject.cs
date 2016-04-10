using UnityEngine;
using System.Collections;

public class ActionObject : MonoBehaviour {

    public BoxCollider m_killingZone;
    public TriggerObject m_triggerObject;
    void Start()
    {
        initialize();
    }

    virtual protected void initialize()
    {
        foreach(BoxCollider box in GetComponents<BoxCollider>())
        {
            if (box.isTrigger)
            {
                m_killingZone = box;
                m_killingZone.enabled = false;
            }
        }        
    }

    virtual public void disableKillingZone()
    {
        m_killingZone.enabled = false;
    }

    public void setTriggerObject(TriggerObject p_trigger)
    {
        m_triggerObject = p_trigger;
    }

    void OnTriggerEnter(Collider p_other)
    {

        if (!m_killingZone.enabled)
        {
            return;
        }            

        if (p_other.gameObject.tag == Tags.m_avatar)
        {
            Destroy(p_other.gameObject);
            m_triggerObject.playerKilled(p_other.gameObject.GetComponent<PlayerId>().m_id);            
        }
    }

    public void activate()
    {
        playUseAnimation();
        m_killingZone.enabled = true;
        Debug.Log("Killing zone : " + m_killingZone.enabled);
    }    

    void playUseAnimation()
    {
        GetComponent<Animator>().SetBool(AnimationsVariables.m_interactibleObject_isUsed, true);
    }

}
