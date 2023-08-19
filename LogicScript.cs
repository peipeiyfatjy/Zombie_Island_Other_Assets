using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    //create list for x and y coordinates of the island-water border
    private List<System.Tuple<float, float>> coordinateList = new List<System.Tuple<float, float>>();
    public List<System.Tuple<float, float>> CoordinateList
    {
        get { return coordinateList; }   // get method
        set { coordinateList = value; }
    }
    public bool doneMapping;
    public bool playerActive;
    // Start is called before the first frame update
    void Start()
    {
        doneMapping = false;
        playerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
