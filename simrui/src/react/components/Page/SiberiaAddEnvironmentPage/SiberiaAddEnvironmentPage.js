import React, { Component } from 'react';
import './SiberiaAddEnvironmentPage.scss';

var Config = require('Config');

class SiberiaAddEnvironmentPage extends Component {
    render() {
        return (
            <form id="add-siberia-environment" className="simr-siberia-add-environment-form" action={Config.apiurl.siberia.add} method='post'>
                <input
                        name="environment"
                        id="siberia-environment-name"
                        type="text"
                        placeholder="environment name"
                        required
                        autoFocus
                        className="simr-form-control simr-input simr-required"
                    />

                <input
                        name="branch"
                        id="siberia-branch-name"
                        type="text"
                        placeholder="Branch name"
                        required
                        className="simr-form-control simr-input simr-required"
                />
                
                <button type="submit" form="add-siberia-environment" className="simr-btn">Create</button>
            </form>
        );
    }
}

export default SiberiaAddEnvironmentPage;
