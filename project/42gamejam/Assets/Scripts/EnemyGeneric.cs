using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGeneric : MonoBehaviour
{
    public int life;
	private int startingLife;
    public float speed;
    private Vector3 startingPos;
    public bool isSpawning;
	public bool isWhite;
    //                               ENEMY SHOOTING
    // public EnBullet bullet;
    // public EnBullet[] EnBullet;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.localPosition;
		startingLife = life;
		isSpawning = false;
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
		transform.localPosition = startingPos;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		life = startingLife;
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
