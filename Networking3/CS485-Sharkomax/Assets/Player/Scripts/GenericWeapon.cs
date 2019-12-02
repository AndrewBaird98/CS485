﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
//using UnityEngine.Networking;

public class GenericWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("Grab Point")] [NotNull] public GameObject grabpoint;
    [FormerlySerializedAs("Angle Point")] [NotNull] public GameObject anglePoint;
    [FormerlySerializedAs("Shot Point")] [NotNull] public GameObject shotPoint;

    [FormerlySerializedAs("Bullet")] [NotNull] public GameObject bullet;
    [FormerlySerializedAs("power")] public float power;
    [FormerlySerializedAs("recoil")] public float recoil;
    [FormerlySerializedAs("rate of fire")] public float rate;
    [FormerlySerializedAs("hold type")] public bool hold;


    private float _timer;
    private float _shotPower;
    public static float _recoil;
    private bool _charge;
    void Start() {
        _timer = 0.0f;
        _shotPower = power / 100;
        _charge = false;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        //transform.RotateAround(shotPoint.transform.position, Vector3.forward, 0.5f);
    }

    public void PositionWeapon(Vector3 dest) {
        transform.position = dest + (transform.position - grabpoint.transform.position);
    }

    public void alignOn(Vector2 line) {
        var shotPos = shotPoint.transform.position;
        var anglePos = anglePoint.transform.position;

        float angle = Vector2.SignedAngle(
            shotPos - anglePos, line);
        transform.RotateAround(anglePos, Vector3.forward, angle / 3);
    }

    bool getPower(bool release) {
        if (!hold && !release) {
            _shotPower = power;
            return true;
        }
        if (release && !_charge)
            return false;
        _shotPower += power / 100;

        if (_shotPower >= power || release) {
            _charge = false;
            return true;
        }
        _charge = true;
        return false;
    }

    
    public void SHOT(bool release)
    {
        float Recoil;
        var shotPos = shotPoint.transform.position;
        var anglePos = anglePoint.transform.position;
        Vector3 shotLine = shotPos - anglePos;
        if (_timer <= 1 / rate || !getPower(release))
        {
            Recoil = 0.0f;
            _recoil = 0.0f;
        }
        else
        {
            var newBullet = (GameObject)Instantiate(bullet, shotPoint.transform.position, Quaternion.FromToRotation(Vector3.up, shotLine));
            newBullet.GetComponent<Rigidbody2D>().AddForce(25 * _shotPower * shotLine.normalized);
            _timer = 0.0f;

            Recoil = _shotPower * recoil;
            _recoil = Recoil;
            _shotPower = power / 100;
            transform.RotateAround(anglePoint.transform.position, Vector3.forward, Recoil);

            Character_Behavior.Shoot(newBullet);
            
        }
    }


    [NotNull]
    public GameObject Grabpoint => grabpoint;

    [NotNull]
    public GameObject AnglePoint => anglePoint;

    [NotNull]
    public GameObject ShotPoint => shotPoint;

}
