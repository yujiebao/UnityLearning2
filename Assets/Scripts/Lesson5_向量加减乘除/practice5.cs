using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice5 : MonoBehaviour
{
    private Vector3 move;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() {
        //改变相机代码卸载lateupdate中，update和lateupdate之间有动画，和特效等
        
        // Camera.main.transform.position = transform.position + move; //假的是世界坐标的偏移，应该加对象的坐标 （无法实现旋转）
        move = transform.forward*-4 + transform.up*7;
        Camera.main.transform.position = transform.position + move;
        Camera.main.transform.LookAt(transform);
    }
}
