using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 工程路径的获取
        // 注意 该方式 获取到的路径 一般情况下 只在编辑模式下使用 
        //我们不会在实际发布游戏后 还使用该路径
        //游戏发布过后 该路径就不存在了
        // print(Application.dataPath);      ---打包后找不到了  ---开发阶段的路径
        #endregion

        #region 知识点二 Resources  资源文件夹
        // 注意这个文件夹需要自己创建  可以创建多个Resources 文件夹
        // 这个包会被打包出去 
        // 打包时unity会对其进行加密压缩  
        // 打包后只读，只能通过Resources相关API调用
        #endregion
    
        #region 知识点三 StreamingAssets  流媒体资源文件夹
        print(Application.streamingAssetsPath);    //streamingAssets路径   
        
        // 注意：需要我们手动创建
        // 作用
        // 流文件夹
        // 2-1.打包出去不会被压缩加密，可以任由我们摆布
        // 2-2.移动平台只读，PC平台可读可写
        // 2-3.可以放入一些需要自定义动态加载的初始资源
        #endregion

        #region 知识点四 persistentDataPath  持久数据文件夹
        print(Application.persistentDataPath); 

        // 注意:
        // 不需要我们自己将创建
        // 作用:
        // 固定数据文件夹
        // 3-1.所有平台都可读可写    运行时候可以使用这个文件夹
        // 3-2.一般用于放置动态下载或者动态创建的文件，游戏中创建或者获取的文件都放在其中
        #endregion

        #region Plugin  插件文件夹
        // 一般不需要

        //注意：
        //需要我们自己创建
        //作用：
        //插件文件夹
        // 不同平台的插件相关文件放在其中
        //比如IOS和Android平台
        #endregion

        #region Editor 编辑器文件夹
        //路径获取:
        //一般不获取
        //如果硬要获取 可以用工程路径拼接
        // print(Application.dataPath + "/Editor");

        //注意:
        //需要我们自己创建
        //作用:
        // 编辑器文件夹
        // 5-1.开发unity编辑器时，编辑器相关脚本放在该文件夹中
        // 5-2.该文件夹中内容不会被打包出去
        #endregion

        #region Standard Assets 默认资源文件夹
        //路径获取:
        //一般不获取
        //如果硬要获取 可以用工程路径拼接
        // print(Application.dataPath + "/Standard Assets");

        //注意:
        //需要我们自己将创建
        //作用:
        // 标准资源文件夹
        // 一般unity自带资源放在这个文件夹中
        // 代码和资源优先被编译
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
