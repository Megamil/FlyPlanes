using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField] float force;
    Rigidbody2D physical;
    bool firstClick;
    MainController mainController;


    private void Awake()
    {
        
        this.physical = this.GetComponent<Rigidbody2D>();
        this.mainController = GameObject.FindObjectOfType<MainController>();

        this.physical.gravityScale = 0;
        this.force = 3.0f;
        this.firstClick = true;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            this.planeUp();
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            this.mainController.pauseGame();
        }   
    }

    private void planeUp()
    {
        this.physical.velocity = Vector2.zero;
        this.physical.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        if(firstClick)
        {
            Destroy(GameObject.FindGameObjectWithTag("handClick"));
            this.firstClick = false;
            this.physical.gravityScale = 1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.mainController.hit(this);
    }


}
