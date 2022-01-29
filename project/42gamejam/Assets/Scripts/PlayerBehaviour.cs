using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //private InputManager iM;
    private Vector3 move;
    private float initialSpeed;
    public float speed = 2.0f;
    public float fireRate = 0.5f;
    private bool canShoot = true;
    public bool triShoot = false;
    public bool divideShoot = false;
    public PBullet fBullet;
    public PBullet iBullet;
    public PBullet[] fBulletsArray;
    public PBullet[] iBulletsArray;
    public Transform parentB;
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        //iM = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        CreateBullets();
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 2)
        {
            //lose one wing;
            move = new Vector3 (1, 0, 0);
            move = move * speed/5 * Time.deltaTime;
            //transform.position += move;
            transform.Translate(move, Space.World);
        }
    }
    public void Move(Vector3 axis)
    {
        move = new Vector3 (axis.x, axis.y, 0);
        move = Vector3.ClampMagnitude(move, 1f);
        move = move * speed * Time.deltaTime;
        //transform.position += move;
        transform.Translate(move, Space.World);
    }
    public void ShootF()
    {
        if(!triShoot)
        {
            NormalShoot();
        }
        if(triShoot)
        {
            TripleShoot();
        }
    }
    private void NormalShoot()
    {
        if(!canShoot) return;
        for(int i = 0; i < fBulletsArray.Length; i++)
        {
            if(!fBulletsArray[i].isMoving)
            {
                fBulletsArray[i].transform.position = transform.position;
                fBulletsArray[i].Shoot(new Vector3(0, 1, 0), 0f);
                fBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    fBulletsArray[i].divideShoot = true;
                }
                canShoot = false;
                StartCoroutine(ShootDelay());
                Debug.Log("Shooting");
                return;
            }
        }
    }
    private void TripleShoot()
    {
        if(!canShoot) return;
        for(int i = 0; i < fBulletsArray.Length; i++)
        {
            if(!fBulletsArray[i].isMoving)
            {
                fBulletsArray[i].transform.position = transform.position;
                fBulletsArray[i].Shoot(new Vector3(0, 1, 0), 0f);
                fBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    fBulletsArray[i].divideShoot = true;
                }

                while(fBulletsArray[i].isMoving)
                {
                    i++;
                }
                fBulletsArray[i].transform.position = transform.position;
                fBulletsArray[i].Shoot(new Vector3(0.5f, 1, 0), -10f);
                fBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    fBulletsArray[i].divideShoot = true;
                }

                while(fBulletsArray[i].isMoving)
                {
                    i++;
                }
                fBulletsArray[i].transform.position = transform.position;
                fBulletsArray[i].Shoot(new Vector3(-0.5f, 1, 0), 10f);
                fBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    fBulletsArray[i].divideShoot = true;
                }
                canShoot = false;

                StartCoroutine(ShootDelay());
                Debug.Log("Shooting");
                return;
            }
            else i++;
        }
    }
    public void ShootI()
    {
        if(!triShoot)
        {
            NormalIShoot();
        }
        if(triShoot)
        {
            TripleIShoot();
        }
    }
    public void NormalIShoot()
    {
        if(!canShoot) return;
        for(int i = 0; i < iBulletsArray.Length; i++)
        {
            if(!iBulletsArray[i].isMoving)
            {
                iBulletsArray[i].transform.position = transform.position;
                iBulletsArray[i].Shoot(new Vector3(0, 1, 0), 0f);
                iBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    iBulletsArray[i].divideShoot = true;
                }
                canShoot = false;
                StartCoroutine(ShootDelay());
                Debug.Log("Shooting");
                return;
            }
        }
    }
    public void TripleIShoot()
    {
        if(!canShoot) return;
        for(int i = 0; i < iBulletsArray.Length; i++)
        {
            if(!iBulletsArray[i].isMoving)
            {
                iBulletsArray[i].transform.position = transform.position;
                iBulletsArray[i].Shoot(new Vector3(0, 1, 0), 0f);
                iBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    iBulletsArray[i].divideShoot = true;
                }

                while(iBulletsArray[i].isMoving)
                {
                    i++;
                }
                iBulletsArray[i].transform.position = transform.position;
                iBulletsArray[i].Shoot(new Vector3(0.5f, 1, 0), -10f);
                iBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    iBulletsArray[i].divideShoot = true;
                }

                while(iBulletsArray[i].isMoving)
                {
                    i++;
                }
                iBulletsArray[i].transform.position = transform.position;
                iBulletsArray[i].Shoot(new Vector3(-0.5f, 1, 0), 10f);
                iBulletsArray[i].isMoving = true;
                if(divideShoot)
                {
                    iBulletsArray[i].divideShoot = true;
                }

                canShoot = false;

                StartCoroutine(ShootDelay());
                Debug.Log("Shooting");
                return;
            }
            //else i++;
        }
    }
    private void CreateBullets()
    {
        for(int i = 0; i < fBulletsArray.Length; i++)
        {
            fBulletsArray[i] = Instantiate(fBullet, new Vector3(i,0,0), Quaternion.identity, parentB);
            fBulletsArray[i].transform.localPosition = new Vector3(i,0,0);
        }
        for(int i = 0; i < iBulletsArray.Length; i++)
        {
            iBulletsArray[i] = Instantiate(iBullet, new Vector3(i,0,0), Quaternion.identity, parentB);
            iBulletsArray[i].transform.localPosition = new Vector3(i,-1,0);
        }
    }
    private void ReceiveDamage()
    {
        life -= 1;
        if(life == 2)
        {
            //lose one wing;
            /*move = new Vector3 (axis.x, 0, 0);
            move = move * speed/3 * Time.deltaTime;
            transform.position += move;*/
        }
        else if(life == 1)
        {
            //lose two wings;
            speed /= 1.5f;
        }
        else Die();
    }
    private void Die()
    {
        speed = 0;
        canShoot = false;
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    public void GetPowerUp(string power)
    {
        if(power == "Triple")
        {
            triShoot = true;
        }
        if(power == "Divide")
        {
            divideShoot = true;
        }
        if(power == "Life")
        {
            if(life >= 3) return;
            life += 1;
            speed = initialSpeed;
        }
    }
}