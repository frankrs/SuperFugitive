#pragma strict

var minSwipeDistY : float;

var minSwipeDistX : float;

var messanger : Messanger;

private var startPos :Vector2; 

	function Update () 
	{

		if (Input.touchCount > 0) 
		{

		var touch : Touch = Input.touches[0];

		switch (touch.phase) 

			{

			case TouchPhase.Began:

			startPos = touch.position;

			break;


			case TouchPhase.Ended:
			var swipeDistVertical : float;
			swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) 
				{
					var swipeValue : float;
					swipeValue = Mathf.Sign(touch.position.y - startPos.y);

					if (swipeValue > 0)//up
					{	

						messanger.jhonny.SendMessage("Jump",SendMessageOptions.DontRequireReceiver);
					}
					else if (swipeValue < 0)//down
					{	
						Debug.Log("down");
						//Swipe.text = "Down Swipe";
					}
				}
				var swipeDistHorizontal : float;

				swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) 
				{
					swipeValue = Mathf.Sign(touch.position.x - startPos.x);

					if (swipeValue > 0)//right
					{


						messanger.jhonny.SendMessage("Attack",SendMessageOptions.DontRequireReceiver);
					}
					else if (swipeValue < 0)//left
					{	
						Debug.Log("left");

						//Swipe.text = "Left Swipe";
					}
				}
				break;
			}
		}	

	}