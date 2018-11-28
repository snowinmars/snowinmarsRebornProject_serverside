import React, { Component } from 'react';
import './SiberiaAddEnvironmentPage.scss';
import { withRouter } from 'react-router-dom';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class SiberiaAddEnvironmentPage extends Component {
    onSubmit = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        var object = {};
        data.forEach(function(value, key){
            object[key] = value;
        });

        Lib.fetchAndHandle({
            uri: Config.apiurl.siberia.add,
            data: object,
            onSuccess: withRouter(_ => {
                _.push(Config.url.siberia);
            }),
        })

        return false;
    }

    render() {
        return (
            <form
                id="add-siberia-environment"
                className="simr-siberia-add-environment-form"
                action={Config.apiurl.siberia.add}
                onSubmit={this.onSubmit}
                method="post"
            >
                <div>
                    Insert the environment and the branch name below
                </div>

                <label for="siberia-environment-name">
                    Environment
                    <input
                        name="environment"
                        id="siberia-environment-name"
                        type="text"
                        placeholder="Environment name"
                        required
                        autoFocus
                        className="simr-form-control simr-input simr-required"
                        />
                </label>

                <label for="siberia-branch-name">
                    Branch
                    <input
                        name="branch"
                        id="siberia-branch-name"
                        type="text"
                        placeholder="Branch name"
                        required
                        className="simr-form-control simr-input simr-required"
                    />
                </label>

                <button
                    type="submit"
                    form="add-siberia-environment"
                    className="simr-btn"
                >
                    Create
                </button>
            </form>
        );
    }
}

export default SiberiaAddEnvironmentPage;
