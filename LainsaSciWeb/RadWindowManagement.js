function GetSender(sender) {
    // Locate de reference substring
    var snd = sender.toString();
    var res = "";
    var pos = 0;
    pos = snd.indexOf("=");
    if (pos > 0) {
        res = snd.substring(pos + 1, snd.length - 1);
    }
    return res;
}