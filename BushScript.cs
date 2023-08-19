using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{
    public PlayerMoveScript playerScript;
    public AudioSource rustle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && playerScript.alreadyMoving)
        {
            rustle.Play();
        }
    }
}
