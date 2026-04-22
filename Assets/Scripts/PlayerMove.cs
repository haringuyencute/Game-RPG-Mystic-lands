using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    private Vector3 currentPos;

    public static bool canMove = true;
    public static bool moving = false;
    public LayerMask moveLayer;

    public GameObject freeCam;
    public GameObject staticCam;
    private bool freeCamActive = true;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currentPos = ct.m_FollowOffset;
        freeCam.SetActive(true);
        staticCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate velocity speed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //Get mouse position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currentPos;

        if (Input.GetMouseButtonDown(0))
        {
            if(canMove)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit,300,moveLayer))
                {
                    nav.destination = hit.point;
                }
            }
        }

        if (velocitySpeed != 0f)
        {
            anim.SetBool("sprinting", true);
            moving = true;
        }
        if (velocitySpeed == 0f)
        {
            anim.SetBool("sprinting",false);
            moving=false;
        }

        if(Input.GetMouseButton(1))
        {
            if(pos.x != 0 || pos.y != 0 )
            {
                currentPos = pos / 200;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (freeCamActive)
            {
                freeCam.SetActive(false);
                staticCam.SetActive(true);
                freeCamActive = false;
            }
            else if (!freeCamActive)
            {
                freeCam.SetActive(true);
                staticCam.SetActive(false);
                freeCamActive = true;
            }
        }
            
    }
}
