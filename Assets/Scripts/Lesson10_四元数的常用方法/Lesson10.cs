using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    public Transform testObj;
    public Transform Target;
    public Transform A;
    public Transform B;
    private Quaternion start;
    public Transform LookA;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        start = B.rotation;
        #region  知识点一 单位四元数
        print(Quaternion.identity);
        testObj.rotation = Quaternion.identity;

        Instantiate(testObj, new Vector3(0, 0, 0), Quaternion.identity);  //可以用于将创建物体的角度变为(0,0,0)
        #endregion

        #region 知识点二 四元数插值
        // 推荐使用Slerp
        #endregion

        #region 知识点三 LookRotation
        Quaternion qA = Quaternion.LookRotation(A.position - LookA.position);    //LookA看向A   LookA，A向量
        LookA.rotation = qA;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region 插值
        //无限接近  先快后忙
        A.rotation = Quaternion.Slerp(A.rotation,Target.rotation,Time.deltaTime);
        //匀速
        time+=Time.deltaTime;
        B.rotation = Quaternion.Slerp(start,Target.rotation,time); 
        #endregion
    }
}
