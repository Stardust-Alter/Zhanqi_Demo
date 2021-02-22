using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))   //判断鼠标点击
        {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Tile"));
                if (isCollider)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                    BattleSystem.instance.activeUnit.Move(tile);
                }
        }
    }
}
