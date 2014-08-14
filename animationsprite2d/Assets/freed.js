#pragma strict
var anim : Animator;
function Start () {

}

function Update () {
if(Input.GetKeyDown("f")){

anim.SetTrigger("Free");


}
}