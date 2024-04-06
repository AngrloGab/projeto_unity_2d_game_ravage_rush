using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Voltou o suficiente

public class SpawnBrics : MonoBehaviour
{
    
    public GameObject brick;
    public GameObject frog;
    public float heigth;
    public float maxTime;

    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBrick = Instantiate(brick);
        newBrick.transform.position = transform.position + new Vector3(0, 0 ,0);
        newBrick.layer = 9;

         

    }

    // Update is called once per frame
    void Update()
    {
         float chance = Random.value;

        if(timer > maxTime){
            GameObject newBrick = Instantiate(brick);
            newBrick.transform.position = transform.position + new Vector3(0, Random.Range(-heigth,heigth),0);
            newBrick.layer = 9;
            Destroy(newBrick, 20f);


            if (chance < 0.5f)
            {
                GameObject newFrog = Instantiate(frog);
                newFrog.transform.position = newBrick.transform.position + new Vector3(0, 0.1f,0);
                newFrog.layer = 10;
                Destroy(newFrog, 20f);
            }

            timer = 0;
        }

        timer += Time.deltaTime;
    }

    
}
