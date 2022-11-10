using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TennisBallControler : MonoBehaviour
{
    Vector3 startPos;

    Vector3 direction;

    RaycastHit hit;
    bool isHit;
    Vector3 dirDown;
    bool touchBat;

    Vector2 press;
    Vector2 release;

    GameManager gm;
    
    float bounceForce = 1f;

    [SerializeField] float posMinZ = -30f;
    [SerializeField] float posMaxZ = 30f;
    [SerializeField] float posMaxX = 20f;
    [SerializeField] float posMinX = -20f;

    [SerializeField] float force;
    [SerializeField] float time;
    [SerializeField] float speed;

    [SerializeField] bool playerHitted;
    int countTouchGround;

    bool inZone = true;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //startPos = transform.position;
        //direction = new Vector3(0, 1, 1);

        //Debug.Log(Physics.gravity.y);
        //transform.position = ballPosStart;

        

        



        startPos = transform.position;
        dirDown = new Vector3(0, 5, -15);
        Level();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime * speed;

        if (Input.GetMouseButtonDown(0))
            press = pressMousePosition();   
        if (Input.GetMouseButtonUp(0))
            release = releaseMousePosition();

        

        if (touchBat == false)
        {
            jumpOnTheSpot(dirDown, time);

            if (CheckTouchBat())
            {
                startPos = transform.position;
                //direction = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
                direction = Vector3.Reflect(direction, Vector3.up);
                direction.x = ((release - press) / (release - press).magnitude).x;
                direction.z = ((release - press) / (release - press).magnitude).y;
                direction.y = 1f;
                force = 12f;
                bounceForce = 0.9f;
                playerHitted = true;
                countTouchGround = 0;

                startPos = transform.position;
                time = 0;

                touchBat = true;
            }
        } 

        transform.position = move(direction, time, force);
        if (CheckCollide(time, direction, force))
        {
            ProcessCollide();
        }

        ReloadGame();
    }

    private void Level()
    {
        if (GameManager.isEasy)
        {
            speed = 1f;
        } else
        {
            speed = 3;
        }            
    }    

    void ProcessCollide()
    {
        if (hit.collider.transform.CompareTag("Ground"))
        {
            countTouchGround++;
            direction = Vector3.Reflect(direction, hit.normal);
            //GameManager.Score(transform.position, playerHitted, countTouchGround, inZone);

            //direction = Vector3.Reflect(direction, Vector3.up);
            force *= bounceForce;
        }
        else if (hit.collider.transform.CompareTag("Player"))
        {
            countTouchGround = 0;
            Debug.Log(countTouchGround + hit.collider.name);
            playerHitted = true;
            //Debug.Log(hit.collider.name);
            direction = -direction;
            direction.x = ((release - press) / (release - press).magnitude).x;
            direction.z = ((release - press) / (release - press).magnitude).y;
            direction.y = 1f;
            force = 12f;
        }
        else if (hit.collider.transform.CompareTag("Enemy"))
        {
            //direction = -direction;
            countTouchGround = 0;
            playerHitted = false;
            if (GameManager.isEasy)
            {
                direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                Vector3 temp;
                if (transform.position.x > 0)
                {
                    temp = new Vector3(transform.position.x - Random.Range(0, 1), transform.position.y + 1f, transform.position.z - Random.Range(1, 2));
                }
                else
                {
                    temp = new Vector3(transform.position.x + Random.Range(0, 1), transform.position.y + 1f, transform.position.z - Random.Range(1, 2));
                }
                direction = temp - transform.position;
            }

            force = Random.Range(12, 15);
            //Debug.Log(force);
        }
        else
        {
            direction = Vector3.Reflect(direction, hit.normal);
            force *= 0.9f;
        }
        //Debug.Log(direction);
        startPos = transform.position;
        time = 0;
    }

    private void jumpOnTheSpot(Vector3 dirDown, float time)
    {
        direction = dirDown - startPos;
        transform.position = move(direction, time, force);
    }

    private Vector2 pressMousePosition()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }    

    private Vector2 releaseMousePosition()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y); ;
    }      

    private bool CheckCollide(float time, Vector3 direction, float force)
    {
        float timeFut = time + (Time.fixedDeltaTime * speed);

        Vector3 posFuture = move(direction, timeFut, force);
        Vector3 directionFuture = posFuture - transform.position;

        float distance = Vector3.Distance(posFuture, transform.position) + 0.5f;
        Debug.DrawRay(transform.position, transform.TransformDirection(directionFuture));

        isHit = Physics.Raycast(transform.position, directionFuture, out hit, distance);

        return isHit;
    }

    private bool CheckTouchBat()
    {
        Vector3 posFuture = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
        Vector3 directionFuture = posFuture - transform.position;
        float distance = Vector3.Distance(posFuture, transform.position) + 0.5f;
        Debug.DrawRay(transform.position, directionFuture);
        isHit = Physics.Raycast(transform.position, directionFuture, out hit, distance);

        return isHit;
    }

    public Vector3 pointTouchGround()
    {
        float t = 0;
        while(true)
        {
            t += Time.fixedDeltaTime;
            Vector3 pointTouchGr = move(direction, t, force);
            if (pointTouchGr.y <= 0)
            {
                return pointTouchGr;
            }
        }
    }

    private void ReloadGame()
    {
        if (transform.position.x > posMaxX || transform.position.x < posMinX || transform.position.z < posMinZ || transform.position.z > posMaxZ || force == 0)
        {
            inZone = false;
            gm.Score(transform.position, playerHitted, countTouchGround, inZone);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
    }

    private Vector3 move(Vector3 direction, float time, float force)
    {
        return startPos + (direction * force * time) + 0.5f * Physics.gravity * (time * time);
    }
}
