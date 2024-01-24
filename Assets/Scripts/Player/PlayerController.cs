using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5;

    private Rigidbody2D rb;
    private Vector2 gotoPos;
    private bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
           gotoPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (canMove)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, gotoPos, Time.deltaTime * speed));
        }

    }

    public void changeMovement()
    {
        canMove = !canMove;
    }

}
