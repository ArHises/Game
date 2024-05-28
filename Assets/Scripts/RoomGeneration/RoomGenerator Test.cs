using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGeneratorTest : MonoBehaviour
{
    private Tilemap tilemap;
    public RuleTile wallsTile;
 //   public Tile[] floorTiles;

    [SerializeField] private int roomWidth = 13;
    [SerializeField] private int roomHeight = 9;
    private int xStartPosition;
    private int yStartPosition;

    [SerializeField] private int randomSeed = 0;
    [SerializeField] private bool debugMode = false;

    void Start()
    {
        tilemap = gameObject.GetComponentInChildren<Tilemap>();
        // Set a rule tile at position (0, 0)
        Vector3Int position = new Vector3Int(0, 0, 0);
        tilemap.SetTile(position, wallsTile);

        // Set the starting positions to center the room around the origin
        xStartPosition = -roomWidth / 2;
        yStartPosition = -roomHeight / 2;

        if (roomWidth % 2 != 0)
        {
            xStartPosition--;
        }

        if (roomHeight % 2 != 0)
        {
            yStartPosition--;
        }

        if (randomSeed != 0)
        {
            Random.InitState(randomSeed);
        }

        GenerateRoom();
    }
    private void GenerateRoom()
    {
        GenerateWalls();
//        GenerateFloors();
    }

    private void GenerateWalls()
    {
        for (int x = xStartPosition; x < xStartPosition + roomWidth; x++)
        {
            for (int y = yStartPosition; y < yStartPosition + roomHeight; y++)
            {
 //               if (IsWallPosition(x, y))
//                {
                    Vector3Int pos = new Vector3Int(x, y, 0);
                    tilemap.SetTile(pos, wallsTile);
 //               }
            }
        }
    }

    /*
    private void GenerateFloors()
    {
        for (int x = xStartPosition + 1; x < xStartPosition + roomWidth - 1; x++)
        {
            for (int y = yStartPosition + 1; y < yStartPosition + roomHeight - 1; y++)
            {
                if (!IsWallPosition(x, y))
                {
                    Vector3Int pos = new Vector3Int(x, y, 0);
                    TileBase randomTile = floorTiles[Random.Range(0, floorTiles.Length)];
                    tilemap.SetTile(pos, randomTile);
                }
            }
        }
    }
    */
    private bool IsWallPosition(int x, int y)
    {
        return x == xStartPosition || x == xStartPosition + roomWidth - 1 || y == yStartPosition || y == yStartPosition + roomHeight - 1;
    }
}
