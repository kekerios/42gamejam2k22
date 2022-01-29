using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    private bool isRed = true;
    public bool isMoving = false;
    public int damage = 1;
    public float speed = 5;
    private Vector3 startingPos;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
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
        }
    }
    public void Reset()
    {
        transform.position = startingPos;
        isMoving = false;
    }
    public void Shoot(Vector3 nDirection)
    {
        isMoving = true;
        direction = nDirection;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Bound")
        {
            Reset();
        }
    }
}
