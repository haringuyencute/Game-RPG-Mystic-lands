using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.SceneManagement;
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
    CinemachineOrbitalTransposer cot;
    private Vector3 pos;
    private Vector3 currentPos;
    private string axisNamed = "Mouse X";

    public static bool canMove = true;
    public static bool moving = false;
    public LayerMask moveLayer;

    public GameObject freeCam;
    public GameObject staticCam;
    private bool freeCamActive = true;
    public GameObject spawnPoint;
    private WaitForSeconds approachEnemy = new WaitForSeconds(0.3f);

    public GameObject[] playerObjs;
    public GameObject[] weapons;
    public GameObject[] armorTorso;
    public GameObject[] armorLegs;
    public string[] attacks;
    public AudioSource audioPlayer;
    public AudioClip[] weaponSounds;
    private AnimatorStateInfo playerInfo;
    private GameObject trailObj;
    private WaitForSeconds trailOffTime = new WaitForSeconds(0.1f);
    public float[] staminaCost;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = freeCam.gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
        cot = staticCam.gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();
        currentPos = ct.m_FollowOffset;
        freeCam.SetActive(false);
        staticCam.SetActive(true);
        SaveScript.spawnPoint = spawnPoint;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerInfo = anim.GetCurrentAnimatorStateInfo(0);
        //Calculate velocity speed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //Get mouse position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currentPos;

        if (SaveScript.weaponChange == true)
        {
            SaveScript.weaponChange = false;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[SaveScript.weaponChoice].SetActive(true);
            StartCoroutine(TurnOffTrail());
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(SaveScript.carryingWeapon == true && SaveScript.staminaAmt > 0.2)
            {
                anim.SetTrigger(attacks[SaveScript.weaponChoice]);
                audioPlayer.clip = weaponSounds[SaveScript.weaponChoice];
                SaveScript.staminaAmt -= staminaCost[SaveScript.weaponChoice];
            }
        }

        if (Input.GetMouseButtonDown(0) && playerInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
        {
            if(canMove)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit,300,moveLayer))
                {
                    if(hit.transform.gameObject.CompareTag("enemy"))
                    {
                        nav.isStopped = false;
                        SaveScript.theTarget = hit.transform.gameObject;
                        nav.destination = hit.point;
                        transform.LookAt(SaveScript.theTarget.transform);
                        StartCoroutine(MoveTo());
                    }
                    else
                    {
                        SaveScript.theTarget = null;

                        nav.destination = hit.point;
                        nav.isStopped = false;
                    }
                }
            }
        }

        if (velocitySpeed != 0f)
        {
            if(SaveScript.carryingWeapon ==false)
            {
                anim.SetBool("sprinting",true);
                anim.SetBool("carryWeapon",false);
            }
            if(SaveScript.carryingWeapon == true)
            {
                anim.SetBool("sprinting",true);
                anim.SetBool("carryWeapon", true);
            }
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
            cot.m_XAxis.m_InputAxisName = axisNamed;
            if(pos.x != 0 || pos.y != 0 )
            {
                currentPos = pos / 200;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            cot.m_XAxis.m_InputAxisName = null;
            cot.m_XAxis.m_InputAxisValue = 0;
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
        if (playerObjs[0].activeSelf == true)
        {
            if (SaveScript.invisible == true)
            {
                for (int i = 0; i < playerObjs.Length; i++)
                {
                    playerObjs[i].SetActive(false);
                }
            }
        }
        if (SaveScript.manaAmt <= 0.1)
        {
            if (SaveScript.invisible == false)
            {
                for (int i = 0; i < playerObjs.Length; i++)
                {
                    playerObjs[i].SetActive(true); 
                    SaveScript.changeArmor = true;
                }
            }
        }
        if (SaveScript.changeArmor == true)
        {
            for (int i = 0; i < armorTorso.Length; i++)
            {
                armorTorso[i].SetActive(false);
            }
            armorTorso[SaveScript.armor].SetActive(true);
            for (int i = 0; i < armorLegs.Length; i++)
            {
                armorLegs[i].SetActive(false);
            }
            armorLegs[SaveScript.armor].SetActive(true);
            SaveScript.changeArmor = false;
        }
        if (SaveScript.playerHealth <= 0.0f)
        {
            SceneManager.LoadScene(0);
            SaveScript.playerHealth = 1;
        }
    }
    public void PlayWeaponSound()
    {
        audioPlayer.Play();
    }
    IEnumerator MoveTo()
    {
        yield return approachEnemy;
        nav.isStopped = true;
    }
    public void TrailOn()
    {
        trailObj.GetComponent<Renderer>().enabled = true;
    }
    public void TrailOff()
    {
        trailObj.GetComponent<Renderer>().enabled = false;
    }
    IEnumerator TurnOffTrail()
    {
        yield return trailOffTime;
        trailObj = GameObject.Find("Trail");
        trailObj.GetComponent<Renderer>().enabled = false;
    }
}
