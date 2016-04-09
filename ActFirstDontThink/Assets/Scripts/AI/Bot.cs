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

    public MazeBuilder builder;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        builder = GameObject.Find("MazeBuilder").GetComponent<MazeBuilder>();
    }
 
	// Update is called once per frame
	void Update ()
    {
        if (currentAction == Actions.TRAVELLING)
        {
            // TODO: trigger closest object
        }
        else
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
        if (Random.Range(0,2) == 1)
        {
            // Travelling to a new room
            int x, z, newX, newZ;
            getCurrentCellIndex(out x, out z);
            nextRandomRoom(x, z, out newX, out newZ);
        }
        else
        {
            // Going to press another button
            //TODO : move to button
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
}
