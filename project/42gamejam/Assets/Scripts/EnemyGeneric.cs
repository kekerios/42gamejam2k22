using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGeneric : MonoBehaviour
{
    public int life;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //                          ENEMY DEATH
	if(life<=0) 
		{
			Death();
		}
    }

	public void Death()
	{
    //                              ENEMY DEATH
	    Debug.Log("Oh no! I have Died!");
		Destroy(gameObject);
	}
}

//                                  BULLET COLLIDER
/*protected virtual void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Bullet")
    {
         //   Debug.Log("Oh no! I have been Shot");
            life--;
    }

}*/
