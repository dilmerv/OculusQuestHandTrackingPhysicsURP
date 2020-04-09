using UnityEngine;

public class ButtonLimit : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTrigger;

    private Vector3 originalPosition;

    private float minDistance;

    private float maxDistance;

    void Awake() 
    {
        // calculate the min distance between activator and the trigger
        minDistance = Vector3.Distance(buttonTrigger.transform.position, 
            transform.position);

        maxDistance = buttonTrigger.transform.position.y; 

        originalPosition = transform.position;   
    }

    void Update()
    {

        // ensure we restore original posion if the distance is >= to min
        if(Vector3.Distance(buttonTrigger.transform.position, transform.position) >= minDistance)
        {
            transform.position = originalPosition;
        }

        // ensure we restore position Y of the activator if <= max
        if(transform.position.y <= maxDistance)
        {
            transform.position = new Vector3(transform.position.x, maxDistance, transform.position.z);
        }
    }
}
