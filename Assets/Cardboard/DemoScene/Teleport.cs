// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
  private Vector3 startingPosition;

  /*identifying objects that will be found*/
 public GameObject microwave;
 public GameObject fridge;
 public GameObject blinds;
 public GameObject sink;
 public GameObject oven;

 public GameObject active;

  void Start() {
    startingPosition = transform.localPosition;
    SetGazedAt(false);

    microwave = GameObject.FindWithTag("microwave");
    fridge = GameObject.FindWithTag("fridge");
    blinds = GameObject.FindWithTag("blinds");
    sink = GameObject.FindWithTag("sink");
    oven = GameObject.FindWithTag("oven");
    active = microwave; //reset active each time microwave etc is found?

    //make array of objects / assign numbers / make function that picks random number from list and number assigned to the object will be "active"
    //when ray from camera intersects with gameobject area / dimensions, change color of the game object (code is in scripts/gazeinputmodel but not sure how to make it owrk with objects)
    //if active = object that camera is intersecting with game object, make change active to a new thing
    //3d text is difficult ??? i couldnt figure out if it would actually preview with android phone or not; commented out


    //other things = assign sound to object
    //make sound (As in name of object in arabic) play when player first enters and when active changes
    //if active = object found, make "correct" (as in, correct in arabic) sound play

  }


  public void SetGazedAt(bool gazedAt) {
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

  public void TeleportRandomly() {
    Vector3 direction = Random.onUnitSphere;
    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
    float distance = 2 * Random.value + 1.5f;
    transform.localPosition = direction * distance;
  }
}
