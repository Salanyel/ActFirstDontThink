using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour
{

    enum Actions
    {
        TRAVELLING,
        PLOTTING
    };

    NavMeshAgent agent;
    Actions currentAction;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (agent.remainingDistance < 0.5f)
        {
            if (currentAction == Actions.PLOTTING)
            {
                // TODO: trigger closest object
            }

            actWithoutThinking();
        }
	}

    void actWithoutThinking()
    {
        if (Random.Range(0,1) == 1)
        {
            // Travelling to a new room
        }
        else
        {
            // Going to press another button
        }
    }

}
