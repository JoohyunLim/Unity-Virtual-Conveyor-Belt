using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component should be used to dyanamically change the interpolation mode of rigidbodies entering the attached trigger region.
/// Rigidbodies' previous interpolation mode will be remembered and reverted to upon exit.
/// </summary>
/// <remarks>
/// Because of the way the conveyor belt works, rigidbodies riding on top will appear to 'jitter' or 'wiggle' a little unless the
/// riding rigidbody interpolation mode is set to 'interpolate'. This is a more expensive operation than simply leaving it set to 'none'.
/// If you wish to correct this wiggle, but don't want to set rigidbodies in your game to interpolate by default, then use this component
/// to temporarily change it.
/// 
/// This does not support adjacent regions. For example, if a rigidbody enters an adjacent region before fully exiting the one it is already in,
/// the newly entered region will cache the rigidbody's interpolation mode as not necessarily what it started with.
/// 
/// For more information on rigidbody interpolation, see: https://docs.unity3d.com/ScriptReference/Rigidbody-interpolation.html
/// </remarks>
[RequireComponent(typeof(Collider))]
public class RigidbodySmoothRegion : MonoBehaviour {

    [Tooltip("Interpolation Mode Given to Rigidbodies Entering Trigger Region")]
    [SerializeField] private RigidbodyInterpolation interpolationMode = RigidbodyInterpolation.None;

    private Dictionary<Rigidbody, RigidbodyInterpolation> rigidbodies = new Dictionary<Rigidbody, RigidbodyInterpolation>();

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (rigidbody)
        {
            if (!rigidbodies.ContainsKey(rigidbody))
            {
                rigidbodies.Add(rigidbody, rigidbody.interpolation);
                rigidbody.interpolation = interpolationMode;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (rigidbody)
        {
            RigidbodyInterpolation interpolation;
            if (rigidbodies.TryGetValue(rigidbody, out interpolation))
            {
                rigidbody.interpolation = interpolation;
                rigidbodies.Remove(rigidbody);
            }
        }
    }
}
