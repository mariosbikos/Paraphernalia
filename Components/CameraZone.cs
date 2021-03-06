﻿using UnityEngine;
using System.Collections;

namespace Paraphernalia.Components {
public class CameraZone : MonoBehaviour {

    public AudioClip music;
    public Vector3 offset = new Vector3(0,0,-150);
    public Vector3 axisLock = Vector3.one;
    public float transitionTime = 1;
    public MonoBehaviour[] behavioursToActivate;

    public Vector3 position {
        get {
            return transform.position + offset;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") AddRemoveZone(true);
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") AddRemoveZone(false);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") AddRemoveZone(true);
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") AddRemoveZone(false);
    }

    void AddRemoveZone (bool add) {
        if (add) CameraController.AddZone(this);
        else CameraController.RemoveZone(this);
        foreach (MonoBehaviour b in behavioursToActivate) {
            b.enabled = add;
        }
    }


    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(position, 0.5f);
    }
}
}
