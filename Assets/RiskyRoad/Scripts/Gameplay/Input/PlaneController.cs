using UnityEngine;
using NRKernal;
using ScriptableObjectArchitecture;

public class PlaneController : MonoBehaviour
{
    /// <summary> A model to place when a raycast from a user touch hits a plane. </summary>
    [SerializeField] GameObject pointer;
    [SerializeField] Vector3Event onPlaneClicked;

    /// <summary> Updates this object. </summary>
    void Update()
    {
        RaycastHit hit;
        bool objectDetected = CheckPlaneWithRay(out hit);

        pointer.SetActive(objectDetected);
        if (objectDetected)
        {
            pointer.transform.position = hit.point;
            pointer.transform.rotation = Quaternion.identity;

            if (NRInput.GetButtonDown(ControllerButton.TRIGGER))
            {
                onPlaneClicked?.Invoke(hit.point);
            }
        }
    }

    public bool CheckPlaneWithRay(out RaycastHit hitResult)
    {
        // Get controller laser origin.
        var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left ? ControllerAnchorEnum.LeftLaserAnchor : ControllerAnchorEnum.RightLaserAnchor;
        Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

        // RaycastHit hitResult;
        bool objectDetected =Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10);
        if (objectDetected)
        {
            bool isNRTrackableBehaviour = hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null;
            if (isNRTrackableBehaviour)
            {
                var behaviour = hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>();
                // if (behaviour.Trackable?.GetTrackableType() == TrackableType.TRACKABLE_PLANE) {
                //     Debug.Log("NO TIENE TRACKEABLE");
                // }
                // if (!behaviour)
                // {
                //     return false;
                // }
                bool isPlane = behaviour.Trackable?.GetTrackableType() == TrackableType.TRACKABLE_PLANE;
                if (!isPlane)
                {
                    return false;
                }

                // Instantiate Andy model at the hit point / compensate for the hit point rotation.
                // Instantiate(pointer, hitResult.point, Quaternion.identity, behaviour.transform);

                return true;
            }
        }

        return false;
    }

    void OnDisable()
    {
        pointer.SetActive(false);
    }
}
