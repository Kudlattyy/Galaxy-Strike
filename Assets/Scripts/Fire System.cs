using UnityEngine;
using UnityEngine.InputSystem;


public class FireSystem : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    bool isFiring = false;


    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
      Shooting();
    }

    public void OnFire(InputValue value){
        isFiring = value.isPressed;
    }

    private void Shooting(){
        foreach(GameObject laser in lasers){
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        } 
    }

    private void CrosshairPossition(){
        crosshair.position = Input.mousePosition;
    }
}
