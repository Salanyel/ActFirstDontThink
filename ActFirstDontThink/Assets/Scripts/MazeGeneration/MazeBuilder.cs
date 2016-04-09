using UnityEngine;
using System.Collections.Generic;

public class MazeBuilder : MonoBehaviour {

    public List<GameObject> roomPrefabs;
    public int roomSize = 10;
    public int size = 5;

    //List<GameObject> rooms;
    int roomOffset;

	// Use this for initialization
	void Start ()
    {
        roomOffset = roomSize / 2;

        // Creating cells
        GameObject cell = new GameObject("Cells");
	    for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                int roomIndex = Random.Range(0, roomPrefabs.Count - 1);
                GameObject newRoom = Instantiate(roomPrefabs[roomIndex]);
                newRoom.transform.SetParent(cell.transform);
                newRoom.transform.position = new Vector3(i * roomSize + roomOffset, 0, j * roomSize + roomOffset);
                //rooms.Add(newRoom);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
