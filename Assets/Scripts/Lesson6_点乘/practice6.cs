using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice6 : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward,Color.blue);
        Debug.DrawRay(transform.position,enemy.position-transform.position,Color.red);
        // if (Vector3.Angle(transform.forward, enemy.position-transform.position) < 22.5f && Vector3.Distance(transform.position, enemy.position) < 5)
        // {
        //     print("发现侵略者");
        // }

        float dotResult = Vector3.Dot(transform.forward.normalized, (enemy.position - transform.position).normalized);
        float angle = Mathf.Acos(dotResult)*Mathf.Rad2Deg;
         if(angle < 22.5f && Vector3.Distance(transform.position, enemy.position) < 5)
         {
            print("发现侵略者");
         }

    }
}
