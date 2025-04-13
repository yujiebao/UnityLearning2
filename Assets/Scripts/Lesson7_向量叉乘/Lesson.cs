using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;

    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 叉乘计算
        print(Vector3.Cross(A.position, B.position));
        #endregion

        #region 知识点二 叉乘的几何意义    
        // 假设向量 A 和 B 都在 xz平面上   右手
        // 向量A叉乘向量B   y大于0--> B在A的右侧  y小于0--> B在A的左侧

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Cross(A.position, B.position).y >0)
        {
            print("B在A的右侧");
        }
        else
        {
            print("B在A的左侧");
        }
    }
}
