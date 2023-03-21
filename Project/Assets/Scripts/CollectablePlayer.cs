using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePlayer : MonoBehaviour
{
    
    [SerializeField] GameObject collectable1;
    [SerializeField] GameObject collectable2;
    [SerializeField] GameObject collectable3;
    [SerializeField] GameObject c;
    [SerializeField] GameObject c1;
    [SerializeField] GameObject c2;
    [SerializeField] GameObject[] collectable;

    public bool collect1 = false;
    public bool collect2 = false;
    public bool collect3 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        collectable1.SetActive(true);
        collectable2.SetActive(true);
        collectable3.SetActive(true);
        c.SetActive(false);
        c1.SetActive(false);
        c2.SetActive(false);

    }
    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.name.Equals("Potion1")){
            collectable1.SetActive(false);
            collect1 = true;
            Dialogue.instance.TriggerDialogue(new string[] { "1", "2", "3" });
        }

        if(other.gameObject.name.Equals("wand05_red")){
            collectable2.SetActive(false);
            collect2 = true;
            Dialogue.instance.TriggerDialogue(new string[] {"good job on finding the wand", "Now go pick up the potion off the table on the second building"}) ;
        }

        if(other.gameObject.name.Equals("orb05_red")){
            collectable3.SetActive(false);
            collect3 = true;
            Dialogue.instance.TriggerDialogue(new string[] { "1","2","3" });
        }

        for(int i = 0; i < collectable.Length; i++){
            if(other.gameObject.name.Equals(collectable[i].gameObject.name)){
                collectable[i].SetActive(false);
            }
        }

        if(other.gameObject.name.Equals("cube") && collect1 && collect2 && collect3){
            c.SetActive(true);
            c1.SetActive(true);
            c2.SetActive(true);
        }

    }



}
