using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmitter : MonoBehaviour
{
    [SerializeField] private float delay = 0;

    private bool canFire = true;

    public void PullTrigger(GameObject projectile, Vector3 pos, Quaternion rot)
    {
        if (!canFire || !projectile) return;

        EmitProjectile(projectile, pos, rot);

        canFire = false;
        StartCoroutine(weaponCooldown());
    }

    private void EmitProjectile(GameObject projectile, Vector3 pos, Quaternion rot)
    {
        // instantiate object and rotate by prefabs initial rotation
        GameObject spawnedProjectile = Instantiate(projectile, pos, rot);
        spawnedProjectile.transform.Rotate(projectile.transform.rotation.eulerAngles);

        ProjectileDamageController projectileDamageController 
            = spawnedProjectile.GetComponent<ProjectileDamageController>();

        if (projectileDamageController)
        {
            projectileDamageController.SetSpawningGameObjectId(gameObject.GetInstanceID());
        }
    }

    private IEnumerator weaponCooldown()
    {
        yield return new WaitForSeconds(delay);
        canFire = true;
    }
}
