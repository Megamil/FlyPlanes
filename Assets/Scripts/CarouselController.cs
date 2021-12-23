using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselController : MonoBehaviour
{

    [SerializeField] float velocity;
    [SerializeField] float sizeOfFloor;
    [SerializeField] Vector3 positionInitial;

    private void Awake()
    {
        this.velocity = this.velocity == 0 ? 5.0f : this.velocity;
        this.positionInitial = this.transform.position;

        float sizeImage = this.GetComponent<SpriteRenderer>().size.x;
        float scale = this.transform.localScale.x;
        this.sizeOfFloor = sizeImage * scale;

    }

    void Update()
    {
        this.transform.Translate(Vector3.left * velocity);
        float displacement = Mathf.Repeat(this.velocity * Time.time, this.sizeOfFloor);
        this.transform.position = this.positionInitial + Vector3.left * displacement;

    }
}
