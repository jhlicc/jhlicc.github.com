/* ajax(elmId, method, url)
 * Ajax function with javascript on loaded page enabled
 * jhlicc@{gmail,hotmail}.com, 20110626
 */
function ajax(elmId, method, url)
{
	var xhr, elm;

	xhr = new XMLHttpRequest();
	elm = document.getElementById(elmId);
	xhr.onreadystatechange = function(){
	if (xhr.readyState == 4){ 
	if (xhr.status == 200){
		var s1, n1;

		elm.innerHTML = xhr.responseText;
		s1 = elm.getElementsByTagName("script");
		n1 = s1.length;
		for (var i = 0; i != n1; i++){
			var s2;

			s2 = document.createElement("script");
			s2.type = "text/javascript";
			if (s1[i].src) s2.src = s1[i].src;
			if (s1[i].text) s2.text = s1[i].text;
			elm.appendChild(s2);
		}
		for (var i = 0; i != n1; i++){
			elm.removeChild(elm.getElementsByTagName("script")[0]);
		}
	} else {
		elm.innerHTML = xhr.status + " " + xhr.statusText;
	}}}

	xhr.open(method, url);
	xhr.send();
}

