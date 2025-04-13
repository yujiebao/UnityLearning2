using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 弧度，角度转换
        //弧度转角度
        float rad = 1f;
        float anger = rad * Mathf.Rad2Deg;    //Rad2Deg = 57.29578f   ---弧度转角度
        Debug.Log("弧度转角度：" + anger);
        //角度转弧度
        float angle = 180f;
        float radian = angle * Mathf.Deg2Rad;    //Deg2Rad = 0.0174533f   ---角度转弧度
        Debug.Log("角度转弧度：" + radian);
        #endregion
    
        #region  三角函数
        //注意Mathf中的三角函数相关函数传入的参数是弧度，而不是角度
        print(Mathf.Sin(30*Mathf.Deg2Rad));
        #endregion
   
        #region 反三角函数 
        //反三角函数得到的也是弧度而不是角度
        print(Mathf.Asin(0.5f));  
        print(Mathf.Asin(0.5f)*Mathf.Rad2Deg);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
