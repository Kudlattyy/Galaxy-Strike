using UnityEngine;
using UnityEngine.InputSystem;


public class FireSystem : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    bool isFiring = false;


    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
      Shooting();
      CrosshairPossition();
      MoveTargetPoint();
      AimLasers();
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

    private void MoveTargetPoint(){
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers(){
        foreach (GameObject laser in lasers){
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
