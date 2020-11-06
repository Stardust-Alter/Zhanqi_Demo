using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool canWalk;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("OnmouseEnter");
    }

    private void OnMouseExit()
    {
        Debug.Log("OnmouseExit");
    }

    private void CheckObstacle()
    {
        bool result=Physics.Raycast(this.transform.position, Vector3.up, 1.0f);
        canWalk = !result;
    }
}
