using UnityEngine;

public class PlayerAttack_FPS : MonoBehaviour
{
    private WeaponManager_FPS weapon_Manager;

    public float fireRate = 15;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;


    private Camera mainCam;
    private GameObject crosshair;

    private bool is_Aiming;

    [SerializeField]
    private GameObject arrow_Prefab, spear_Prefab;

    [SerializeField]
    private Transform arrow_Bow_StartPosition;

    private void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager_FPS>();

        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;
    }
    private void Update()
    {
        WeaponShoot();
        ZoomInAndOut();
    }
    private void WeaponShoot()
    {
        // if we have assault riffle
        if (weapon_Manager.GetCurrentSelectedWeapon().fire_Type == WeaponFireType.AUTOMATIC)
        {
            // if we press and hold left mouse click AND
            // if Time is greater than the nextTimeToFire
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                BulletFired();
            }
        }
        // if we have a regular weapon that shoots once
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                // handle axe
                if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                // handle shoot
                if (weapon_Manager.GetCurrentSelectedWeapon().bullet_Type == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                    BulletFired();
                }
                else
                {
                    // we have an arrow or spear
                    if (is_Aiming)
                    {
                        weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                        if (weapon_Manager.GetCurrentSelectedWeapon().bullet_Type == WeaponBulletType.ARROW)
                        {
                            // throw arrow
                            ThrowArrowOrSpear(true);
                        }
                        else if (weapon_Manager.GetCurrentSelectedWeapon().bullet_Type == WeaponBulletType.SPEAR)
                        {
                            // throw spear
                            ThrowArrowOrSpear(false);
                        }
                    }
                } // else
            } // if input get mouse button down 0
        } // else
    } // weapon shoot

    void ZoomInAndOut()
    {
        // we are going to aim with our camera on the weapon
        if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.AIM)
        {
            // if we press and hold right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                crosshair.SetActive(false);
            }
            // when we release the right mouse button click
            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                crosshair.SetActive(true);
            }

        } // if we need to zoom the weapon

        if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(true);
                is_Aiming = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(false);
                is_Aiming = false;
            }
        } // weapon self aim
    } // zoom in and out

    void ThrowArrowOrSpear(bool throwArrow)
    {
        if (throwArrow)
        {
            GameObject arrow = Instantiate(arrow_Prefab);
            
            arrow.transform.position = arrow_Bow_StartPosition.position;
            arrow.GetComponent<ArrowBowScript>().Launch(mainCam);
        }
        else
        {
            GameObject spear = Instantiate(spear_Prefab);
            
            spear.transform.position = arrow_Bow_StartPosition.position;
            spear.GetComponent<ArrowBowScript>().Launch(mainCam);
        }
    } // throw arrow or spear
    
    void BulletFired()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit))
        {
            print("We hit : " + hit.transform.gameObject.name);
            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthScript_FPS>().ApplyDamage(damage);
            }
        }
    } // bullet fired
}