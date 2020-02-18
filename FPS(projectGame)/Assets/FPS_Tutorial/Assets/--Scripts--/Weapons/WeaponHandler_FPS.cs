using UnityEngine;

public enum WeaponAim { NONE, SELF_AIM, AIM }
public enum WeaponFireType { SINGLE, AUTOMATIC }
public enum WeaponBulletType { NONE, BULLET, ARROW, SPEAR }

public class WeaponHandler_FPS : MonoBehaviour
{
    private Animator animator;
    public WeaponAim weapon_Aim;
    [SerializeField] private GameObject muzzle_Flash;
    [SerializeField] private AudioSource shoot_Sound;
    [SerializeField] private AudioSource reload_Sound;

    public WeaponFireType fire_Type;
    public WeaponBulletType bullet_Type;
    public GameObject attack_Point; // NOTE: This field references the attack point on melee weapons, which holds the AttackScript_FPS.

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        animator.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim)
    {
        animator.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    private void Turn_On_MuzzleFlash()
    {
        muzzle_Flash.SetActive(true);
    }

    private void Turn_Off_MuzzleFlash()
    {
        muzzle_Flash.SetActive(false);
    }

    private void Play_ShootSound()
    {
        shoot_Sound.Play();
    }

    private void Play_ReloadSound()
    {
        reload_Sound.Play();
    }

    private void Turn_On_AttackPoint()
    {
        attack_Point.SetActive(true);
    }

    private void Turn_Off_AttackPoint()
    {
        if (attack_Point.activeInHierarchy)
            attack_Point.SetActive(false);
    }
}
