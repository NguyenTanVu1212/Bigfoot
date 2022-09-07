using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConfig : MonoBehaviour
{
    public static DialogIndex[] dialogs = { DialogIndex.ResultDialog ,
        DialogIndex.CardReviewDialog  , DialogIndex.PauseDialog , DialogIndex.MissionDialog};
}
public enum DialogIndex
{
    ResultDialog =0 ,
    CardReviewDialog = 1,
    PauseDialog = 2, 
    MissionDialog
}

public class DialogParam
{

}
// 
public class CardReviewDialogParam: DialogParam
{
    public int id;
}

public class ResultDialogParam : DialogParam
{
    public int id;
}
public class MissionDialogParam : DialogParam
{
    public int id;
}