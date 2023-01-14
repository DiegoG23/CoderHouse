using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowObjective();
    }

    private void FollowObjective()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GetTargetFloorPosition(), step);
    }

    private Vector3 GetTargetFloorPosition()
    {
        return new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
    }
}
