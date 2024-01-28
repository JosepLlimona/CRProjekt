using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatController : MonoBehaviour
{

    private bool isDeattached = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        if(isDeattached)
        {
            rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trash")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Meat")
        {
            collision.GetComponentInParent<MeatController>().CleanMeat(this.gameObject);
        }
    }

    public void Deattach()
    {
        this.gameObject.tag = "DeattachedFat";
        transform.parent = null;
        isDeattached = true;
    }
}
