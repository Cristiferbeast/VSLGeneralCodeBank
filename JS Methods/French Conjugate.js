
function conjugateVerbFr() {
  const verb = document.getElementById('verb').value;
  if (verb.endsWith('er')) {
    const conjugatedVerb = {
      Je: verb.slice(0, -2) + 'e',
      Tu: verb.slice(0, -2) + 'es',
      Il: verb.slice(0, -2) + 'e',
      Elle: verb.slice(0, -2) + 'e',
      Nous: verb.slice(0, -2) + 'ons',
      Vous: verb.slice(0, -2) + 'ez',
      Ils: verb.slice(0, -2) + 'ent',
      Elles: verb.slice(0, -2) + 'ent'
    };
    const result = Object.entries(conjugatedVerb).map(([subject, conjugation]) => `${subject} ${conjugation}`).join('\n');
    document.getElementById('conjugatedVerb').innerText = result;
  }
  else if (verb.endsWith('re')) {
    const conjugatedVerb = {
      Je: verb.slice(0, -2) + 's',
      Tu: verb.slice(0, -2) + 's',
      Il: verb.slice(0, -2) + '',
      Elle: verb.slice(0, -2) + '',
      Nous: verb.slice(0, -2) + 'ons',
      Vous: verb.slice(0, -2) + 'ez',
      Ils: verb.slice(0, -2) + 'ent',
      Elles: verb.slice(0, -2) + 'ent'
    };
    const result = Object.entries(conjugatedVerb).map(([subject, conjugation]) => `${subject} ${conjugation}`).join('\n');
    document.getElementById('conjugatedVerb').innerText = result;
  }
  else if (verb.endsWith('ir')) {
    const conjugatedVerb = {
      Je: verb.slice(0, -2) + 'is',
      Tu: verb.slice(0, -2) + 'is',
      Il: verb.slice(0, -2) + 'it',
      Elle: verb.slice(0, -2) + 'it',
      Nous: verb.slice(0, -2) + 'issons',
      Vous: verb.slice(0, -2) + 'issez',
      Ils: verb.slice(0, -2) + 'issent',
      Elles: verb.slice(0, -2) + 'issent'
    };
    const result = Object.entries(conjugatedVerb).map(([subject, conjugation]) => `${subject} ${conjugation}`).join('\n');
    document.getElementById('conjugatedVerb').innerText = result;
  }
  else {
    document.getElementById('conjugatedVerb').innerText = 'Please enter a valid verb.';
  }
}