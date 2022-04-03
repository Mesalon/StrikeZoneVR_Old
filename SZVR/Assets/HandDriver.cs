using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandDriver : MonoBehaviour {
    [SerializeField] GameObject handPrefab;
    [SerializeField] InputDeviceCharacteristics characteristics;
    private GameObject spawnedHand;
    private Animator anim;
    private InputDevice device;

    private void Start() {
        spawnedHand = Instantiate(handPrefab, transform);
        anim = spawnedHand.GetComponent<Animator>();

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        foreach(var item in devices) {
            print(item.name);
        }

        if(devices.Count > 0) { device = devices[0]; }
        else { Debug.LogWarning("User Warning: Could not find device with specified characteristics"); }
    }

    private void Update() {
        if(device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) {
            anim.SetFloat("Trigger", triggerValue);
        } else {
            Debug.LogError($"User Error: Cannot get trigger value from {device.name}");
            anim.SetFloat("Trigger", 0);
        }

        if(device.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) {
            anim.SetFloat("Grip", gripValue);
        } else {
            Debug.LogError($"User Error: Cannot get grip value from {device.name}");
            anim.SetFloat("Grip", 0);
        }
    }
}