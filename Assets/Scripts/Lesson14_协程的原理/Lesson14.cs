using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class aa
{

}

public class Lesson14 : MonoBehaviour
{
    IEnumerator test()
    {
        print("第一次执行");
        yield return 1;
        print("第二次执行");
        yield return new WaitForSeconds(1);
        print("第三次执行");
        yield return "ddsa";
        print("第四次执行");
        yield return new aa();

    }
    // Start is called before the first frame update
    void Start()
    {

        #region 知识点一 协程的本质
        // 协程可以分成两部分
        // 1.协程函数本体
        // 2.协程调度器

        // 协程本体就是一个能够中间暂停返回的函数
        // 协程调度器是unity内部实现的，会在对应的时机帮助我们继续执行协程函数

        // unity只实现了协程调度部分
        // 协程的本体本质上就是一个 c#的迭代器方法
        #endregion

        #region 知识点二 协程本体是迭代器的体现
        // 1.协程函数本体
        // 如果我们不通过 开启协程方法执行协程
        // unity的协程调度器是不会帮助我们管理协程函数的
        IEnumerator ie = test();

        //2.但我们可以自己执行协程函数
        // ie.MoveNext();    //执行直至yield return
        // object a = ie.Current;   //return的结果
        // print(a);
        // ie.MoveNext();    ---> ie.MoveNext()
        //     while (ie.MoveNext())   //执行所有的yield return
        //         object a = ie.Current;   //return的结果
        //         print(a);
        //     }

        //2.协程调度器
        //继承MonoBehavior后 开启协程
        //相当于是把一个协程函数(迭代器)放入unity的协程调度器中帮助我们管理进行执行
        //具体的yield return 后面的规则 也是Unity定义的一些规则

        //总结
        // 你可以简化理解迭代器函数
        // C#看到迭代器函数和yield return 语法糖
        // 就会把原本是一个的 函数 变成"几部分"
        // 我们可以通过迭代器 从上到下遍历这“几部分"进行执行
        // 就达到了将一个函数中的逻辑分时执行的目的
        
        // 而协程调度器就是 利用迭代器函数返回的内容来进行之后的处理
        // 比如unity中的协程调度器
        // 根据yield return返回的内容 决定了下一次在何时继续执行迭代器函数中的"下一部分
        // 理论上来说 我们可以利用迭代器函数的特点 自己实现协程调度器来取代unity自带的调度器
        #endregion

        #region 总结
        // 协程的本质 就是利用
        // c#的迭代器函数"分步执行"的特点
        // 加上
        // 协程调度逻辑
        // 实现的一套分时执行函数的规则
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
