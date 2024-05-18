using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int numberOfRooms = 5;

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        for (int i = 0; i < numberOfRooms; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
            Instantiate(roomPrefab, randomPosition, Quaternion.identity);
        }
    }
}
