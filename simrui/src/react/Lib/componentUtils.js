var fetchAndHandle = function({ uri, body, method, onSuccess, onError }) {
    if (!method) {
        method = 'POST';
    }

    if (method === 'GET' || method === 'HEAD') {
        uri = uri + '?' + objToQueryString(body);
        body = undefined;
    } else {
        body = JSON.stringify(body);
    }

    fetch(uri, {
        body: JSON.stringify(body),
        method: method,
        headers: {
            'Content-Type': 'application/json',
            'User-Agent': 'Fiddler'
        }
    })
        .catch(err => {
            console.log('Api Error : ', err);
            onError(err);
        })

        .then(response => {
            if (response && response.ok) {
                return response.json();
            }

            throw new Error('api error');
        })

        .then(json => onSuccess(json))

        .catch(err => {
            console.log('Response deserialization error : ', err);
            onError(err);
        });

    function objToQueryString(obj) {
        const keyValuePairs = [];
        for (const key in obj) {
            keyValuePairs.push(
                encodeURIComponent(key) + '=' + encodeURIComponent(obj[key])
            );
        }
        return keyValuePairs.join('&');
    }
};

exports.fetchAndHandle = fetchAndHandle;
