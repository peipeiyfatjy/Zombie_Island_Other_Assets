using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBushScript : MonoBehaviour
{
    public GameObject bush;
    LogicScript logicScript;
    System.Random random;
    int n;
    float X1;
    float X2;
    float Y1;
    float Y2;
    // Start is called before the first frame update
    void Start()
    {
        //islandScript = GameObject.FindGameObjectWithTag("Rocky Island").GetComponent<SpawnRockyIslandScript>();
        //while (islandScript.counter < 5)
        //{
        //islandScript = GameObject.FindGameObjectWithTag("Rocky Island").GetComponent<SpawnRockyIslandScript>();
        //}
        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (logicScript.doneMapping==true)
        {
            for (int i = 0; i < 10; i++)
            {
                n = random.Next(0, logicScript.CoordinateList.Count - 1);
                X1 = logicScript.CoordinateList[n].Item1;
                Y1 = logicScript.CoordinateList[n].Item2;
                X2 = logicScript.CoordinateList[n + 1].Item1;
                Y2 = logicScript.CoordinateList[n + 1].Item2;
                spawnBush(X1, X2, Y1, Y2);
            }
            logicScript.doneMapping = false;
        }
        
    }
    public void spawnBush(float x1,float x2,float y1,float y2)
    {
        float xPos = Random.Range(x1, x2);
        float yPos = Random.Range(y1, y2);
        float angle = Random.Range(0, 360);
        Instantiate(bush, new Vector3(xPos, yPos, -1), Quaternion.Euler(Vector3.forward * angle));
    }
}
