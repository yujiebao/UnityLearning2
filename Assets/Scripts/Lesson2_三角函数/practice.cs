using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float max;
     
     float moveX = 0;
     float moveY = 0;
     Vector3 startplace;
    // Start is called before the first frame update
    void Start()
    {
         startplace = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //x  y = sinx   z不变
        moveX += speed*Time.deltaTime;
        moveY = max* Mathf.Sin(moveX);
        transform.position = new Vector3(startplace.x+moveX,startplace.y+moveY,transform.position.z); 
        

    }
}
