using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHearts : MonoBehaviour
{
    [SerializeField] GameObject[] hearts = new GameObject[3];
    [SerializeField] int numOfHearts = 3;

    [SerializeField] GameObject eyeClose;

    [SerializeField] GameObject player;

    [SerializeField] GameObject[] obstacles;


     
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
            //eyeClose.SetActive(true);
        }
       
    }

    private void OnCollisionEnter(Collision other) {
        //If its a item damage

            for(int i = 0; i < obstacles.Length; i++){
                if(other.gameObject.name.Equals(obstacles[i].gameObject.name)){
                    TakeDamage();
                }
            }
            
    }

    void restartPlayer(){
        player.transform.position = new Vector3((float)31.21, (float)4.65, (float)69.47);
        eyeClose.SetActive(false);

    }

    
}
