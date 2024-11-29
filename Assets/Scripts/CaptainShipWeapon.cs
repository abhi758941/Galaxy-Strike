using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaptainShipWeapon : MonoBehaviour
{
    [SerializeField]  GameObject[] lasers;
    [SerializeField]  GameObject targetShip;
    private void OnEnable() 
    {
        target();
    }
    private void Update() 
    {
        firingSequence();
    }
    void firingSequence()
    {
        startFiring();
        if (targetShip == null)
        {
            stopFiring();
        }
    }
    void startFiring()
    {
        foreach(GameObject laser in lasers)
        {
        var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
        emmisionModule.enabled = true;
        } 
    }
    void stopFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = false;
        }
    }
    void target()
    {
        foreach (GameObject laser in lasers)
        {
        Vector3 targetLocation = targetShip.transform.position - laser.transform.position;
        Quaternion laserRotation = Quaternion.LookRotation(targetLocation);
        laser.transform.rotation = laserRotation;    
        }
    }
}
