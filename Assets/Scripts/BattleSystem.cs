using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;


    public Unit[] players;
    public Unit[] enemys;

    public List<Unit> units = new List<Unit>();

    public int activeUnitIndex=-1;     //当前行动单位序号              
    public Unit activeUnit;            //当前行动单位

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        Init();
        UnitSort();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            activeUnit = GetNextActiveUnit();
            Vector2Int currentPositon = new Vector2Int(Mathf.RoundToInt(activeUnit.transform.position.x), Mathf.RoundToInt(activeUnit.transform.position.z));
            TileManager.instance.SetMoveBoundary(currentPositon, activeUnit.moveDistance);
            TileManager.instance.ShowMoveBoundary();
        }

    }


    //将单位加入行动列表
    void Init()
    {
        foreach(Unit u in players)
        {
            units.Add(u);
        }
        foreach (Unit u in enemys)
        {
            units.Add(u);
        }
    }


    //行动顺序排序
    void UnitSort()
    {
        units.Sort(
                delegate (Unit p1, Unit p2)
                {
                       return p1.speed == p2.speed ? 0 : (p1.speed > p2.speed) ? 1 : -1;
                });
    }

    //选择下一个行动的单位
    private Unit GetNextActiveUnit()
    {
        activeUnitIndex = (activeUnitIndex + 1) % units.Count;
        return units[activeUnitIndex];
    }


    private void ShowNextActiveUnit()
    {

    }


}
