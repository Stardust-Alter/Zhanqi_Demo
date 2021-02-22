using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit: MonoBehaviour
{
    public string unitName;             //名称
    public int maxHP;                   //最大生命值
    public int currentHP;               //当前生命值
    public int damage;                  //伤害
    public int speed;                   //速度
    public int moveDistance=5;          //移动距离
    public float moveSpeed = 1.0f;      //移动速度

    public void Move(Tile tile)       //移动方法
    {
        StartCoroutine(MoveCO(tile));
    }

    IEnumerator MoveCO(Tile tile)       //移动协程
    {
        Vector3 targetPosition=Vector3.zero;
        Stack<Tile> tileList = new Stack<Tile>();
        Tile nexTile;

        while (tile.parent!=null)
        {
            tileList.Push(tile);
            tile = tile.parent;
        }

        while (tileList.Count!=0)
        {
            nexTile = tileList.Pop();
            targetPosition = new Vector3(nexTile.tilePos.x, 0.5f, nexTile.tilePos.y);
            while(transform.position!=targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return new WaitForSeconds(0);
            }
        }
    }

    public void getHurt()
    {

    }

    public void Die()
    {
        BattleSystem.instance.units.Remove(this);
    }
}