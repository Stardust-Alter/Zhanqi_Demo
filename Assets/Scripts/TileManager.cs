using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;    //单例模式


    public int tileWidth = 20;
    public int tileHeigth = 20;

    public Tile[,] tiles;
    public Tile fisrtTile;

    private Stack<Tile> moveBoundary;           //这个栈就是用来存放可移动节点

    private void Awake()
    {
        instance = this;
        tiles = new Tile[tileWidth, tileHeigth];
    }

    void Start()
    {
        Init();      
    }

    void Init()
    {
        int i = 0;
        int j = 0;
        GameObject[]  tileset = GameObject.FindGameObjectsWithTag("Tile");


        foreach(var tile in tileset)
        {
            tiles[i,j] = tile.GetComponent<Tile>();
            Debug.Log(tile.GetComponent<Tile>().tilePos);
            //Debug.Log(tiles[i, j].tilePos);
            i++;
            if(i==20)
            {
                i = 0;
                j++;
            }
        }      
    }


    public void SetMoveBoundary(Vector2Int pos,int moveRange)
    {
        Queue<Tile> openList = new Queue<Tile>();
        Stack<Tile> closeList = new Stack<Tile>();
        if (moveBoundary == null) moveBoundary = new Stack<Tile>();

        foreach (var tile in tiles)//初始化节点
        {
            tile.action = -1;
            tile.parent = null;
        }

        tiles[pos.x, pos.y].action = moveRange;//设置初始点行动力                                        TODO人物行动力
        openList.Enqueue(tiles[pos.x, pos.y]);//将初始点加入openList
        fisrtTile = tiles[pos.x, pos.y];

        while (openList.Count != 0)
        {
            var node = openList.Dequeue();
            //对4个方向检测
            if (node.tilePos.x + 1 < tileWidth)
                check(tiles[node.tilePos.x + 1, node.tilePos.y], node);

            if (node.tilePos.x - 1 >= 0)
                check(tiles[node.tilePos.x - 1, node.tilePos.y], node);

            if (node.tilePos.y + 1 < tileHeigth)
                check(tiles[node.tilePos.x, node.tilePos.y + 1], node);

            if (node.tilePos.y - 1 >= 0)
                check(tiles[node.tilePos.x, node.tilePos.y - 1], node);

            //if (!GameDataManager.Instance.characters.Exists(p => p.Pos == node.pos))
                closeList.Push(node);
        }
        //isMoved = true;
        moveBoundary = closeList;//closelist里面的就是移动范围了

        //子方法
        void check(Tile node1, Tile node)
        {
                if (!closeList.Contains(node1))
                {
                    var act = node.action - node1.cost;//当前点到该点花费的体力
                    if (act >= 0)
                    {
                        if (node1.action < act)//只有大于原来的移动力才选择从这边走
                        {
                            if (!openList.Contains(node1))//不在openlist才加入
                                openList.Enqueue(node1);
                            node1.action = act;//设置到该节点的体力
                            node1.parent = node;//设置父节点

                        }
                    }
                }
        }
    }

    public void ShowMoveBoundary()
    {
        while(moveBoundary.Count!=0)
        {
            moveBoundary.Pop().RedHighlightTile();
        }
    }


}
