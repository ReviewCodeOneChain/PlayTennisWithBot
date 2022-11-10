using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    } 

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * 0);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed * -1);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
    }
}
