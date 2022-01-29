using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPBullet : MonoBehaviour
{
    public bool isRed;
    private bool isMoving = false;
    private Vector3 direction;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    public void Shoot(Vector3 nDirection)
    {
        isMoving = true;
        direction = nDirection;
    }
}
