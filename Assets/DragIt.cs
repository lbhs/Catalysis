using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragIt : MonoBehaviour
{
    private bool isDragging;
    private Vector2 mousePosition;
    private Vector2 MovePosition;
    private float deltaX;
    private float deltaY;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void OnMouseDown()
    {
        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        deltaX = mousePosition.x - transform.position.x;
        deltaY = mousePosition.y - transform.position.y;
        
    }

    public void OnMouseUp()
    {
        if (gameObject.GetComponent<H_DraggingScript>() && gameObject.GetComponent<H_DraggingScript>().IsDraggable == true)
        {
            gameObject.GetComponent<H_DraggingScript>().LetTheH_Float();
        }
    }

   
    
    void OnMouseDrag()
    {
        if (gameObject.GetComponent<H_DraggingScript>() && gameObject.GetComponent<H_DraggingScript>().IsDraggable == false)
        {
           
        }

        else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));
            //transform.position = new Vector2(mousePosition.x-deltaX, mousePosition.y-deltaY);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }


    }

    // Start is called before the first frame update
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
