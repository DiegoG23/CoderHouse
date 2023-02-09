using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    private float timer = 0;
    private float randomOffset;

    private void Awake()
    {
        randomOffset = Random.Range(1f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * randomOffset;

        float finalPosition = Mathf.Lerp(-0.2f, 0.2f, Mathf.PingPong(timer, 1));
        transform.Translate(new Vector3(0, finalPosition, 0) * Time.deltaTime);
    }
}
