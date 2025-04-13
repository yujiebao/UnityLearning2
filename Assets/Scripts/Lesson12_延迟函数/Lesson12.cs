using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
{
    private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是延迟函数
        //延迟函数顾名思义
        //就是会延时执行的函数
        //我们可以自己设定延时要执行的函数和具体延时的时间
        //是MonoBehaviour基类中实现好的方法
        #endregion

        #region 知识点二 延迟函数的使用
        //1.延迟函数
        // Invoke("DelayFunction", 2);
        //参数一:延迟执行的函数名    参数二:延时的时间(单位:秒) 执行一次

        //注意:
        //函数无法传入参数   只能在无参函数中包裹
        //必须是该脚本上声明的函数   也是可以通过包裹进行调用

        // 2.延迟重复执行函数
        InvokeRepeating("DelayFunction", 2, 1);
        // 参数一:延迟执行的函数名    参数二:延时的时间(单位:秒)    参数三:重复执行的时间间隔(单位:秒) 执行多次

        //3.取消延迟函数
        //3-1.取消该脚本的全部延迟函数
        //CancelInvoke();
        //3-2.取消该脚本中指定的延迟函数
        // CancelInvoke("DelayFunction");  取消所有执行的函数名为DelayFunction的延迟函数

        //4.判断是否有延迟函数
        // if (IsInvoking("DelayFunction"))
        #endregion
    
        #region 知识点三 延迟函数受对象失活销毁的影响
        //脚本依附对象失活  
        //延迟函数可以继续执行  脚本只要执行过start，失活后依旧执行  但一开始失活对象或不启用脚本不执行(没执行过start)
        //可以在OnEnable和OnDisable开启和关闭延时函数    ---实现在脚本启用的时候执行,在脚本失活的时候终止

        //脚本依附对象销毁或者脚本移除
        //延迟函数无法继续执行
        #endregion
    }

    private void OnEnable() {
        print("执行OnEnable");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void DelayFunction()
    {   
        Func(i);  //通过包裹调用有参数函数
        i++;
    }

    void Func(int a)
    {
        Debug.Log("延迟函数执行了" + a);
    }
}
