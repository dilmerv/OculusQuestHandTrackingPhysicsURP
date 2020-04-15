using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private float minFingerPinchDownStrength = 0.5f;
    
    [SerializeField]
    private Transform objectToMove;

    private OVRHand ovrHand;

    private OVRBone boneToTrack;

    private OVRSkeleton ovrSkeleton;

    private bool IsPinchingReleased = false;

    // Start is called before the first frame update
    void Start()
    {
        ovrHand = GetComponent<OVRHand>();
        ovrSkeleton = GetComponent<OVRCustomSkeleton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boneToTrack == null)
        {
            boneToTrack = ovrSkeleton.Bones
                .Where(b => b.Id == OVRSkeleton.BoneId.Hand_Index3)
                .SingleOrDefault();
        }

        CheckPinchState();
    }

    private void CheckPinchState()
    {
        bool isIndexFingerPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        float indexFingerPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        if(ovrHand.GetFingerConfidence(OVRHand.HandFinger.Index) != OVRHand.TrackingConfidence.High)
            return;

        // finger pinch down
        if (isIndexFingerPinching && indexFingerPinchStrength >= minFingerPinchDownStrength)
        {
            objectToMove.position = boneToTrack.Transform.position;
            return;
        }
    }
}
