using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{

    private List<GameObject> fat;
    private float increment;
    private int clean = 0;
    private Rigidbody2D rb;

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
            increment = 100 / fat.Count;
    }

    private void OnMouseDrag()
    {
        if( fat.Count <= 0 )
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Chopper")
        {
            Destroy(gameObject);
        }
    }

    public void CleanMeat(GameObject fat)
    {
        clean += (int)increment;
        if (clean >= 100)
        {
            clean = 100;
        }
        this.fat.Remove(fat);
        Debug.Log("Actual clean: " + clean);
    }
}
