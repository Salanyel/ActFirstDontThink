using UnityEngine;
using System.Collections.Generic;

public class TriggerObject : MonoBehaviour {

    public List<ActionObject> targets;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Activate()
    {
        foreach (ActionObject t in targets)
        {
            t.activate();
        }
    }
}
