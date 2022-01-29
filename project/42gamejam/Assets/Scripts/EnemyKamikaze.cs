using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


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

}

//                                  BULLET COLLIDER
private void OnTriggerEnter2D(Collider2D other)
{
    void Movement()
	{
        transform.position = Vector2.MoveTowards(playerObject.transform.position,Time.deltaTime*speed);
    }

}
