using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    /*
    Handles check points.
    -Object attatched must have at least 1 3D collider attached with "isTrigger" selected
    -Player/Trigger object must have at least 1 3D collider and a 3D rigid body attached to it
    -It will activate whatever is chosen to be CheckPointEvent when the check point is activated
    */

    public CheckPoint previousCheckPoint;
    public string requiredTag = "Player";
    public GameObject CheckPointEvent;
    public bool destroyOnceAcivated = true;

    private bool activated = false;
    private bool objectInside = false;

    bool hasBeenActivated() {
        return activated;
    }

    void FixedUpdate() {
        //If preivous check point has not been activated then execution will stop here
        if (previousCheckPoint != null)
            if (!previousCheckPoint.hasBeenActivated())
                return;

        //Activate once and only once if the trigger object is inside the checkpoint
        if (!activated && objectInside) {
            activated = true;
            if(CheckPointEvent != null) Instantiate(CheckPointEvent);
            if (destroyOnceAcivated) Destroy(gameObject);
        }
    }

    //Determines whether chosen object is inside checkpoint (Only capable of keeping track of 1 trigger object at the moment)
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals(requiredTag))
            objectInside = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag.Equals(requiredTag))
            objectInside = false;
    }
}
