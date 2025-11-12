using System;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public float rotationSpeed;
    public float amplitude=0.5f;
    public float frequency=0.5f;
    Vector3 startPos;

    float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = UnityEngine.Random.Range(5f, 25f);
        transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
        startPos = transform.position;
        yOffset = UnityEngine.Random.Range(-10f, 10f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        float newY = (float)(startPos.y +  Math.Sin(Time.time * frequency + yOffset) * amplitude);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
