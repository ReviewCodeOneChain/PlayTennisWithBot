using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    //[SerializeField] GameObject BallPrefab;

//    Vector3 ballPos;
    
//    Vector3 endPointPos;
//    Vector3 direction;
//    Vector3 startPos;
//    bool isTouch;
//    public RaycastHit hit;
//    Vector3 pressMousePos;
//    Vector3 releaseMousePos;

//    [SerializeField] float posMinZ = -30f;
//    [SerializeField] float posMaxZ = 30f;
//    [SerializeField] float posMaxX = 20f;
//    [SerializeField] float posMinX = -20f;

//    [SerializeField] float force = 10f;
//    [SerializeField] float time;
//    [SerializeField] float speed = 2f;
//    // Start is called before the first frame update
//    void Start()
//    {
//        ballPos = new Vector3 (0, 4, 1);
//        startPos = transform.position;
//        direction = new Vector3(0, 1, 1);
//;       //direction = endPointPos - ballPos;

//        //direction = ballPos(0, transform.position.y++, transform.position.z++);
//    }

//    void FixedUpdate()
//    {
//        time += Time.fixedDeltaTime * speed;
       
//        transform.position = move(direction, time);

        

//        if (Input.GetMouseButtonDown(0))
//        {
//            //pressMousePos = Camera.main.WorldToViewportPoint(Input.mousePosition)
//            pressMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//        }
//        if (Input.GetMouseButtonUp(0))
//        {
//            //releaseMousePos = Camera.main.WorldToViewportPoint(Input.mousePosition);
//            releaseMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//        }

//        CheckCollider();

//        if (!isTouch) return;

//        if (hit.collider.transform.CompareTag("Wall"))
//        {
//            direction = -direction;
//            force *= 0.9f;
//            if (force <= 0) force = 0;
//        } else if (hit.collider.transform.CompareTag("Player"))
//        {
//            direction = -direction;
//            direction.x = ((releaseMousePos - pressMousePos)/ (releaseMousePos - pressMousePos).magnitude).x;
//            direction.z = ((releaseMousePos - pressMousePos) / (releaseMousePos - pressMousePos).magnitude).y;
//            force = 12f;
//        } else if (hit.collider.transform.CompareTag("Enemy"))
//        {
//            direction = -direction;
//            force = 12f;
//        }
//        else
//        {
//            direction = Vector3.Reflect(direction, hit.normal);
//            force*=0.9f;
//            if (force <= 0) force = 0;
//        }
//        startPos = transform.position;
//        time = 0;

//        ReloadGame();
//    }

//    public void CheckCollider()
//    {
//        float timeFut = time + (Time.fixedDeltaTime * speed);
//        Vector3 posFuture = move(direction, timeFut);
//        Vector3 directionFuture = posFuture - transform.position;

//        float distance = Vector3.Distance(posFuture, transform.position) + 0.5f;
//        isTouch = Physics.Raycast(transform.position, directionFuture, out hit, distance);
//    }

//    private void ReloadGame()
//    { 
//        if (transform.position.x > posMaxX || transform.position.x < posMinX || transform.position.z < posMinZ || transform.position.z > posMaxZ)
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }

//    public Vector3 move(Vector3 direction, float time)
//    {
//        return startPos + (direction * force * time) + 0.5f * Physics.gravity * (time * time);
//    }
}
