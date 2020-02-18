using UnityEngine;

//NOTE: This class goes under the gameobject refering the attack point of a melee weapon.
public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;

    private void Update()
    {
        // How many objects did we hit inside the overlap sphere with the specific layer condition.
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (hits.Length > 0)
        {
            // Kill/Destroy the object et voilà.
            hits[0].gameObject.GetComponent<HealthScript_FPS>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}