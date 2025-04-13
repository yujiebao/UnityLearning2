using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 Resources重复加载资源会浪费内存吗
        //其实Resources加载一次资源过后
        //该资源就一直存放在内存中作为缓存
        //第二次加载时发现缓，冲存在该资源
        //会直接取出来进行使用
        //所以 多次重复加载不会浪费内存
        //但是 会浪费性能(每次加载都会去查找取出，始终伴随一些性能消耗)
        #endregion

        #region 知识点二 如何手动释放资源
        //1.卸载指定资源
        //Resources.UnloadAsset 方法
        //注意:
        //该方法 不能释放 Gameobject对象 因为它会用于实例化对象
        //它只能用于一些 不需要实例化的内容 比如 图片 和 音效 文本等等
        //一般情况下 我们很少单独使用它

        //2.卸载未使用资源
        //注意:
        //一般在过场景时和Gc一起使用
        Resources.UnloadUnusedAssets();
        GC.Collect();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
