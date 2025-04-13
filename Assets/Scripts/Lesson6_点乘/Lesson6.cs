using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        #region 

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region  补充知识 调试划线 
        // Debug.DrawLine(this.transform.position, this.transform.forward+this.transform.position, Color.red);  //划线  --线段  第二个参数为位置
        Debug.DrawRay(transform.position,this.transform.forward, Color.yellow);// 划线--射线  第二个参数为方向
        #endregion
   
        #region  知识点一 通过点乘判断对象的方向
        //vector3提供了计算点乘的方法
        Debug.DrawRay(transform.position,transform.forward, Color.yellow);
        Debug.DrawRay(transform.position,(target.position - transform.position).normalized , Color.red);

        float dotResult =Vector3.Dot(transform.forward,(target.position - transform.position ));
        if (dotResult >= 0)   
        { 
            print("他在我的前方");
        }
        else
        {
            print("他在我的后方");
        }
        #endregion
   
        #region  知识点二 通过点乘推导公式计算夹角
        {//1.用单位向量点乘
        dotResult = Vector3.Dot(transform.forward.normalized, (target.position - transform.position).normalized);
        //2.用反三角函数得出弧度
        float angle = Mathf.Acos(dotResult);
        print("夹角为："+angle*Mathf.Rad2Deg);}  //  知识点二代码等价于Vector3.Angle(transform.forward, (target.position - transform.position));
        #endregion
    }
}
