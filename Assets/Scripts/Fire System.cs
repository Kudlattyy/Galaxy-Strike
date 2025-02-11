using UnityEngine;
using UnityEngine.InputSystem;


public class FireSystem : MonoBehaviour
{
    [SerializeField] GameObject laser;
    bool isFiring = false;

    // Update is called once per frame
    void Update()
    {
      Shooting();
    }

    public void OnFire(InputValue value){
        isFiring = value.isPressed;
    }

    private void Shooting(){
        var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFiring;
    }
}
