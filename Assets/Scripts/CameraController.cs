using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public float hMoveSpeed = 20.0f;  //水平平移速度
    public float vMoveSpeed = 20.0f;  //竖直平移速度

    public GameObject center;

    void Update()
    {
        float fDeltaTime = Time.deltaTime;

        //控制位移
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position+= new Vector3(0,0, vMoveSpeed * fDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= new Vector3(vMoveSpeed * fDeltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= new Vector3(0, 0, vMoveSpeed * fDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(vMoveSpeed * fDeltaTime, 0, 0);
        }

        //控制旋转

        if (Input.GetKeyDown(KeyCode.Q))
        {

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)
            {
                center.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
            transform.RotateAround(center.transform.position, Vector3.up, 90);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)
            {
                center.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
            transform.RotateAround(center.transform.position, Vector3.up, -90);
        }

    }
}
