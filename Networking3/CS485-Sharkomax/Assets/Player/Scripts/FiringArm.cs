using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
//using UnityEngine.Networking;
public class FiringArm : MonoBehaviour
{
    [FormerlySerializedAs("EndPoint")] [NotNull] public GameObject endPoint;
    [FormerlySerializedAs("Weapon")] public GenericWeapon weapon;
    public Character_Behavior character;

    // Start is called before the first frame update
    void Start() {
       
    }


    void RotateArm() {
        Vector2 mousePos =  new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 lookVec = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 endVec = endPoint.transform.position;

        Vector2 position = transform.position;
        lookVec -= position;
        endVec -= position;

        float angle = Vector2.SignedAngle(endVec, lookVec);
        transform.Rotate(0,0, angle / 4);
    }

    void PlaceWeapon() {
        if (!weapon)
            return;
        Vector2 Shotline = endPoint.transform.position - transform.position;
        weapon.alignOn(Shotline);
        weapon.PositionWeapon(endPoint.transform.position);
    }

    // Update is called once per frame
    void Update() {

        if (!character.CheckClient())
            return;
        //if (!isLocalPlayer)
          //  return;
        RotateArm();
        PlaceWeapon();

        bool click = Input.GetMouseButton(0);
        if (weapon) {
           
            weapon.SHOT(!click);
            float Recoil = GenericWeapon._recoil;

            transform.Rotate(0, 0, Recoil);
            PlaceWeapon();
        }

    }
    void OnDrawGizmos() {
        Vector2 mousePos =  new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 lookVec = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 endVec = endPoint.transform.position;

        Gizmos.color = Color.red;
        Vector2 position = transform.position;
        Gizmos.DrawLine(position, lookVec);
        Gizmos.DrawLine(position, endVec);
    }
}
