using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 15;
    [SerializeField] Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        //ballGO = GameObject.FindWithTag("Target");
        //posHitted = ballGO.GetComponent<BallController>().move();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (ball.position.z >= 0)
        {
            //transform.position = Vector3.Lerp(transform.position, ball.position, Time.deltaTime * 1 + 0.5f);
            Vector3 targetPos = ball.GetComponent<TennisBallControler>().pointTouchGround();
            targetPos.z -= 2f; //tien ve truoc 1f de va cham ball soon
            targetPos.y = 0;
            if (targetPos.z > 30)
                targetPos.z = 30;
            if (targetPos.z < 0)
                targetPos.z = 0;
            if (targetPos.x > 19)
                targetPos.x = 19;
            if (targetPos.x < -19)
                targetPos.x = -19;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        //else
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 22), speed * Time.deltaTime);
        //}
    }
}

//MoveTowards: di chuyen toi vi tri muc tieu
