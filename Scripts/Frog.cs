using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Voltou o suficiente

public class Frog : MonoBehaviour
{
    public float speed;

    public float timer = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

       
    }
    public void Devour(){
         Destroy(gameObject);
    }
}
