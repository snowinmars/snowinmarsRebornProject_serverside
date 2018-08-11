import React, { Component } from 'react';
import './Userinfo.scss';
import Username from './../Username/Username';
import Userauth from './../Userauth/Userauth';
import Usersync from './../Usersync/Usersync';

class Userinfo extends Component {
    render() {
        return (
            <div className="r-Userinfo flex-item">
                <Username />
                <div className="r-Userinfo-buttons">
                    <Userauth />
                    <Usersync />
                </div>
            </div>
        );
    }
}

export default Userinfo;
