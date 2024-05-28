using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerator : MonoBehaviour
{
    private Tilemap tilemap;
    [SerializeField] private RuleTile groundTile;  // Assuming RuleTile with 9 ground variations
    [SerializeField] private TileBase wallTile;
    [SerializeField] private TileBase doorTile;
    [SerializeField] private int roomWidth = 10;
    [SerializeField] private int roomHeight = 8;
    [SerializeField] private float floorTileProbability = 0.9f;
    [SerializeField] private int randomSeed = 0;
    [SerializeField] private bool debugMode = false;

    private int xStartPosition;
    private int yStartPosition;

    private enum TileType { Floor, Wall, Door }

    private void Start()
    {
        // Set the starting positions to center the room around the origin
        xStartPosition = -roomWidth / 2;
        yStartPosition = -roomHeight / 2;

        // Ensure roomWidth and roomHeight are even
        if (roomWidth % 2 != 0)
        {
            roomWidth++;
        }

        if (roomHeight % 2 != 0)
        {
            roomHeight++;
        }

        tilemap = GetComponent<Tilemap>();

        if (randomSeed != 0)
        {
            Random.InitState(randomSeed);
        }

        GenerateRoom();
    }

    private void GenerateRoom()
    {
        GenerateWalls();
        GenerateFloors();
        GenerateDoors();
    }

    private void GenerateWalls()
    {
        for (int x = xStartPosition; x < xStartPosition + roomWidth; x++)
        {
            for (int y = yStartPosition; y < yStartPosition + roomHeight; y++)
            {
                if (IsWallPosition(x, y))
                {
                    SetTile(x, y, TileType.Wall);
                }
            }
        }
    }

    private bool IsWallPosition(int x, int y)
    {
        return x == xStartPosition || x == xStartPosition + roomWidth - 1 || y == yStartPosition || y == yStartPosition + roomHeight - 1;
    }

    private void GenerateFloors()
    {
        for (int x = xStartPosition + 1; x < xStartPosition + roomWidth - 1; x++)
        {
            for (int y = yStartPosition + 1; y < yStartPosition + roomHeight - 1; y++)
            {
                if (Random.value <= floorTileProbability)
                {
                    SetTile(x, y, TileType.Floor);
                }
            }
        }
    }

    private void GenerateDoors()
    {
        // Bottom door
        SetTile(Random.Range(xStartPosition + 1, xStartPosition + roomWidth - 1), yStartPosition, TileType.Door);
        // Top door
        SetTile(Random.Range(xStartPosition + 1, xStartPosition + roomWidth - 1), yStartPosition + roomHeight - 1, TileType.Door);
        // Left door
        SetTile(xStartPosition, Random.Range(yStartPosition + 1, yStartPosition + roomHeight - 1), TileType.Door);
        // Right door
        SetTile(xStartPosition + roomWidth - 1, Random.Range(yStartPosition + 1, yStartPosition + roomHeight - 1), TileType.Door);
    }

    private void SetTile(int x, int y, TileType tileType)
    {
        TileBase tile = null;

        switch (tileType)
        {
            case TileType.Floor:
                tile = groundTile;  // Use the RuleTile that contains variations
                break;
            case TileType.Wall:
                tile = wallTile;
                break;
            case TileType.Door:
                tile = doorTile;
                break;
        }

        tilemap.SetTile(new Vector3Int(x, y, 0), tile);

        if (debugMode && tileType == TileType.Door)
        {
            Debug.Log($"Door placed at: ({x}, {y})");
        }
    }
}
