var fetchAndHandle = function ({ uri, onSuccess, onError }) {
    fetch(uri, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
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
};

exports.fetchAndHandle = fetchAndHandle;
