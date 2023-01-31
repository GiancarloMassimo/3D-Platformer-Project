using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePlayer : MonoBehaviour
{

    GameObject collectable1;
    GameObject collectable2;
    GameObject collectable3;

    public bool collect1 = false;
    public bool collect2 = false;
    public bool collect3 = false;
    // Start is called before the first frame update
    void Start()
    {
        collectable1.SetActive(true);
        collectable2.SetActive(true);
        collectable3.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.name.Equals("collectable1")){
            collectable1.SetActive(false);
            collect1 = true;
        }

         if(other.gameObject.name.Equals("collectable2")){
            collectable2.SetActive(false);
            collect2 = true;
        }

         if(other.gameObject.name.Equals("collectable3")){
            collectable3.SetActive(false);
            collect3 = true;
        }
    }


}
