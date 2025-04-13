using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region Mathf
        //Math   ---System namespace（C#）   Mathf   --------UnityEngine namespace unity封装，增加了试用于游戏开发的方法（包含Math的方法，一般使用Mathf）
        //1.π
        Debug.Log(Mathf.PI);
        //2.绝对值
        Debug.Log(Mathf.Abs(-10));
        //3.向上取整
        Debug.Log(Mathf.Ceil(10.1f));
        //4.向下取整  强制转换---默认为向下取整
        Debug.Log(Mathf.Floor(10.9f));
        //5.四舍五入
        Debug.Log(Mathf.Round(10.5f));
        //6.平方根
        Debug.Log(Mathf.Sqrt(16));
        //7.钳制函数    值在[min,max]之间，否则返回min或max
        Debug.Log(Mathf.Clamp(10, 11, 20));
        Debug.Log(Mathf.Clamp(21, 11, 20));
        Debug.Log(Mathf.Clamp(15, 11, 20));
        //8.获取最大值    
        Debug.Log(Mathf.Max(1,2,3,4,5,10, 20));
        //9.获取最小值
        Debug.Log(Mathf.Min(1, 2, 3, 4, 5, 10, 20));
        //10.一个数的幂次
        Debug.Log(Mathf.Pow(2,5));
        //11.返回一个数的平方根
        Debug.Log(Mathf.Sqrt(4));
        //12.判断一个数是否是2的n次方
        Debug.Log(Mathf.IsPowerOfTwo(16));
        //判断正负数
        Debug.Log(Mathf.Sign(-10));
       
        #endregion
    }
    private float start; 
    private float result;

    private float time;

    // Update is called once per frame
    void Update()
    {
        #region 线性插值
        //Lerp ---线性插值
        //result = Mathf.Lerp(start, end, t);
        //t为插值系数，取值范围为 0~1
        //result=start+(end -start)*t
        //用法1
        start = Mathf.Lerp(start, 10, Time.deltaTime);//每帧改变start的的值,变化速度先快后慢，数值无限接近但不会得到end的值
        //用法2
        time+= Time.deltaTime;
        result = Mathf.Lerp(start, 10, time);//每帧改变start的的值,匀速变化  ---加上（end-Start）*Time.deltaTime(常量)，因为仅有time在均匀变化,当time大于1时，result的值会等于10

        #endregion
    }
}
