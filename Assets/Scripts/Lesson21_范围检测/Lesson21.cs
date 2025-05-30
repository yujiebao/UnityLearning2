using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21 : MonoBehaviour
{
    private Collider[] Colliders1 = new Collider[10];
    // Start is called before the first frame update
    void Start()
    {
        #region 知识回顾 物理系统之碰撞检测
        //碰撞产生的必要条件
        //1.至少一个物体有刚体
        //2.两个物体都必须有碰撞器

        //碰撞和触发
        //碰撞会产生实际的物理效果

        //触发看起来不会产生碰撞但是可以通过函数监听触发
        //碰撞检测主要用于实体物体之间产生物理效果时使用
        #endregion

        #region 知识点一 什么是范围检测
        // 游戏中瞬时的攻击范围判断一般会使用范围检测
        // 举例:
        // 1.玩家在前方5m处释放一个地刺魔法，在此处范围内的对象将受到地刺伤害
        // 2.玩家攻击，在前方1米圆形范围内对象都受到伤害
        // 等等
        // 类似这种并没有实体物体 只想要检测在指定某一范围是否让敌方受到伤害时 便可以使用范围判断
        // 简而言之
        // 在指定位置 进行 范围判断 我们可以得到处于指定范围内的 对象
        // 目的是对 对象进行处理
        // 比如 受伤 减血等等
        #endregion
        
        #region 知识点二 如何进行碰撞检测
        //必备条件:想要被范围检测到的对象 必须具备碰撞器
        //注意点:
        //1.范围检测相关API 只有当执行该句代码时 进行一次范围检测 它是瞬时的
        //2.范围检测相关API 并不会真正产生一个碰撞器 只是碰撞判断计算而已
        
        //范围检测API
        //1.盒状范围检测
        //参数一:立方体中心点
        //参数二:立方体三边大小
        //参数三:立方体角度
        //参数四:检测指定层级(不填检测所有层)
        //参数五:是否忽略触发器 useGloba1-使用全局设置 collide-检测触发器 Ignore-忽略触发器 不填使用UseGlobal
            //参数五说明：Collide：检测所有碰撞器（包括触发器）。   Ignore：仅检测普通碰撞器，忽略触发器。
        //返回值:在该范围内的触发器(得到了对象触发器就可以得到对象的所有信息)
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1), Quaternion.AngleAxis(45,Vector3.up), 
        1<<LayerMask.NameToLayer("UI")|1<<LayerMask.NameToLayer("Player"),   //不写，默认检测所有层
        QueryTriggerInteraction.Ignore);
        foreach (var item in colliders)
        {
            print(item.name);
        }
        
        //重要知识点
        //关于层级
        //通过名字得到层级编号 LayerMask.NameToLayer
        //我们需要通过编号左移构建二进制数
        //这样每一个编号的层级 都是 对应位为1的2进制数
        //我们通过 位运算 可以选择想要检测层级
        //好处 一个int 就可以表示所有想要检测的层级信息     ---通过与操作实现

        //层级编号是 0~31 刚好32位
        //是一个int数
        //每一个编号 代表的 都是二进制的一位

        //另一个API
        //传入一个数据进行存储
        if(Physics.OverlapBoxNonAlloc(this.transform.position,Vector3.one,colliders)!=0)  //范围内的物体数目
        {

        }

        //2.球形检测  和盒状一样的
        // Physics.OverlapSphere(Vector3.zero,1);  //第二个参数:半径

        //另一个API
        // Physics.OverlapSphereNonAlloc(this.transform.position,1,colliders);

        //3.胶囊体
        //参数一:圆一的中心点
        //参数二:圆二的中心点
        //参数三:半径
        //参数四：检测指定层级
        //参数五:是否忽略触发器
        Physics.OverlapCapsule(this.transform.position, this.transform.position + Vector3.up, 1, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        //另一个API和前面的类似(参考盒状)
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
