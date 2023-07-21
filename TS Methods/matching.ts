interface TermPair {
  english: string;
  french: string;
}

const terms: TermPair[] = [
  { english: 'hello', french: 'bonjour' },
  { english: 'goodbye', french: 'au revoir' },
  { english: 'thank you', french: 'merci' },
  // Add more terms here
];

const cardsContainer = document.querySelector('.cards-container') as HTMLElement;

// Function to create and render the cards on the screen
function renderCards() {
  cardsContainer.innerHTML = '';
  terms.forEach((term) => {
    const englishCard = document.createElement('div');
    englishCard.classList.add('card', 'english-card');
    englishCard.textContent = term.english;
    englishCard.addEventListener('click', () => {
      flipCard(englishCard, term.french);
    });

    const frenchCard = document.createElement('div');
    frenchCard.classList.add('card', 'french-card');
    frenchCard.textContent = term.french;
    frenchCard.addEventListener('click', () => {
      flipCard(frenchCard, term.english);
    });

    const cardPairContainer = document.createElement('div');
    cardPairContainer.classList.add('card-pair-container');
    cardPairContainer.appendChild(englishCard);
    cardPairContainer.appendChild(frenchCard);

    cardsContainer.appendChild(cardPairContainer);
  });
}

// Function to flip a card
function flipCard(cardElement: HTMLElement, content: string) {
  cardElement.textContent = content;
  cardElement.style.backgroundColor = '#A9DFBF';
  cardElement.removeEventListener('click', () => {});
}

// Initial render of the cards
renderCards();
