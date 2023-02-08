using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] CollectablePlayer collectable;
    public Vector3 spawn;
    public Vector3 startPoint;
    public Vector3 area1;
    public Vector3 area2;
    public Vector3 area3;


    // Start is called before the first frame update
    void Start()
    {

        spawn = transform.position;
        startPoint = spawn;
        area1 = new Vector3( (float)31.21, (float)4.65, (float)84.35);
    }

    // Update is called once per frame
    void Update()
    {
       //
        //if(transform.position.x > 0 || transform.position.x < 0){
         //   if(transform.position.y > 0 || transform.position.y < 0){
            //    if(transform.position.z > 0 || transform.position.z < 0){
              //      spawn = area2;
                //}
            //}
        //}

       // if(transform.position.x > 0 || transform.position.x < 0){
        //    if(transform.position.y > 0 || transform.position.y < 0){
        //        if(transform.position.z > 0 || transform.position.z < 0){
        //            spawn = area3;
        //        }
        //    }
        //}

        //if(transform.position.x > 0 || transform.position.x < 0){
         //   if(transform.position.y > 0 || transform.position.y < 0){
        //        if(transform.position.z > 0 || transform.position.z < 0){
        //            spawn = area1;
        //        }
        //    }
        //}
    }


}
