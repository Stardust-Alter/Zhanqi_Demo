using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int tilePos; //位置信息
    public Tile parent;//父节点，寻路用
    public int action = -1;//行动力，寻路用


    public int cost=1;  //行走费用 excel配置

    public bool canWalk;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        tilePos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));   //初始化坐标

        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        CheckObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckObstacle()
    {
        bool result=Physics.Raycast(this.transform.position, Vector3.up, 1.0f);
        canWalk = !result;
    }

    public void RedHighlightTile()
    {
        meshRenderer.material.color = Color.red;
    }

    public void ResetTile()
    {
        meshRenderer.material.color = Color.white;
    }

}
