using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practise_Enemy : MonoBehaviour
{
    Transform player;
    Transform enemy;
    Vector3 start;
    
    Vector3 playerposition;
    float time = 0;
    Vector3 distinct;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        enemy = GetComponent<Transform>();
        start = enemy.position;
        playerposition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //先快后慢
        // float moveX = Mathf.Lerp(enemy.position.x,player.position.x,Time.deltaTime); 
        // float moveY = Mathf.Lerp(enemy.position.y,player.position.y,Time.deltaTime);
        // float moveZ = Mathf.Lerp(enemy.position.z,player.position.z,Time.deltaTime);
        // enemy.position = new Vector3(moveX,moveY,moveZ);
        //匀速   
        // time += Time.deltaTime;
        // float Px = Mathf.Lerp(start.x,player.position.x,time);
        // float Py = Mathf.Lerp(start.y,player.position.y,time);
        // float Pz = Mathf.Lerp(start.z,player.position.z,time);
        // enemy.position = new Vector3(Px,Py,Pz);
        // if(enemy.position == player.position)//可根据具体情况重置  此处为追上重置（但一定要重置否知time一直大于等于1，一直在一起），也可以当目标位置改变的时候重置
        // {
        //     start = player.position;   //此种判断start没有根据移动更新，只有追上的时候才更新，都是以上一次追上的对象的位置为起点
        //     time = 0;
        // }
       
        if(player.position != playerposition)
        {
            // Debug.Log("" + playerposition);
            start = enemy.position;    //只要移动就更新，最近的直线
            time = 0;
            playerposition = player.position;
        }
        time += Time.deltaTime;
        float Px = Mathf.Lerp(start.x,playerposition.x,time);
        float Py = Mathf.Lerp(start.y,playerposition.y,time);
        float Pz = Mathf.Lerp(start.z,playerposition.z,time);
        enemy.position = new Vector3(Px,Py,Pz);
        
    }
}
