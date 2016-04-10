using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class useInteractiveObject : MonoBehaviour {

    public List<GameObject> m_objects;

    #region Unity Methodes

    void Start()
    {
        m_objects = new List<GameObject>();
        initialize();
    }

    void Update()
    {
        if (m_objects.Count > 0)
        {
            shouldUseObject();
        }        
    }

    virtual protected void initialize()
    {

    }

    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.gameObject.tag == Tags.m_interactibleObject)
        {
            m_objects.Add(p_other.gameObject);
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (p_other.gameObject.tag == Tags.m_interactibleObject)
        {
            m_objects.Remove(p_other.gameObject);
        }
    }

        #endregion

        #region Methods

    protected void useNeariestInteractibleObject()
    {
        GameObject gameObject;
        float distance = -1;
        float neariestObject = -1;
        int index = -1;

        for(int i = 0; i < m_objects.Count; ++i)
        {
            gameObject = m_objects[i];
            distance = Vector3.Distance(transform.position, gameObject.transform.position);

            if (distance < neariestObject || neariestObject == -1)
            {
                index = i;
                neariestObject = distance;
            }
        }

        if (index != -1)
        {

            if (m_objects[index].GetComponent<TriggerObject>().m_canBeActivated)
            {
                Debug.Log("Object triggered : " + m_objects[index].name + " by player " + this.gameObject.GetComponent<PlayerId>().m_id, m_objects[index]);
                m_objects[index].GetComponent<TriggerObject>().setPlayerWhoUseIt(GetComponent<PlayerId>().m_id);
                m_objects[index].GetComponent<TriggerObject>().Activate();
                transform.LookAt(m_objects[index].transform.position);

                Debug.Log(transform.localEulerAngles.y);

                //Escroquerie
                Vector3 vector = new Vector3(0f, transform.localEulerAngles.y, 0f);
                transform.localEulerAngles = vector;

                if (GetComponent<PlayerController>() == null)
                {
                    GetComponent<Bot>().launchInteraction();
                }
                else
                {
                    GetComponent<PlayerController>().launchInteraction();
                }                    
            }         
            else
            {
                Debug.Log("The object has to wait before being activated again");
            }   
        }
        else
        {
            Debug.Log("No object to activate from " + this.gameObject.name, this.gameObject);
        }
    }

        virtual protected void shouldUseObject()
        {
        Debug.Log("Should Use Object");
            useNeariestInteractibleObject();
        }

    #endregion

}