using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;

    public Transform Target;
    private float time;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = B.position;
    }

    // Update is called once per frame
    void Update()
    {
        #region 知识点一 线性插值
        //先快后慢
        A.position = Vector3.Lerp(A.position,Target.position,Time.deltaTime);
        //匀速
        //到达后再次移动要  置空时间 和重新设置位置
        if(B.position == Target.position)
        {
            time = 0;
            startPos = B.position;
        }
        time += Time.deltaTime;
        B.position = Vector3.Lerp(startPos,Target.position,time);
        #endregion
    
        #region 知识点二 球形插值Slerp
        C.position = Vector3.Slerp(C.position,Target.position,Time.deltaTime);
        #endregion
    }
}
