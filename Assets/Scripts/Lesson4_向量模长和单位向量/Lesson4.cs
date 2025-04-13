using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 向量
        //三维向量 vector3 
        // 1.位置   代表一个点
            print(transform.position);
        // 2.方向    代表一个方向\
        print(transform.forward);
        #endregion

        #region 知识点二 两点决定一个向量
        //A和B点
        Vector3 A = new Vector3(1,2,4);
        Vector3 B = new Vector3(2,6,7);
        //AB和BA向量
        Vector3 AB = B - A;
        Vector3 BA = A - B;
        #endregion

        #region 知识点三 零向量和负向量
        print(Vector3.zero);
        print(A); 
        print(-A);
        print(-1*A); 

        #endregion

        #region 知识点四 向量的模长
        print(AB.magnitude);
        Vector3 C = new Vector3(1,2,4);
        print(C.magnitude);  // 相对与原点的距离 也视为一个向量

        Vector3.Distance(A,B);//距离
        #endregion

        #region 知识点五 单位向量
        // Vector3中提供了获取单位向量的成员属性（\
        print(AB.normalized);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
