import React, { Component } from 'react';

var Config = require('Config');

class WelcomePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            version: 'loading...'
        };

        fetch(Config.apiurl.system.version, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'User-Agent': 'Fiddler'
            }
        })
            .then(res => res.json())
            .then(json => this.setState({ version: JSON.parse(json) }));
    }

    render() {
        return (
            <div>
                <div>Welcome</div>

                <div>Current version is {this.state.version.Backend}</div>
            </div>
        );
    }
}

export default WelcomePage;
