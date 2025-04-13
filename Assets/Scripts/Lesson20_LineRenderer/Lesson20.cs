using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20 : MonoBehaviour
{
    private Material M;
    // Start is called before the first frame update
    void Start()
    {
        #region LineRanderer 代码相关
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
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
