﻿using UnityEngine;
using System.Collections;

/*
 * 用来制定是对象子对象对象的行为
 */ 
namespace SimuUtils {


	public class BaseChildObject : MonoBehaviour
	{
		public GameObject parentObject;		// 父对象，可手动设置

		public void Start() {
			var script = get_parent_script ();
			gameObject.layer = script.myLayer;
		}
		/*
		 * 获得父对象的脚本
		 */ 
		public BackgroundController get_parent_script() {
			BackgroundController bkg = parentObject.GetComponent<BackgroundController> ();
			if (bkg == null) {
				Debug.Log ("parentObject in " + this.ToString() + " is null!");
				parentObject = this.transform.parent.gameObject;
				bkg = parentObject.GetComponent<BackgroundController> ();
				gameObject.layer = bkg.myLayer;
				if (bkg == null) {
					Debug.LogError ("parentObject in " + this.ToString() + "'s father is still null!");
				}
			} 
			return bkg;
		}

		public Bounds get_box_render() {
			SpriteRenderer cur_render = GetComponent<SpriteRenderer> ();
			return cur_render.bounds;
		}
	}
}