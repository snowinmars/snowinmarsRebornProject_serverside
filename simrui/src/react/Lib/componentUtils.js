const _fetchAndHandle = function({ uri, data, method, onSuccess, onError }) {
    let _method;
    if (!method) {
        _method = 'POST';
    } else {
        _method = method;
    }

    let _body;
    if (method === 'GET' || method === 'HEAD') {
        uri = uri + '?' + objectToHttpQueryString(data);
        _body = undefined;
    } else {
        _body = JSON.stringify(data);
    }

    fetch(uri, {
        body: _body,
        method: _method,
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        }
    })

        .then(response => {
        
            if (response && response.ok) {
                return response.json();
            }

            throw new Error('api error');
        })

        .then(json => onSuccess(json))

        .catch(err => {
            onError(err);
        });

    function objectToHttpQueryString(obj) {
        const keyValuePairs = [];
        for (const key in obj) {
            keyValuePairs.push(
                encodeURIComponent(key) + '=' + encodeURIComponent(obj[key])
            );
        }
        return keyValuePairs.join('&');
    }
};

export { _fetchAndHandle as fetchAndHandle };