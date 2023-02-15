using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{

    [SerializeField] int maxHealth = 100;
    
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name.Equals("Papermen")){
            TakeDamage();
        }
    }

    public void TakeDamage(){

        currentHealth -= 20;

       
    }
}
