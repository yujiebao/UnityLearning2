# 1.Mathf

## 1.Mathf和Math

Math   ---System namespace（C#）   

Mathf   --------UnityEngine namespace      ————unity封装，增加了试用于游戏开发的方法（包含Math的方法，一般使用Mathf） 

## 2.Mathf 提供的方法

```c#
		//1.π
        Debug.Log(Mathf.PI);
        //2.绝对值
        Debug.Log(Mathf.Abs(-10));
        //3.向上取整
        Debug.Log(Mathf.Ceil(10.1f));
        //4.向下取整  强制转换---默认为向下取整
        Debug.Log(Mathf.Floor(10.9f));
        //5.四舍五入
        Debug.Log(Mathf.Round(10.5f));
        //6.平方根
        Debug.Log(Mathf.Sqrt(16));
        //7.钳制函数    值在[min,max]之间，否则返回min或max
        Debug.Log(Mathf.Clamp(10, 11, 20));
        //8.获取最大值    
        Debug.Log(Mathf.Max(1,2,3,4,5,10, 20));
        //9.获取最小值
        Debug.Log(Mathf.Min(1, 2, 3, 4, 5, 10, 20));
        //10.一个数的幂次
        Debug.Log(Mathf.Pow(2,5));
        //11.返回一个数的平方根
        Debug.Log(Mathf.Sqrt(4));
        //12.判断一个数是否是2的n次方
        Debug.Log(Mathf.IsPowerOfTwo(16));

		//线性插值
        //Lerp ---线性插值
        //result = Mathf.Lerp(start, end, t);
        //t为插值系数，取值范围为 0~1
        //result=start+(end -start)*t
        //用法1
        start = Mathf.Lerp(start, 10, Time.deltaTime);//每帧改变start的的值,变化速度先快后慢，数值无限接近但不会得到end的值
        //用法2
        time+= Time.deltaTime;
        result = Mathf.Lerp(start, 10, time);//每帧改变start的的值,匀速变化  ---加上（end-Start）*Time.deltaTime(常量)，因为仅有time在均匀变化,当time大于1时，result的值会等于10
		//球形差值
		C.position = Vector3.Slerp(C.position,Target.position,Time.deltaTime);     
```

# 2.三角函数

## 1.角度 弧度相互转换

```C#
		//弧度转角度
        float rad = 1f;
        float anger = rad * Mathf.Rad2Deg;    //Rad2Deg = 57.29578f   ---弧度转角度
        //角度转弧度
        float angle = 180f;
        float radian = angle * Mathf.Deg2Rad;    //Deg2Rad = 0.0174533f   ---角度转弧度
```

## 2.三角函数和反三角函数

```C#
        //三角函数
		//注意Mathf中的三角函数相关函数传入的参数是弧度，而不是角度
        print(Mathf.Sin(30*Mathf.Deg2Rad));    
	    //反三角函数 
        //反三角函数得到的也是弧度而不是角度
        print(Mathf.Asin(0.5f));  
        print(Mathf.Asin(0.5f)*Mathf.Rad2Deg);

```

# 3.坐标系

## 1.世界坐标

```C#
	    this.transform.position;
        this.transform.rotation;
        this.transform.eulerAngles;
        this.transform.lossyScale;
```



## 2.相对坐标

```C#
		//相对于父对象的坐标位置  本地坐标 相对坐标
        this.transform.localPosition;
        this.transform.localEulerAngles;
        this.transform.localRotation;
        this.transform.localScale;   //只读属性，获取物体实际放大的倍数
        //修改他们  会相对于父对象物体坐标系变化
```



## 3.屏幕坐标

```C#
        Input.mousePosition;   //获取当前鼠标指针位置的一个属性，距离左下角（unity）
        Screen.width; 
        Screen.height;
```

# 4.向量的点乘（Dot）

## 1.通过点乘可以判断物体的前后位置

```c#
float dotResult =Vector3.Dot(transform.forward,(target.position - transform.position ));
        if (dotResult >= 0)   
        { 
            print("他在我的前方");
        }
        else
        {
            print("他在我的后方");
        }
```



## 2.通过点乘推导公式计算夹角

```C#
        //1.用单位向量点乘

        dotResult = Vector3.Dot(transform.forward.normalized, (target.position - transform.position).normalized);

        //2.用反三角函数得出弧度

        float angle = Mathf.Acos(dotResult);

        print("夹角为："+angle*Mathf.Rad2Deg);} 
//上面代码等价于Vector3.Angle(transform.forward, (target.position - transform.position));

        

```

## 3.补充Unity的划线函数

```C#
        Debug.DrawRay(transform.position,this.transform.forward, Color.yellow);
        // 划线--射线  第二个参数为方向

```

# 5.向量的叉乘(Cross)

## 1.叉乘的几何意义    

​        假设向量 A 和 B 都在 xz平面上   右手定则

​        向量A叉乘向量B   y大于0--> B在A的右侧  y小于0--> B在A的左侧

## 2.叉乘可以判断左右

```C#
//   A B 为两物体的Transform
if (Vector3.Cross(A.position, B.position).y >0)
        {
            print("B在A的右侧");
        }
        else
        {
            print("B在A的左侧");
        }
```

# 6.欧拉角与四元数

## 1.四元数

###      1.计算公式

​	四元数 Q = [cos (β/2) , sin(β/2)x,sin(β/2)y,sin(β/2)z]

​        Quaternion q = new Quaternion( sin(β/2)x,sin(β/2)y,sin(β/2)z,cos (β/2));

###      2.公式对应的实现代码(一般不用)

```C#
Quaternion q = new Quaternion(1 * Mathf.Sin(30*Mathf.Deg2Rad),0,0,Mathf.Cos(30*Mathf.Deg2Rad));  //绕x轴旋转60度
        GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
        a.transform.rotation = q;
```

###      3.unity提供的方法

```C#
        //与上面的方法等价
        Quaternion q2 = Quaternion.AngleAxis(60, Vector3.right);
        GameObject a2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        a2.name = "q2";
        a2.transform.rotation = q2;
```



## 2.欧拉角和四元数的转换

```C#
 		//1.欧拉角转四元数 
        Quaternion q1 = Quaternion.Euler(new Vector3(30,0,0));   //绕x轴旋转30度
        Quaternion q3 = Quaternion.Euler(30,0,0);

        //2.四元数转欧拉角
        print(q1.eulerAngles);
```

## 3.四元数解决的问题

### 1.同一旋转的表示不唯一

 ```C#
void Update()
    {
        //四元数相乘代表旋转四元数
        //旋转的角度在-180-180(检查窗口)   解决同一旋转表示不唯一的问题
        this.transform.rotation *=Quaternion.AngleAxis(1,Vector3.up);    //代表自己坐标的y轴旋转1度
    }
 ```

### 2.万向节死锁

​        达到死锁条件下  仍按照设定的角度旋转

# 7.四元数的常用方法

## 1.四元数插值

推荐使用Slerp

```C#
        //无限接近  先快后忙
        A.rotation = Quaternion.Slerp(A.rotation,Target.rotation,Time.deltaTime);
        //匀速
        time+=Time.deltaTime;
        B.rotation = Quaternion.Slerp(start,Target.rotation,time);
```



## 2.LookRotation  看向某个方向

```C#
Quaternion qA = Quaternion.LookRotation(A.position - LookA.position);    //LookA看向A   LookA，A向量

        LookA.rotation = qA;

```

# 8.四元数的计算

## 1.四元数相乘

```C#
        Quaternion q1 = Quaternion.AngleAxis(30,Vector3.up);
        testObj.rotation *=q1;
```

## 2.四元数乘以向量

```C#
        Vector3 v = Vector3.forward;
        print(v);
        print(q1*v);    //就是将向量绕y旋转30度
```

## 3.总结

​        在进行旋转时 使用四元数相乘进行旋转  

​        使用欧拉角旋转时存在  不唯一 和 死锁问题

​        四元数相乘进行旋转时相对的坐标系是自身坐标系

# 9.延迟函数

## 1.什么是延迟函数

​        延迟函数顾名思义

​        就是会延时执行的函数

​        我们可以自己设定延时要执行的函数和具体延时的时间

​        是MonoBehaviour基类中实现好的方法

## 2.延迟函数的使用

```C#
		//1.延迟函数
         Invoke("DelayFunction", 2);
        //参数一:延迟执行的函数名    参数二:延时的时间(单位:秒) 执行一次

        //注意:
        //函数无法传入参数   只能在无参函数中包裹
        //必须是该脚本上声明的函数   也是可以通过包裹进行调用

        // 2.延迟重复执行函数
        InvokeRepeating("DelayFunction", 2, 1);
        // 参数一:延迟执行的函数名    参数二:延时的时间(单位:秒)    参数三:重复执行的时间间隔(单位:秒) 执行多次

        //3.取消延迟函数
        //3-1.取消该脚本的全部延迟函数
        CancelInvoke();
        //3-2.取消该脚本中指定的延迟函数
         CancelInvoke("DelayFunction");  取消所有执行的函数名为DelayFunction的延迟函数

        //4.判断是否有延迟函数
         if (IsInvoking("DelayFunction"))
```

## 3.延迟函数受对象失活销毁的影响

​        脚本依附对象失活    ---延迟函数可以继续执行  脚本只要执行过start，失活后依旧执行  但一开始失活对象或不启用脚本不执行(没执行过start)

​        可以在OnEnable和OnDisable开启和关闭延时函数    ---实现在脚本启用的时候执行,在脚本失活的时候终止

 脚本依附对象销毁或者脚本移除

延迟函数无法继续执行

# 10.协同程序

## 1.unity是否支持多线程

首先要明确一点

Unity是支持多线程的

只是新开线程无法访问unity相关对象的内容

 注意：unity中的多线程  要记住关闭

关闭游戏时也会继续执行

解决在OnDestroy或者合适的位置关闭线程

## 2.协同程序是什么

### 1.本质就是一个迭代器

协同程序简称协程

它是假的多线程，不是多线程

 

### 2.它的主要作用

将代码分时执行，不卡主线程

理解，是把可能会让主线程卡顿的耗时的逻辑分时分步执行

 

### 3.主要使用场景

异步加载文件

异步下载文件

场景异步加载

批量创建时防止卡顿

## 3.协程和多线程的区别

新开一个线程是独立的一个管道，和主线程并行执行

新开一个协程是在原线程之上开启，进行逻辑分时分步执行



## 4.协程的使用

```C#
 //继承MonoBehaviour的类 都可以开启 协程函数
        //第一步：声明协程函数
        //协程函数2个关键点
        //1-1返回值为IEnumerator类型及其子类
        //1-2函数中通过 yield return 返回值;进行返回

        //第二步:开启协程函数
        //常用开启方式
        //MyCoroutine();  这样执行是没有任何效果的
        //1.
        Coroutine coroutine =  StartCoroutine(MyCoroutine());
        //2.
        // IEnumerator a = MyCoroutine();
        // StartCoroutine(a);

        //第三步：停止协程
        //关闭所有
        StopAllCoroutines();
        //关闭指定
        StopCoroutine(coroutine);
```

## 5.常见的yield return 的含义

```C#
		// 下一帧执行
         yield return null;
         yield return 数字
        // updata和Lateupdate之间执行

        //2.等待指定秒后执行
        yield return new WaitForseconds(秒);
        //在Update和LateUpdate之间执行
        
        //3.等待下一个固定物理帧更新时执行
        yield return new WaitForFixedUpdate()
        //在Fixedupdate和碰撞检测相关函数之后执行
        
        //4.等待摄像机和GUI渲染完成后执行    ----截图中使用
        yield return new WaitForEndofFrame();
        //在Lateupdate之后的渲染相关处理完毕后之后
        
        //5.一些特殊类型的对象 比如异步加载相关函数返回的对象
        //之后讲解 异步加载资源 异步加载场景 网络加载时再讲解
        //一般在update和Lateupdate之间执行
        
        //6.跳出协程
        // yield break;
```

## 6.协程受对象和组件失活的影响

​	协程开启后

​        组件和物体销毁，协程不执行

​        物体失活协程不执行

​        组件失活协程执行

# 11.协程的原理

## 1.协程的本质

协程可以分成两部分

​        1.协程函数本体

​        2.协程调度器

 协程本体就是一个能够中间暂停返回的函数

协程调度器是unity内部实现的，会在对应的时机帮助我们继续执行协程函数

 unity只实现了协程调度部分

 协程的本体本质上就是一个 c#的迭代器方法

## 2.协程本体是迭代器的体现

### 1.协程函数本体

​        如果我们不通过 开启协程方法执行协程

​        unity的协程调度器是不会帮助我们管理协程函数的

### 2.但我们可以自己执行协程函数 

```C#
    IEnumerator ie = test();  
    ie.MoveNext();    //执行直至yield return
        object a = ie.Current;   //return的结果
        print(a);
        ie.MoveNext();    ---> ie.MoveNext()
            while (ie.MoveNext())   //执行所有的yield return
                object a = ie.Current;   //return的结果
                print(a);
            }
```

协程调度器

继承MonoBehavior后 开启协程

相当于是把一个协程函数(迭代器)放入unity的协程调度器中帮助我们管理进行执行

具体的yield return 后面的规则 也是Unity定义的一些规则

## 3.总结

你可以简化理解迭代器函数

C#看到迭代器函数和yield return 语法糖

就会把原本是一个的 函数 变成"几部分"

我们可以通过迭代器 从上到下遍历这“几部分"进行执行

就达到了将一个函数中的逻辑分时执行的目的

​        

而协程调度器就是 利用迭代器函数返回的内容来进行之后的处理

比如unity中的协程调度器

根据yield return返回的内容 决定了下一次在何时继续执行迭代器函数中的"下一部分

理论上来说 我们可以利用迭代器函数的特点 自己实现协程调度器来取代unity自带的调度器



协程的本质 就是利用

c#的迭代器函数"分步执行"的特点

加上

协程调度逻辑

实现的一套分时执行函数的规则

# 12.unity的特殊文件

## 1.工程路径的获取

```C#
print(Application.dataPath);      //打包后找不到了  ---开发阶段的路径
```

注意 该方式 获取到的路径 一般情况下 只在编辑模式下使用 

我们不会在实际发布游戏后 还使用该路径

游戏发布过后 该路径就不存在了

## 2.Resources 资源文件夹

注意这个文件夹需要自己创建  可以创建多个Resources 文件夹

这个包会被打包出去 

打包时unity会对其进行加密压缩  

打包后只读，只能通过Resources相关API调用

## 3.StreamingAssets  流媒体资源文件夹

```C#
print(Application.streamingAssetsPath);    //streamingAssets路径    
```

注意：需要我们手动创建

作用

流文件夹

2-1.打包出去不会被压缩加密，可以任由我们摆布

2-2.移动平台只读，PC平台可读可写

2-3.可以放入一些需要自定义动态加载的初始资源

## 4.persistentDataPath  持久数据文件夹 

```C#
print(Application.persistentDataPath); 
```

注意:

不需要我们自己将创建

作用:

固定数据文件夹

3-1.所有平台都可读可写    运行时候可以使用这个文件夹

3-2.一般用于放置动态下载或者动态创建的文件，游戏中创建或者获取的文件都放在其中

## 5.其他文件夹

### Plugin  插件文件夹  

我们自己创建         不同平台的插件相关文件放在其中 

### Editor 编辑器文件夹   

一般不获取  需要我们自己创建   如果硬要获取 可以用工程路径拼接

开发unity编辑器时，编辑器相关脚本放在该文件夹中

该文件夹中内容不会被打包出去

### Standard Assets 默认资源文件夹 

一般不获取  需要我们自己创建   如果硬要获取 可以用工程路径拼接

一般unity自带资源放在这个文件夹中		代码和资源优先被编译

# 13.加载Resources资源

## 1.同步加载

```C#
      //1.不指定类型
      Object prefab = Resources.Load("Cube");   //在所有的Resources 文件夹下找Cube.prefab
	
	 //2.加载所有
        Object[] objs =Resources.LoadAll("Texture");    //性能消耗大

	 //3.指定类型
        obj =Resources.Load("Texture",typeof(Texture));  //指定资源类型
	//4.使用泛型
        print(Resources.Load<TextAsset>("Test"));

```

## 2.异步加载

###    1.同步加载的问题:

​        如果我们加载过大的资源可能会造成程序卡顿

​        卡顿的原因就是 从硬盘上把数据读取到内存中 是需要进行计算的

​        越大的资源耗时越长，就会造成掉帧卡顿

        Resources异步加载 就是内部新开一个线程进行资源加载 不会造成主线程卡顿 

### 2.异步加载方法

​	注意:

​        异步加载 不能马上得到加载的资源 至少要等一帧   使用异步加载的资源要确保加载完成 否者空引用

```C#
		// 1.通过异步加载中的完成事件监听 使用加载的资源
        // unity就会在内部开一个线程去加载
        ResourceRequest resourceRequest = Resources.LoadAsync<Texture>("Texture");
        // 监听加载(Resources)  加载结束时候执行事件中的代码
        resourceRequest.completed += (a) => {   //a的类型是ResourceRequest的父类
            // texture = (a as ResourceRequest).asset as Texture;    //先装换为ResourceRequest
            texture = resourceRequest.asset as Texture;
        };
        // resourceRequest不能在这使用 resourceRequest还没加载完成

        //2.通过协程 使用加载的资源
        //上面的代码改用协程
        StartCoroutine(Load());

		//协程函数
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
```

# 14.卸载Resources资源

## 1.Resources重复加载资源会浪费内存吗

其实Resources加载一次资源过后    该资源就一直存放在内存中作为缓存

第二次加载时发现缓冲存在该资源    会直接取出来进行使用  所以 多次重复加载不会浪费内存 

但是 会浪费性能(每次加载都会去查找取出，始终伴随一些性能消耗)

## 2.手动卸载资源

1.卸载指定资源

​        Resources.UnloadAsset 方法

​        注意:

​        该方法 不能释放 Gameobject对象 因为它会用于实例化对象

​        它只能用于一些 不需要实例化的内容 比如 图片 和 音效 文本等等

​        一般情况下 我们很少单独使用它

2.卸载未使用资源

​        注意:

​        一般在过场景时和Gc一起使用

      ```C#
  Resources.UnloadUnusedAssets();
  GC.Collect();

      ```

# 15.场景异步加载

## 1.场景同步切换的缺点:

在切换场景时  unity会删除当前场景上所有对象  并且去加载下一个场景的相关信息

如果当前场景 对象过多或者下一个场最对象过多   这个过程会非常的耗时 会让玩家感受到卡顿

所以异步切换就是来解决该问题的

## 2.场景异步加载的方法

### 1.通过事件回调

```C#
        AsyncOperation ao = SceneManager.LoadSceneAsync(1);
		ao.completed +=(a)=>{ print("切换完成");};

```

### 2.通过协程异步加载

需要注意的是 加载场景会把当前场景上 没有特别处理的对象 都删除了

所以 协程中的部分逻辑 可能是执行不了的

解决思路

让处理场景加载的脚本依附的对象 过场景时 不被移除

StartCoroutine(LoadAsyncScene());

```C#
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
```

# 16.LineRender

```C#
GameObject line = new GameObject();
        line.name = "line";
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();

        //首尾相连
        lineRenderer.loop = true;

        //首尾的宽
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        //开始的颜色    
        lineRenderer.startColor = Color.red;
        lineRenderer.startColor = Color.red;

        //设置材质
        M = Resources.Load<Material>("M");
        lineRenderer.material = M;

        //设置点
        //要先设置点的数目，再设置点的位置
        //树木
        lineRenderer.positionCount = 2;
        //设置每一个点  少设置的点默认为(0,0,0)
        // lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        // lineRenderer.SetPosition(1, new Vector3(1, 0, 0));
        //=>
        lineRenderer.SetPositions(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0) });
        
        //是否使用世界坐标系
        lineRenderer.useWorldSpace = true;

        //是否受光照影响
        lineRenderer.generateLightingData = true;
```

# 17.范围检测

## 1.游戏中瞬时的攻击范围判断一般会使用范围检测

​        举例:

​        1.玩家在前方5m处释放一个地刺魔法，在此处范围内的对象将受到地刺伤害

​        2.玩家攻击，在前方1米圆形范围内对象都受到伤害

​        等等

​        类似这种并没有实体物体 只想要检测在指定某一范围是否让敌方受到伤害时 便可以使用范围判断

​        简而言之

​        在指定位置 进行 范围判断 我们可以得到处于指定范围内的 对象

​        目的是对 对象进行处理

​        比如 受伤 减血等等

## 2.如何进行碰撞检测

必备条件:想要被范围检测到的对象 必须具备碰撞器

注意点:

1.范围检测相关API 只有当执行该句代码时 进行一次范围检测 它是瞬时的

2.范围检测相关API 并不会真正产生一个碰撞器 只是碰撞判断计算而已

## 3.范围检测API 

### 1. 盒状范围检测

```C#
//写法一  
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
//写法二 : 传入存储的数据的容器 
Physics.OverlapBoxNonAlloc(this.transform.position,Vector3.one,colliders)  
    colliders就是容器  前面上的参数和写法一一样
```

### 2.球形检测  

```C#
// Physics.OverlapSphere(Vector3.zero,1);  //第二个参数:半径

//另一个API
// Physics.OverlapSphereNonAlloc(this.transform.position,1,colliders);
```

### 3.胶囊体 

```C#
//参数一:圆一的中心点
//参数二:圆二的中心点
//参数三:半径
//参数四：检测指定层级
//参数五:是否忽略触发器
Physics.OverlapCapsule(this.transform.position, this.transform.position + Vector3.up, 1, Physics.AllLayers, QueryTriggerInteraction.Ignore);
//另一个API和前面的类似(参考盒状)
```



### 4.重要知识:层级

关于层级

通过名字得到层级编号 LayerMask.NameToLayer

我们需要通过编号左移构建二进制数

这样每一个编号的层级 都是 对应位为1的2进制数

我们通过 位运算 可以选择想要检测层级

好处 一个int 就可以表示所有想要检测的层级信息     ---通过与操作实现

 

层级编号是 0~31 刚好32位

是一个int数

每一个编号 代表的 都是二进制的一位

# 18.射线检测 

## 1.什么是射线检测

   物理系统中

目前我们学习的物体相交判断

1.碰撞检测一必备条件 1刚体2碰撞器

2.范围检测一必备条件 碰撞器

​        

如果想要做这样的碰撞检测呢?

1.鼠标选择场景上一物体

2.FPS射击游戏(无弹道-不产生实际的子弹对象进行移动)

等等 需要判断一条线和物体的碰撞情况

射线检测 就是来解决这些问题的

它可以在指定点发射一个指定方向的射线

判断该射线与哪些碰撞器相交，得到对应对象

## 2.射线对象

```C#
 Ray ray = new Ray(this.transform.position,this.transform.forward);   //第一个参数起点  第二个参数方向

        //Ray中的参数
        print("ray起点："+ray.origin);
        print("ray方向："+ray.direction);

        //摄像机发射出的射线
        //得到一条从屏幕位置作为起点
        //摄像机视口方向为 方向的射线
        Ray cameraRay = Camera.main.ViewportPointToRay(Input.mousePosition);
```

## 3.碰撞检测函数

Physics类中提供了很多进行射线检测的静态函数

他们有很多种重载类型 我们只需要掌握核心的几个函数 其它函数自然就明白什么意思了

注意:

射线检测也是瞬时的

执行代码时进行一次射线检测

## 4.相关检测API

ray  等在前面声明

### 1.原始的射线检测

```C#
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

```

### 2.获取相交的单个物体信息

```C#
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
```

### 3.获取相交的多个物体信息

```C#
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
```

