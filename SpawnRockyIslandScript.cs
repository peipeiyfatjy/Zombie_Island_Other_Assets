using UnityEngine;

public class SpawnRockyIslandScript : MonoBehaviour
{
    public GameObject rockyIsland;
    // Start is called before the first frame update
    void Start()
    {
        spawnRockyIsland();
    }
    void spawnRockyIsland()
    {
        Instantiate(rockyIsland, new Vector3(0, 0, 1), Quaternion.Euler(Vector3.forward * 0));
    }

}
