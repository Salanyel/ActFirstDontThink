using UnityEngine;
using System.Collections.Generic;

public class MazeBuilder : MonoBehaviour {

    public List<GameObject> roomPrefabs;
    public int roomSize = 10;
    public int labyrinthSize = 5;

    GameObject[,] rooms;
    int roomOffset;

	// Use this for initialization
	void Start ()
    {
        roomOffset = roomSize / 2;

        rooms = new GameObject[labyrinthSize,labyrinthSize];

        // Creating cells
        GameObject cell = new GameObject("Cells");
	    for (int i = 0; i < labyrinthSize; ++i)
        {
            for (int j = 0; j < labyrinthSize; ++j)
            {
                int roomIndex = Random.Range(0, roomPrefabs.Count);
                GameObject newRoom = Instantiate(roomPrefabs[roomIndex]);
                newRoom.transform.SetParent(cell.transform);
                newRoom.transform.position = new Vector3(i * roomSize + roomOffset, 0, j * roomSize + roomOffset);
                newRoom.transform.rotation = Quaternion.Euler(new Vector3(0, 90*Random.Range(0,4), 0));
                rooms[i,j] = newRoom;
            }
        }
	}

    public int getTypeCell(int x, int z)
    {
        //TODO Amarre
    }
}
