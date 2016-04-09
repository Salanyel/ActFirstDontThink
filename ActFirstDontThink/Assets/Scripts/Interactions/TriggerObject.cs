using UnityEngine;
using System.Collections.Generic;

public class TriggerObject : MonoBehaviour {

    public List<ActionObject> targets;

    public void Activate()
    {

        Debug.Log(this.gameObject.name + " has been activated", this.gameObject);

        foreach (ActionObject t in targets)
        {
            t.activate();
        }
    }
}
