using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collapseBtn : MonoBehaviour
{

	[SerializeField] GameObject upBtn;
	[SerializeField] GameObject scrollView;
    	
    	public void toggleView(){
		scrollView.SetActive(false);
	    	upBtn.SetActive(true);
	    	gameObject.SetActive(false);
    	}
	
  }
