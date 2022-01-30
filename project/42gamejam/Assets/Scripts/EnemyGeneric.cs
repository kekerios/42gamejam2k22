using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGeneric : MonoBehaviour
{
    public int life;
    public float speed;
      private Vector3 startingPos;
    bool isSpawning;
    //                               ENEMY SHOOTING
    // public EnBullet bullet;
    // public EnBullet[] EnBullet;
    private Transform parentE;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        parentE = transform.parent;
        //CreateBullets();
    }

    // Update is called once per frame
    void Update()
    {

        //                          ENEMY DEATH
    }

	public void Death()
	{
    //                              ENEMY DEATH
	    Debug.Log("Oh no! I have Died!");
		transform.position = startingPos;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        isSpawning = false;
	}


//                                  BULLET COLLIDER
	void OnTriggerEnter2D(Collider2D other)
	{
	    if (other.tag == "Bullet")
	    {
	         //   Debug.Log("Oh no! I have been Shot");
	        life--;
			if(life<=0) 
			{
				Death();
			}
		}
	    if (other.tag == "Player")
	    {
	         //   Debug.Log("Oh no! I have been Shot");
	            Death();
	    }

	}
    //                               ENEMY SHOOTING
    //         private void CreateBullets(){
    //     for(int i = 0; i < lBullet.Length; i++)
    //     {
    //         lBullet[i] = Instantiate(bullet, new Vector3(i,0,0), Quaternion.identity, parentE);
    //         lBullet[i].transform.localPosition = new Vector3(i,-2,0);
    //     }
    // }
}
