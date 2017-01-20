//Replace old radconfirm with a changed version.   
var oldConfirm = radconfirm;

//TELERIK
//window.radconfirm = function(text, mozEvent)
//We will change the radconfirm function so it takes all the original radconfirm attributes
window.radconfirm = function (text, mozEvent, oWidth, oHeight, callerObj, oTitle)
{
    var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually   
    //Cancel the event   
    ev.cancelBubble = true;
    ev.returnValue = false;
    if (ev.stopPropagation) ev.stopPropagation();
    if (ev.preventDefault) ev.preventDefault();

    //Determine who is the caller   
    var callerObj = ev.srcElement ? ev.srcElement : ev.target;

    //Call the original radconfirm and pass it all necessary parameters   
    if (callerObj)
    {
        //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.   
        var callBackFn = function (arg)
        {
            if (arg)
            {
                callerObj["onclick"] = "";
                if (callerObj.click) callerObj.click(); //Works fine every time in IE, but does not work for links in Moz   
                else if (callerObj.tagName == "A") //We assume it is a link button!   
                {
                    try
                    {
                        eval(callerObj.href)
                    }
                    catch (e)
                    {
                    }
                }
            }
        }
        //TELERIK
        //oldConfirm(text, callBackFn, 300, 100, null, null);       
        //We will need to modify the oldconfirm as well                
        oldConfirm(text, callBackFn, oWidth, oHeight, callerObj, oTitle);
    }
    return false;
} 