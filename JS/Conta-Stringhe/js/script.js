function setCookie() {
  var d = new Date();
  var cvalue = document.getElementById("testo").value;
  d.setTime(d.getTime() + (365*24*60*60*1000));
  var expires = "expires="+ d.toUTCString();
  document.cookie = "Contenuto" + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(';');
  for(var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) == ' ') {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

function count(){

var conta = document.getElementById('testo').value.length;
var totalLength = 0;

if (conta != 0){
totalLength = conta;
} else {
totalLength = 'Nessuna stringa inserita';
}

document.getElementById('result').innerText = totalLength;
//alert(totalLength);

setCookie();

}

function exe(event){
	
	var x = event.which || event.keyCod;
	
	if (x == 13){
		count();
		return false;
		
	}
}

function getFocus(){
	document.getElementById("testo").focus;
}

window.onload = function() {
  var input = document.getElementById("testo").focus();
  
  var user=getCookie("Contenuto");
  if (user != "") {
    //alert("Welcome again " + user);
	var conta = user.length;
	//alert("Welcome again " + conta);
	document.getElementById('testo').value = user;
	document.getElementById('result').innerText = conta;
  } else {
     
  }
	
	//window.moveTo(0,0);
	window.resizeTo(420,300);

}

function clearALL(){

	document.cookie = "Contenuto=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
	document.getElementById('testo').value = "";
	document.getElementById('result').innerText = 'Nessuna stringa inserita';
	document.getElementById("testo").focus();

}