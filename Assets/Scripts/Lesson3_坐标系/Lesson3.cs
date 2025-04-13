using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 世界坐标系
        // this.transform.position;
        // this.transform.rotation;
        // this.transform.eulerAngles;
        // this.transform.lossyScale;
        #endregion

        #region 物体坐标
        //相对于父对象的坐标位置  本地坐标 相对坐标
        // this.transform.localPosition;
        // this.transform.localEulerAngles;
        // this.transform.localRotation;
        // this.transform.localScale;   //只读属性，获取物体实际放大的倍数
        //修改他们  会相对于父对象物体坐标系变化
        #endregion

        #region 屏幕坐标系
        // Input.mousePosition;   //获取当前鼠标指针位置的一个属性，距离左下角（unity）
        // Screen.width; 
        // Screen.height;
        #endregion

        #region 视口坐标系
        //摄像机的视口范围
        #endregion

        #region 坐标转换
        
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
