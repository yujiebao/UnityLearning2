using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int order = -1;
    [SerializeField] private Transform[] transforms;
    [SerializeField] private Transform fatherobj;
    private Color[] colors = {Color.red,Color.black,Color.blue,Color.green,Color.yellow,Color.white}; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            Debug.DrawRay(fatherobj.position,transforms[i].position-fatherobj.position,Getcolor());
        } 

    }

    private Color Getcolor()
    {         
        order++;
        if(order % colors.Length == 0 && order!= 0)
        {
            order = 0;
        }
        return colors[order];
    }
}
