using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11 : MonoBehaviour
{
    public Transform testObj;
    // Start is called before the first frame update
    void Start()
    {
        // 在进行旋转时 使用四元数相乘进行旋转  
        // 使用欧拉角旋转时存在  不唯一 和 死锁问题
        // 四元数相乘进行旋转时相对的坐标系是自身坐标系

        #region 知识点一 四元数相乘
        Quaternion q1 = Quaternion.AngleAxis(30,Vector3.up);
        testObj.rotation *=q1;
        #endregion

        #region 知识点二 四元数乘以向量
        Vector3 v = Vector3.forward;
        print(v);
        print(q1*v);    //就是将向量绕y旋转30度
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
