using DilmerGames.Core.Extensions;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onButtonPressed;

    private bool pressedInProgress = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.IsTriggerButton() && !pressedInProgress)
        {
            pressedInProgress = true;
            onButtonPressed?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.IsTriggerButton())
        {
            pressedInProgress = false;
        }
    }
}
