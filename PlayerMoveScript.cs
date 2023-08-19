using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public Animator standingController;
    public Animator walkingLController;
    public Animator walkingRController;
    public Animator shootingController;
    public Animator sinkingController;
    public AudioSource swimmingSFX;
    public GameObject standingPerson;
    public GameObject walkingLPerson;
    public GameObject walkingRPerson;
    public GameObject shootingPerson;
    public GameObject sinkingPerson;
    public GameObject wadingPerson;
    public LogicScript logicScript;
    public Rigidbody2D myRigidBody;
    public SpawnBulletScript spawnBulletScript;
    public float myDriftSpeed;
    public float mySwimSpeed;
    public double spawnRate;
    private float timer;
    private float timer2;
    private double splashTime;
    public bool walkL;
    private float lastAngle;
    public bool shooting;
    public bool swimming;
    public bool wading;
    public bool alreadyMoving;


    // Start is called before the first frame update
    void Start()
    {
        standingPerson.SetActive(true);
        walkingLPerson.SetActive(false);
        walkingRPerson.SetActive(false);
        shootingPerson.SetActive(false);
        sinkingPerson.SetActive(false);
        lastAngle = 0;
        walkL = true;
        shooting = false;
        alreadyMoving = false;
        wading = false;
        swimming = false;
        spawnBulletScript = GameObject.FindGameObjectWithTag("Bullet Spawner").GetComponent<SpawnBulletScript>();
        spawnRate = 0.25;
        timer = 0;
        timer2 = 0;
        splashTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (logicScript.playerActive == true)
        {
            if (swimming)
            {
                stopSwim(lastAngle);
                swimmingSFX.Stop();
                swimming = false;
                wading = false;
            } else
            {
                if (!alreadyMoving)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (shooting == true && (lastAngle != 0 && lastAngle != 180))
                        {
                            walkL = walkFunction(walkL, 270);
                            alreadyMoving = true;
                        }
                        else if (shooting == false)
                        {
                            walkL = walkFunction(walkL, 270);
                            lastAngle = 270;
                            alreadyMoving = true;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (shooting == true && (lastAngle != 0 && lastAngle != 180))
                        {
                            walkL = walkFunction(walkL, 90);
                            alreadyMoving = true;
                        }
                        else if (shooting == false)
                        {
                            walkL = walkFunction(walkL, 90);
                            lastAngle = 90;
                            alreadyMoving = true;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (shooting == true && (lastAngle != 90 && lastAngle != 270))
                        {
                            walkL = walkFunction(walkL, 180);
                            alreadyMoving = true;
                        }
                        else if (shooting == false)
                        {
                            walkL = walkFunction(walkL, 180);
                            lastAngle = 180;
                            alreadyMoving = true;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (shooting == true && (lastAngle != 90 && lastAngle != 270))
                        {
                            walkL = walkFunction(walkL, 0);
                            alreadyMoving = true;
                        }
                        else if (shooting == false)
                        {
                            walkL = walkFunction(walkL, 0);
                            lastAngle = 0;
                            alreadyMoving = true;
                        }
                    }
                }
                //right arrow
                if (alreadyMoving)
                {
                    if (Input.GetKeyUp(KeyCode.RightArrow))
                    {
                        stopWalkFunction(walkL, 270);
                        alreadyMoving = false;
                    }
                    else if (Input.GetKeyUp(KeyCode.LeftArrow))
                    {
                        stopWalkFunction(walkL, 90);
                        alreadyMoving = false;
                    }
                    else if (Input.GetKeyUp(KeyCode.DownArrow))
                    {
                        stopWalkFunction(walkL, 180);
                        alreadyMoving = false;
                    }
                    else if (Input.GetKeyUp(KeyCode.UpArrow))
                    {
                        stopWalkFunction(walkL, 0);
                        alreadyMoving = false;
                    }
                }

                //spacebar
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    shooting = true;
                    shootFunction(lastAngle);
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    shooting = false;
                    stopShootingFunction();
                }

                if (shooting == true)
                {
                    if (timer < spawnRate)
                    {
                        timer = timer + Time.deltaTime;
                    }
                    else
                    {
                        spawnBulletScript.spawnBullet(myRigidBody.position.x, myRigidBody.position.y, 0, lastAngle);
                        timer = 0;
                    }
                }
            }
        } else
        {
            if (!wading)
            {
                wade(lastAngle);
                wading = true;
            } else
            {
                 if (Input.GetKeyDown(KeyCode.RightArrow))
                 {
                     swim(270);
                        lastAngle = 270;
                    }
                 else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        swim(90);
                        lastAngle = 90;
                    }
                 else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        swim(180);
                        lastAngle = 180;
                    }
                 else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        swim(0);
                        lastAngle = 0;
                    }
             }
        }
    }
            /*
            if (timer2 < splashTime)
            {
                timer2 = timer2 + Time.deltaTime;
                splash.Play();
            } else
            {
                timer2 = 0;
            }*/
            
            /*
            Destroy(walkingLPerson);
            Destroy(walkingRPerson);
            Destroy(shootingPerson);
            */
            //

            //
            //
            //
            /*
            Destroy(sinkingPerson);
            */
        
   //end update
    public bool walkFunction(bool walkL, float angle)
    {
        rotateMoveFunction(angle);
        standingPerson.SetActive(false);
        if (walkL)
        {
            walkingLPerson.SetActive(true);
            walkingLController.Play("walkingL");
            return false;
        }
        else
        {
            walkingRPerson.SetActive(true);
            walkingRController.Play("walkingR");
            return true;
        }
    }

    public void stopWalkFunction(bool walkL, float angle)
    {
        rotateStopFunction(angle);
        if (walkL)
        {
            walkingRPerson.SetActive(false);
            
        } else
        {
            walkingLPerson.SetActive(false);
        }
        standingPerson.SetActive(true);
        standingController.Play("standing");
    }
    public void rotateStopFunction(float angle)
    {
        if (angle == 0)
        {
            myRigidBody.velocity = Vector2.up * 0;
        }
        else if (angle == 90)
        {
            myRigidBody.velocity = Vector2.left * 0;
        }
        else if (angle == 180)
        {
            myRigidBody.velocity = Vector2.down * 0;
        }
        else if (angle == 270)
        {
            myRigidBody.velocity = Vector2.right * 0;
        }
    }
    public void rotateMoveFunction(float angle)
    {
        if (!shooting)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        if (angle == 0)
        {
            myRigidBody.velocity = Vector2.up * myDriftSpeed;
        }
        else if (angle == 90)
        {
            myRigidBody.velocity = Vector2.left * myDriftSpeed;
        }
        else if (angle == 180)
        {
            myRigidBody.velocity = Vector2.down * myDriftSpeed;
        }
        else if (angle == 270)
        {
            myRigidBody.velocity = Vector2.right * myDriftSpeed;
        }
    }
    public void shootFunction(float angle)
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        standingPerson.SetActive(false);
        shootingPerson.SetActive(true);
        shootingController.Play("shooting");
        spawnBulletScript.spawnBullet(myRigidBody.position.x, myRigidBody.position.y, 0, angle);
    }
    public void stopShootingFunction()
    {
        shootingPerson.SetActive(false);
        standingPerson.SetActive(true);
        standingController.Play("standing");
    }
    private void swim(float angle)
    {
        wadingPerson.SetActive(false);
        sinkingPerson.SetActive(true);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        sinkingController.Play("sinking", -1, 1);
        if (!swimming)
        {
            swimmingSFX.Play();
            swimming = true;
        }
        if (angle == 0)
        {
            myRigidBody.velocity = Vector2.up * mySwimSpeed;
        }
        else if (angle == 90)
        {
            myRigidBody.velocity = Vector2.left * mySwimSpeed;
        }
        else if (angle == 180)
        {
            myRigidBody.velocity = Vector2.down * mySwimSpeed;
        }
        else if (angle == 270)
        {
            myRigidBody.velocity = Vector2.right * mySwimSpeed;
        }
    }

    private void stopSwim(float angle)
    {
        sinkingPerson.SetActive(false);
        standingPerson.SetActive(true);
        if (angle == 0)
        {
            myRigidBody.velocity = Vector2.up * 0;
        }
        else if (angle == 90)
        {
            myRigidBody.velocity = Vector2.left * 0;
        }
        else if (angle == 180)
        {
            myRigidBody.velocity = Vector2.down * 0;
        }
        else if (angle == 270)
        {
            myRigidBody.velocity = Vector2.right * 0;
        }
        standingController.Play("standing");
    }

    private void wade(float angle)
    {
        standingPerson.SetActive(false);
        walkingLPerson.SetActive(false);
        walkingRPerson.SetActive(false);
        shootingPerson.SetActive(false);
        wadingPerson.SetActive(true);
        if (angle == 0)
        {
            myRigidBody.velocity = Vector2.up * 0;
        }
        else if (angle == 90)
        {
            myRigidBody.velocity = Vector2.left * 0;
        }
        else if (angle == 180)
        {
            myRigidBody.velocity = Vector2.down * 0;
        }
        else if (angle == 270)
        {
            myRigidBody.velocity = Vector2.right * 0;
        }
    }
}
