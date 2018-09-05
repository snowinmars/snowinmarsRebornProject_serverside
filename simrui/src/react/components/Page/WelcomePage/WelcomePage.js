import React, { Component } from 'react';
import './WelcomePage.scss';

const Config = require('Config');
const Lib = require('./../../../Lib/componentUtils');

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

    getApiStatus() {
        let apiStatus;
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
        let loader;
        if (this.state.isInit) {
            loader = <span>{this.state.version.Backend}</span>;
        }
        else {
            loader = <span>...loading...</span>;
        }
        return loader;
    }

    render() {
        if (this.state.hasErrors) {
            return <div className="simr-component-error">Error</div>;
        }

        const loader = this.getLoader();

        const apiStatus = this.getApiStatus();

        return <div className="simr-Welcome">
                <div>Welcome</div>

                <div>Current version is {loader}</div>

                <div>API status: {apiStatus}</div>
            </div>;
    }
}

export default WelcomePage;
