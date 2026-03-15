using Convai.Scripts.Runtime.Features;
using UnityEngine;

public class DatuakController : MonoBehaviour
{
    private ConvaiActionsHandler _convaiActionHandler;

    void Awake()
    {
        _convaiActionHandler = GetComponent<ConvaiActionsHandler>();
    }

    public void MoveTo(GameObject obj)
    {
        StartCoroutine(_convaiActionHandler.MoveTo(obj));
    } 
}
