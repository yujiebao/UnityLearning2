using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是射线检测
        // 物理系统中
        // 目前我们学习的物体相交判断
        // 1.碰撞检测一必备条件 1刚体2碰撞器
        // 2.范围检测一必备条件 碰撞器
        
        // 如果想要做这样的碰撞检测呢?
        // 1.鼠标选择场景上一物体
        // 2.FPS射击游戏(无弹道-不产生实际的子弹对象进行移动)
        // 等等 需要判断一条线和物体的碰撞情况
        // 射线检测 就是来解决这些问题的
        // 它可以在指定点发射一个指定方向的射线
        // 判断该射线与哪些碰撞器相交，得到对应对象
        #endregion

        #region 知识点二 射线对象
        Ray ray = new Ray(this.transform.position,this.transform.forward);   //第一个参数起点  第二个参数方向

        //Ray中的参数
        print("ray起点："+ray.origin);
        print("ray方向："+ray.direction);

        //摄像机发射出的射线
        //得到一条从屏幕位置作为起点
        //摄像机视口方向为 方向的射线
        Ray cameraRay = Camera.main.ViewportPointToRay(Input.mousePosition);
        #endregion
    
        #region 知识点三 碰撞检查函数
        // Physics类中提供了很多进行射线检测的静态函数
        // 他们有很多种重载类型 我们只需要掌握核心的几个函数 其它函数自然就明白什么意思了
        // 注意:
        // 射线检测也是瞬时的
        // 执行代码时进行一次射线检测
        
        //1.原始的射线检测
        // 进行射线检测 如果碰撞到对象 返回true
        //参数一:射线
        //参数二:检测的最大距离 超出这个距离不检测
        //参数三:检测指定层级(不填检测所有层)
        //参数四:是否忽略触发器 useGloba1-使用全局设置 co1lide-检测触发器 Ignore-忽略触发器 不填使用useGlobal
        //返回值:boo1 当碰撞到对象时 返回 true 没有 返回false
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000, Color.red, 10f); // 绘制射线10单位长度
        print(1<<LayerMask.GetMask("Ground"));
        if(Physics.Raycast(ray,1000,1<<LayerMask.NameToLayer("Ground"),QueryTriggerInteraction.UseGlobal))
        {
            print("API1射线检测到物体");
        }
        //另一种重载 直接传入起点和方向 
        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.right * 1000, Color.red, 10f);
        if(Physics.Raycast(this.transform.position,this.transform.right,1000,1 << LayerMask.NameToLayer("Ground"),QueryTriggerInteraction.UseGlobal))
        {
            print("API2射线检测到物体");
        }

        //2.获取相交的单个物体信息
        RaycastHit hit;
        //参数一:射线
        //参数二:RaycastHit结构体 unity会通过out 关键字在 函数内部处理后  得到碰撞数据返回到该结构体中
        //参数三:检测的最大距离 超出这个距离不检测
        //参数四:检测指定层级(不填检测所有层)
        //参数五:是否忽略触发器 useGloba1-使用全局设置 co1lide-检测触发器 Ignore-忽略触发器 不填使用useGlobal
        if(Physics.Raycast(ray,out hit,1000,1<<LayerMask.NameToLayer("Ground"),QueryTriggerInteraction.UseGlobal))
        {
            
            // RaycastHit包含的信息：
              //碰撞器信息  
              print("碰撞器:"+hit.collider.name);
              //碰撞到的点
              print("碰撞点:"+hit.point);
              //碰撞点的法线信息
              print("碰撞点法线:"+hit.normal);    //创建贴图 特效的角度 更贴合
              //碰撞到物体的位置
              print("碰撞点位置:"+hit.transform.position);
              //碰撞点与发射点的距离   ----计算子弹下落   
              print("碰撞点距离:"+hit.distance);
        }
        //另一种写法  和上面的一样 传入位置和方向而不传入射线

        //3.获取相交的多个物体信息
        RaycastHit[] hits = new RaycastHit[10];
        // hits = Physics.RaycastAll(ray,1000,1<<LayerMask.NameToLayer("Ground"),QueryTriggerInteraction.UseGlobal);
        // for(int i=0;i<hits.Length;i++)
        // {
        //     print(hits[i].collider.name);
        // }
        //也有另一个写法 参考上面

        //还有一种函数 返回碰撞的数目 并通过out得到数据
        //注意此方法和上面的有区别 
        // 上面的返回一个数组并使用该数组  数组的长度就是碰撞的数目
        //而此方法传入一个参数 API对这个数组进行添加 但是数组的长度还是创建时候的长度 就会造成数组的长度不等于碰撞的数目 
        if(Physics.RaycastNonAlloc(ray,hits,1000,1<<LayerMask.NameToLayer("Ground"),QueryTriggerInteraction.UseGlobal)!=0)
        {
            print(hits.Length);
            //使用返回碰撞体的数目 数组的数目不对
            for(int i=0;i<Physics.RaycastNonAlloc(ray,hits,1000,1<<LayerMask.NameToLayer("Ground"),QueryTriggerInteraction.UseGlobal);i++)  
            {
                print(hits[i].collider.name);
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
