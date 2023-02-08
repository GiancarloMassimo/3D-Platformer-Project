using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    [SerializeField] GameObject[] hearts = new GameObject[3];
    [SerializeField] int numOfHearts = 3;


     [SerializeField] int maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        numOfHearts = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(){

        numOfHearts--;
        if(numOfHearts >= 0){
            hearts[numOfHearts].SetActive(false);
        }
        if(numOfHearts <= 0){
            //respawn
        }
       
    }

    private void OnCollisionEnter(Collision other) {
        //If its a item damage

            if(other.gameObject.name.Equals("Robert")){
                TakeDamage();
            }if(other.gameObject.name.Equals("Engie")){
                TakeDamage();
            }if(other.gameObject.name.Equals("Catherine")){
                TakeDamage();
            }
    }

    
}
