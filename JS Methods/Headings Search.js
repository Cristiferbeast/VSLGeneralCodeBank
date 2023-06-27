function searchHeadings() {
    var searchInput = document.getElementById("searchInput").value.toLowerCase();
    var headings = document.querySelectorAll("h1, h2, h3");
    var resultsContainer = document.getElementById("results");
    resultsContainer.innerHTML = "";

    for (var i = 0; i < headings.length; i++) {
        var title = headings[i].innerText.toLowerCase();
        if (title.includes(searchInput)) {
            var link = document.createElement("a");
            link.href = "#" + headings[i].id;
            link.textContent = headings[i].innerText;
            resultsContainer.appendChild(link);
            resultsContainer.appendChild(document.createElement("br"));
        }
    }
}