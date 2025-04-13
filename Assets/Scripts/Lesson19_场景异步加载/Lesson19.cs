using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson19 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 场景同步切换的缺点
        // SceneManager.LoadScene(1);
        //在切换场景时
        //unity会删除当前场景上所有对象
        //并且去加载下一个场景的相关信息
        //如果当前场景 对象过多或者下一个场最对象过多
        //这个过程会非常的耗时 会让玩家感受到卡顿
        //所以异步切换就是来解决该问题的
        #endregion

        #region 知识点二 场景异步切换
        //1.通过事件回调
        // AsyncOperation ao = SceneManager.LoadSceneAsync(1);
        // ao.completed +=(a)=>{ print("切换完成");};
        
        //2.通过协程异步加载
        //需要注意的是 加载场景会把当前场景上 没有特别处理的对象 都删除了
        //所以 协程中的部分逻辑 可能是执行不了的
        //解决思路
        //让处理场景加载的脚本依附的对象 过场景时 不被移除
        StartCoroutine(LoadAsyncScene());
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsyncScene(string sceneName ="SampleScene")
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.completed +=(a)=>{ print(Time.frameCount); print("异步加载完成");};
        //这里可以写异步加载和结束异步加载之间的逻辑
        print(Time.frameCount);
        print("异步加载中");
        yield return ao;   //等待异步加载结束
        print("异步加载完成");   //不做处理  执行不了  场景加载时会删除当前场景上的所有对象  /使用方法1不会 对于事件的引用一直建立

        //使用协程进行异步加载场景可以  设计进度条
        //设计进度条的方法  
        //1.AsyncOperation.progress
        //2.自己定义规则  如：加载完树木+20%  加载完人物+30% ...
    }
}
