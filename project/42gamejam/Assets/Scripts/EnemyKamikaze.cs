using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyKamikaze : EnemyGeneric
{
	private GameObject playerObject;

    // Start is called before the first frame update
    void Awake()
    {
		playerObject = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
		Movement();
        //                          ENEMY DEATH
		if(life<=0) 
		{
			Death();
		}
    }


    void Movement()
	{
        transform.position = playerObject.transform.position * speed * Time.deltaTime;
    }
//                                  BULLET COLLIDER
}
