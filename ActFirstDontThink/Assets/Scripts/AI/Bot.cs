using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bot : MonoBehaviour
{

    enum Actions
    {
        TRAVELLING,
        PLOTTING
    };

    NavMeshAgent agent;
    Actions currentAction;

    MazeBuilder builder;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        builder = GameObject.Find("MazeBuilder").GetComponent<MazeBuilder>();
    }
 
	// Update is called once per frame
	void Update ()
    {
        if (currentAction == Actions.TRAVELLING && agent.remainingDistance < 4.5f)
            actWithoutThinking();
        else if (currentAction == Actions.PLOTTING && agent.remainingDistance < 1f)
        {
            // TODO : trigger object
            actWithoutThinking();
        }
	}

    void actWithoutThinking()
    {

        int x, z;
        getCurrentCellIndex(out x, out z);

        if (Random.Range(0,2) == 1)
        {

            // Travelling to a new room
            int newX, newZ;
            nextRandomRoom(x, z, out newX, out newZ);

            Vector3 cellDestination = new Vector3(newX * 10 + 5, 0, newZ * 10 + 5);
            agent.SetDestination(cellDestination);
        }
        else
        {
            // Going to press another button
            //TODO : move to button
            float newX, newZ;
            List<GameObject> objectInRoom = FindObjectInRoom();
            int objectRand = Random.Range(0, objectInRoom.Count);

            GameObject objectChoice = objectInRoom[objectRand];

            newX = objectChoice.transform.position.x;
            newZ = objectChoice.transform.position.z;

            Vector3 destination = new Vector3(newX, 0.0f, newZ);
            agent.SetDestination(destination);
        }
    }


    /**
    *
    */
    void getCurrentCellIndex(out int x, out int z)
    {
        x = (int) Mathf.Floor(transform.position.x % 10);
        z = (int) Mathf.Floor(transform.position.z % 10);
    }

    //Fonction permettant de choisir aléatoirement la salle suivante
    //Numéro de la colonne : x
    //Numéro de la ligne : z
    void nextRandomRoom(int x, int z, out int newX, out int newZ)
    {
        int choiceMovement = Random.Range(0, 4);

        switch (choiceMovement)
        {
            
            case 0:
                //Mouvement vers la gauche si le pion n'est pas sur le bord gauche.
                //Si sur le bord gauche vas a droite
                if (x == 0)
                {
                    newX = x + 1;
                    newZ = z;
                }
                else
                {
                    newX = x - 1;
                    newZ = z;
                }
                break;

            case 1:
                //Mouvement vers la droite si le pion n'est pas sur le bord droit. 
                //Si sur le bord droit vas a gauche.
                if(x == builder.labyrinthSize - 1)
                {
                    newX = x - 1;
                    newZ = z;
                }
                else
                {
                    newX = x + 1;
                    newZ = z;
                }

                break;

            case 2:
                //Mouvement vers le haut si le pion n'est pas sur le bord haut
                //Vas vers le bas sinon
                if (z == 0)
                {
                    newX = x;
                    newZ = z + 1;
                }
                else
                {
                    newX = x;
                    newZ = z - 1;
                }
            
                break;

            case 3:
                //Mouvement vers le bas si le pion n'est pas sur le bord bas
                //Vas vers le haut sinon
                if (z == builder.labyrinthSize - 1)
                {
                    newX = x;
                    newZ = z - 1;
                }
                else
                {
                    newX = x;
                    newZ = z + 1;
                }
                break;

            default:
                newX = x;
                newZ = z;
                break;
        }
    }

   List<GameObject> FindObjectInRoom()
    {

        //TODO : Completer le tag !!!!!
        GameObject[] listOfObject = GameObject.FindGameObjectsWithTag("InteractibleObject");
        List<GameObject> listOfObjectInRoom = new List<GameObject>();
        
        int botX, botY;
        this.getCurrentCellIndex(out botX, out botY);

        int itemX, itemY;
        foreach(GameObject item in listOfObject){
            itemX = (int)Mathf.Floor(item.transform.position.x % 10);
            itemY = (int)Mathf.Floor(item.transform.position.y % 10);
            
            if(itemX == botX && itemY == botY)
                listOfObjectInRoom.Add(item);
             
        }


        return listOfObjectInRoom;
    }
}
