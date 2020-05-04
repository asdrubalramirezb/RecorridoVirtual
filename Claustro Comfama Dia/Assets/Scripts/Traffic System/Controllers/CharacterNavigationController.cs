using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigationController : MonoBehaviour
{
    [SerializeField][Header("Movement Settings")]
    private float stopDistance;
    public bool reachedDestination;
    [SerializeField]
    private Vector3 destination;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float currentMovementSpeed;
    [SerializeField]
    private float maxMovementSpeed;
    [SerializeField]
    private float minMovementSpeed = 0f;
    [SerializeField][Range(0f, 1f)]
    private float accelerationRate;
    [SerializeField][Range(0f,1f)]
    private float decelerationRate;
    [Header("Collision detection")]
    [SerializeField]
    private bool hasToStop;
    [SerializeField]
    private LayerMask agents;
    [SerializeField]
    private float maxRayDistance;
    [SerializeField]
    private float collisionStoppingDistance;
    public GameObject collisionHitPoint;
    [SerializeField][Header("Warning Dev mode")]
    private float collisionWarningDistance;
    [SerializeField]
    private bool collisionWarning;

    public bool HasToStop { get => hasToStop; set => hasToStop = value; }
    public bool CollisionWarning { get => collisionWarning; set => collisionWarning = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position != destination) {
            Vector3 destinationDirection = destination - this.transform.position;
            destinationDirection.y = 0f;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance <= stopDistance) {
                reachedDestination = true;
            }
            else {
                //if (HasToStop == false)
                //{
                    reachedDestination = false;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    //currentMovementSpeed = Mathf.Lerp(minMovementSpeed, maxMovementSpeed, lerpTime * Time.deltaTime);
                    currentMovementSpeed = currentMovementSpeed + accelerationRate * Time.deltaTime;
                    currentMovementSpeed = Mathf.Clamp(currentMovementSpeed, minMovementSpeed, maxMovementSpeed);
                    this.transform.Translate(Vector3.forward * currentMovementSpeed);
                //}
                //else {
                //    if (CollisionWarning == false)
                //    {
                //        reachedDestination = false;
                //        Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                //        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                //        //currentMovementSpeed = Mathf.Lerp(minMovementSpeed, maxMovementSpeed, lerpTime * Time.deltaTime);
                //        currentMovementSpeed = currentMovementSpeed - decelerationRate * Time.deltaTime;
                //        currentMovementSpeed = Mathf.Clamp(currentMovementSpeed, minMovementSpeed, maxMovementSpeed);
                //        this.transform.Translate(Vector3.forward * currentMovementSpeed);
                //    }
                //    else {
                //        currentMovementSpeed = 0;
                //    }
                //}
            }
        }

        //CollisionDetection();

    }

    public void SetDestination(Vector3 destination) {
        this.destination = destination;
        reachedDestination = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, stopDistance);
    }

    void CollisionDetection() {
        RaycastHit hit;
        if (Physics.Raycast(collisionHitPoint.transform.position, collisionHitPoint.transform.forward, out hit, maxRayDistance, agents))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.distance <= collisionStoppingDistance)
                {
                    HasToStop = true;
                    if (hit.distance <= collisionWarningDistance)
                    {
                        CollisionWarning = true;
                    }
                    else
                    {
                        CollisionWarning = false;
                    }
                }
                else
                {
                    HasToStop = false;
                }
           
        }
        else {
            HasToStop = false;
        }
       
        
    }

   

}
