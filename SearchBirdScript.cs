using System.Collections.Generic;
using UnityEngine;

public class SearchBirdScript : MonoBehaviour
{
    //public Collider2D hit;
    bool moveLeft;
    bool alive;
    LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = false;
        alive = true;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //bird starts at the leftmost coordinate of island, so it can enter the leftmost coordinate of island trigger
        /*
        Debug.Log(string.Format("minX = {0}", minX));
        Debug.Log(string.Format("maxX = {0}", maxX));
        Debug.Log(string.Format("minY = {0}", minY));
        Debug.Log(string.Format("maxY = {0}", maxY));
        */
        //hit = GameObject.FindGameObjectWithTag("Rocky Island").GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
        moveSearchBird();
        } 
        
    }

    

    //object moves right until it exits the rightmost coordinate of island trigger, then it is removed from memory
    
    void moveSearchBird()
    {
        if (transform.position.x < 40 && moveLeft==false)
        {
            transform.position = transform.position + Vector3.right * 1000 * Time.deltaTime;
        } else if (transform.position.x > 40 && moveLeft == false)
        {
            transform.position = transform.position + Vector3.up * 100 * Time.deltaTime;
            moveLeft = true;
        } else if (transform.position.x > 40 && moveLeft == true)
        {
            transform.position = transform.position + Vector3.left * 1000 * Time.deltaTime;
        } else if (transform.position.x > -40 && moveLeft == true)
        {
            transform.position = transform.position + Vector3.left * 1000 * Time.deltaTime;
        }
        else if (transform.position.x < -40 && moveLeft == true)
        {
            transform.position = transform.position + Vector3.up * 100 * Time.deltaTime;
            moveLeft = false;
        } else if (transform.position.x < -40 && moveLeft == false)
        {
            transform.position = transform.position + Vector3.right * 1000 * Time.deltaTime;
        } 
        if(transform.position.y > -5)
        {
            Destroy(gameObject);
            logicScript.doneMapping = true;
            alive = false;
        }
    }
}
