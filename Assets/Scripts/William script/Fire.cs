using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Projectile;
    public Transform shootPoint;
    public void Shoot()
        {
        Instantiate(Projectile, shootPoint.position, shootPoint.rotation);
    }
}
