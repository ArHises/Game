using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    public Vector2Int gridPosition;
    public GameObject roomPrefab;
    public bool doorTop;
    public bool doorBottom;
    public bool doorLeft;
    public bool doorRight;
    public int enemyCount;

    public void EnemyKilled()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            UnlockDoors();
        }
    }

    void UnlockDoors()
    {
        Transform doors = roomPrefab.transform.Find("Doors");
        if (doors != null)
        {
            doors.Find("DoorTop").gameObject.SetActive(true);
            doors.Find("DoorBottom").gameObject.SetActive(true);
            doors.Find("DoorLeft").gameObject.SetActive(true);
            doors.Find("DoorRight").gameObject.SetActive(true);
        }
    }
}

public class RoomGenerator : MonoBehaviour
{
    public GameObject[] roomPrefabs;
    public int gridWidth = 5;
    public int gridHeight = 5;
    public float roomSpacing = 10f;
    private List<Room> rooms = new List<Room>();

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // Randomly choose a room prefab
                GameObject roomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
                Vector2Int gridPosition = new Vector2Int(x, y);

                // Instantiate room and set its position
                GameObject roomInstance = Instantiate(roomPrefab, new Vector3(x * roomSpacing, y * roomSpacing, 1), Quaternion.identity);

                // Add room to list with its grid position
                Room room = new Room
                {
                    gridPosition = gridPosition,
                    roomPrefab = roomInstance,
                    doorTop = false,
                    doorBottom = false,
                    doorLeft = false,
                    doorRight = false
                };
                rooms.Add(room);
            }
        }
        ConnectRooms();
    }

    void ConnectRooms()
    {
        foreach (Room room in rooms)
        {
            // Check adjacent rooms to connect doors
            Room topRoom = rooms.Find(r => r.gridPosition == room.gridPosition + Vector2Int.up);
            if (topRoom != null)
            {
                room.doorTop = true;
                topRoom.doorBottom = true;
            }

            Room bottomRoom = rooms.Find(r => r.gridPosition == room.gridPosition + Vector2Int.down);
            if (bottomRoom != null)
            {
                room.doorBottom = true;
                bottomRoom.doorTop = true;
            }

            Room leftRoom = rooms.Find(r => r.gridPosition == room.gridPosition + Vector2Int.left);
            if (leftRoom != null)
            {
                room.doorLeft = true;
                leftRoom.doorRight = true;
            }

            Room rightRoom = rooms.Find(r => r.gridPosition == room.gridPosition + Vector2Int.right);
            if (rightRoom != null)
            {
                room.doorRight = true;
                rightRoom.doorLeft = true;
            }

            // Update room prefab to show doors (assuming door objects are children of the room prefab)
            UpdateRoomDoors(room);
        }
    }

    void UpdateRoomDoors(Room room)
    {
        Transform doors = room.roomPrefab.transform.Find("Doors");
        if (doors != null)
        {
            doors.Find("DoorTop").gameObject.SetActive(room.doorTop);
            doors.Find("DoorBottom").gameObject.SetActive(room.doorBottom);
            doors.Find("DoorLeft").gameObject.SetActive(room.doorLeft);
            doors.Find("DoorRight").gameObject.SetActive(room.doorRight);
        }
    }
}
