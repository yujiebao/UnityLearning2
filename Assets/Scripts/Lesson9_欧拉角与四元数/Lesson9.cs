using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Lesson9 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 四元数 Quaternion
        // 四元数 Q = [cos (β/2) , sin(β/2)x,sin(β/2)y,sin(β/2)z]
        // Quaternion q = new Quaternion( sin(β/2)x,sin(β/2)y,sin(β/2)z,cos (β/2));
        //计算原理
        Quaternion q = new Quaternion(1 * Mathf.Sin(30*Mathf.Deg2Rad),0,0,Mathf.Cos(30*Mathf.Deg2Rad));  //绕x轴旋转60度
        GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
        a.name = "q";
        a.transform.rotation = q;
        
        //unity提供的方法
        //与上面的方法等价
        Quaternion q2 = Quaternion.AngleAxis(60, Vector3.right);
        GameObject a2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        a2.name = "q2";
        a2.transform.rotation = q2;
        #endregion

        #region 知识点二 四元数和欧拉角的转换
        //1.欧拉角转四元数 
        Quaternion q1 = Quaternion.Euler(new Vector3(30,0,0));   //绕x轴旋转30度
        Quaternion q3 = Quaternion.Euler(30,0,0);

        //2.四元数转欧拉角
        print(q1.eulerAngles);
        #endregion

        #region 知识点三 四元数弥补的缺点
        // 1.同一旋转的表示不唯一

        // 2.万向节死锁
        // 达到死锁条件下  仍按照设定的角度旋转
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        //四元数相乘代表旋转四元数
        //旋转的角度在-180-180(检查窗口)   解决同一旋转表示不唯一的问题
        this.transform.rotation *=Quaternion.AngleAxis(1,Vector3.up);    //代表自己坐标的y轴旋转1度
    }
}
