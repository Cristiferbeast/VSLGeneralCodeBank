var terms = [
    { english: 'hello', french: 'bonjour' },
    { english: 'goodbye', french: 'au revoir' },
    { english: 'thank you', french: 'merci' },
    // Add more terms here
];
var cardsContainer = document.querySelector('.cards-container');
// Function to create and render the cards on the screen
function renderCards() {
    cardsContainer.innerHTML = '';
    terms.forEach(function (term) {
        var englishCard = document.createElement('div');
        englishCard.classList.add('card', 'english-card');
        englishCard.textContent = term.english;
        englishCard.addEventListener('click', function () {
            flipCard(englishCard, term.french);
        });
        var frenchCard = document.createElement('div');
        frenchCard.classList.add('card', 'french-card');
        frenchCard.textContent = term.french;
        frenchCard.addEventListener('click', function () {
            flipCard(frenchCard, term.english);
        });
        var cardPairContainer = document.createElement('div');
        cardPairContainer.classList.add('card-pair-container');
        cardPairContainer.appendChild(englishCard);
        cardPairContainer.appendChild(frenchCard);
        cardsContainer.appendChild(cardPairContainer);
    });
}
// Function to flip a card
function flipCard(cardElement, content) {
    cardElement.textContent = content;
    cardElement.style.backgroundColor = '#A9DFBF';
    cardElement.removeEventListener('click', function () { });
}
// Initial render of the cards
renderCards();
