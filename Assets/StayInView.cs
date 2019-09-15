using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInView : MonoBehaviour
{

    public Transform _transform;
    public float _speed;

    private float _startTime;

    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Have the cube face the player
        this.gameObject.transform.LookAt(Camera.main.transform.position);

        float journeyLength = Vector3.Distance(this.gameObject.transform.position, _transform.position);

        // Distance moved = time * speed.
        float distCovered = (Time.time - _startTime) * _speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(this.gameObject.transform.position, _transform.position, fracJourney);
    }
}
