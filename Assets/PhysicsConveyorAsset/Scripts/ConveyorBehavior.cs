using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class to be extended for all conveyor variants.
/// </summary>
/// <remarks>
/// Keeping the speed value here makes it easier for other scripts to interact with it.
/// For an example, see the included demo scene and DemoManager.cs script.
/// </remarks>
public class ConveyorBehavior : MonoBehaviour {

    public float speed = 0.4F;

}
