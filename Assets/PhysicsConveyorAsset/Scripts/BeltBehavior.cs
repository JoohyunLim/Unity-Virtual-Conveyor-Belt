using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place this component on the Conveyor Belt GameObject that should move Rigidbodies.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BeltBehavior : ConveyorBehavior {

    [Tooltip("Enter the names of each texture in the shader you wish to scroll. If you are using the Standard Shader, all you need to enter is '_MainTex' and the shader will automatically scroll the other textures (like normal, emission, etc.) for you.")]
    [SerializeField] private string[] texturesToScroll = { "_MainTex" };

    private Rigidbody rigidBody;
    private Material material;
    private float texOffset;

    /// <summary>
    /// Initialization
    /// </summary>
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (!rigidBody.isKinematic)
        {
            Debug.Log("Setting conveyor belt rigidbody: " + rigidBody + " to kinematic.");
            rigidBody.isKinematic = true;
        }

        if (meshRenderer)
            material = meshRenderer.material;
        else
            Debug.LogWarning("No MeshRenderer found on Conveyor Belt " + gameObject + " or its children. For proper functionality, please ensure Conveyor Belts have a MeshRenderer, Rigidbody, and Collider.");
    }

    /// <summary>
    /// Physics Movement
    /// </summary>
    /// <remarks>
    /// In the FixedUpdate method, we get the conveyors to actually move rigidbodies resting on top. This is done by taking advantage of
    /// the fact that moving a rigidbody with MovePosition takes physics into account, whereas simply setting the rigidbody position does not.
    /// Therefore, we are able to set the position of the conveyor rigidbody back some distance ignoring physics, then move it forward again with
    /// physics thus applying friction to bodies resting on top.
    /// 
    /// The speed float comes from the extended class: ConveyorBehavior.
    /// </remarks>
    private void FixedUpdate()
    {
        Vector3 newPosition = transform.forward * Time.fixedDeltaTime * speed;
        rigidBody.position = rigidBody.position - newPosition;
        rigidBody.MovePosition(rigidBody.position + newPosition);
    }

    /// <summary>
    /// Material Scrolling
    /// </summary>
    /// <remarks>
    /// In the Update method, we update the texture offset of the material to give the illusion of actual conveyor belt behavior.
    /// This is done for each texture specified in the serialized field texturesToScroll.
    /// </remarks>
    private void Update()
    {
        if (material)
        {
            texOffset += speed * Time.deltaTime;
            texOffset = texOffset % 1; //To ensure value stays within a 0-1 range
            foreach (string texture in texturesToScroll)
                material.SetTextureOffset(texture, new Vector2(0, texOffset));
        }
    }
}
