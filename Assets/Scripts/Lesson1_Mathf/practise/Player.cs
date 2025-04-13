using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        // player.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
             player.Translate( Vector3.forward *Time.deltaTime );
        }
         if (Input.GetKey(KeyCode.S))
        {
            player.Translate(  Vector3.back *Time .deltaTime );
        }
         if (Input.GetKey(KeyCode.A))
        {
            player.Translate( Vector3.left * Time.deltaTime );
        }
         if (Input.GetKey(KeyCode.D))
        {
            player.Translate(  Vector3.right * Time.deltaTime );
        }
           
        
    }
}
