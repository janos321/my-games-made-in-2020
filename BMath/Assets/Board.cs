using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public GameObject Game2Gameobject;
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }

    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);
    private Vector3Int torles = new Vector3Int(999, 999, 999);
    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<Piece>();

        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        if(torles != new Vector3Int(999, 999, 999)&&torles!=null)
        {
            tilemap.SetTile(torles, null);
            torles = new Vector3Int(999, 999, 999);

        }
        Game2.pontok++;
        int random = -1;
        while (random == -1)
        {
            random = Random.Range(0, tetrominoes.Length);
            if(random>6)
            {
                int random2=0;
                if (tetrominoes[random].tetromino==Tetromino.G)
                {
                    random2 = Random.Range(0, 1);
                }
                else
                   if (tetrominoes[random].tetromino == Tetromino.Q)
                {
                    random2 = Random.Range(0, 5);
                }
                else
                                if (tetrominoes[random].tetromino == Tetromino.W)
                {
                    random2 = Random.Range(0, 2);
                }
                else
                                                if (tetrominoes[random].tetromino == Tetromino.E)
                {
                    random2 = Random.Range(0, 2);
                }
                
                if (random2!=0)
                {
                    random = -1;
                }
            }
        }
        //int random = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];

        activePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(activePiece, spawnPosition))
        {
            Set(activePiece);
        }
        else
        {
            GameOver();
        }
    }
    public void BackGameOver()
    {
        tilemap.ClearAllTiles();

        // Do anything else you want on game over here..
    }
    public void GameOver()
    {
        Game2Gameobject.GetComponent<Game2>().End();
        tilemap.ClearAllTiles();

        // Do anything else you want on game over here..
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    public void Gyokvonas(Vector3Int piece,int mennyit)
    {
        RectInt bounds = Bounds;
        List<Vector3Int> pieces=new List<Vector3Int>();
        if(tilemap.HasTile(new Vector3Int(piece.x-1, piece.y, 0)))
        {
            pieces.Add(new Vector3Int(piece.x-1, piece.y, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x, piece.y-1, 0)))
        {
            pieces.Add(new Vector3Int(piece.x, piece.y-1, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x+1, piece.y, 0)))
        {
            pieces.Add(new Vector3Int(piece.x+1, piece.y, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x, piece.y+1, 0)))
        {
            pieces.Add(new Vector3Int(piece.x, piece.y+1, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x-1, piece.y+1, 0)))
        {
            pieces.Add(new Vector3Int(piece.x-1, piece.y+1, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x+1, piece.y-1, 0)))
        {
            pieces.Add(new Vector3Int(piece.x+1, piece.y-1, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x+1, piece.y+1, 0)))
        {
            pieces.Add(new Vector3Int(piece.x+1, piece.y+1, 0));
        }
        if (tilemap.HasTile(new Vector3Int(piece.x-1, piece.y-1, 0)))
        {
            pieces.Add(new Vector3Int(piece.x-1, piece.y-1, 0));
        }
        if(mennyit>pieces.Count)
        {
            mennyit = pieces.Count;
        }
        while (mennyit!=0)
        {
            int index = Random.Range(0, pieces.Count);
            if(pieces[index]!= new Vector3Int(piece.x, piece.y, 0))
            {
                tilemap.SetTile(pieces[index], null);
                pieces[index] = new Vector3Int(piece.x, piece.y, 0);
                mennyit--;
            }

        }
        torles = piece;
        //tilemap.SetTile(activePiece.po, null);
        /*for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            // The line is not full if a tile is missing
            if (!tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;*/
    }
    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = Bounds;

        // The position is only valid if every cell is valid
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            // An out of bounds tile is invalid
            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            // A tile already occupies the position, thus invalid
            if (tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = Bounds;
        int row = bounds.yMin;

        // Clear from bottom to top
        while (row < bounds.yMax)
        {
            // Only advance to the next row if the current is not cleared
            // because the tiles above will fall down when a row is cleared
            if (IsLineFull(row))
            {
                LineClear(row);
            }
            else
            {
                row++;
            }
        }
    }

    public bool IsLineFull(int row)
    {
        RectInt bounds = Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            // The line is not full if a tile is missing
            if (!tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    public void LineClear(int row)
    {
        RectInt bounds = Bounds;

        // Clear all tiles in the row
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }

        // Shift every row above down one
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, above);
            }

            row++;
        }
    }
}
