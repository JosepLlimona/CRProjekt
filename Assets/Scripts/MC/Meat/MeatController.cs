using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{

    private List<GameObject> fat;
    private Rigidbody2D rb;

    public float mass;
    private bool isInBox = true;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fat = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if(child.tag == "Fat")
            {
                fat.Add(child.gameObject);
            }

        }

        mass = Random.Range(0.5f, 3.5f);
        mass = Mathf.Round(mass * 100f) / 100f;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Entering");
        //if (fat.Count <= 0 || canMove)
        //{
            rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)));
        //}
    }

    private void OnMouseUp()
    {
        canMove = !isInBox;
        if(!isInBox)
        {
            gameObject.layer = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Chopper")
        {
            collision.GetComponent<ChopperController>().addMass(mass);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Box")
        {
            isInBox = false;
        }
    }

    public void CleanMeat(GameObject fat)
    {
        this.fat.Remove(fat);
        if(this.fat.Count <= 0)
        {
            gameObject.layer = 0;
        }
    }
}
