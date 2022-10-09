using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    #region Variables
    [Header("Setup and Configuration")]
    [Tooltip("The grappling hook prefab.")]
    public GameObject hookObj;
    [Tooltip("The main scene camera.")]
    public Transform mainCamera;
    [Tooltip("How fast the player will grapple to the hook.")]
    public float speed = 3f;
    [Tooltip("The maximum distance the grappling hook can travel.")]
    public float maxDistance = 55f;
    [Tooltip("Re-enables kinematics on the player once done grappling.")]
    public bool resetKinematic = false;

    private GUIStyle style = new GUIStyle();

    // [CAN BE CHANGED]
    private MinifigController playerControl;         // Unity Standard Assets 
    private float heightOffset;                         // The height of the player transform


    // [LEAVE AS IS BELOW THIS POINT]
    private Vector3 grapplePoint, adjustmentPoint;      // The positions we'll be grappling to
    private GameObject hookTmp;                         // Cloned hook prefab.
    private GameObject hookedObj;                       // The surface we're grappling to.
    private Rigidbody trb;                              // Rigidbody of the grappling hook.


    [SerializeField] private bool isSecured = false, firedHook = false;     // For debug and script purposes.
    [SerializeField] private bool isTargeting = false;                      // For debug and script purposes.
    private Rigidbody rb;                                                   // Player's attached rigidbody.

    private float step;                                                     // Grappling movement broken up
    private float momentum;                                                 // Grappling speed build up

    private bool onGrappleSurface;                                          // Are we standing on a hookable surface?

    private bool hooked;

    private Ray ray;                                                        // Raycasting. Everybody Loves Ray!
    private RaycastHit hit;      // Where'd Ray hit that guy at?

    public LineRenderer lr;
    [SerializeField] Transform grapplingStart;

    public float time = 2;

    #endregion

    #region StartUpdates
    void Start()
    {
        // [CAN BE CHANGED]
        playerControl = FindObjectOfType<MinifigController>();

        // [LEAVE ALONE BEYOND HERE]
        lr = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag.Equals("Hookable"))
            {
                isTargeting = true;
            }
            else isTargeting = false;
        }
        else
        {
            isTargeting = false;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTargeting && !hooked)
            {
                hooked = true;
                hookedObj = hit.collider.gameObject;
            } else if (hooked)
            {
                hooked = false;
                hookedObj = null;
                playerControl.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }


        if (hooked)
        {
            //playerControl.enabled = false;
            playerControl.gameObject.GetComponent<CharacterController>().enabled = false;
            playerControl.gameObject.transform.position = Vector3.Lerp(playerControl.gameObject.transform.position, hookedObj.transform.position, time * Time.deltaTime);
            lr.SetPositions(new Vector3[] { grapplingStart.position, hookedObj.transform.position});
        }
    }
    #endregion

    private void Unhook()
    {
        isSecured = false;
        firedHook = false;
        hookedObj = null;
        momentum = 0;
        step = 0;
        Destroy(hookTmp);
        if (resetKinematic)
            rb.isKinematic = false;
    }

    private Vector3 AdjustedGrapple(Vector3 tmp, bool firstPass = true)
    {
        Vector3 ret = tmp;

        ret.x += 0.45f;
        if (IsCentered(ret))
            return ret;
        else
        {
            ret.x += 0.45f;
            if (IsCentered(ret))
                return ret;
        }

        ret = tmp;
        ret.x -= 0.45f;

        if (IsCentered(ret))
            return ret;
        else
        {
            ret.x -= 0.45f;
            if (IsCentered(ret))
                return ret;
        }

        ret = tmp;
        ret.z += 0.45f;

        if (IsCentered(ret))
            return ret;
        else
        {
            ret.z += 0.45f;
            if (IsCentered(ret))
                return ret;
        }

        ret = tmp;
        ret.z -= 0.45f;

        if (IsCentered(ret))
            return ret;
        else
        {
            ret.z -= 0.45f;
            if (IsCentered(ret))
                return ret;
        }

        if (firstPass)
        {
            ret = tmp;
            ret.z += 0.45f;
            ret.x += 0.45f;
            ret = AdjustedGrapple(ret, false);
            if (ret != Vector3.zero)
                if (IsCentered(ret))
                    return ret;

            ret = tmp;
            ret.z -= 0.45f;
            ret.x -= 0.45f;
            ret = AdjustedGrapple(ret, false);
            if (ret != Vector3.zero)
                if (IsCentered(ret))
                    return ret;
        }

        return Vector3.zero;
    }

    private bool IsCentered(Vector3 ret)
    {
        if (Physics.Raycast(new Ray(ret + new Vector3(1f, 1f, 1f), Vector3.down), 2f + heightOffset)
           && Physics.Raycast(new Ray(ret + new Vector3(-1f, 1f, 1f), Vector3.down), 2f + heightOffset)
           && Physics.Raycast(new Ray(ret + new Vector3(1f, 1f, -1f), Vector3.down), 2f + heightOffset)
           && Physics.Raycast(new Ray(ret + new Vector3(-1f, 1f, -1f), Vector3.down), 2f + heightOffset))
            if (Physics.Raycast(new Ray(ret, Vector3.down), out RaycastHit hitCenter, 2f + heightOffset))
                if (hitCenter.transform.tag == "Hookable")
                    return true;

        return false;
    }

    private void OnGUI()
    {
        if (isTargeting)
        {
            GUI.Box(new Rect(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(150, 20)), "Right Click To Grapple");
        }
    }
}
