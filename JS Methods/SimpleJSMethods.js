function searchHeadings() {
    var searchInput = document.getElementById("searchInput").value.toLowerCase();
    var headings = document.querySelectorAll("h1, h2, h3");
    var resultsContainer = document.getElementById("results");
    resultsContainer.innerHTML = "";

    var regexPattern = new RegExp(searchInput.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&').split('').join('.?'), 'i');

    for (var i = 0; i < headings.length; i++) {
        var title = headings[i].innerText.toLowerCase();
        if (regexPattern.test(title)) {
            var link = document.createElement("a");
            link.href = "#" + headings[i].id;
            link.textContent = headings[i].innerText;
            resultsContainer.appendChild(link);
            resultsContainer.appendChild(document.createElement("br"));
        }
    }
}
function convertToVaporwaveText(inputText) {
  var vaporwaveText = "";
  for (var i = 0; i < inputText.length; i++) {
    var c = inputText.charAt(i);
    if (c !== " ") {
      var code = inputText.charCodeAt(i);
      if (code >= 33 && code <= 126) {
        vaporwaveText += String.fromCharCode(0xFF00 + code - 0x20); //This is the Key Line WhichConverts
      } else {
        vaporwaveText += c;
      }
    } else {
      vaporwaveText += c;
    }
  }
  return vaporwaveText;
}

function findzero(arr){
    let x = 0;
    let left = 0;
    let right =arr.length-1;
    while (left < right)
    {
        const sum = arr[left]+arr[right]
        if(sum === x){
            console.log(arr[right])
            console.log(arr[left])
            break;
         }
         else if(sum < x){
             left++;
         }
         else{
             right++;
         }
    }
}

function graph(canvasid, data){
    //canvasid has to be a string, data has to be an array

    // Get the canvas element
    const canvas = document.getElementById(canvasid);
    const context = canvas.getContext('2d');

    // Calculate the graph dimensions
	const graphWidth = canvas.width - 20;
	const graphHeight = canvas.height - 20;
	const columnWidth = graphWidth / data.length;

    // Calculate the maximum value in the data array
	const maxValue = Math.max(...data);

    //Draw the Graph
    // Clear the canvas
    context.clearRect(0, 0, canvas.width, canvas.height);

    // Draw the horizontal axis
	context.beginPath();
	context.moveTo(10, canvas.height - 10);
	context.lineTo(canvas.width - 10, canvas.height - 10);
	context.stroke();

    // Draw the vertical axis
	context.beginPath();
	context.moveTo(10, canvas.height - 10);
	context.lineTo(10, 10);
	context.stroke();

    // Draw the data points and lines
	context.beginPath();
	for (let i = 0; i < data.length; i++) {
	    const x = 10 + i * columnWidth;
		const y = canvas.height - 10 - (data[i] / maxValue) * graphHeight;
		if (i === 0) {
		    context.moveTo(x, y);
		} else {
		    context.lineTo(x, y);
		}
		context.stroke();
		context.beginPath();
		context.arc(x, y, 4, 0, Math.PI * 2);
		context.fill();
		context.stroke();
	}

}
function shuffle(array) {
    var _a;
    for (var i = array.length - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1));
        _a = [array[j], array[i]], array[i] = _a[0], array[j] = _a[1];
    }
    return array;
}
