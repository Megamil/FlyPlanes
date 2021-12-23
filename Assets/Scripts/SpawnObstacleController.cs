using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleController : MonoBehaviour
{

    [SerializeField] float spawnTime;
    [SerializeField] float chronometer;
    [SerializeField] GameObject obstacle;

    private void Awake()
    {
        this.spawnTime = this.spawnTime == 0 ? 3.0f : this.spawnTime;
        this.chronometer = this.spawnTime;
    }

    void Update()
    {

        this.chronometer -= Time.deltaTime;

        if(this.chronometer <= 0)
        {
            this.chronometer = this.spawnTime;
            GameObject.Instantiate(this.obstacle, this.transform.position, Quaternion.identity);

        }

    }

}
