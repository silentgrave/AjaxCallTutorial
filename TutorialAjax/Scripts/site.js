
function addAntiForgeryToken(data) {
    if (!data) {
        data = {};
    }
    var tokenInput = $('input[name=__RequestVerificationToken]');
    if (tokenInput.length) {
        data.__RequestVerificationToken = tokenInput.val();
    }
    return data;
};