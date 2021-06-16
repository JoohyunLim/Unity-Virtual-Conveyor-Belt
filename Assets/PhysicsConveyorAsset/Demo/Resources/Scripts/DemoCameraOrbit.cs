using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DemoCameraOrbit : MonoBehaviour {

    private enum MouseButton
    {
        LeftClick,
        RightClick,
        MiddleClick
    }

    [SerializeField] private Transform targetParent;
    [Space]
    [SerializeField] private bool enableOrbit = true;
    [SerializeField] private MouseButton orbitButton = MouseButton.RightClick;
    [SerializeField] private float orbitSpeed = 3;
    [SerializeField] private float orbitDampening = 9;
    [SerializeField] private float topOrbitDegreesLimit = 90;
    [SerializeField] private float bottomOrbitDegreesLimit = 0;
    [Space]
    [SerializeField] private bool enableZoom = true;
    [SerializeField] private float zoomSpeed = 2;
    [SerializeField] private float zoomDampening = 6;
    [SerializeField] private float defaultZoom = 10;
    [SerializeField] private float zoomInDistanceLimit = 1;
    [SerializeField] private float zoomOutDistanceLimit = 75;
    [Space]
    [SerializeField] private bool enablePan = true;
    [SerializeField] private MouseButton panButton = MouseButton.MiddleClick;
    [SerializeField] private float panSpeed = 5;

    private Camera cam;
    private Vector3 parentRotation;
    private float zoom;
    private float closeZoomPadding = 0.2F;
    private Vector3 panPosition;
    private Vector3 lastMousePosition;
    private int orbitButtonInt;
    private int panButtonInt;

    private void Start()
    {
        cam = GetComponent<Camera>();
        zoom = defaultZoom;
        orbitButtonInt = SetMouseButton(orbitButton);
        panButtonInt = SetMouseButton(panButton);
    }

    private int SetMouseButton(MouseButton mouseButton)
    {
        switch (mouseButton)
        {
            case MouseButton.LeftClick:
                return 0;
            case MouseButton.RightClick:
                return 1;
            case MouseButton.MiddleClick:
                return 2;
            default:
                return 0;
        }
    }

    void LateUpdate()
    {
        if (enableOrbit)
            DoOrbit();
        if (enableZoom)
            DoZoom();
        if (enablePan)
            DoPan();
    }

    private void DoOrbit()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX != 0 && Input.GetMouseButton(orbitButtonInt) || mouseY != 0 && Input.GetMouseButton(orbitButtonInt))
        {
            parentRotation.x += mouseX * orbitSpeed;
            parentRotation.y -= mouseY * orbitSpeed;

            parentRotation.y = Mathf.Clamp(parentRotation.y, bottomOrbitDegreesLimit, topOrbitDegreesLimit);
        }
        targetParent.localRotation = Quaternion.Lerp(targetParent.localRotation, Quaternion.Euler(parentRotation.y, parentRotation.x, 0), Time.deltaTime * orbitDampening);
    }

    private void DoZoom()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll != 0)
        {
            zoom += mouseScroll * zoomSpeed * zoom * closeZoomPadding * -1;

            zoom = Mathf.Clamp(zoom, zoomInDistanceLimit, zoomOutDistanceLimit);
        }
        transform.localPosition = new Vector3(0, 0, Mathf.Lerp(transform.localPosition.z, -zoom, Time.deltaTime * zoomDampening));
    }

    private void DoPan()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(panButtonInt))
            lastMousePosition = mousePosition;

        if (Input.GetMouseButton(panButtonInt))
        {
            Vector3 pos = cam.ScreenToViewportPoint(lastMousePosition - mousePosition);

            panPosition = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            targetParent.Translate(panPosition, Space.Self);
            lastMousePosition = mousePosition;
        }
    }
}