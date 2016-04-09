using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class useInteractiveObject : MonoBehaviour {

    protected List<GameObject> m_objects;

    #region Unity Methodes

    void Start()
    {
        m_objects = new List<GameObject>();
    }

    void Update()
    {
        if (m_objects.Count > 0)
        {
            shouldUseObject();
        }        
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
            Debug.Log("Object triggered : " + m_objects[index].name, m_objects[index]);
            m_objects[index].GetComponent<TriggerObject>().Activate();
        }
        else
        {
            Debug.Log("No object to activate from " + this.gameObject.name, this.gameObject);
        }
    }

        virtual protected void shouldUseObject()
        {
            useNeariestInteractibleObject();
        }

    #endregion

}