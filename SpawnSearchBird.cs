using System.Collections.Generic;
using UnityEngine;

public class SpawnSearchBird : MonoBehaviour
{
    public Collider2D islandCollider;
    public GameObject searchBird1;
    /*
    public GameObject searchBird2;
    public GameObject searchBird3;
    public GameObject searchBird4;
    public GameObject searchBird5;
    public GameObject searchBird6;
    float minX;
    float minY;
    float maxY;
    int numIntervals = 5;
    float intervalSize;
    */
    // Start is called before the first frame update
    void Start()
    {   
        /*
        //get the leftmost, bottommost, & topmost boundaries of the island
        minX = islandCollider.bounds.min.x;
        minY = islandCollider.bounds.min.y;
        maxY = islandCollider.bounds.max.y;
        //vertical spacing between search birds
        intervalSize = (maxY - minY) / numIntervals;
        */
        //create 6 parallel birds at leftmost edge of the island to capture both boundaries of the island trigger as the birds move right
        Instantiate(searchBird1, new Vector3(-40, -30f, 1), Quaternion.Euler(Vector3.forward * 0));
        /*
        Instantiate(searchBird2, new Vector3(minX - 1, minY + intervalSize, 1), Quaternion.Euler(Vector3.forward * 0));
        Instantiate(searchBird3, new Vector3(minX - 1, minY + 2 * intervalSize, 1), Quaternion.Euler(Vector3.forward * 0));
        Instantiate(searchBird4, new Vector3(minX - 1, minY + 3 * intervalSize, 1), Quaternion.Euler(Vector3.forward * 0));
        Instantiate(searchBird5, new Vector3(minX - 1, minY + 4 * intervalSize, 1), Quaternion.Euler(Vector3.forward * 0));
        Instantiate(searchBird5, new Vector3(minX - 1, minY + 5 * intervalSize, 1), Quaternion.Euler(Vector3.forward * 0));
        */

        //birdScript = searchBird.GetComponent<SearchBirdScript>();
        //birdScript = searchBird.GetComponent<SearchBirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //tupleList = birdScript.TupleList;
        //Debug.Log(birdScript.TupleList.ToString());
    }

    
}
