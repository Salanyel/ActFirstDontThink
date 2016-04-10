using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class ConfigPrefabs{
	public List<GameObject> configPrefs;
}

public class MazeBuilder : MonoBehaviour {

    public List<GameObject> roomPrefabs;
	public List<ConfigPrefabs> roomConfigPrefabs;
    public int roomSize = 10;
    public int labyrinthSize = 5;

    int[,] roomTypes;
    GameObject[,] rooms;
    int roomOffset;

	// Use this for initialization
	void Awake ()
    {
        roomOffset = roomSize / 2;

        rooms = new GameObject[labyrinthSize,labyrinthSize];
        roomTypes = new int[labyrinthSize, labyrinthSize];

        // Creating cells
        GameObject cell = new GameObject("Cells");
	    for (int i = 0; i < labyrinthSize; ++i)
        {
            for (int j = 0; j < labyrinthSize; ++j)
            {
                int roomIndex = Random.Range(0, roomPrefabs.Count);
                GameObject newRoom = Instantiate(roomPrefabs[roomIndex]);
                newRoom.transform.SetParent(cell.transform);

				Vector3 pos = new Vector3(i * roomSize + roomOffset, 0, j * roomSize + roomOffset);
				Vector3 rot = new Vector3 (0, 90 * Random.Range (0, 4), 0);

				newRoom.transform.position = pos;
				newRoom.transform.rotation = Quaternion.Euler(rot);

				if (roomConfigPrefabs [roomIndex].configPrefs.Count > 0) {
					int confIndex = Random.Range (0, roomConfigPrefabs [roomIndex].configPrefs.Count);
					GameObject newRoomConfig = Instantiate (roomConfigPrefabs[roomIndex].configPrefs[confIndex]);
					newRoomConfig.transform.SetParent (cell.transform);
					newRoomConfig.transform.position = pos;
					newRoomConfig.transform.rotation = Quaternion.Euler (rot);

				}
                
				rooms[i,j] = newRoom;
                roomTypes[i, j] = roomIndex;
            }
        }
	}

    public int getTypeCell(int x, int z)
    {
        return roomTypes[x, z] + 1;
    }
}
