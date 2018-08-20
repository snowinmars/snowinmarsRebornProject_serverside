import React, { Component } from 'react';
import './WelcomePage.scss';

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

        var loader = this.getLoader();

        var apiStatus = this.getApiStatus();

        return <div className="simr-Welcome">
                <div>Welcome</div>

                <div>Current version is {loader}</div>

                <div>API status: {apiStatus}</div>
            </div>;
    }

    getApiStatus() {
        var apiStatus;
        if (this.state.gotApiError) {
            apiStatus = <span className="simr-api simr-api-error">
                    Api Error
                </span>;
        }
        else {
            if (this.state.isInit) {
                apiStatus = <span className="simr-api simr-api-ok">
                        Api ok
                    </span>;
            }
            else {
                apiStatus = <span>...loading...</span>;
            }
        }
        return apiStatus;
    }

    getLoader() {
        var loader;
        if (this.state.isInit) {
            loader = <span>{this.state.version.Backend}</span>;
        }
        else {
            loader = <span>...loading...</span>;
        }
        return loader;
    }
}

export default WelcomePage;
