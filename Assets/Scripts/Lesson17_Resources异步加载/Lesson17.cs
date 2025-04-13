using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson17 : MonoBehaviour
{
    public Texture texture;  //数据缓冲区用于存储异步记载的数据
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 Resources异步加载是什么?
        //上节课学习的同步加载中
        //如果我们加载过大的资源可能会造成程序卡顿
        //卡顿的原因就是 从硬盘上把数据读取到内存中 是需要进行计算的
        //越大的资源耗时越长，就会造成掉帧卡顿
        
        //Resources异步加载 就是内部新开一个线程进行资源加载 不会造成主线程卡顿
        #endregion

        #region Resources 异步加载方法
        //注意:
        //异步加载 不能马上得到加载的资源 至少要等一帧   使用异步加载的资源要确保加载完成 否者空引用
        
        //1.通过异步加载中的完成事件监听 使用加载的资源
        //unity就会在内部开一个线程去加载
        // ResourceRequest resourceRequest = Resources.LoadAsync<Texture>("Texture");
        //监听加载(Resources)  加载结束时候执行事件中的代码
        // resourceRequest.completed += (a) => {   //a的类型是ResourceRequest的父类
        //     // texture = (a as ResourceRequest).asset as Texture;
        //     texture = resourceRequest.asset as Texture;
        // };
        // resourceRequest不能在这使用 resourceRequest还没加载完成

        //2.通过协程 使用加载的资源
        //上面的代码改用协程
        StartCoroutine(Load());
        #endregion  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI() {
        if(texture != null) {
            GUI.DrawTexture(new Rect(0,0,100,100),texture);
        }
    }

    IEnumerator Load()
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<Texture>("Texture");
        // yield return resourceRequest;  //判断该资源是否加载完成
        while(!resourceRequest.isDone) {
            print("加载中PG"+resourceRequest.progress);  //加载的进度
            yield return null;   //下一帧执行
        }
        texture = resourceRequest.asset as Texture;
    }

}
