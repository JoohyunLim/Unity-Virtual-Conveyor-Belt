using UnityEngine;

/// <summary>
/// Place this component on the parent of all roller children.
/// </summary>
/// <remarks>
/// For best results, ensure roller scale is 1, and make sure the capsule collider
/// assigned to each roller is roughly the same radius as the mesh it represents.
/// Otherwise, surface speed will be inconsistent with belt conveyors.
/// 
/// See included prefabs and demo scene for how to best set this up.
/// </remarks>
public class RollerBehavior : ConveyorBehavior {

    [Tooltip("If checked, each roller will start with a random rotation.")]
    [SerializeField] private bool randomStartRotation = true;

    private Rigidbody[] rollers;
    private float radius;

    /// <summary>
    /// Initialization
    /// </summary>
    /// <remarks>
    /// In the Start method, we first get all the rigidbodies from each child GameObject and store them in the rollers array.
    /// Then, we loop through each roller rigidbody and make sure they are kinematic, apply random starting rotation,
    /// and add up each radius. This sumRadius is used to produce the average radius that gets used in later calculation.
    /// </remarks>
    private void Start()
    {
        float sumRadius = 0;

        rollers = GetComponentsInChildren<Rigidbody>();
        if (rollers.Length < 1)
            Debug.LogError("RollerBehavior found no rigidbodies in its children! Rollers need to have a Capsule Collider and a kinematic Rigidbody assigned.");
        else
        {
            foreach (var roller in rollers)
            {
                if (!roller.isKinematic)
                {
                    roller.isKinematic = true;
                    Debug.Log("Setting roller rigidbody: " + roller + " to kinematic.");
                }

                if (randomStartRotation)
                    roller.transform.localRotation = roller.transform.localRotation * Quaternion.Euler(Random.Range(0, 360), 0, 0);

                CapsuleCollider collider = roller.GetComponent<CapsuleCollider>();
                if (collider)
                    sumRadius += collider.radius;
                else
                    Debug.LogError("No Capsule Collider found on RollerBehavior's child: " + roller + ". Please ensure each roller has a Capsule Collider and a kinematic Rigidbody.");
            }
            radius = sumRadius / rollers.Length;
        }
    }

    /// <summary>
    /// Roller Rotation
    /// </summary>
    /// <remarks>
    /// We use FixedUpdate here so that our manual rotations play nicer with the physics engine.
    /// First, we calculate a new rotation to apply to each roller, then apply that rotation to each roller in the roller array.
    /// 
    /// The speed float comes from the extended class: ConveyorBehavior.
    /// </remarks>
    private void FixedUpdate()
    {
        Quaternion newRotation = Quaternion.Euler(Time.fixedDeltaTime * (speed/radius) * Mathf.Rad2Deg, 0, 0); //Angular Velocity = Speed/Radius
        foreach (var roller in rollers)
        {
            roller.MoveRotation(roller.rotation * newRotation);
        }
    }
}
