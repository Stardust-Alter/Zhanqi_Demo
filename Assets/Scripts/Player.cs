using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int moveRange = 3;
    [SerializeField] private int moveSpeed = 1;

    public bool hasMove;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameManagement.instance.selectPlayer = this;
        ShowWalkAbleTile();
    }

    private void ShowWalkAbleTile()
    {
        if(hasMove)
        {
            return;
        }


        for (int i=0;i<GameManagement.instance.tiles.Length;i++)
        {
            float disX = Mathf.Abs(transform.position.x - GameManagement.instance.tiles[i].transform.position.x);
            float disZ = Mathf.Abs(transform.position.z - GameManagement.instance.tiles[i].transform.position.z);
            if(disX+disZ<=moveRange)
            {
                if(GameManagement.instance.tiles[i].canWalk)
                {
                    GameManagement.instance.tiles[i].RedHighlightTile();
                }
            }
        }
    }


    public void Move(Transform _transform)
    {
        StartCoroutine(MoveCO(_transform));
    }

    IEnumerator MoveCO(Transform _transform)
    {
        while(transform.position.x!=_transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_transform.position.x, transform.position.y, transform.position.z),moveSpeed*Time.deltaTime);
            yield return new WaitForSeconds(0);
        }

        while (transform.position.z != _transform.position.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, _transform.position.z), moveSpeed * Time.deltaTime);
            yield return null;
        }

        hasMove = true;
        ResetTiles();
    }

    private void ResetTiles()
    {
        for(int i=0;i<GameManagement.instance.tiles.Length;i++)
        {
            GameManagement.instance.tiles[i].ResetTile();
        }
    }
}
