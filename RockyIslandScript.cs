using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyIslandScript : MonoBehaviour
{
    Collider2D hit;
    LogicScript logicScript;
    public AudioSource splash;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        hit = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y), 8,-0.9f,-1.1f);
        if (hit != null)
        {
            CoordinateList.Add(new System.Tuple<float, float>(transform.position.x, transform.position.y));
            Debug.Log(CoordinateList.Count.ToString());
        }*/
    }
    
    //add x and y coordinates to a list when object enters the island trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==8)
        {
            System.Tuple<float, float> c = new System.Tuple<float, float>(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            logicScript.CoordinateList.Add(c);
            /*
            Debug.Log(c.ToString());
            Debug.Log(CoordinateList.Count.ToString());
            */
        }
        if (collision.gameObject.layer == 0)
        {
            logicScript.playerActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            splash.Play();
            logicScript.playerActive = false;
            
        }
    }
}
