using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Lesson16 : MonoBehaviour
{
    public AudioSource audioSource;
    public Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 常用的资源类型
        //1.预设体对象-Gameobject
        //2.音效文件-Audioclip
        //3.文本文件-TextAsset
        //4.图片文件-Texture
        //5.其它类型一需要什么用什么类型
        
        //注意：
        //预制体对象加载需要实例化
        //其他资源一般直接用
        #endregion

        #region 知识点二 资源同步加载 普通方法
        //1.预设体对象 想要创建在场景上 记住实例化
        // 第一步:要去加载预设体的资源文件
        Object prefab = Resources.Load("Cube");   //在所有的Resources 文件夹下找Cube.prefab
        Instantiate(prefab);

        //2.音效资源
        Object music = Resources.Load("Music/AOE_Effect");
        audioSource.clip = music as AudioClip;
        // audioSource.Play();

        //3.文本资源
        //文本资源支持的格式
        //.txt 
        //.xml 
        //.json 
        //.csv 
        //.bytes
        //.html
        //....
        Object obj = Resources.Load("Test");
        TextAsset textAsset = obj as TextAsset;
        //文本内容
        print(textAsset.text);
        //字节数组
        // print(textAsset.bytes);

        //4.图片资源
        obj = Resources.Load("Texture");
        texture = obj as Texture;
        
        //5.资源同名覆盖问题
        //不同类型资源同名 或者不同文件夹资源同名  ----无法准确加载

        //使用另外的API
        //5-1指定类型资源
        obj =Resources.Load("Texture",typeof(Texture));  //指定资源类型
        texture = obj as Texture;
        //5-2加载所有的资源
        Object[] objs =Resources.LoadAll("Texture");    //性能消耗大
        // foreach (Object o in objs)
        // {
        //     if(o is Texture)
        //     {

        //     }
        //     else
        //     {

        //     }
        // }
        #endregion

        #region 知识点三 资源同步加载的泛型方法
        print(Resources.Load<TextAsset>("Test"));
        #endregion         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        GUI.DrawTexture(new Rect(0, 0, 100, 100), texture);
    }
}
