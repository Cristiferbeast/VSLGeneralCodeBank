//JQuery Select All Paragraphs
var $paragraphs = $("p");
$paragraphs.each(function () {
    var originalText = $(this).text();
    var pigLatinText = toPigLatin(originalText);
    $(this).text(pigLatinText);
});

//JQuery Chain
$("<img>").attr({ src: 'https://upload.wikimedia.org/wikipedia/commons/2/29/English_Daisy_(Bellis_Perennis).jpg', width: '100', alt: 'daisy' }).appendTo('body');