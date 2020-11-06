using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int moveRange = 5;

    
    
    
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
        ShowWalkAbleTile();
    }

    private void ShowWalkAbleTile()
    {
        for(int i=0;i<=GameManagement.instance.tiles.Length;i++)
        {
            float disX=
        }
    }
}
