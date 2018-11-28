import React, { Component } from 'react';
import './SiberiaEditEnvironmentPage.scss';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class SiberiaEditEnvironmentPage extends Component {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInit: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };
    }

    getDefaultData = () => {
        return {
            environment: 'Loading...',
            branch: 'Loading...'
        };
    };

    componentDidMount() {
        const id = this.props.location.pathname.substr(
            this.props.location.pathname.lastIndexOf('/') + 1
        );
        Lib.fetchAndHandle({
            uri: Config.apiurl.siberia.get,
            data: id,
            onSuccess: json => {
                console.log(json);
                this.setState({
                    response: JSON.parse(json),
                    isInit: true
                });
            },
            onError: err =>
                this.setState({
                    gotApiError: true,
                    hasErrors: true,
                    isInit: false
                })
        });
    }

    onSubmit = e => {
        e.preventDefault();
        const data = new FormData(e.target);
        var object = {};
        data.forEach(function(value, key) {
            object[key] = value;
        });

        Lib.fetchAndHandle({
            uri: Config.apiurl.siberia.update,
            data: object,
            onSuccess: () => {}
        });

        return false;
    };

    render() {
        return (
            <form
                id="add-siberia-environment"
                className="simr-siberia-add-environment-form"
                onSubmit={this.onSubmit}
                method="post"
            >
                <input
                    name="id"
                    id="id"
                    type="hidden"
                    required
                    value={this.state.response.data.id}
                />

                <label for="siberia-environment-name">
                    Environment
                    <input
                        name="environment"
                        id="siberia-environment-name"
                        type="text"
                        placeholder="environment name"
                        required
                        autoFocus
                        onChange={e => {
                            var newState = this.state;
                            newState.response.data.environment = e.target.value;
                            this.setState(newState);
                        }}
                        value={this.state.response.data.environment || ''}
                        className="simr-form-control simr-input simr-required"
                    />
                </label>

                <label for="siberia-environment-branch">
                    Branch
                    <input
                        name="branch"
                        id="siberia-branch-name"
                        type="text"
                        placeholder="Branch name"
                        required
                        onChange={e => {
                            var newState = this.state;
                            newState.response.data.branch = e.target.value;
                            this.setState(newState);
                        }}
                        value={this.state.response.data.branch || ''}
                        className="simr-form-control simr-input simr-required"
                    />
                </label>

                <button
                    type="submit"
                    form="add-siberia-environment"
                    className="simr-btn"
                >
                    Update
                </button>
            </form>
        );
    }
}

export default SiberiaEditEnvironmentPage;
