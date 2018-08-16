import React, { Component } from 'react';
import Userinfo from './../Userinfo/Userinfo';
import ToggleMenu from './../ToggleMenu/ToggleMenu';
import './Head.scss';
import { Link } from 'react-router-dom';

var Config = require('Config');

class Head extends Component {
    render() {
        return (
            <header className="simr-r-header">
                <div className="simr-flex simr-flex-justify-space-between">
                    <Link to={Config.url.root}>
                        <div className="simr-flex-item simr-r-title">simr</div>
                    </Link>

                    <ToggleMenu />
                    <Userinfo />
                </div>
            </header>
        );
    }
}

export default Head;
