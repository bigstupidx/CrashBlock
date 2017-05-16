@MenuItem("Scripts/Mass Set Materials")
static function MassSetMaterials() {
    Undo.RegisterSceneUndo("Mass Set Materials");

     var mats : Material[] = Selection.activeGameObject.GetComponent.<Renderer>().sharedMaterials;
     for (var obj : GameObject in Selection.gameObjects) {
         obj.GetComponent.<Renderer>().sharedMaterials = mats;
     }


}
