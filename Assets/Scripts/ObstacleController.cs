using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] float velocity;
    [SerializeField] float variation;
    AudioSource audioEffect;
    MainController mainController;
    PlaneController plane;
    bool punctuated;

    private void Awake()
    {
        this.velocity = this.velocity == 0 ? 0.1f : this.velocity;
        this.variation = this.variation == 0 ? 1.2f : this.variation;
        this.audioEffect = this.GetComponent<AudioSource>();
        this.transform.Translate(Vector3.up * Random.Range(-this.variation, this.variation));
        this.plane = GameObject.FindObjectOfType<PlaneController>();
        this.mainController = GameObject.FindObjectOfType<MainController>();
        this.punctuated = false;
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * this.velocity * Time.deltaTime);

        if(!this.punctuated)
        {
            if(this.plane.transform.position.x > this.transform.position.x)
            {
                this.punctuated = true;
                this.audioEffect.Play();
                this.mainController.toScore();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
