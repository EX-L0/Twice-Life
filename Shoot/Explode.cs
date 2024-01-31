using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Explode : MonoBehaviour {
    //就是设置一下销毁时间
	void Start () {
        Destroy(gameObject, 10f);//10秒后销毁爆炸效果
    }
}