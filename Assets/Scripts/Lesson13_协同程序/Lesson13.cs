using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Lesson13 : MonoBehaviour
{
    public Thread thread;
    
    //声明一个变量作为公共容器
    Queue<Vector3> queue = new Queue<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 unity是否支持多线程？
        //首先要明确一点
        //Unity是支持多线程的
        //只是新开线程无法访问unity相关对象的内容

        //注意：unity中的多线程  要记住关闭
        //关闭游戏时也会继续执行
        // 解决在OnDestroy或者合适的位置关闭线程
        thread = new Thread(test);
        thread.Start();
        #endregion
    
        #region 知识点二 协同程序是什么
        //本质就是一个迭代器
        //协同程序简称协程
        //它是假的多线程，不是多线程

        //它的主要作用
        //将代码分时执行，不卡主线程
        //简单理解，是把可能会让主线程卡顿的耗时的逻辑分时分步执行

        //主要使用场景
        //异步加载文件
        //异步下载文件
        //场景异步加载
        //批量创建时防止卡顿
        #endregion

        #region 知识点三 协程和线程的区别
        //新开一个线程是独立的一个管道，和主线程并行执行
        //新开一个协程是在原线程之上开启，进行逻辑分时分步执行
        #endregion
    
        #region 知识点四 协程的使用
        //继承MonoBehaviour的类 都可以开启 协程函数
        //第一步：声明协程函数
        //协程函数2个关键点
        //1-1返回值为IEnumerator类型及其子类
        //1-2函数中通过 yield return 返回值;进行返回

        //第二步:开启协程函数
        //常用开启方式
        // MyCoroutine();  这样执行是没有任何效果的
        //1.
        Coroutine coroutine =  StartCoroutine(MyCoroutine());
        //2.
        // IEnumerator a = MyCoroutine();
        // StartCoroutine(a);

        //第三步：停止协程
        //关闭所有
        // StopAllCoroutines();
        //关闭指定
        // StopCoroutine(coroutine);
        #endregion

        #region 知识点五 yield return不同内容的含义
        // 下一帧执行
        // yield return null;
        // yield return 数字
        // updata和Lateupdate之间执行

        //2.等待指定秒后执行
        //yield return new WaitForseconds(秒);
        //在Update和LateUpdate之间执行
        
        //3.等待下一个固定物理帧更新时执行
        //yield return new WaitForFixedUpdate()
        //在Fixedupdate和碰撞检测相关函数之后执行
        
        //4.等待摄像机和GUI渲染完成后执行    ----截图中使用
        //yield return new WaitForEndofFrame();
        //在Lateupdate之后的渲染相关处理完毕后之后
        
        //5.一些特殊类型的对象 比如异步加载相关函数返回的对象
        //之后讲解 异步加载资源 异步加载场景 网络加载时再讲解
        //一般在update和Lateupdate之间执行
        
        //6.跳出协程
        // yield break;
        #endregion

        #region 知识点六 协程受对象和组件失活的影响
        //协程开启后
        //组件和物体销毁，协程不执行
        //物体失活协程不执行
        //组件失活协程执行
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        // if(queue.Count>0)
        // {
        //     print("读取其他线程传入的数据");
        //     print(queue.Dequeue());
        // }
    }

    public void test()
    {
        while (true)
        {
            System.Random r = new System.Random();
            queue.Enqueue(new Vector3(r.Next(0, 100), r.Next(0, 100), r.Next(0, 100)));
            Thread.Sleep(1000);
        }
    }
    private void OnDestroy() {
        thread.Abort();
        thread = null;
    }

    //关键点一 ：协同程序 返回值必须是IEnumerator或者继承它的类型
    IEnumerator MyCoroutine()
    {
        while (true)  //死循环   一直分步执行
        {
            print("线程读取其他线程的数据：");
            print(queue.Dequeue());
            //关键点二 ：必须使用yield return 进行返回
            yield return new WaitForSeconds(1);
            print("线程读取本线程的数据：");
            yield return new WaitForSeconds(1);
        }
    }
}
