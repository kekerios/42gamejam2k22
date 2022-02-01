using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 axis;
    private Vector3 move;
    private PlayerBehaviour player;
    private UI ui;
    public bool isMobile;
    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMobile)
        {
            if (Input.GetButton("Fire1"))
            {
                player.ShootF();
            }
            if (Input.GetButton("Fire2"))
            {
                player.ShootI();
            }
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
                player.Move(axis);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ui.ShowPauseMenu();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                axis = touch.position;
                player.Move(axis);
            }  
        }
    }
    
}
