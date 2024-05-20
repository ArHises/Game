using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject nextRoomTrigger;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            nextRoomTrigger.SetActive(true);
        }
    }
}
