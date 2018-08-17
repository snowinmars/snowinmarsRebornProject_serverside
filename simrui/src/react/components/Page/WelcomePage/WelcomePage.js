import React, { Component } from 'react';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class WelcomePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            version: 'loading...',
            isInit: false,
            gotApiError: false,
            hasErrors: false
        };
    }

    componentDidMount() {
        Lib.fetchAndHandle({
            uri: Config.apiurl.system.version,
            onSuccess: json =>
                this.setState({
                    version: JSON.parse(json),
                    isInit: true
                }),
            onError: err => this.setState({ gotApiError: true })
        });
    }

    componentDidCatch() {
        this.setState({ hasErrors: true });
    }

    render() {
        if (this.state.hasErrors) {
            return <div className="simr-component-error">Error</div>;
        }

        if (this.state.gotApiError) {
            return <div className="simr-api-error">Api Error</div>;
        }

        var loader;

        if (this.state.isInit) {
            loader = <span>{this.state.version.Backend}</span>;
        } else {
            loader = <span>...loading...</span>;
        }

        return (
            <div>
                <div>Welcome</div>

                <div>Current version is {loader}</div>
            </div>
        );
    }
}

export default WelcomePage;
