using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basitkendieksen : MonoBehaviour
{
    public float timer = 0.0f;

    private void Update()
    {
timer += Time.deltaTime;

   if  ( timer > 36.0f)
     {
        timer = 0.0f;
     }
   else{
         transform.localRotation = Quaternion.Euler(1,1,timer * 10.0f);
       }     
    }
}

/* Rüzgar tirbünü, uçak pervanesi veya değirmenin yelpazesi gibi şeylerin kod ile animasyonu.
Olayı ise matematiği belirli bir saniyeye geldikten sonra loopta olduğu belli olmuyor kusursun bir şekilde loopa devam ediyor.
Direkt animasyonu blender üzerinden vs. yapmak yerine koddan yapmak daha kolayıma geldi ayrıca :D
*/
