using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefensive : EnemyGeneric
{
	private GameObject playerObject;
	private Vector3 target;
    bool landingPhase,formationPhaseAxis;
    float random1,random2;
    int unUnoxD,unoRandomjaja;
	// Start is called before the first frame update
    void Start()
    {
        landingPhase=true;
        unUnoxD=(Random.Range(0,2));

    if(unUnoxD==1){unoRandomjaja=1;formationPhaseAxis=!formationPhaseAxis;}else{unoRandomjaja=-1;}

		random1=(Random.Range(unoRandomjaja,0));
        random2=(Random.Range(0f,-1f));
        //                          MOVEMENT        The enemy falls from the sky 
         target = new Vector3 (random1,random2,0f);
    }

    // Update is called once per frame
    public void Update()
    {//                             MOVEMENT        Constant movement 
        Debug.Log(landingPhase);
        transform.Translate(target*speed*Time.deltaTime, Space.World);
     //                        MOVEMENT        The enemy falls from the sky 
    if(landingPhase==false){
     //                        MOVEMEMNT       The enemy gets in "formation"
        if(formationPhaseAxis==false){target = new Vector3(-1,0);
    }else{target = new Vector3(1,0);}
       
        
    }
        
        //                          ENEMY DEATH
		if(life<=0) 
		{
			Death();
		}
    }

    void OnTriggerExit2D(Collider2D other)
{
    if (other.tag == "Bound")
    {
        landingPhase=false;
        Debug.Log("I have collapsed with a bound");
        formationPhaseAxis=!formationPhaseAxis;
    }
}


//                                  BULLET COLLIDER
}
