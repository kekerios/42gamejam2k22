using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    private bool isRed = true;
    public bool isMoving = false;
    public bool divideShoot = false;
    public int damage = 1;
    public float speed = 5;
    private Vector3 startingPos;
    private Vector3 direction;
    public LPBullet bullet;
    public LPBullet[] lBullet;
    private Transform parentB;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        parentB = transform.parent;
        CreateBullets();
    }
    void Update()
    {
        if(isMoving)
        {
            transform.position += direction * speed * Time.deltaTime;
            
        }
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //TakeDamage
            Debug.Log("Hit");

            if(divideShoot)
            {
                lBullet[0].transform.position = transform.position;
                lBullet[0].Shoot(new Vector3(1,0,0));
                lBullet[0].transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
                lBullet[1].transform.position = transform.position;
                lBullet[1].Shoot(new Vector3(-1,0,0));
                lBullet[1].transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            }
            
            //Insanciar mas balas
        }
    }
    public void Reset()
    {
        transform.position = startingPos;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        isMoving = false;
    }
    public void Shoot(Vector3 nDirection, float zRot)
    {
        isMoving = true;
        direction = nDirection;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,zRot));
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Bound")
        {
            Reset();
        }
    }
    private void CreateBullets()
    {
        for(int i = 0; i < lBullet.Length; i++)
        {
            lBullet[i] = Instantiate(bullet, new Vector3(i,0,0), Quaternion.identity, parentB);
            lBullet[i].transform.localPosition = new Vector3(i,-2,0);
        }
    }
}
